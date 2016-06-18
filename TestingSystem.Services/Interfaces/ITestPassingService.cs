using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Entities;

namespace TestingSystem.Services.Interfaces
{
    public interface ITestPassingService
    {
        Test GetTestById(int id);


    }
}
