using System.Data.SqlTypes;
using Quiz.Domain.Entity;
using Quiz.Domain.Repository;
using Quiz.Infra.Context;
using Dapper;
using Quiz.Domain.Enum;

namespace Quiz.Infra.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly DataContext _context;

    public QuestionRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        try
        {
            string sql = @"UPDATE
                                tb_questions
                            SET
                                status = @status
                            WHERE
                                id = @id,
                                AND status = @beforeStatus";

            var parms = new 
            {
                id,
                status = StatusEnum.Inactive,
                beforeStatus = StatusEnum.Active
            };

            await _context._connection.ExecuteAsync(sql, parms);
        }
        catch (Exception ex)
        {
            throw new SqlTypeException(ex.Message);
        }
        finally
        {
            _context.DisposeAsync();
        }
    }

    public async Task<List<Questions>> Get(int id_quiz)
    {
        try
        {
            string sql = @"SELECT
                                question
                            FROM
                                tb_questions
                            WHERE
                                id = @id,
                                AND status = @beforeStatus";

            var parms = new 
            {
                id = id_quiz,
                beforeStatus = StatusEnum.Active
            };

            var result = await _context._connection.QueryAsync<Questions>(sql, parms);

            return result.ToList();
        }
        catch (Exception ex)
        {
            throw new SqlTypeException(ex.Message);
        }
        finally
        {
            _context.DisposeAsync();
        }
    }

    public async Task<Questions> Insert(Questions questions)
    {
        try
        {
            string sql = @"INSERT 
                                INTO
                                    tb_questions
                                    (
                                        questions,
                                        fk_id_quiz
                                    ) VALUES
                                    (
                                        @questions,
                                        @fk_id_quiz
                                    )
                                RETURNING 
                                    tb_questions.*";

            var parms = new 
            {
                questions = questions.Question,
                fk_id_quiz = questions.Fk_id_quiz
            };

            return await _context._connection.QueryFirstOrDefaultAsync<Questions>(sql, parms);
        }
        catch (Exception ex)
        {
            throw new SqlTypeException(ex.Message);
        }
        finally
        {
            _context.DisposeAsync();
        }
    }
}