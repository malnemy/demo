using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;
using VT.CodeTest.WebSite.Models;
using VT.CodeTest.WebSite.Services;
using Xunit;

namespace WebSiteTests
{
    public class ExpressionServiceTests
    {
        [Fact]
        public void CalculateExpression()
        {
            var serviceProvider = new ServiceCollection().AddTransient<IExpressionService, ExpressionService>().BuildServiceProvider();
            var expressionService = serviceProvider.GetRequiredService<IExpressionService>();
            //Add
            Assert.Equal(3, expressionService.CalculateExpression(new EquationParameters { Number1 = 1, Number2 = 2, Operator = ExpressionType.Add }));
            Assert.Equal(-1, expressionService.CalculateExpression(new EquationParameters { Number1 = 1, Number2 = -2, Operator = ExpressionType.Add }));
            Assert.Equal(-3, expressionService.CalculateExpression(new EquationParameters { Number1 = -1, Number2 = -2, Operator = ExpressionType.Add }));
            Assert.Equal(124.556m, expressionService.CalculateExpression(new EquationParameters { Number1 = 123.456m, Number2 = 1.1m, Operator = ExpressionType.Add }));
            //Subtract
            Assert.Equal(8, expressionService.CalculateExpression(new EquationParameters { Number1 = 10, Number2 = 2, Operator = ExpressionType.Subtract }));
            Assert.Equal(-8, expressionService.CalculateExpression(new EquationParameters { Number1 = 2, Number2 = 10, Operator = ExpressionType.Subtract }));
            Assert.Equal(-12, expressionService.CalculateExpression(new EquationParameters { Number1 = -2, Number2 = 10, Operator = ExpressionType.Subtract }));
            Assert.Equal(8, expressionService.CalculateExpression(new EquationParameters { Number1 = -2, Number2 = -10, Operator = ExpressionType.Subtract }));
            Assert.Equal(122.356m, expressionService.CalculateExpression(new EquationParameters { Number1 = 123.456m, Number2 = 1.1m, Operator = ExpressionType.Subtract }));
            //Multiply
            Assert.Equal(2, expressionService.CalculateExpression(new EquationParameters { Number1 = 1, Number2 = 2, Operator = ExpressionType.Multiply }));
            Assert.Equal(-2, expressionService.CalculateExpression(new EquationParameters { Number1 = 1, Number2 = -2, Operator = ExpressionType.Multiply }));
            Assert.Equal(2, expressionService.CalculateExpression(new EquationParameters { Number1 = -1, Number2 = -2, Operator = ExpressionType.Multiply }));
            Assert.Equal(135.8016m, expressionService.CalculateExpression(new EquationParameters { Number1 = 123.456m, Number2 = 1.1m, Operator = ExpressionType.Multiply }));
            //Divide
            Assert.Equal(5, expressionService.CalculateExpression(new EquationParameters { Number1 = 10, Number2 = 2, Operator = ExpressionType.Divide }));
            Assert.Equal(.2m, expressionService.CalculateExpression(new EquationParameters { Number1 = 2, Number2 = 10, Operator = ExpressionType.Divide }));
            Assert.Equal(-.2m, expressionService.CalculateExpression(new EquationParameters { Number1 = -2, Number2 = 10, Operator = ExpressionType.Divide }));
            Assert.Equal(.2m, expressionService.CalculateExpression(new EquationParameters { Number1 = -2, Number2 = -10, Operator = ExpressionType.Divide }));
            Assert.Equal(2, expressionService.CalculateExpression(new EquationParameters { Number1 = 2.2m, Number2 = 1.1m, Operator = ExpressionType.Divide }));
        }
    }
}
