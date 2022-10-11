using System;
using System.IO;
using System.Text;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
           
            if (args.Length < 1)
            {
                Console.WriteLine("No file provided");
                return;
            }

            string fileName = args[0];
            using (StreamReader streamReader = new StreamReader(fileName, Encoding.ASCII, true))
            {
                string text = streamReader.ReadToEnd();
                var program = ParserUtility.Parse(text);
                if (program != null)
                {
                    //Console.WriteLine(program.Pretty());

                    var data = Encoding.ASCII.GetBytes(text);
                    var stream = new MemoryStream(data, 0, data.Length);
                    var l = new Scanner(stream);
                    var p = new Parser(l);
                    p.Parse();
                    Interpreter interpreter = new Interpreter();
                    interpreter.Eval(p.Program);
                }
            }
        }
    }
}