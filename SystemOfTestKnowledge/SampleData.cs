using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemOfTestKnowledge.Models;

namespace SystemOfTestKnowledge
{
    public class SampleData
    {
        public static void Initialize(SystemContext context)
        {
            
            if (!context.Questions.Any())
            {
                context.Questions.AddRange
                    (
                        new TestingQuestion
                        {
                            Text = "Сколько бит в байте?",
                            CorrectAnswer = "8",
                            AnswerOptions = "9 10 11 8",
                            TestId = 1
                        },
                        new TestingQuestion
                        {
                            Text = "Что выведет на экран этот кусок кода?\n * \n int a = 3, b = 4;\n Console.WriteLine(Math.Pow(a,b))\n * ",
                            CorrectAnswer = "81",
                            AnswerOptions = "-1 64 81 7",
                            TestId = 1
                        }
                    );
                context.SaveChanges();
            }
            if (!context.TestTable.Any())
            {
                context.TestTable.AddRange
                (
                    new Test
                    {
                        Title = "Тест по основам C#",
                        Id = 1,
                        KnowledgeArea = "C#"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
