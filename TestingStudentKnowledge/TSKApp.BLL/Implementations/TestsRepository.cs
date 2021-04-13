using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;

namespace TSKApp.BLL.Implementations
{
    public class TestsRepository: ITestsRepository
    {
        private readonly TSKDbContext _context;
        public TestsRepository(TSKDbContext context)
        {
            _context = context;
        }
    }
}
