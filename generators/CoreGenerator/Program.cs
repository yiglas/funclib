﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static funclib.Core;

namespace CoreGenerator
{
    public class Program
    {
        const string MODIFIER = ":modifier";
        const string NAME = ":name";
        const string FULLNAME = ":full-name";
        const string COMMENTS = ":comments";
        const string PRIVATENAME = ":private-name";
        const string TYPED_PARAMETERS = ":typed-parameters";
        const string RETURNTYPE = ":return-type";
        const string PARAMETERS = ":parameters";
        const string PARAMETERLIST = ":parameter-list";
        const string IS_MACRO_FUNCTION = ":macro-function?";
        const string CLASSNAME = ":class-name";
        const string PARENT = ":parent";

        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var dir = new DirectoryInfo(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName + @"/src/funclib";
            var files = Filter(ExtensionsPredicate, Directory.GetFiles(dir + @"/Components/Core", "*", SearchOption.AllDirectories));
            var syntax = Filter(ClassDeclarationsPredicate, Flatten(Map(GetDescendantNodes<ClassDeclarationSyntax>(), Map(ConvertToSyntaxNode, files))));

            var lines = new List<string>();

            lines.Add("//------------------------------------------------------------------------------");
            lines.Add("// <auto-generated>");
            lines.Add("//     This code was generated by a tool on {DateTime.Now}");
            lines.Add("//");
            lines.Add("//     Changes to this file may cause incorrect behavior and will be lost if");
            lines.Add("//     the code is regenerated.");
            lines.Add("// </auto-generated>");
            lines.Add("//------------------------------------------------------------------------------");
            lines.Add("using funclib.Collections;");
            lines.Add("using funclib.Components.Core;");
            lines.Add("using funclib.Components.Core.Generic;");
            lines.Add("using System.Text.RegularExpressions;");
            lines.Add("using System;");
            lines.Add(Environment.NewLine);
            lines.Add("namespace funclib");
            lines.Add("{");
            lines.Add("\tpublic static class Core");
            lines.Add("\t{");

            var l = ((object[])ToArray(Flatten(Map(Build, syntax)))).Select(x => $"\t\t{x}");

            lines.AddRange(l);
            lines.Add("\t}");
            lines.Add("}");

            var source = dir + @"/Core.cs";
            File.WriteAllLines(source, lines);

            Console.WriteLine($"Time Elapsed: {sw.Elapsed}");
            Console.WriteLine("========== Finished ==========");
            Console.ReadLine();
        }

        public static object ExtensionsPredicate => Func(file => Path.GetExtension((string)file) == ".cs");
        public static object ConvertToSyntaxNode => Func(file => CSharpSyntaxTree.ParseText(File.ReadAllText((string)file)).GetRoot());
        public static object GetDescendantNodes<T>() => Func(node => ListS(((CSharpSyntaxNode)node).DescendantNodes().OfType<T>()));
        public static object IsChildOfNamespace => Func(node => node != null && ((SyntaxNode)node).Parent.Kind() == SyntaxKind.NamespaceDeclaration);
        public static object IsNotAnAbstractClass => Func(node => node != null && !((BaseTypeDeclarationSyntax)node).Modifiers.Any(x => x.Text == "abstract"));
        public static object ClassDeclarationsPredicate => Func(node => And(Identity(node), Invoke(IsChildOfNamespace, node), Invoke(IsNotAnAbstractClass, node)));
        public static object IsInvokeIdentifier => Func(map => Get(map, NAME).Equals("Invoke"));
        public static object IsPublic => Func(map => Get(map, MODIFIER).Equals("public"));
        public static object MethodDeclarationPredicate(object node) => Func(map => And(Invoke(IsInvokeIdentifier, map), Invoke(IsPublic, map), Invoke(IsChildOf(node), map)));
        public static object IsChildOf(object node) => Func(map => Get(map, PARENT) == node);

