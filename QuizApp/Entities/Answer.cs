using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApp.Entities
{
    public class Answer : BaseModel
    {
        [DisplayName("Answer")]
        public string Text { get; set; }
    }
}