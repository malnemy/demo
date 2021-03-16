using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VT.CodeTest.WebSite.Equation;
using VT.CodeTest.WebSite.Models;
using VT.CodeTest.WebSite.Services;

namespace VT.CodeTest.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpressionService _expressionService;

        public HomeController(ILogger<HomeController> logger, IExpressionService expressionService)
        {
            _logger = logger;
            _expressionService = expressionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            EquationParameters equationParameters = new EquationParameters()
            {
                Number1 = 1,
                Number2 = 2,
                Operator = System.Linq.Expressions.ExpressionType.Add
            };

            ViewBag.SupportedOperators = SupportedOperators.GetSupportedOperatorsAsListItems();

            return View(equationParameters);
        }

        [HttpPost]
        public IActionResult Index([FromForm] EquationParameters equationParameters)
        {
            ViewBag.EquationResult = _expressionService.CalculateExpression(equationParameters);
            ViewBag.SupportedOperators = SupportedOperators.GetSupportedOperatorsAsListItems();
            return View(equationParameters);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
