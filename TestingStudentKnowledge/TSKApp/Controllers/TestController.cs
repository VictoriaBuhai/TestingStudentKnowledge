using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSKApp.BLL;
using TSKApp.PL;
using TSKApp.PL.Models;
using static TSKApp.Enums.Helpers;

namespace TSKApp.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly DataManager _dataManager;
        private readonly ServicesManager _serviceManager;
        public TestController(ILogger<TestController> logger, DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateTest()
        {
            return View();
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
        public IActionResult StartCreateQuestion(int testId /*adminName*/)
        {
            ViewBag.testId = testId;
            var _Model = new QuestionEditModel() { };
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
                    _model = new QuestionEditModel() {  };
                    ModelState.Clear();
                    break;
                case Actions.MoreAnswer:
                    _model.AnswerEditModels.Add(new AnswerEditModel() { });
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
