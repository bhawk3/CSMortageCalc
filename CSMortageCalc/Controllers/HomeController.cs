using CSMortageCalc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CSMortageCalc.Helpers;

namespace CSMortageCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult App()
        {
            Loan loan = new();

            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0m;
            loan.Rate = 3.5m;
            loan.Amount = 15000m;
            loan.Term = 60;
            
            return View(loan);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult App(Loan loan)
        {
            //Calculate the loan and get the payments bruh
            var loanHelper = new LoanHelper();

            Loan newloan = loanHelper.GetPayments(loan);


            return View(newloan);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}