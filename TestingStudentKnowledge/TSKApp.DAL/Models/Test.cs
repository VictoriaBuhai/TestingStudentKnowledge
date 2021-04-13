using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSKApp.DAL.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int timeLimit { get; set; }
        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<Question> Questions { get; set; }
    }
}
