using System;

namespace compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("input.txt");
            Token token = lexer.getLexem();
            Console.WriteLine($"{token.str}, {token.col}, {token.type}, \"{token.code}\", {token.value}");

            while (!token.isEOF())
            {
                token = lexer.getLexem();
                Console.WriteLine($"{token.str}, {token.col}, {token.type}, \"{token.code}\", {token.value}");
            }
        }
    }
}
