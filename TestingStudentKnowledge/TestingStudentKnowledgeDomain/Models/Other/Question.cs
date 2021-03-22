using System;
using System.Collections.Generic;
using System.Text;

namespace TestingStudentKnowledgeDomain.Models.Other
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Answer> Answers { get; set; }
        public double Points { get; set; }
    }
}
