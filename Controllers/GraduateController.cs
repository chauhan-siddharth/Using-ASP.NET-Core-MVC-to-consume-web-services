using Microsoft.AspNetCore.Mvc;
using Project3_FinalExam.Services;
using Project3_FinalExam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3_FinalExam.Controllers
{
    //The control s used to display graduate degree data obtained form GetGraduate service
    public class GraduateController : Controller
    {
        private readonly IGetGraduate _graduateRepository;

        public GraduateController(IGetGraduate graduateRepository)
        {
            _graduateRepository = graduateRepository;
        }
       
        public async Task<IActionResult> GetGraduate()
        {
            var allGraduate = await _graduateRepository.GetAllGraduate();
            var sortedGraduate = allGraduate.OrderBy(f => f.degreeName);
            var GradViewModel = new GradViewModel()
            {
                Grads = allGraduate.ToList(),
                Title = "Graduate Degree"
            };
            return View(GradViewModel);
        }

    }
}
