using System.Collections.Generic;
using TestingStudentKnowledgeDomain.Models.Other;

namespace TestingStudentKnowledgeDomain.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetTests();
    }
}