using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project3_FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Services;
using Project3_FinalExam.ViewModels;

namespace Project3_FinalExam.Controllers
{
    //The controller is reponsible for the home/layout page in the beginning
    //the controller also shows the data from about endpoint
    //The map endpoint is also mapped to this controller
    public class HomeController : Controller
    {

        private readonly IGetAbout _AboutRepository;

        public HomeController(IGetAbout AboutRepository)
        {
            _AboutRepository = AboutRepository;
        }
       


        public async Task<IActionResult> Index()
        {
            var allAbout = await _AboutRepository.GetAllAbout();
            var sortedAbout = allAbout.OrderBy(f => f.title);
            var AboutViewModel = new AboutViewModel()
            {
                About = allAbout.ToList(),
                Title = "About"
            };
            return View(AboutViewModel);
        }
        public IActionResult Maps()
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
