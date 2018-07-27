using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static funclib.core;
using funclib;

namespace CoreGenerator
{
    class Program
    {
        const string MODIFIER = ":modifier";
        const string NAME = ":name";
        const string FULLNAME = ":full-name";
        const string COMMENTS = ":comments";
        const string PRIVATENAME = ":private-name";
        const string TYPEDPARAMTERS = ":typed-parameters";
        const string RETURNTYPE = ":return-type";
        const string PARAMETERS = ":parameters";
        const string PARAMETERLIST = ":parameter-list";



        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var dir = new DirectoryInfo(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName + @"\src\funclib";
            var files = GetClassFiles(dir + @"\Components\Core");

            //var lines = new List<string>();
            //lines.Add($"// Generated on {DateTime.Now}");
            //lines.Add("using funclib.Collections;");
            //lines.Add("using funclib.Components.Core;");
            //lines.Add("using System;");
            //lines.Add("");
            //lines.Add("namespace funclib");
            //lines.Add("{");
            //lines.Add("\tpublic static class Core");
            //lines.Add("\t{");
            //lines.Add("\t\t#region Properties");
            //lines.AddRange(GenerateProperties(files).Select(x => "\t\t" + x));
            //lines.Add("\t\t#endregion");
            //lines.Add("\t\t#region Methods");
            //lines.AddRange(GenerateMethods(files).Select(x => "\t\t" + x));
            //lines.Add("\t\t#endregion");
            //lines.Add("\t}");
            //lines.Add("}");

            //var source = dir + @"\Core.cs";

            //File.WriteAllLines(source, lines);
            //sw.Stop();

            Console.WriteLine($"Time Elapsed: {sw.Elapsed}");
            Console.WriteLine("========== Finished ==========");
            Console.ReadLine();
        }

        
        static object ConvertToSyntax(object files) => flatten(map(new GetClassDeclaration(), files));

