using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOfTestKnowledge.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> QuestionsId { get; set; }
        public List<TestingQuestion> Questions { get; set; }
    }
}
