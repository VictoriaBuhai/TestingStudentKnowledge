using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.PL.Models;
using TSKApp.PL.Services;
using TSKTests.Mocks;
using Xunit;

namespace TSKTests.Tests
{
    public class QuestionServiceTests
    {
        [Fact]
        public void GetQuestionsByTestIdTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock());
            var questionService = new QuestionService(managerMock);
            var expected = new List<QuestionViewModel>()
            {
                new QuestionViewModel()
                {
                   AnswerViewModels = new List<AnswerViewModel>()
                    {
                        new AnswerViewModel() { Id = 1, Name = "answer1", Correct = true},
                        new AnswerViewModel() { Id = 3, Name = "answer2", Correct = false }
                    },
                   Id = 1,
                   Name = "Question1"
                },

                new QuestionViewModel()
                {
                   AnswerViewModels = new List<AnswerViewModel>()
                    {
                        new AnswerViewModel() { Id = 4, Name = "answer4", Correct = false},
                        new AnswerViewModel() { Id = 5, Name = "answer5", Correct = true }
                    },
                   Id = 2,
                   Name = "Question2"
                }
            };

            var actual = questionService.GetQuestionsByTestId(1);

            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Name, actual[i].Name);
                Assert.Equal(expected[i].AnswerViewModels[i].Name, actual[i].AnswerViewModels[i].Name);
                Assert.Equal(expected[i].AnswerViewModels[i].Id, actual[i].AnswerViewModels[i].Id);
                Assert.Equal(expected[i].AnswerViewModels[i].Correct, actual[i].AnswerViewModels[i].Correct);
            }
        }
    }
}
