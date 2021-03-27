using TestingStudentKnowledgeApplication.Interfaces;
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
    }
}