        public static object Build => Func(node =>
        {
            var @class = Invoke(GetClassDeclaration, node);
            var constructors = Filter(IsPublic, Map(GetConstructorDeclaration(@class), Invoke(GetDescendantNodes<ConstructorDeclarationSyntax>(), node)));
            var methods = Filter(MethodDeclarationPredicate(node), Map(GetMethodDeclaration(@class), Invoke(GetDescendantNodes<MethodDeclarationSyntax>(), node)));

            var className = Get(@class, NAME);
            var classModifier = Get(@class, MODIFIER);
            var isMacroFunction = Get(@class, IS_MACRO_FUNCTION);
            var typedParameters = Get(@class, TYPED_PARAMETERS);

            var v = Conj(Vector(), $"#region {classModifier} - {className}{typedParameters}");

            if (className.Equals("Function") || className.Equals("FunctionParams"))
            {
                v = Reduce(conj, v, Flatten(Map(BuildStatement(GetFunctionStatement), constructors)));
            }
            else if (className.Equals("LazySeq"))
            {
                v = Reduce(conj, v, Flatten(Map(BuildStatement(GetLazySeqStatement), constructors)));
            }
            else if ((bool)Truthy(isMacroFunction))
            {
                v = Reduce(conj, v, Flatten(Map(BuildStatement(GetMacroFunctionStatement), constructors)));
            }
            else
            {
                v = Apply(conj, v, Invoke(BuildClassStatement, @class));
                v = Reduce(conj, v, Flatten(Map(BuildStatement(Partial(GetMethodStatement, classModifier)), methods)));
            }

            v = Conj(v, "#endregion");

            return v;
        });

        public static object BuildClassStatement => Func(map =>
        {
            var v = Conj(Vector(), Invoke(GetPrivatePropertyStatement, map));
            v = Apply(conj, v, Get(map, COMMENTS));
            v = Conj(v, Invoke(GetPropertyStatement, map));
            return v;
        });

        public static object BuildStatement(object f) => Func(map =>
        {
            var v = Vector();
            v = Apply(conj, v, Get(map, COMMENTS));
            v = Conj(v, Invoke(f, map));
            return v;
        });

        public static object GetClassDeclaration => Func(node =>
        {
            var declaration = (ClassDeclarationSyntax)node;

            return ArrayMap(
                MODIFIER, GetModifier(declaration.Modifiers),
                NAME, declaration.Identifier.Text,
                FULLNAME, GetFullyQualifiedName(declaration),
                COMMENTS, GetComments(declaration),
                PRIVATENAME, Str("__", FixClassName(declaration.Identifier.Text).Replace("@", "")),
                TYPED_PARAMETERS, declaration.TypeParameterList?.ToString(),
                IS_MACRO_FUNCTION, declaration.DescendantNodes().OfType<BaseListSyntax>().FirstOrDefault().Types.ToString() == "IMacroFunction"
                );
        });

        public static object GetMethodDeclaration(object classMap) => Func(node =>
        {
            var declaration = (MethodDeclarationSyntax)node;

            return ArrayMap(
                CLASSNAME, Get(classMap, NAME),
                MODIFIER, GetModifier(declaration.Modifiers),
                NAME, declaration.Identifier.Text,
                RETURNTYPE, declaration.ReturnType.ToString(),
                PARAMETERS, declaration.ParameterList.ToString(),
                PARAMETERLIST, GetParameterList(declaration.ParameterList),
                COMMENTS, GetComments(declaration),
                PARENT, declaration.Parent
                );
        });

        public static object GetConstructorDeclaration(object @class) => Func(node =>
        {
            var declaration = (ConstructorDeclarationSyntax)node;

            return ArrayMap(
                CLASSNAME, Get(@class, NAME),
                FULLNAME, Get(@class, FULLNAME),
                MODIFIER, Get(@class, MODIFIER),
                COMMENTS, GetComments(declaration),
                PARAMETERS, declaration.ParameterList.ToString(),
                PARAMETERLIST, GetParameterList(declaration.ParameterList),
                TYPED_PARAMETERS, Get(@class, TYPED_PARAMETERS)
                );
        });

        public static object GetPropertyStatement => Func(map =>
        {
            var modifier = Get(map, MODIFIER);
            var fullName = Get(map, FULLNAME);
            var name = FixClassName(Get(map, NAME));
            var privateName = Get(map, PRIVATENAME);

            return $"{modifier} static {fullName} {name} => {privateName} ?? ({privateName} = new {fullName}());";
        });

