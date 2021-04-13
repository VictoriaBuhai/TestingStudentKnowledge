using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Data;

namespace TSKApp.BLL.Implementations
{
    class CorrectAnswerRepository
    {
        private readonly TSKDbContext _context;
        public CorrectAnswerRepository(TSKDbContext context)
        {
            _context = context;
        }
    }
}
