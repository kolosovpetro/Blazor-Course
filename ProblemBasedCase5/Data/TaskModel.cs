﻿using System;

namespace ProblemBasedCase5.Data
{
    public class TaskModel
    {
        public long TaskId { get; set; }
        public string TaskName { get; set; }
        public string Supervisor { get; set; }
        public string EmailSupervisor { get; set; }
        public string Responsible { get; set; }
        public string EmailResponsible { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime FirstDelivering { get; set; }
        public DateTime FirstRevising { get; set; }
        public int EstimateHours { get; set; }
        public int EffectiveHours { get; set; }
        public TaskStatus Status { get; set; }
    }
}