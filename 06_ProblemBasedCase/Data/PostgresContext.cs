using System.Data;
using Npgsql;

namespace ProblemBasedCase6.Data
{
    public class PostgresContext
    {
        private const string ConnectionString =
            "Server=209.126.96.59;User Id=u107417;Password=DVZ7USF8;Database=adv_prog;";

        private DataTable DataTable { get; } = new DataTable();

        public DataTable GetAllCountries()
        {
            DataTable?.Clear();
            const string sql = @"SELECT * FROM country;";

            using var dataAdapter = new NpgsqlDataAdapter(sql, ConnectionString);
            dataAdapter.Fill(DataTable!);
            return DataTable;
        }
        
        public DataTable GetAllLanguages()
        {
            DataTable?.Clear();
            const string sql = @"SELECT * FROM programming_language;";

            using var dataAdapter = new NpgsqlDataAdapter(sql, ConnectionString);
            dataAdapter.Fill(DataTable!);
            return DataTable;
        }
    }
}