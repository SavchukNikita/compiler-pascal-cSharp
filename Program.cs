using System;

namespace compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args[0] == "-l")
            {
                Lexer lexer = new Lexer("input.txt");
                Token token = lexer.getLexem();
                Console.WriteLine($"{token.str}, {token.col}, {token.type}, \"{token.code}\", {token.value}");

                while (!token.isEOF())
                {
                    token = lexer.getLexem();
                    if(!token.isEOF())
                        Console.WriteLine($"{token.str}, {token.col}, {token.type}, \"{token.code}\", {token.value}");
                }
            }

            if (args[0] == "-ps")
            {
                Lexer lexer = new Lexer("input.txt");
                Node node = new Parser(lexer).parseExpr();

                string res = node.print(1);
                Console.WriteLine(res);
            }
        }
    }
}
