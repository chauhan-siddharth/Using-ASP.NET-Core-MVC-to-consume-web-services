using Microsoft.AspNetCore.Mvc;
using Project3_FinalExam.Services;
using Project3_FinalExam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3_FinalExam.Controllers

{   //underGrad controller is used for underGraduate degree.
    public class UnderGraduateController : Controller
    {
        private readonly IGetUnderGraduate _underGraduateRepository;

        public UnderGraduateController(IGetUnderGraduate underGraduateRepository)
        {
            _underGraduateRepository = underGraduateRepository;
        }
      
        public async Task<IActionResult> GetUndergraduate()
        {
            var allUnderGraduate = await _underGraduateRepository.GetAllUnderGraduate();
            var sortedUnderGraduate = allUnderGraduate.OrderBy(f => f.degreeName);
            var UndergradViewModel = new UndergradViewModel()
            {
                UnderGrads = allUnderGraduate.ToList(),
                Title = "UnderGraduate Degree"
            };
            return View(UndergradViewModel);
        }



    }
}
