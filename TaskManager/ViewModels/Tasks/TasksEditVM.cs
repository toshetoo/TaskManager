using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.ViewModels.Tasks
{
    public class TasksEditVM
    {
        public int ID { get; set; }
        public string Caption { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}