namespace compiler
{
  class Parser
  {
    private Lexer lexer;

    public Parser(Lexer lexer)
    {
      this.lexer = lexer;
    }

    public void parseExpr()
    {
      Token token = lexer.getLexem();
      if (token.isEOF())
      {
        
      }
    }
  }
}