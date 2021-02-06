using System;
using System.Data;
using Npgsql;

namespace ProblemBasedCase6.Data
{
    public class PostgresContext
    {
        private static readonly string ConnectionString 
            = Environment.GetEnvironmentVariable("BLAZOR_CONN_STR");

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