using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOfTestKnowledge.Models
{
    public class TestingQuestion
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get;  set; }
        public string AnswerOptions { get; set; }
        public int TestId { get; set; }
    }
}
