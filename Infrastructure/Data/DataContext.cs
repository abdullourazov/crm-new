using Npgsql;

namespace Infrastructure;

public class DataContext
{
    private const string ConnectionString = "Server=localhost; Database=crm; User Id=postgres; Password=35709120;";
    public Task<NpgsqlConnection> GetConnection()
    {
        return Task.FromResult(new NpgsqlConnection(ConnectionString));
    }
}
