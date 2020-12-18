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
    //The controller implements minors and immersions data 
    public class MinorsController : Controller
    {
        private readonly IGetMinors _minorsRepository;

        public MinorsController(IGetMinors minorsRepository)
        {
            _minorsRepository = minorsRepository;
        }

        public async Task<IActionResult> GetMinors()
        {
            var allMinors = await _minorsRepository.GetAllMinors();
            var sortedFaculty = allMinors.OrderBy(f => f.name);
            var MinorsViewModel = new MinorsViewModel()
            {
                Minors = allMinors.ToList(),
                Title = "Minors and Immersions"
            };
            return View(MinorsViewModel);
        }

    }
}
