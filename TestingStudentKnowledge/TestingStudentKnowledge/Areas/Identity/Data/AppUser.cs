﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TestingStudentKnowledge.Areas.Identity
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvchar(100)")]
        public string FirstName 
        {
            get;
            set;
        }

        [PersonalData]
        [Column(TypeName = "nvchar(100)")]
        public string LastName
        {
            get;
            set;
        }
    }
}
