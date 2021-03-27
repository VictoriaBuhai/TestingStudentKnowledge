using System.Collections.Generic;
using TestingStudentKnowledgeDomain.Models.Other;

namespace TestingStudentKnowledgeDomain.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<Test> Tests { get; set; }
    }
}