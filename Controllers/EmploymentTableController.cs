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
using System.Dynamic;
namespace Project3_FinalExam.Controllers
{   
    //The controller is used to display employment and Co-op table using dynamic view
    public class EmploymentTableController : Controller
    {
        private readonly IGetEmploymentTable _employmentTableRepository;
        private readonly IGetCoopTable _coopTableRepository;

        public EmploymentTableController(IGetEmploymentTable employmentTableRepository, IGetCoopTable coopTableRepository)
        {
            _employmentTableRepository = employmentTableRepository;
            _coopTableRepository = coopTableRepository;
        }       

        public async Task<IActionResult> GetEmploymentTable()
        {
          //  var allEmploymentTable = await _employmentTableRepository.GetAllEmploymentTable();
            dynamic allTable = new ExpandoObject();
            allTable.employmentTable = await _employmentTableRepository.GetAllEmploymentTable();
            allTable.coopTable = await _coopTableRepository.GetAllCoopTable();        
            return View(allTable);
        }
    }
}
