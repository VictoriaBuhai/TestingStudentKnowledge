using System;
using System.Collections.Generic;
using System.Text;

namespace TestingStudentKnowledgeDomain.Models.Other
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public List<Question> Questions { get; set; }
    }
}
