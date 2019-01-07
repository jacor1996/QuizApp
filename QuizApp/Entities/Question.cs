using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApp.Entities
{
    public class Question : BaseModel
    {
        [DisplayName("Question")]
        public string Text { get; set; }

        [Required]
        public Answer CorrectAnswer { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}