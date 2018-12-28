using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApp.Entities
{
    public class Answer : BaseModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        public string Text { get; set; }
    }
}