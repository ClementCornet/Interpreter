using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class PrettyBuilder
    {
        StringBuilder builder;
        int indent = 0;

        public PrettyBuilder()
        {
            builder = new StringBuilder();
        }

        public void Indent()
        {
            indent += 2;
        }

        public void Unindent()
        {
            indent -= 2;
        }

        public void NewLine()
        {
            builder.Append("\n");
            if (indent > 0) builder.Append(new string(' ', indent));
        }

        public void Append(string s)
        {
            builder.Append(s);
        }

        override public string ToString()
        {
            return builder.ToString();
        }

    }
}
