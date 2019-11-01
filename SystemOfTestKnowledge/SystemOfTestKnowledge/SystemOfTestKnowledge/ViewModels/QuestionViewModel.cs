using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOfTestKnowledge.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public string AnswerOptions { get; set; }
        public int TestId { get; set; }
        public int Index { get; set; }
        public string CurrentAnswer { get; set; }
    }
}
