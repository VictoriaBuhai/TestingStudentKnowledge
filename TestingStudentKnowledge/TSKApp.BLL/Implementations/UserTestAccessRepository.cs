using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Implementations
{
    public class UserTestAccessRepository : IUserTestAccessRepository
    {
        private readonly TSKDbContext _context;
        public UserTestAccessRepository(TSKDbContext context)
        {
            _context = context;
        }
        public List<UserTestAccess> GetAllByUserId(int Id)
        {
            throw new NotImplementedException();
        }

        public void SetUserTest(UserTestAccess userTestAccess)
        {
            throw new NotImplementedException();
        }
    }
}
