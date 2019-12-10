using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOfTestKnowledge.Models
{
    public class UsersAnswer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
