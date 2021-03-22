using System;
using System.Collections.Generic;
using System.Text;
using TestingStudentKnowledgeDomain.Models.Users;

namespace TestingStudentKnowledgeDomain.Models.Other
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<User> Users { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
