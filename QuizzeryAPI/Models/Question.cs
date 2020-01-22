using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzeryAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public Answer CorrectAnswer { get; set; }
        public QuestionType QuestionType { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}
