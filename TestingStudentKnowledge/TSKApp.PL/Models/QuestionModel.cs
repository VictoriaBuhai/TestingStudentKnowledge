using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSKApp.PL.Models
{
    public class QuestionViewModel
    {

    }
    public class QuestionEditModel
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(null)]
        public List<AnswerEditModel> AnswerEditModels { get; set; }
    }
}
