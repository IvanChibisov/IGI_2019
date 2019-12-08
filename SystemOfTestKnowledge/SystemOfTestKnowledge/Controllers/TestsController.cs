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
    
    public class TestsController: Controller
    {
        private SystemContext _context;
        public TestsController(SystemContext context)
        {
            _context = context;
        }

        public IActionResult TestList()
        {
            return View(_context.TestTable.ToList());
        }

        public IActionResult StartTest(string Id)
        {
            List<TestingQuestion> result = new List<TestingQuestion>();
            foreach (var question in _context.Questions.ToList())
            {
                if (question.TestId.ToString() == Id)
                {
                    result.Add(question);
                }
            }
            return View(result);
        }


        public IActionResult GetAnswer(string id, string answer, string correctAnswer)
        {
            var list = _context.UsersAnswers;
            var users = _context.Users.Where(u => u.Email == User.Identity.Name);
            string userId = "";
            foreach(var el in users)
            {
                userId = el.Id;
            }
            var answers = list.Where(p => p.QuestionId == Convert.ToInt32(id) && p.UserId == userId);
            var question = _context.Questions.Find(Convert.ToInt32(id));
            bool result = answer == correctAnswer;
            int TestId = question.TestId;
            if (answers.Count() != 0)
            {
                var el = answers.First();
                el.IsCorrectAnswer = result;
                _context.Update(el);
                _context.SaveChanges();
            }
            else
            {
                SystemOfTestKnowledge.Models.UsersAnswer ans = new UsersAnswer()
                {
                    IsCorrectAnswer =  result,
                    UserId = userId,
                    QuestionId = Convert.ToInt32(id)
                };
                _context.Add(ans);
                _context.SaveChanges();
            }
            return RedirectToRoute("start_test", new { id = TestId.ToString() });
        }

        public IActionResult EndTest(string Id)
        {
            int test_id = Convert.ToInt32(Id);
            var users = _context.Users.Where(u => u.Email == User.Identity.Name);
            string userId = "";
            foreach (var el in users)
            {
                userId = el.Id;
            }
            var question = _context.Questions.Where(q => q.TestId == test_id);
            int correct = 0, all = 0;
            foreach ( var q in question)
            {
                var this_question = _context.UsersAnswers.Where(p => p.QuestionId == q.Id && p.UserId == userId);
                if (this_question != null)
                {
                    if (this_question.Count() != 0)
                    {

                        if (this_question.First().IsCorrectAnswer == true)
                        {
                            correct++;
                        }
                    }
                }
                all++;
            }
            ResultTestViewModel model = new ResultTestViewModel { CountAllQuestion = all, CountCorrectAnswer = correct };
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public IActionResult QuestionsList(string Id)
        {
            EditTestViewModel model = new EditTestViewModel();
            List<TestingQuestion> questions = new List<TestingQuestion>();
            var currentTest = _context.Questions.Where(q => q.TestId == Convert.ToInt32(Id));
            questions = currentTest.ToList();
            model.TestId = Convert.ToInt32(Id);
            model.Questions = questions;
            return View(model);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult QuestionList()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddTest()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddTest(Test model)
        {
            var test = new Test
            {
                Title = model.Title,
                KnowledgeArea = model.KnowledgeArea
            };
            _context.TestTable.Add(test);
            _context.SaveChanges();
            return RedirectToRoute("testlist");
        }
    }
}
