using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;

namespace TSKApp.PL.Services
{
    public class CorrectAnswerService
    {
        private readonly DataManager _dataManager;
        public CorrectAnswerService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
