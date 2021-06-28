using System;

namespace compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("./Tests/Lexer/40.txt");

            if(args[0] == "-l")
            {
                Token token;

                do
                {
                    token = lexer.getLexem();
                    if(!token.isEOF())
                        Console.WriteLine($"{token.str}, {token.col}, {token.type}, \"{token.code}\", {token.value}");
                }
                while (!token.isEOF());
            }

            if (args[0] == "-ps")
            {
                Node node = new Parser(lexer).parseExpr();

                string res = node.print(1);
                Console.WriteLine(res);
            }
        }
    }
}
