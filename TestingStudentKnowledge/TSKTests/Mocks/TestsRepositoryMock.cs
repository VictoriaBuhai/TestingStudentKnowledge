using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class TestsRepositoryMock : ITestsRepository
    {
        public List<Test> GetAllTests()
        {
            return new List<Test>();
        }

        public Test GetTestById(int Id)
        {
            return new Test();
        }

        public List<Test> GetTestsByUserId(string Id)
        {
            return new List<Test>();
        }

        public void SetTestIntoDb(Test test)
        {
            // do nothing
        }
    }
}
