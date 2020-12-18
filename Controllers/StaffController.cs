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
    //The controller implements staff section of our people and consumes/people/staff endpoint
    public class StaffController : Controller
    {
        private readonly IGetStaff _staffRepository;

        public StaffController(IGetStaff staffRepository)
        {
            _staffRepository = staffRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetStaff()
        {
            var allStaff = await _staffRepository.GetAllStaff();
            var sortedStaff = allStaff.OrderBy(f => f.username);
            var staffViewModel = new StaffViewModel()
            {
                Staff = allStaff.ToList(),
                Title = "School of Information Science Staff Members"
            };
            return View(staffViewModel);
        }
      
    }
}
