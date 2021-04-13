using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;

namespace TSKApp.PL.Services
{
    class QuestionService
    {
        private readonly DataManager _dataManager;
        public QuestionService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
