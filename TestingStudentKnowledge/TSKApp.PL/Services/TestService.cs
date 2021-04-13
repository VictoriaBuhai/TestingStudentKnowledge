using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;

namespace TSKApp.PL.Services
{
    class TestService
    {
        private readonly DataManager _dataManager;
        public TestService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
