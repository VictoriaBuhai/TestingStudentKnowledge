using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class QuestionsRepositoryMock : IQuestionsRepository
    {
        public List<Question> GetQuestionsByTestId(int Id)
        {
            return new List<Question>();
        }

        public void SetQuestionIntoDb(Question question)
        {
            // do nothing
        }
    }
}