        class GetCSFiles :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object dir) => filter(new CSExtensionPred(), Directory.GetFiles((string)dir));
        }


        class CSExtensionPred :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object path) => Path.GetExtension((string)path) == ".cs";
        }

        /// <summary>
        /// Given a CS file return all of the class syntax trees.
        /// </summary>
        class GetClassDeclarationSyntax :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object file) =>
                list(CSharpSyntaxTree
                    .ParseText(File.ReadAllText((string)file))
                    .GetRoot()
                    .DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .Where(x => IsChildOfNamespace(x) && IsNotAnAbstractClass(x))
                    .ToArray());
        }

        // given a CSharpSyntaxTree return a map of its class info.
        class GetClassDeclaration :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object node)
            {
                var declaration = (ClassDeclarationSyntax)node;

                return arrayMap(
                    MODIFIER, GetModifier(declaration.Modifiers),
                    NAME, declaration.Identifier.Text,
                    FULLNAME, GetFullyQualifiedName(declaration),
                    COMMENTS, GetComments(declaration),
                    PRIVATENAME, str("__", declaration.Identifier.Text.ToLower()),
                    TYPEDPARAMTERS, declaration.TypeParameterList?.ToString()
                    );
            }
        }

        class GetMethodDeclaration :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object node)
            {
                var declaration = (MethodDeclarationSyntax)node;

                return arrayMap(
                    MODIFIER, GetModifier(declaration.Modifiers),
                    NAME, declaration.Identifier.Text,
                    RETURNTYPE, declaration.ReturnType.ToString(),
                    PARAMETERS, declaration.ParameterList.ToString(),
                    PARAMETERLIST, GetParameterList(declaration.ParameterList),
                    COMMENTS, GetComments(declaration)
                    );
            }
        }

        class GetConstructorDeclaration :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object node)
            {
                var declaration = (ConstructorDeclarationSyntax)node;

                return arrayMap(
                    COMMENTS, GetComments(declaration),
                    PARAMETERS, declaration.ParameterList.ToString(),
                    PARAMETERLIST, GetParameterList(declaration.ParameterList)
                    );
            }
        }

        class GetPropertyStatement :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object map)
            {
                var modifier = get(map, MODIFIER);
                var fullName = get(map, FULLNAME);
                var name = FixClassName(get(map, NAME));
                var privateName = get(map, PRIVATENAME);

                return $"{modifier} static {fullName} {name} => {privateName} ?? ({privateName} = new {fullName}());";
            }
        }

        class GetPrivatePropertyStatement :
            funclib.Components.Core.IFunction<object, object>
        {
            public object Invoke(object map)
            {
                var fullName = get(map, FULLNAME);
                var privateName = get(map, PRIVATENAME);

                return $"static {fullName} {privateName};";
            }
        }

        class GetMacroFunctionStatement :
            funclib.Components.Core.IFunction<object, object, object, object>
        {
            public object Invoke(object classMap, object constructorMap, object methodMap)
            {
                var modifier = get(classMap, MODIFIER);
                var returnType = get(methodMap, RETURNTYPE);
                var className = get(classMap, NAME);
                var typedParameters = get(classMap, TYPEDPARAMTERS);
                var constructorParameters = get(constructorMap, PARAMETERS);
                var parameterList = apply(Str, interpose(",", get(constructorMap, PARAMETERLIST)));

                return $"{modifier} static {returnType} {className}{typedParameters}{constructorParameters} => new {className}{typedParameters}({parameterList}).Invoke();";
            }
        }

        class GetFunctionStatement :
            funclib.Components.Core.IFunction<object, object, object, object>
        {
            public object Invoke(object classMap, object constructorMap, object methodMap)
            {
                var name = "Func";
                var modifier = get(classMap, MODIFIER);
                var returnType = get(methodMap, RETURNTYPE);
                var className = get(classMap, NAME);
                var typedParameters = get(classMap, TYPEDPARAMTERS);
                var constructorParameters = get(constructorMap, PARAMETERS);
                var parameterList = apply(Str, interpose(",", get(constructorMap, PARAMETERLIST)));

                return $"{modifier} static {className}{typedParameters} {name}{typedParameters}{constructorParameters} => new {className}{typedParameters}({parameterList});";
            }
        }

        class GetLazySeqStatement :
            funclib.Components.Core.IFunction<object, object, object, object>
        {
            public object Invoke(object classMap, object constructorMap, object methodMap)
            {
                var modifier = get(classMap, MODIFIER);
                var returnType = get(methodMap, RETURNTYPE);
                var className = get(classMap, NAME);
                var typedParameters = get(classMap, TYPEDPARAMTERS);
                var constructorParameters = get(constructorMap, PARAMETERS);
                var parameterList = apply(Str, interpose(",", get(constructorMap, PARAMETERLIST)));

                return $"{modifier} static {className}{typedParameters} {className}{typedParameters}{constructorParameters} => new {className}{typedParameters}({parameterList});";
            }
        }

        class GetMethodStatement :
            funclib.Components.Core.IFunction<object, object, object, object>
        {
            public object Invoke(object classMap, object constructorMap, object methodMap)
            {
                var modifier = get(classMap, MODIFIER);
                var returnType = get(methodMap, RETURNTYPE);
                var className = get(classMap, NAME);
                var methodName = get(methodMap, NAME);
                var typedParameters = get(classMap, TYPEDPARAMTERS);
                var constructorParameters = get(constructorMap, PARAMETERS);
                var parameterList = apply(Str, interpose(",", get(constructorMap, PARAMETERLIST)));
                var parameters = get(methodMap, PARAMETERS);

                return $"{modifier} static {returnType} {className}{typedParameters}{parameters} => {className}.{methodName}({parameterList});";
            }
        }


        //static IList<string> GenerateProperties(IList<CSharpSyntaxTree> files) =>
        //        files.Aggregate(new List<string>() as IList<string>, (acc, node) =>
        //            GetClassDeclarations(node, acc, (a, n) =>
        //            {
        //                if (!FilterClasses(n)) return a;

        //                var modifier = GetModifier(n.Modifiers);
        //                var className = n.Identifier.Text;
        //                var fullName = GetFullyQualifiedName(n);
        //                var comments = GetComments(n);
        //                var privateName = "__" + className.ToLower();

        //                a.Add($"static {fullName} {privateName};");

        //                if (comments != null)
        //                    comments.ForEach(x => a.Add(x));

        //                a.Add($"{modifier} static {fullName} {className} => {privateName} ?? ({privateName} = new {fullName}());");
        //                return a;
        //            }));

        //static IList<string> GenerateMethods(IList<CSharpSyntaxTree> files) =>
        //    files.Aggregate(new List<string>() as IList<string>, (accumulator, syntaxTree) =>
        //        GetClassDeclarations(syntaxTree, accumulator, (acc, classDeclaration) =>
        //            GetMethodDeclarations(classDeclaration, acc, (a, n) =>
        //            {
        //                var className = classDeclaration.Identifier.Text;
        //                var modifier = GetModifier(classDeclaration.Modifiers);
        //                var methodName = n.Identifier.Text;
        //                var returnType = n.ReturnType.ToString();
        //                var typedParameters = classDeclaration.TypeParameterList?.ToString();

        //                if (className == "Function" || className == "FunctionParams")
        //                {
        //                    string parameters = "";
        //                    string parameterList = "";
        //                    List<string> comments = null;
        //                    string constructorParams = "";

        //                    GetConstructorDeclarations(classDeclaration, acc, (a1, n1) =>
        //                    {
        //                        comments = GetComments(n1);
        //                        parameters = n1.ParameterList.ToString();
        //                        constructorParams = n1.ParameterList.ToString();
        //                        parameterList = GetParameterList(n1.ParameterList);

        //                        if (comments != null)
        //                            comments.ForEach(x => a.Add(x));

        //                        a.Add($"{modifier} static {className}{typedParameters} Func{typedParameters}{parameters} => new {className}{typedParameters}({string.Join(", ", parameterList)});");
        //                        return a;
        //                    });

        //                    constructorParams = constructorParams.Replace("x", "func").Replace("Func", "IFunction").TrimStart('(').TrimEnd(')');
        //                    parameters = n.ParameterList.ToString().TrimStart('(').TrimEnd(')');
        //                    parameterList = GetParameterList(n.ParameterList);
        //                    comments = GetComments(n);

        //                    if (comments != null)
        //                        comments.ForEach(x => a.Add(x));

        //                    a.Add($"{modifier} static {returnType} Invoke{typedParameters}({constructorParams}{(string.IsNullOrWhiteSpace(parameters) ? "" : ", " + parameters)}) => func.Invoke({string.Join(", ", parameterList)});");
        //                }
        //                else if (className == "LazySeq")
        //                {
        //                    GetConstructorDeclarations(classDeclaration, acc, (a1, n1) =>
        //                    {
        //                        var comments = GetComments(n1);
        //                        var parameters = n1.ParameterList.ToString();
        //                        var constructorParams = n1.ParameterList.ToString();
        //                        var parameterList = GetParameterList(n1.ParameterList);

        //                        if (comments != null)
        //                            comments.ForEach(x => a.Add(x));

        //                        a.Add($"{modifier} static {className}{typedParameters} {FixClassName(className)}{typedParameters}{constructorParams} => new {className}{typedParameters}({string.Join(", ", parameterList)});");
        //                        return a;
        //                    });
        //                }
        //                else if (classDeclaration.DescendantNodes().OfType<BaseListSyntax>().FirstOrDefault().Types.ToString() == "IMacroFunction")
        //                {
        //                    GetConstructorDeclarations(classDeclaration, acc, (a1, n1) =>
        //                    {
        //                        var comments = GetComments(n1);
        //                        var parameters = n1.ParameterList.ToString();
        //                        var constructorParams = n1.ParameterList.ToString();
        //                        var parameterList = GetParameterList(n1.ParameterList);

        //                        if (comments != null)
        //                            comments.ForEach(x => a.Add(x));

        //                        a.Add($"{modifier} static {returnType} {FixClassName(className)}{typedParameters}{constructorParams} => new {className}{typedParameters}({string.Join(", ", parameterList)}).Invoke();");
        //                        return a;
        //                    });
        //                }
        //                else
        //                {
        //                    var parameters = n.ParameterList.ToString();
        //                    var parameterList = GetParameterList(n.ParameterList);
        //                    var comments = GetComments(n);

        //                    if (comments != null)
        //                        comments.ForEach(x => a.Add(x));

        //                    a.Add($"{modifier} static {returnType} {FixClassName(className)}{typedParameters}{parameters} => {className}.{methodName}({string.Join(", ", parameterList)});");
        //                }

        //                return a;
        //            })));

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

        static string GetModifier(SyntaxTokenList modifier) =>
            modifier.Count == 1
                ? modifier[0].Text
                : "internal";

        static IList<CSharpSyntaxTree> GetClassFiles(string directory) =>
            Directory.EnumerateFiles(directory)
                .Where(x => Path.GetExtension(x) == ".cs")
                .Select(x => CSharpSyntaxTree.ParseText(File.ReadAllText(x)))
                .Cast<CSharpSyntaxTree>()
                .ToList();


        //static IList<string> GetClassDeclarations(CSharpSyntaxTree syntaxTree, IList<string> seed, Func<IList<string>, ClassDeclaration, IList<string>> aggregate) =>
        //    syntaxTree.GetRoot()
        //            .DescendantNodes()
        //            .OfType<ClassDeclarationSyntax>()
        //            .Where(x => IsChildOfNamespace(x) && IsNotAnAbstractClass(x))
        //            .Select(x => new ClassDeclaration()
        //            {
        //                Modifier = GetModifier(x.Modifiers),
        //                Name = x.Identifier.Text,
        //                FullName = GetFullyQualifiedName(x),
        //                Comments = GetComments(x),
        //                PrivateName = $"__{x.Identifier.Text.ToLower()}"
        //            })
        //            .Aggregate(seed, aggregate)

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



        static string FixClassName(object className)
        {
            var name = className.ToString();

            name = System.Char.ToLowerInvariant(name[0]).ToString()
                + System.Char.ToLowerInvariant(name[1]).ToString()
                + name.Substring(2);

            switch (name)
            {
                case "class": return "@class";
                case "do": return "@do";
                case "char": return "@char";
                case "function": return "invoke";
                case "invokeFunction": return "invoke";
                case "uuID": return "uuid";
                case "rSeq": return "rseq";
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
                case "ATransducerFunction":
                    return false;
            }

            return true;
        }

        static bool IsPublic(SyntaxTokenList modifier) => modifier.Count == 1 && modifier[0].Text == "public";
        static bool IsChildOfNamespace(SyntaxNode node) => node.Parent.Kind() == SyntaxKind.NamespaceDeclaration;
        static bool IsChildOf(SyntaxNode parent, SyntaxNode child) => child.Parent == parent;
        static bool IsInvokeIdentifier(SyntaxToken identifier) => identifier.Text == "Invoke";
        static bool IsNotAnAbstractClass(BaseTypeDeclarationSyntax node) => !node.Modifiers.Any(x => x.Text == "abstract");
    }
}
