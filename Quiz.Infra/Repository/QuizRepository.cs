using Dapper;
using Quiz.Domain.DTO;
using Quiz.Domain.Enum;
using Quiz.Domain.Repository;
using Quiz.Infra.Context;
using System.Data.SqlTypes;

namespace Quiz.Infra.Repository;

public class QuizRepository : IQuizRepository
{
    private readonly DataContext _context;

    public QuizRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public async Task Delete(int id)
    {
        try
        {
            string sql = @"UPDATE
                                tb_quiz
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

    public async Task<QuizDTO> Get(int id)
    {
        //TODO: take questions
        try
        {
            string sql = @"SELECT
                                qz.*,
                                tqz.type,
                                tqz.level
                            FROM
                                tb_quiz qz
                                INNER JOIN tb_type_quiz tqz ON tqz.id = qz.fk_id_type_quiz
                            WHERE
                                qz.id = @id,
                                AND qz.status = @beforeStatus";

            var parms = new
            {
                id,
                beforeStatus = StatusEnum.Active
            };

            var result = await _context._connection.QueryFirstAsync<QuizDTO>(sql, parms);

            return result;
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

    public async Task<IList<QuizDTO>> GetAll()
    {
        try
        {
            string sql = @"SELECT
                                qz.*,
                                tqz.type,
                                tqz.level
                            FROM
                                tb_quiz qz
                                INNER JOIN tb_type_quiz tqz ON tqz.id = qz.fk_id_type_quiz
                            WHERE
                                qz.status = @beforeStatus";

            var parms = new
            {
                beforeStatus = StatusEnum.Active
            };

            var result = await _context._connection.QueryAsync<QuizDTO>(sql, parms);

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

    public async Task<IList<QuizDTO>> GetByType(int id)
    {
        try
        {
            string sql = @"SELECT
                            qz.*,
                            tqz.type,
                            tqz.level
                        FROM
                            tb_quiz qz
                            INNER JOIN tb_type_quiz tqz ON tqz.id = qz.fk_id_type_quiz
                        WHERE
                            tqz.id = @id,
                            AND qz.status = @beforeStatus";

            var parms = new
            {
                id,
                beforeStatus = StatusEnum.Active
            };

            var result = await _context._connection.QueryAsync<QuizDTO>(sql, parms);

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

    public async Task Insert(Domain.Entity.Quiz quiz)
    {
        try
        {
            string sql = @"INSERT 
                                INTO
                                    tb_quiz
                                    (
                                        name,
                                        fk_id_type_quiz
                                    ) VALUES
                                    (
                                        @name,
                                        @fk_id_type_quiz
                                    )
                                RETURNING 
                                    tb_quiz.*";

            var parms = new
            {
                name = quiz.Name,
                fk_id_type_quiz = quiz.Fk_id_type_quiz
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

    public Task<List<Domain.Entity.Quiz>> Search(string search)
    {
        throw new NotImplementedException();
    }

    public Task Update(Domain.Entity.Quiz quiz)
    {
        throw new NotImplementedException();
    }
}
