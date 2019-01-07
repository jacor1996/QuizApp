using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuizApp.Services.Abstract
{
    public interface IAnswerService
    {
        SelectList GetAnswersSelectList();
    }
}
