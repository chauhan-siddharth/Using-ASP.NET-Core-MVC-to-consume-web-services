using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3_FinalExam.Models
{
    public class ResearchFaculty
    {
        public string facultyName { get; set; }
        public string username { get; set; }

        public List<string> citations { get; set; }
    }
}
