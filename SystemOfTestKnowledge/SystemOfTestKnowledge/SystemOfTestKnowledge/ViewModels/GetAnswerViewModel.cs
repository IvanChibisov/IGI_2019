using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOfTestKnowledge.ViewModels
{
    public class GetAnswerViewModel
    {
        public int QuestionId { get; set; }
        public bool result { get; set; }
        public string User { get; set; }
        public int TestId { get; set; }
    }
}
