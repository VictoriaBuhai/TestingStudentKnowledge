using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class CorrectAnswerRepository : ICorrectAnswerRepository
    {
        public List<CorrectAnswer> GetAllCorrectAnswersByQuestionId(int Id)
        {
            return new List<CorrectAnswer>();
        }

        public void SetCorrectAnswerIntoDb(CorrectAnswer correct)
        {
            // do nothing
        }
    }
}
