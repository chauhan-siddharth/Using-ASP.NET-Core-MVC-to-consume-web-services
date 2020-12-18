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
    //The controller is used for faculty data 
    public class FacultyController : Controller
    {
        private readonly IGetFaculty _facultyRepository;

        public FacultyController(IGetFaculty facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
        // The data obtained from the GetAllFaculty is sorted further and passed into view model
        public async Task<IActionResult> GetFaculty()
        {
            var allFaculty = await _facultyRepository.GetAllFaculty();
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            var facultyViewModel = new FacultyViewModel()
            {
                Faculty = allFaculty.ToList(),
                Title = "School of Information Faculty Members",
                Subtitle= "To view more about our faculty and staff, click below."
            };
            return View(facultyViewModel);
        }



     
    }
}

