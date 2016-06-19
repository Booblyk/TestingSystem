using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.Services.TeacherServices;
using TestingSystem.DataBaseConfigurations.Repositories;

namespace TestingSystem.Services.TeacherServices
{
    public interface IQuestions
    {
        List<QuestionsDTO> GetQuestion();
        List<QuestionsDTO> GetQuestionByCourse(int id);
        void CreateQuestion(QuestionsDTO dto);
        void DeleteQuestion(int id);
    }
}
