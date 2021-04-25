using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;
using TSKApp.PL.Models;

namespace TSKApp.PL.Services
{
    public class TestService
    {
        private readonly IDataManager _dataManager;
        public TestService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public int SetTestEditModelIntoDb(TestEditModel _model, string adminName)
        {
            Test test;
            if (_model.Id != 0)
            {
                test = _dataManager.Tests.GetTestById(_model.Id);
                test.Name = _model.Title;
                test.timeLimit = _model.TimeStamp;
            }
            else
            {
                string userId = _dataManager.Users.GetIdByName(adminName);
                test = new Test()
                {
                    Name = _model.Title,
                    UserId = userId,
                    timeLimit = _model.TimeStamp
                };
            }
            _dataManager.Tests.SetTestIntoDb(test);

            return test.Id;
        }
    }
}
