using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Services.TeacherServices
{
    public interface ITests
    {
        List<QuestionsDTO> GetTest();
        //List<QuestionsDTO> GetQuestionByCourse(int id);
        void CreateTest(QuestionsDTO dto);
        void DeleteTest(int id);
    }
}
