using System;
using System.Linq.Expressions;
using VT.CodeTest.WebSite.Models;

namespace VT.CodeTest.WebSite.Services
{
    public class ExpressionService : IExpressionService
    {

        public decimal CalculateExpression(EquationParameters equationParameters)
        {
            // Create the BinaryExpression e.g (1 + 2)
            var binaryExpression =
                Expression.MakeBinary(
                    equationParameters.Operator,
                    Expression.Constant(equationParameters.Number1),
                    Expression.Constant(equationParameters.Number2));
            // Create the lambda expression.
            var lambdaExpression = Expression.Lambda<Func<decimal>>(binaryExpression);
            // Compile the lambda expression.  
            var compiledExpression = lambdaExpression.Compile();
            // Execute the lambda expression.  
            return compiledExpression();
        }

    }
}
