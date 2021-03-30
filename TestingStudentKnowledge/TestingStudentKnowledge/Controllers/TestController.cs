using Microsoft.AspNetCore.Mvc;
using TestingStudentKnowledgeApplication.Interfaces;
using TestingStudentKnowledgeApplication.ViewModels;

namespace TestingStudentKnowledge.Controllers
{
    public class TestController : Controller
    {
        private ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        public IActionResult Index()
        {
            TestViewModel model = _testService.GetTests();
            return View(model);
        }
    }
}