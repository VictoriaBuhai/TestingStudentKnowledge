using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;

namespace TSKApp.PL.Services
{
    class UserService
    {
        private readonly DataManager _dataManager;
        public UserService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
