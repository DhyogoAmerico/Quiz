using System.Data.SqlTypes;
using Quiz.Domain.Entity;
using Quiz.Domain.Repository;
using Quiz.Infra.Context;
using Quiz.Domain.Enum;
using Dapper;

namespace Quiz.Infra.Repository;

public class AnswerOptionRepository : IAnswerOptionRepository
{
    private readonly DataContext _context;

    public AnswerOptionRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> GetCorrect(int id_answer)
    {
        try
        {
            string sql = @"SELECT
                                    correct
                                FROM
                                    tb_answer_options
                                WHERE
                                    id = @id
                                    AND status = @status";

            var parms = new
            {
                id = id_answer,
                status = StatusEnum.Active
            };

            return await _context._connection.QueryFirstAsync<bool>(sql, parms);
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

    public async Task<List<AnswerOptions>> GetOptions(int id_question)
    {
        try
        {
            string sql = @"SELECT
                                    correct,
                                    answer
                                FROM
                                    tb_answer_options
                                WHERE
                                    fk_id_question = @id_question
                                    AND status = @status";

            var parms = new
            {
                id_question,
                status = StatusEnum.Active
            };

            var result = await _context._connection.QueryAsync<AnswerOptions>(sql, parms);

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
}