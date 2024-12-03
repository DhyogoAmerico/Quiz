using System.Data.SqlTypes;
using Quiz.Domain.Entity;
using Quiz.Domain.Repository;
using Quiz.Infra.Context;
using Dapper;
using Quiz.Domain.ValueType;

namespace Quiz.Infra.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<User?> Login(string email, string password)
    {
        try
        {
            string sql = @"SELECT
                                    use.name,
                                    use.email
                                FROM
                                    tb_user use
                                WHERE
                                    use.email = @email
                                    AND use.password = @password";

            var parms = new {
                email,
                password = ((Password)password).ToMD5()
            };

            return await _context._connection.QueryFirstOrDefaultAsync<User>(sql, parms);
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

    public async Task Insert(User user)
    {
        try
        {
            string sql = @"INSERT 
                                INTO
                                    tb_user
                                    (
                                        name,
                                        email,
                                        password,
                                        phone,
                                        date_birth,
                                        token
                                    ) VALUES
                                    (
                                        @name,
                                        @email,
                                        @password,
                                        @phone,
                                        @date_birth,
                                        @token
                                    )";

            var parms = new {
                name = user.Name,
                email = user.Email,
                password = user.Password.ToMD5(),
                phone = user.Phone,
                date_birth = user.DateBirth,
                token = user.Token
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
}