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
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Ivan",
                        Surname = "Ivanov",
                        Age = 35,
                        Email = "ivanov@mail.ru",
                        Password = "12345678",
                        Permission = "SimpleUser"
                    },
                    new User
                    {
                        Name = "Petr",
                        Surname = "Petrov",
                        Age = 36,
                        Email = "petrov@mail.ru",
                        Password = "12345678",
                        Permission = "SimpleUser"
                    },
                    new User
                    {
                        Name = "Sidor",
                        Surname = "Sidorov",
                        Age = 37,
                        Email = "sidorov@mail.ru",
                        Password = "12345678",
                        Permission = "Admin"
                    }
                );
                context.SaveChanges();
            }
 /*           if (!context.Tests.Any())
            {
                context.Tests.AddRange
                (
                    new Test
                    {
                        Title = "C#",
                        Questions = new List<TestingQuestion>
                        {
                            new TestingQuestion
                            {
                                Text = "Сколько бит в байте?",
                                CorrectAnswer = "8",
                                AnswerOptions = new List<string> { "9", "10", "11", "8"}
                            },
                            new TestingQuestion
                            {
                                Text = "Что выведет на экран этот кусок кода?\n int a = 3, b = 4;\n Console.WriteLine(Math.Pow(a,b))",
                                CorrectAnswer = "81",
                                AnswerOptions = new List<string> { "-1", "81", "64", "7"}
                            }
                        }
                    }
                );
                context.SaveChanges();
            }*/
            if (!context.Questions.Any())
            {
                context.Questions.AddRange
                (
                    new TestingQuestion
                    {
                        Text = "Сколько бит в байте?",
                        CorrectAnswer = "8",
                        AnswerOptions ="9 10 11 8"
                    },
                    new TestingQuestion
                    { 
                        Text = "Что выведет на экран этот кусок кода?\n * \n int a = 3, b = 4;\n Console.WriteLine(Math.Pow(a,b))\n * ",
                        CorrectAnswer = "81",
                        AnswerOptions = "-1 64 81 7"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
