using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SystemOfTestKnowledge.Models;
using SystemOfTestKnowledge.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SystemOfTestKnowledge.Controllers
{
    public class QuestionController : Controller
    {
        private SystemContext _context;
        public QuestionController(SystemContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult EditQuestion(EditQuestionViewModel model)
        {
            TestingQuestion question = new TestingQuestion
            {
                Id = model.Id,
                TestId = model.TestId,
                CorrectAnswer = model.CorrectAnswer,
                Text = model.Title,
                AnswerOptions = model.AnswerOptions
            };
            var currentQuestion = _context.Questions.Find(model.Id);
            _context.Questions.Remove(currentQuestion);
            _context.Questions.Add(question);
            _context.SaveChanges();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditQuestion(string id)
        {
            EditQuestionViewModel model = new EditQuestionViewModel();
            var currentQuestion = _context.Questions.Where(q => q.Id == Convert.ToInt32(id)).First();
            model.AnswerOptions = currentQuestion.AnswerOptions;
            model.CorrectAnswer = currentQuestion.CorrectAnswer;
            model.Title = currentQuestion.Text;
            model.Id = currentQuestion.Id;
            model.TestId = currentQuestion.TestId;
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddQuestion(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddQuestion(CreateQuestionViewModel model)
        {
            var question = new TestingQuestion
            {
                Text = model.Text,
                AnswerOptions = model.AnswerOption,
                CorrectAnswer = model.CorrectAnswer,
                TestId = model.TestId
            };
            _context.Questions.Add(question);
            _context.SaveChanges();

            return RedirectToRoute("testlist");
        }
    }
}
