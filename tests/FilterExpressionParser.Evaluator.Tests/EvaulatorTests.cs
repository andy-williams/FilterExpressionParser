using System;
using Xunit;

namespace FilterExpressionParser.Evaluator.Tests
{
    public class EvaulatorTests
    {
        private readonly FilterExpressionEvaluator _sut;

        public EvaulatorTests()
        {
            _sut = new FilterExpressionEvaluator();
        }

        [Theory]
        [InlineData("1 > 1", false)]
        [InlineData("1 > 2", false)]
        [InlineData("4 > 1", true)]
        [InlineData("3 < 1", false)]
        [InlineData("1 < 2", true)]
        [InlineData("4 < 4", false)]
        [InlineData("22 > 11 and (2 < 6 and 5 > 6)", false)]
        [InlineData("22 > 11 and (2 < 6 or 5 > 6)", true)]
        public void Expression_Returns_Expected_Result(string expression, bool expectedResult)
        {
            var actualResult = _sut.Evaluate(expression);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
