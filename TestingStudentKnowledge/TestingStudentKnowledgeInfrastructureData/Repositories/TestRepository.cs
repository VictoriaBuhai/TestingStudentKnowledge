//using System;
//using System.Collections.Generic;
//using TestingStudentKnowledgeDomain.Interfaces;
//using TestingStudentKnowledgeDomain.Models.Other;
//using TestingStudentKnowledgeInfrastructureData.Data;

//namespace TestingStudentKnowledgeInfrastructureData.Repositories
//{
//    public class TestRepository : ITestRepository
//    {
//        public TestingStudentKnowledgeDbContext _context;

//        public TestRepository(TestingStudentKnowledgeDbContext context)
//        {
//            _context = context;
//        }

//        public IEnumerable<Test> GetTests()
//        {
//            return _context.Tests;
//        }
//    }
//}