using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemOfTestKnowledge.Models;
using Microsoft.AspNetCore.Mvc;
using SystemOfTestKnowledge.ViewModels;

namespace SystemOfTestKnowledge.Component
{
    public class Question: ViewComponent
    {
        private SystemContext _context;
        public Question(SystemContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int questionId, int _index)
        {
            var item = _context.Questions.Find(questionId);
            QuestionViewModel model = new QuestionViewModel
            {
                Id = item.Id,
                CorrectAnswer = item.CorrectAnswer,
                AnswerOptions = item.AnswerOptions,
                Index = _index,
                TestId = item.TestId,
                Text = item.Text
            };
            return View(model);
        }
    }
}
