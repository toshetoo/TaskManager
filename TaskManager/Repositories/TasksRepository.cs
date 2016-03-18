using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TasksRepository: BaseRepository<Task>
    {
        public TasksRepository() : base() { }
    }
}