using System;
using System.Collections.Generic;
using System.Linq;
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

        public string GetIdByName(string Name)
        {
            return _context.Users.Where(x => x.UserName == Name).FirstOrDefault().Id.ToString();
        }

        public void GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