        public static object GetPrivatePropertyStatement => Func(map =>
        {
            var fullName = Get(map, FULLNAME);
            var privateName = Get(map, PRIVATENAME);

            return $"static {fullName} {privateName};";
        });

        public static object GetMacroFunctionStatement => Func(constructorMap =>
        {
            var modifier = Get(constructorMap, MODIFIER);
            var returnType = "object";
            var className = Get(constructorMap, CLASSNAME);
            var fullName = Get(constructorMap, FULLNAME);
            var typedParameters = Get(constructorMap, TYPED_PARAMETERS);
            var constructorParameters = Get(constructorMap, PARAMETERS);
            var parameterList = Get(constructorMap, PARAMETERLIST);

            return $"{modifier} static {returnType} {className}{typedParameters}{constructorParameters} => new {fullName}{typedParameters}({parameterList}).Invoke();";
        });

        public static object GetFunctionStatement => Func(constructorMap =>
        {
            var name = "Func";
            var modifier = Get(constructorMap, MODIFIER);
            var fullName = Get(constructorMap, FULLNAME);
            var typedParameters = ReplaceObjectTypes(Get(constructorMap, TYPED_PARAMETERS));
            var constructorParameters = ReplaceObjectTypes(Get(constructorMap, PARAMETERS));
            var parameterList = Get(constructorMap, PARAMETERLIST);

            return $"{modifier} static {fullName}{typedParameters} {name}{constructorParameters} => new {fullName}{typedParameters}({parameterList});";
        });

        public static object GetLazySeqStatement => Func((constructorMap) =>
        {
            var modifier = Get(constructorMap, MODIFIER);
            var className = Get(constructorMap, CLASSNAME);
            var fullName = Get(constructorMap, FULLNAME);
            var typedParameters = Get(constructorMap, TYPED_PARAMETERS);
            var constructorParameters = Get(constructorMap, PARAMETERS);
            var parameterList = Get(constructorMap, PARAMETERLIST);

            return $"{modifier} static {fullName}{typedParameters} {className}{typedParameters}{constructorParameters} => new {fullName}{typedParameters}({parameterList});";
        });

        public static object GetMethodStatement => Func((modifier, methodMap) =>
        {
            //var modifier = Get(methodMap, MODIFIER);
            var returnType = Get(methodMap, RETURNTYPE);
            var className = Get(methodMap, CLASSNAME);
            var methodName = Get(methodMap, NAME);
            var parameterList = Get(methodMap, PARAMETERLIST);
            var parameters = Get(methodMap, PARAMETERS);

            return $"{modifier} static {returnType} {FixMethodName(className)}{parameters} => {FixClassName(className)}.{methodName}({parameterList});";
        });

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

        static string ReplaceObjectTypes(object str) =>
            str.ToString()
                .Replace("T1", "object")
                .Replace("T2", "object")
                .Replace("T3", "object")
                .Replace("T4", "object")
                .Replace("T5", "object")
                .Replace("T6", "object")
                .Replace("T7", "object")
                .Replace("T8", "object")
                .Replace("T9", "object")
                .Replace("T10", "object")
                .Replace("T11", "object")
                .Replace("T12", "object")
                .Replace("T13", "object")
                .Replace("T14", "object")
                .Replace("T15", "object")
                .Replace("T16", "object")
                .Replace("T17", "object")
                .Replace("TRest", "object")
                .Replace("TResult", "object");

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

            if (name.Length > 1)
                name = System.Char.ToLowerInvariant(name[0]).ToString()
                    + System.Char.ToLowerInvariant(name[1]).ToString()
                    + name.Substring(2);

            if (name.Length == 1)
                name = name.ToLower();

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

        static string FixMethodName(object methodName)
        {
            var name = methodName.ToString();

            switch (name)
            {
                case "InvokeFunction": return "Invoke";
            }

            return name;
        }

        static string GetFullyQualifiedName(ClassDeclarationSyntax classDeclaration)
        {
            if (!SyntaxNodeHelper.TryGetParentSyntax(classDeclaration, out NamespaceDeclarationSyntax ns)) return "";

            var nsName = ns.Name.ToString();
            return nsName + "." + classDeclaration.Identifier.ToString();
        }
    }
}
