using TestingStudentKnowledgeApplication.Interfaces;
using TestingStudentKnowledgeApplication.ViewModels;
using TestingStudentKnowledgeDomain.Interfaces;

namespace TestingStudentKnowledgeApplication.Services
{
    public class TestService : ITestService
    {
        public ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public TestViewModel GetTests()
        {
            return new TestViewModel
            {
                Tests = _testRepository.GetTests()
            };
        }
    }
}