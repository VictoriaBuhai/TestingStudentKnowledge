using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;

namespace TSKApp.BLL.Implementations
{
    public class CorrectAnswerRepository: ICorrectAnswerRepository
    {
        private readonly TSKDbContext _context;
        public CorrectAnswerRepository(TSKDbContext context)
        {
            _context = context;
        }
    }
}
