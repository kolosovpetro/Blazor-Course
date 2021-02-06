using System;
using System.Data;
using Npgsql;

namespace ProblemBasedCase5.Data
{
    public class PostgresContext
    {
	    private static readonly string ConnectionString 
		    = Environment.GetEnvironmentVariable("BLAZOR_CONN_STR");

        private DataTable DataTable { get; } = new DataTable();

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

        public static void DeleteTask(long id)
        {
            var sql = $"DELETE FROM task WHERE task_id = {id}";
            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            var command = new NpgsqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        public static void Insert(TaskModel task)
        {
            var sql = "INSERT INTO task(" +
                      "taskname," +
                      "supervisor," +
                      "email_supervisor," +
                      "responsible," +
                      "email_responsible," +
                      "created_on," +
                      "deadline," +
                      "first_delivaring," +
                      "first_revising," +
                      "estimate_hours," +
                      "effective_hours," +
                      "status) " +
                      "VALUES(" +
                      $"'{task.TaskName}'," +
                      $"'{task.Supervisor}'," +
                      $"'{task.EmailSupervisor}'," +
                      $"'{task.Responsible}'," +
                      $"'{task.EmailResponsible}'," +
                      $"'{task.CreatedOn:yyyy-MM-dd HH:mm:ss}'," +
                      $"'{task.Deadline:yyyy-MM-dd HH:mm:ss}'," +
                      $"'{task.FirstDelivering:yyyy-MM-dd HH:mm:ss}'," +
                      $"'{task.FirstRevising:yyyy-MM-dd HH:mm:ss}'," +
                      $"{task.EstimateHours}," +
                      $"{task.EffectiveHours}," +
                      $"'{task.Status}');";

            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            var command = new NpgsqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }
        
        public static void Update(TaskModel task)
        {
            var sql = @$"UPDATE task 
                        SET
	                    taskname = '{task.TaskName}',
	                    supervisor = '{task.Supervisor}',
	                    email_supervisor = '{task.EmailSupervisor}',
	                    responsible = '{task.Responsible}',
	                    email_responsible = '{task.EmailResponsible}',
	                    created_on = '{task.CreatedOn:yyyy-MM-dd HH:mm:ss}',
	                    deadline = '{task.Deadline:yyyy-MM-dd HH:mm:ss}',
	                    first_delivaring = '{task.FirstDelivering:yyyy-MM-dd HH:mm:ss}',
	                    first_revising = '{task.FirstRevising:yyyy-MM-dd HH:mm:ss}',
	                    estimate_hours = {task.EstimateHours},
	                    effective_hours = {task.EffectiveHours},
	                    status = '{task.Status}'
                        WHERE task_id = {task.TaskId}";

            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            var command = new NpgsqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }
    }
}