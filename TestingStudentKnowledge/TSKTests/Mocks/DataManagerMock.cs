using TSKApp.BLL.Interfaces;

namespace TSKTests.Mocks
{
    public class DataManagerMock : IDataManager
    {
        public DataManagerMock(IAnswersRepository answersRepository, ITestsRepository testsRepository,
            IQuestionsRepository questionsRepository, IUsersRepository usersRepository,
            ICorrectAnswerRepository correctAnswerRepository)
        {
            Answers = answersRepository;
            Tests = testsRepository;
            Questions = questionsRepository;
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