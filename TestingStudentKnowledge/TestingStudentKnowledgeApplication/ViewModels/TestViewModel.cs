using System;
using System.Collections.Generic;
using System.Text;
using TestingStudentKnowledgeDomain.Models.Other;

namespace TestingStudentKnowledgeApplication.ViewModels
{
    public class TestViewModel
    {
        public IEnumerable<Test> Tests { get; set; }
    }
}
