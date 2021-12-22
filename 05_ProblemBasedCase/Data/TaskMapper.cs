using System;
using System.Collections.Generic;
using System.Data;

namespace ProblemBasedCase5.Data
{
    public static class TaskMapper
    {
        public static IEnumerable<TaskModel> Map(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                yield return null;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                var statusParsed = Enum.TryParse(row["status"].ToString(), out TaskStatus status);
                yield return new TaskModel
                {
                    TaskId = long.Parse(row["task_id"].ToString() ?? "0"),
                    TaskName = row["taskname"].ToString(),
                    Supervisor = row["supervisor"].ToString(),
                    EmailSupervisor = row["email_supervisor"].ToString(),
                    Responsible = row["responsible"].ToString(),
                    EmailResponsible = row["email_responsible"].ToString(),
                    CreatedOn = DateTime.Parse(row["created_on"].ToString()!),
                    Deadline = DateTime.Parse(row["deadline"].ToString()!),
                    FirstDelivering = DateTime.Parse(row["first_delivaring"].ToString()!),
                    FirstRevising = DateTime.Parse(row["first_revising"].ToString()!),
                    EstimateHours = int.Parse(row["estimate_hours"].ToString() ?? "0"),
                    EffectiveHours = int.Parse(row["effective_hours"].ToString() ?? "0"),
                    Status = statusParsed ? status : TaskStatus.Running,
                };
            }
        }
    }
}