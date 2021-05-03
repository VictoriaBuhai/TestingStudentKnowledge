namespace TSKApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using TSKApp.BLL;
    using TSKApp.DAL.Models;
    using TSKApp.PL;
    using TSKApp.PL.Models;
    using static TSKApp.Enums.Helpers;

    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly DataManager _dataManager;
        private readonly ServicesManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public TestController(ILogger<TestController> logger, DataManager dataManager, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult MyTests()
        {
            var tests = _serviceManager.Tests.GetTestsList();
            return View(tests);
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult TestPassed(int totalMarks)
        {
            List<CorrectAnswerEditModel> rememberPreviousQuestionResult = _httpContextAccessor.HttpContext.Session.Get<List<CorrectAnswerEditModel>>("ListOfQuestionsResult");
            _httpContextAccessor.HttpContext.Session.Remove("ListOfQuestionsResult");

            var testId = rememberPreviousQuestionResult[0].TestId;
            var testTitle = _serviceManager.Tests.GetTestById(testId).Name;
            ViewBag.TotalMarks = totalMarks;
            ViewBag.TestId = testId; //not used
            ViewBag.TestTitle = testTitle;
            var models = _serviceManager.CorrectAnswers.GetModelsFromEditToView(rememberPreviousQuestionResult);
            return View(models);
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult TestPassing(int testId, int questionIndex = 0, int totalMarks = 0)
        {
            var questions = _serviceManager.Questions.GetQuestionsByTestId(testId);

            //For remember prev questions result
            List<CorrectAnswerEditModel> rememberPreviousQuestionResult = _httpContextAccessor.HttpContext.Session.Get<List<CorrectAnswerEditModel>>("ListOfQuestionsResult") ?? new List<CorrectAnswerEditModel>();

            ViewBag.TotalMarks = totalMarks;
            if (questionIndex > questions.Count - 1)
            {
                return RedirectToAction("TestPassed", new { totalMarks, rememberPreviousQuestionResult });
            }

            _httpContextAccessor.HttpContext.Session.Set("ListOfQuestionsResult", rememberPreviousQuestionResult);

            var testTitle = _serviceManager.Tests.GetTestById(testId).Name;
            var currentQuestion = questions[questionIndex];
            ViewBag.testId = testId;
            ViewBag.Questions = questions;
            ViewBag.CurrentQuestion = questionIndex + 1;
            ViewBag.QuestionIndex = questionIndex;
            ViewBag.TestTitle = testTitle;

            return View(currentQuestion);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public RedirectToActionResult TestPassingAct(int testId, int questionId, int answerId, int questionIndex, int totalMarks, TestPassingActions actionType/*, List<CorrectAnswerEditModel> rememberPreviousQuestionResult*/)
        {
            var rememberPreviousQuestionResult = _httpContextAccessor.HttpContext.Session.Get<List<CorrectAnswerEditModel>>("ListOfQuestionsResult");
            switch (actionType)
            {
                case TestPassingActions.NextQuestion:
                    bool correct = _serviceManager.CorrectAnswers.GetCorrectPropertyByQuestionAndAnswerIds(questionId, answerId);
                    totalMarks = correct ? totalMarks + 1 : totalMarks;
                    rememberPreviousQuestionResult.Add(new CorrectAnswerEditModel() { TestId = testId, QuestionId = questionId, AnswerId = answerId, Correct = correct });
                    _httpContextAccessor.HttpContext.Session.Set("ListOfQuestionsResult", rememberPreviousQuestionResult);
                    questionIndex++;
                    break;
                default:
                    //Maybe use in future
                    break;
            }
            return RedirectToAction("TestPassing", new { testId, questionIndex, totalMarks });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult BeginTestPassing(int testId, string title)
        {
            ViewBag.testId = testId;
            ViewBag.Title = title;
            TestViewModel model = _serviceManager.Tests.GetTestById(testId);
            return View(model);
        }

        [HttpGet]
        [Route("/Allow/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Allow(int id)
        {
            ViewBag.testId = id;
            return PartialView("_AllowStudentPartial");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Allow(int testId, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            _serviceManager.UserTestAccess.SetAllow(testId, user.Id);
            return RedirectToAction("MyTests");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public RedirectToActionResult CreateTest(TestEditModel _model)
        {
            string adminName = User.Identity.Name;
            int testId = _serviceManager.Tests.SetTestEditModelIntoDb(_model, adminName);
            return RedirectToAction("StartCreateQuestion", new { testId });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult StartCreateQuestion(int testId)
        {
            ViewBag.testId = testId;
            var _Model = new QuestionEditModel();
            return View(_Model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult StartCreateQuestion(int testId, QuestionEditModel _model, Actions actionType, int removingAnswerId)
        {
            ViewBag.testId = testId;
            _model.Id = testId;
            switch (actionType)
            {
                case Actions.MoreQuestion:
                    _serviceManager.Questions.SaveQuestionEditModelIntoDb(_model);
                    _model = new QuestionEditModel();
                    ModelState.Clear();
                    break;
                case Actions.MoreAnswer:
                    _model.AnswerEditModels.Add(new AnswerEditModel());
                    break;
                case Actions.RemoveAnswer:
                    AnswerEditModel _answerToDelete = _model.AnswerEditModels[removingAnswerId];
                    if (_model.AnswerEditModels.Count > 1)
                    {
                        _model.AnswerEditModels.Remove(_answerToDelete);
                        ModelState.Clear();
                    }
                    break;
                case Actions.End:
                    _serviceManager.Questions.SaveQuestionEditModelIntoDb(_model);
                    return RedirectToAction("EndCreating", new { testId });
                    break;
                default:
                    break;
            }
            return View(_model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EndCreating(int testId)
        {
            return View();
        }
    }
}
