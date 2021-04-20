using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface IUserTestAccessRepository
    {
        List<UserTestAccess> GetAllByUserId(int Id);
        void SetUserTest(UserTestAccess userTestAccess);
    }
}
