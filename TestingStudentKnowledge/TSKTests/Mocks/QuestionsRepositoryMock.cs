﻿using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class QuestionsRepositoryMock : IQuestionsRepository
    {
        public Question GetQuestionsById(int questionId)
        {
            return new Question();
        }

        public List<Question> GetQuestionsByTestId(int Id)
        {
            List<Answer> answers1 = new List<Answer>() { new Answer() { Id = 1, Text = "answer1" }, new Answer() { Id = 3, Text = "answer3" } };
            List<Answer> answers2 = new List<Answer>() { new Answer() { Id = 4, Text = "answer4" }, new Answer() { Id = 5, Text = "answer5" } };
            return new List<Question>() { new Question() { Answers = answers1, Id = 1, Text = "Question1" }, new Question() { Answers = answers2, Id = 2, Text = "Question2" } };
        }

        public void SetQuestionIntoDb(Question question)
        {
            // do nothing
        }
    }
}
