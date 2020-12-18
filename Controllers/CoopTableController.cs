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
    //Co-op controller: The controller is used to give details about 
    //Co-op offered in a JavaScript grid layout
    public class CoopTableController : Controller
    {
        private readonly IGetCoopTable _coopTableRepository;

        public CoopTableController(IGetCoopTable coopTableRepository)
        {
            _coopTableRepository = coopTableRepository;
        }

        public async Task<IActionResult> GetCoopTable()
        {
            var allCoopTable = await _coopTableRepository.GetAllCoopTable();
            var sortedCoopTable = allCoopTable.OrderBy(f => f.employer);
            var coopTableViewModel = new CoopTableViewModel()
            {
                CoopTable = allCoopTable.ToList(),
                Title = "Co-op Table"
            };
            return View(coopTableViewModel);
        }
    }
}
