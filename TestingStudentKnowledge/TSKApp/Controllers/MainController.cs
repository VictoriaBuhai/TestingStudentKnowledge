namespace TSKApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TSKApp.BLL;
    using TSKApp.DAL.Models;
    using TSKApp.PL;
    using TSKApp.PL.Models;

    [Authorize(Roles = "Student")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly DataManager _dataManager;
        private readonly ServicesManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public MainController(ILogger<MainController> logger, DataManager dataManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userEmail = User.Identity.Name;
            List<TestViewModel> models = _serviceManager.UserTestAccess.GetAllAllowTestsByUserEmail(userEmail);
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> PersonalInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            var personalInfo = new PersonalInfoViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return View(personalInfo);
        }

        [HttpPost]
        public async Task<IActionResult> PersonalInfo(PersonalInfoViewModel personalInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.FirstName = personalInfoViewModel.FirstName;
                user.LastName = personalInfoViewModel.LastName;
                user.Email = personalInfoViewModel.Email;

                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
