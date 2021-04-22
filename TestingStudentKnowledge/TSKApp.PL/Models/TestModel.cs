using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSKApp.PL.Models
{
    public class TestViewModel
    {
    }
    public class TestEditModel
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        [Required]
        [DefaultValue("")]
        public string Title { get; set; }
        [DefaultValue(null)]
        public int TimeStamp { get; set; }
    }
}
