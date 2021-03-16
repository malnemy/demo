using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VT.CodeTest.WebSite.Models;

namespace VT.CodeTest.WebSite.Services
{
    public interface IExpressionService
    {
        /// <summary>
        /// Calculates the given expression.
        /// </summary>
        /// <param name="equationParameters"></param>
        /// <returns></returns>
        decimal CalculateExpression(EquationParameters equationParameters);
    }
}
