
using System.Data;
using Npgsql;
using Quiz.Domain.DTO;

namespace Quiz.Infra.Context;

public class DataContext
{
    public readonly NpgsqlConnection _connection;
    private readonly NpgsqlTransaction _transaction;
    private readonly Configuration _configuration;
    public DataContext(Configuration configuration)
    {
        _configuration = configuration;
        _connection = new NpgsqlConnection(_configuration.ConnectionString);
        OpenConnection();

        _transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);
    }

    private async void OpenConnection()
    {
        await _connection.OpenAsync();
    }

    public async void RollbackDataBase()
    {
        await _transaction.RollbackAsync();
        await _connection.CloseAsync();
    }

    public async void DisposeAsync()
    {
        await _transaction.CommitAsync();
        await _connection.CloseAsync();
    }
}