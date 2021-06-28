using System;

namespace compiler
{
  class Parser
  {
    private Lexer lexer;
    private TokenType TokenType = new TokenType();

    private Token currToken;

    public Parser(Lexer lexer)
    {
      this.lexer = lexer;
      currToken = lexer.getLexem();
    }

    public Node parseExpr()
    {
      Token token = currToken;
      if (token.isEOF())
      {
        new CustomException($"{token.str}: {token.col}  expected expression");
        throw new System.Exception();
      }
      else
      {
        Node left = parseTerm();
        Token operation = currToken;
        while (Convert.ToString(operation.value) == "+" || Convert.ToString(operation.value) == "-")
        {
          currToken = lexer.getLexem();
          Node right = parseTerm();
          left = new BinaryOpNode(operation, left, right);
          operation = currToken;
        }

        return left;
      }
    }

    public Node parseTerm()
    {
      Node left = parseFactor();
      Token operation = currToken;
      while (Convert.ToString(operation.value) == "*" || Convert.ToString(operation.value) == "/")
      {
        currToken = lexer.getLexem();
        Node right = parseFactor();
        left = new BinaryOpNode(operation, left, right);
        operation = currToken;
      }

      return left;
    }

    public Node parseFactor()
    {
      Token token = currToken;
      currToken = lexer.getLexem();
      
      if (token.type == TokenType.identifier) return new IdentifierNode(token);
      if ( Convert.ToString(token.value) == "-" || Convert.ToString(token.value) == "+")
      {
        Node operand = parseFactor();
        return new UnaryOpNode(operand, token);
      }

      if (Convert.ToString(token.value) == "(")
      {
        Node left = parseExpr();
        token = currToken;

        if (Convert.ToString(token.value) != ")") new CustomException($"{token.str}: {token.col}  ')' expected");
        else
        {
          currToken = lexer.getLexem();
          return left;
        }
        
      }

      return new IntegerNode(token);
    }
  }
}