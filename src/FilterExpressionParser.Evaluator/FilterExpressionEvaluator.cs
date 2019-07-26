using System;
using Antlr4.Runtime;

namespace FilterExpressionParser.Evaluator
{
    public class FilterExpressionEvaluator
    {
        public bool Evaluate(string expression)
        {
            var inputStream = new AntlrInputStream(expression);
            var lexer = new FilterExpressionDslLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new FilterExpressionDslParser(commonTokenStream)
            {
                BuildParseTree = true
            };

            var expressionTree = parser.expr();

            if (expressionTree.exception != null)
                throw new Exception(expressionTree.exception.OffendingToken.Text, expressionTree.exception);

            var visitor = new FilterExpressionDslVisitor();

            return visitor.Visit(expressionTree);
        }
    }
}
