using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;

namespace TSKApp.BLL.Implementations
{
    public class QuestionsRepository: IQuestionsRepository
    {
        private readonly TSKDbContext _context;
        public QuestionsRepository(TSKDbContext context)
        {
            _context = context;
        }
    }
}
