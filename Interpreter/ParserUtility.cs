using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public static class ParserUtility
    {
        public static Expression Parse(string prg)
        {
            byte[] data = Encoding.ASCII.GetBytes(prg);
            MemoryStream stream = new MemoryStream(data, 0, data.Length);
            Scanner lexer = new Scanner(stream);
            Parser parser = new Parser(lexer);

            if (parser.Parse())
            {
                return parser.Program;
            }
            else
            {
                return null;
            }
        }
    }
}
