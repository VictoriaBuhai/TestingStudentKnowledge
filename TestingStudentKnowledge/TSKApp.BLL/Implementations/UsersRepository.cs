using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;

namespace TSKApp.BLL.Implementations
{
    public class UsersRepository: IUsersRepository
    {
        private readonly TSKDbContext _context;
        public UsersRepository(TSKDbContext context)
        {
            _context = context;
        }

        public void GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
