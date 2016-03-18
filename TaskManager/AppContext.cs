using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager
{
    public class AppContext: DbContext
    {
        public AppContext(): base("TaskManagerDB") { }

        public DbSet<Task> Tasks { get; set; }
    }
}