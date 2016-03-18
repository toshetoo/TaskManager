using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.ViewModels.Tasks
{
    public class TasksListVM
    {
        public List<Task> Tasks { get; set; }
    }
}