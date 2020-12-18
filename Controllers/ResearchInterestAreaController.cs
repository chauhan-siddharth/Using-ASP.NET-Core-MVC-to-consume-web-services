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
    //The controller implements the research section which uses research by interest
    public class ResearchInterestAreaController : Controller
    {
        private readonly IGetResearchInterestArea _researchInterestAreaRepository;

        public ResearchInterestAreaController(IGetResearchInterestArea facultyRepository)
        {
            _researchInterestAreaRepository = facultyRepository;
        }


        public async Task<IActionResult> GetResearchInterestArea()
        {
            var allResearchInterestArea = await _researchInterestAreaRepository.GetAllResearchInterestArea();
            //var sortedResearch = allResearchInterestArea.OrderBy(f => f.username);
            var researchInterestAreaViewModel = new ResearchInterestAreaViewModel()
            {
                ResearchInterestArea = allResearchInterestArea.ToList(),
                Title = "Research by Area of Interest"
                
            };
            return View(researchInterestAreaViewModel);
        }




    }
}
