using System;
using System.Collections.Generic;
using System.Text;

namespace TSKApp.DAL.Models
{
    public class UserTestAccess
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}
