﻿using TSKApp.BLL.Interfaces;

namespace TSKApp.BLL
{
    public class DataManager : IDataManager
    {
        public DataManager(IAnswersRepository answersRepository, ITestsRepository testsRepository,
            IQuestionsRepository quesionsRepository, IUsersRepository usersRepository,
            ICorrectAnswerRepository correctAnswerRepository)
        {
            Answers = answersRepository;
            Tests = testsRepository;
            Questions = quesionsRepository;
            Users = usersRepository;
            CorrectAnswers = correctAnswerRepository;
        }

        public IAnswersRepository Answers { get; }

        public ITestsRepository Tests { get; }

        public IQuestionsRepository Questions { get; }

        public IUsersRepository Users { get; }

        public ICorrectAnswerRepository CorrectAnswers { get; }
    }
}