using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Async_Thing_Module.Models;
using Async_Thing_Module.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Async_Thing_Module.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var apiData = new apiData();

            var randomNumber = await apiData.GetRandomNumber();
            var vm = new RandomNumberViewModel();
            vm.RandomNumber = randomNumber;

            var chuckFact = await apiData.GetChuckNorrisFact();
            vm.ChuckNorrisFact = chuckFact;

            var seleucids = await apiData.GetSeleucids();
            vm.Seleucids = seleucids;

            var teacher = await apiData.GetATeacher();
            vm.Teacher = teacher;

            return View(vm);
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
