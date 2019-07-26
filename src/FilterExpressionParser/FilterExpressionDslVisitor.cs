using System;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace FilterExpressionParser
{
    public class FilterExpressionDslVisitor : FilterExpressionDslBaseVisitor<bool>
    {
        public override bool VisitExpr([NotNull] FilterExpressionDslParser.ExprContext context)
        {
            if (context.@operator() != null)
            {
                var operatorSymbolType = ((ITerminalNode)context.@operator().GetChild(0)).Symbol.Type;
                var operand1 = context.operand()[0].GetText();
                var operand2 = context.operand()[1].GetText();

                switch (operatorSymbolType)
                {
                    case FilterExpressionDslLexer.GreaterThan:
                        return int.Parse(operand1) > int.Parse(operand2);
                    case FilterExpressionDslLexer.LessThan:
                        return int.Parse(operand1) < int.Parse(operand2);
                    case FilterExpressionDslLexer.GreaterThanEqual:
                        return int.Parse(operand1) >= int.Parse(operand2);
                    case FilterExpressionDslLexer.LessThanEqual:
                        return int.Parse(operand1) <= int.Parse(operand2);
                    case FilterExpressionDslLexer.Equal:
                        return int.Parse(operand1) == int.Parse(operand2);
                    default:
                        throw new Exception("WHAT?1");
                }
            }

            if (context.booleanOperator() != null)
            {
                var booleanOperatorSymbolType = ((ITerminalNode)context.booleanOperator().GetChild(0)).Symbol.Type; ;

                switch (booleanOperatorSymbolType)
                {
                    case FilterExpressionDslLexer.And:
                        return Visit(context.expr(0)) && Visit(context.expr(1));
                    case FilterExpressionDslLexer.Or:
                        return Visit(context.expr(0)) || Visit(context.expr(1));
                    default:
                        throw new Exception("WHAT?2");
                }
            }

            if (context.OpenParen() != null && context.CloseParen() != null)
            {
                return Visit(context.expr(0));
            }

            throw new Exception("WHAT?3");
        }

    }
}
