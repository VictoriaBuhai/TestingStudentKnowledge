using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;
using TSKApp.DAL.Models;
using TSKApp.PL.Models;

namespace TSKApp.PL.Services
{
    public class QuestionService
    {
        private readonly DataManager _dataManager;
        public QuestionService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public void SaveQuestionEditModelIntoDb(QuestionEditModel _model)
        {
            Question _question;
            Answer _answer;
            CorrectAnswer _correctAnswer;
            List<Answer> _answers;

            _question = new Question()
            {
                Text = _model.Name,
                TestId = _model.Id,
            };
            _dataManager.Questions.SetQuestionIntoDb(_question);

            for (int i = 0; i < _model.AnswerEditModels.Count; i++)
            {
                _answer = new Answer();
                _answer.Text = _model.AnswerEditModels[i].Name;
                _answer.QuestionId = _question.Id;
                _dataManager.Answers.SaveAnswer(_answer);

                if (_model.AnswerEditModels[i].Correct)
                {
                    _correctAnswer = new CorrectAnswer()
                    {
                        QuestionId = _question.Id,
                        AnswerId = _answer.Id,
                    };
                    _dataManager.CorrectAnswers.SetCorrectAnswerIntoDb(_correctAnswer);
                }
            }
        }
    }
}
