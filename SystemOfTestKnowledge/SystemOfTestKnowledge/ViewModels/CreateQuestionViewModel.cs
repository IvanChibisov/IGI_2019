using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOfTestKnowledge.ViewModels
{
    public class CreateQuestionViewModel
    {
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public string AnswerOption { get; set; }
        public int TestId { get; set; }
    }
}
