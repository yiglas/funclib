using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis;

namespace funclib.Components.Core.Generators
{
    [Generator]
    public class FalsyGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Debug.WriteLine("Executor");
        }

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif

            Debug.WriteLine("Initalizer");
        }
    }
}
