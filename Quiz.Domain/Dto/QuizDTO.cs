using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz.Domain.Entity;

namespace Quiz.Domain.DTO
{
    public class QuizDTO: Entity.Quiz
    {
        public List<QuestionDTO>? ListQuestions { get; set; }
    }
}