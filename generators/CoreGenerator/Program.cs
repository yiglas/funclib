using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var dir = new DirectoryInfo(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName + @"\src\funclib";
            var files = GetClassFiles(dir + @"\Components\Core");

            var lines = new List<string>();
            lines.Add($"// Generated on {DateTime.Now}");
            lines.Add("using funclib.Collections;");
            lines.Add("using funclib.Components.Core;");
            lines.Add("using System;");
            lines.Add("");
            lines.Add("namespace funclib");
            lines.Add("{");
            lines.Add("\tpublic static class Core");
            lines.Add("\t{");
            lines.Add("\t\t#region Properties");
            lines.AddRange(GenerateProperties(files).Select(x => "\t\t" + x));
            lines.Add("\t\t#endregion");
            lines.Add("\t\t#region Methods");
            lines.AddRange(GenerateMethods(files).Select(x => "\t\t" + x));
            lines.Add("\t\t#endregion");
            lines.Add("\t}");
            lines.Add("}");

            var source = dir + @"\Core.cs";

            File.WriteAllLines(source, lines);
            sw.Stop();

            Console.WriteLine($"Time Elapsed: {sw.Elapsed}");
            Console.WriteLine("========== Finished ==========");
            Console.ReadLine();
        }

        static IList<string> GenerateProperties(IList<CSharpSyntaxTree> files) =>
            files.Aggregate(new List<string>() as IList<string>, (acc, node) => 
                GetClassDeclarations(node, acc, (a, n) =>
                {
                    if (!FilterClasses(n)) return a;

                    var className = n.Identifier.Text;
                    var fullName = GetFullyQualifiedName(n);
                    var comments = GetComments(n);

                    if (comments != null)
                        comments.ForEach(x => a.Add(x));

                    a.Add($"public static {fullName} {className} => new {fullName}();");
                    return a;
                }));

        static IList<string> GenerateMethods(IList<CSharpSyntaxTree> files) =>
            files.Aggregate(new List<string>() as IList<string>, (accumulator, syntaxTree) =>
                GetClassDeclarations(syntaxTree, accumulator, (acc, classDeclaration) =>
                    GetMethodDeclarations(classDeclaration, acc, (a, n) =>
                    {
                        var className = classDeclaration.Identifier.Text;
                        var methodName = n.Identifier.Text;
                        var returnType = n.ReturnType.ToString();
                        var typedParameters = classDeclaration.TypeParameterList?.ToString();

                        if (className == "Function" || className == "FunctionParams")
                        {
                            string parameters = "";
                            string parameterList = "";
                            List<string> comments = null;
                            string constructorParams = "";

                            GetConstructorDeclarations(classDeclaration, acc, (a1, n1) =>
                            {
                                comments = GetComments(n1);
                                parameters = n1.ParameterList.ToString();
                                constructorParams = n1.ParameterList.ToString();
                                parameterList = GetParameterList(n1.ParameterList);

                                if (comments != null)
                                    comments.ForEach(x => a.Add(x));

                                a.Add($"public static {className}{typedParameters} func{typedParameters}{parameters} => new {className}{typedParameters}({string.Join(", ", parameterList)});");
                                return a;
                            });

                            constructorParams = constructorParams.Replace("x", "func").Replace("Func", "IFunction").TrimStart('(').TrimEnd(')');
                            parameters = n.ParameterList.ToString().TrimStart('(').TrimEnd(')');
                            parameterList = GetParameterList(n.ParameterList);
                            comments = GetComments(n);

                            if (comments != null)
                                comments.ForEach(x => a.Add(x));

                            a.Add($"public static {returnType} invoke{typedParameters}({constructorParams}{(string.IsNullOrWhiteSpace(parameters) ? "" : ", " + parameters)}) => func.Invoke({string.Join(", ", parameterList)});");
                        }
                        else if (className == "LazySeq")
                        {
                            GetConstructorDeclarations(classDeclaration, acc, (a1, n1) =>
                            {
                                var comments = GetComments(n1);
                                var parameters = n1.ParameterList.ToString();
                                var constructorParams = n1.ParameterList.ToString();
                                var parameterList = GetParameterList(n1.ParameterList);

                                if (comments != null)
                                    comments.ForEach(x => a.Add(x));

                                a.Add($"public static {className}{typedParameters} {FixClassName(className)}{typedParameters}{constructorParams} => new {className}{typedParameters}({string.Join(", ", parameterList)});");
                                return a;
                            });
                        }
                        else if (classDeclaration.DescendantNodes().OfType<BaseListSyntax>().FirstOrDefault().Types.ToString() == "IMacroFunction")
                        {
                            GetConstructorDeclarations(classDeclaration, acc, (a1, n1) =>
                            {
                                var comments = GetComments(n1);
                                var parameters = n1.ParameterList.ToString();
                                var constructorParams = n1.ParameterList.ToString();
                                var parameterList = GetParameterList(n1.ParameterList);

                                if (comments != null)
                                    comments.ForEach(x => a.Add(x));

                                a.Add($"public static {returnType} {FixClassName(className)}{typedParameters}{constructorParams} => new {className}{typedParameters}({string.Join(", ", parameterList)}).Invoke();");
                                return a;
                            });
                        }
                        else
                        {
                            var parameters = n.ParameterList.ToString();
                            var parameterList = GetParameterList(n.ParameterList);
                            var comments = GetComments(n);

                            if (comments != null)
                                comments.ForEach(x => a.Add(x));

                            a.Add($"public static {returnType} {FixClassName(className)}{typedParameters}{parameters} => {className}.{methodName}({string.Join(", ", parameterList)});");
                        }

                        return a;
                    })));

        static List<string> GetComments(CSharpSyntaxNode node) =>
            node
                ?.GetLeadingTrivia()
                .FirstOrDefault(x => x.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia)
                .GetStructure()
                ?.GetText()
                ?.ToString()
                ?.Split(Environment.NewLine)
                ?.Select(x => x.Trim())
                ?.Where(x => !string.IsNullOrWhiteSpace(x))
                ?.ToList();

        static IList<CSharpSyntaxTree> GetClassFiles(string directory) =>
            Directory.EnumerateFiles(directory)
                .Where(x => Path.GetExtension(x) == ".cs")
                .Select(x => CSharpSyntaxTree.ParseText(File.ReadAllText(x)))
                .Cast<CSharpSyntaxTree>()
                .ToList();
        
        static IList<string> GetClassDeclarations(CSharpSyntaxTree syntaxTree, IList<string> seed, Func<IList<string>, ClassDeclarationSyntax, IList<string>> aggregate) =>
            syntaxTree.GetRoot()
                    .DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .Where(x => IsPublic(x.Modifiers) && IsChildOfNamespace(x))
                    .Aggregate(seed, aggregate);

        static IList<string> GetMethodDeclarations(ClassDeclarationSyntax classDeclaration, IList<string> seed, Func<IList<string>, MethodDeclarationSyntax, IList<string>> aggregate) =>
            classDeclaration
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Where(x => IsInvokeIdentifier(x.Identifier) && IsPublic(x.Modifiers) && IsChildOf(classDeclaration, x))
                .Aggregate(seed, aggregate);

        static IList<string> GetConstructorDeclarations(ClassDeclarationSyntax classDeclaration, IList<string> seed, Func<IList<string>, ConstructorDeclarationSyntax, IList<string>> aggregate) =>
            classDeclaration
                .DescendantNodes()
                .OfType<ConstructorDeclarationSyntax>()
                .Aggregate(seed, aggregate);

        static string GetParameterList(ParameterListSyntax parameters) =>
            string.Join(", ", 
                parameters.Parameters.Aggregate(new List<string>(), (a, c) =>
                {
                    a.Add(c.Identifier.Text);
                    return a;
                }));



        static string FixClassName(string name)
        {
            name = Char.ToLowerInvariant(name[0]) + name.Substring(1);

            switch (name)
            {
                case "class": return "@class";
                case "function": return "invoke";
                case "uUID": return "uuid";
            }

            return name;
        }

        static string GetFullyQualifiedName(ClassDeclarationSyntax classDeclaration)
        {
            NamespaceDeclarationSyntax ns = null;
            if (!SyntaxNodeHelper.TryGetParentSyntax(classDeclaration, out ns)) return "";

            var nsName = ns.Name.ToString();
            return nsName + "." + classDeclaration.Identifier.ToString();
        }

        static bool FilterClasses(ClassDeclarationSyntax syntax)
        {
            if (syntax.DescendantNodes().OfType<BaseListSyntax>().FirstOrDefault().Types.ToString() == "IMacroFunction")
                return false;

            switch (syntax.Identifier.Text)
            {
                case "LazySeq":
                case "Locking":
                case "Time":
                case "DoTimes":
                case "Function":
                case "FunctionParams":
                    return false;
            }

            return true;
        }

        static bool IsPublic(SyntaxTokenList modifier) => modifier.Count == 1 && modifier[0].Text == "public";
        static bool IsChildOfNamespace(SyntaxNode node) => node.Parent.Kind() == SyntaxKind.NamespaceDeclaration;
        static bool IsChildOf(SyntaxNode parent, SyntaxNode child) => child.Parent == parent;
        static bool IsInvokeIdentifier(SyntaxToken identifier) => identifier.Text == "Invoke";
    }
}
