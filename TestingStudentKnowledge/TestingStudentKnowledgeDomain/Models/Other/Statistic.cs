using System;
using TestingStudentKnowledgeDomain.Models.Users;

namespace TestingStudentKnowledgeDomain.Models.Other
{
    public class Statistic
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public double Mark { get; set; }
        public DateTime PassDate { get; set; }
    }
}