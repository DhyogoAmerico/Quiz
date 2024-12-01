using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz.Domain.Entity;

namespace Quiz.Domain.DTO
{
    public class QuestionDTO : Questions
    {
        public List<AnswerOptions>? ListAnswwer { get; set; }
    }
}