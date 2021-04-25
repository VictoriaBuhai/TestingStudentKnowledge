using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;

namespace TSKTests.Mocks
{
    class UsersRepositoryMock : IUsersRepository
    {
        public string GetIdByName(string Name)
        {
            return "";
        }

        public void GetUserById(int userId)
        {
            // do nothing
        }
    }
}
