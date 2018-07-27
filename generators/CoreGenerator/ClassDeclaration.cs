using System;
using System.Collections.Generic;
using System.Text;

namespace CoreGenerator
{
    public class ClassDeclaration
    {
        public string Name { get; set; }
        public string Modifier { get; set; }
        public string FullName { get; set; }
        public string PrivateName { get; set; }
        public IList<string> Comments { get; set; }

        public string PrivateStatement() => $"static {FullName} {PrivateName};";
        public string PublicStatement() => $"{Modifier} static {FullName} {Name} => {PrivateName} ?? ({PrivateName} = new {FullName}());";
    }
}
