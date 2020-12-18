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
    //The controller implements the research tab which consumes the /research/byfaculty end points
    public class ResearchFacultyController : Controller
    {
        private readonly IGetResearchFaculty _researchFacultyRepository;

        public ResearchFacultyController(IGetResearchFaculty facultyRepository)
        {
            _researchFacultyRepository = facultyRepository;
        }


        public async Task<IActionResult> GetResearchFaculty()
        {
            var allResearchFaculty = await _researchFacultyRepository.GetAllResearchFaculty();
            //var sortedResearch = allResearchFaculty.OrderBy(f => f.username);
            var researchFacultyViewModel = new ResearchFacultyViewModel()
            {
                ResearchFaculty = allResearchFaculty.ToList(),
                Title = "Research by Faculty"
                
            };
            return View(researchFacultyViewModel);
        }



    }
}
