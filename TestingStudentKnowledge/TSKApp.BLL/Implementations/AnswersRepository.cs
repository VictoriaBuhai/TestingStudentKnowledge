using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;

namespace TSKApp.BLL.Implementations
{
    public class AnswersRepository: IAnswersRepository
    {
        private readonly TSKDbContext _context;
        public AnswersRepository(TSKDbContext context)
        {
            _context = context;
        }
    }
}
