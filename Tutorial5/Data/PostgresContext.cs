using System;
using System.Data;
using Npgsql;

namespace Tutorial5.Data
{
    public class PostgresContext
    {
        private static readonly string ConnectionString 
            = Environment.GetEnvironmentVariable("BLAZOR_CONN_STR");

        private DataTable DataTable { get; set; } = new DataTable();

        public DataTable GetAllTasks()
        {
            DataTable?.Clear();
            const string sql = @"SELECT task_id, taskname, supervisor, email_supervisor,
										responsible, email_responsible, created_on, deadline,
	                                    first_delivaring, first_revising, estimate_hours, effective_hours,
	                                    status FROM task;";
            
            using var dataAdapter = new NpgsqlDataAdapter(sql, ConnectionString);
            dataAdapter.Fill(DataTable!);
            return DataTable;
        }
    }
}