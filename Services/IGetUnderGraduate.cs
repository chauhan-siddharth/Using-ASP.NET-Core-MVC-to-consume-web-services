﻿using Project3_FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3_FinalExam.Services
{
    public interface IGetUnderGraduate
    {
        Task<List<UnderGradMajors>> GetAllUnderGraduate();
    }
}
