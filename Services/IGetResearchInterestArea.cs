using System.Collections.Generic;
using System.Threading.Tasks;
using Project3_FinalExam.Models;

namespace Project3_FinalExam.Services
{
   public interface IGetResearchInterestArea
    {
        Task<List<ResearchInterestArea>> GetAllResearchInterestArea();
    }
}
