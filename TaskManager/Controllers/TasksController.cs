using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.ViewModels.Tasks;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        public ActionResult List()
        {
            TasksListVM model = new TasksListVM();
            model.Tasks = new TasksRepository().GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TasksEditVM model)
        {
             
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            TasksEditVM model = new TasksEditVM();
            Task task;

            if (id.HasValue)
            {
                task = new TasksRepository().GetByID(id.Value);
            }
            else
            {
                task = new Task();
            }

            model.ID = task.ID;
            model.Body = task.Body;
            model.Caption = task.Caption;
            model.Date = task.Date;
            model.Time = task.Time;


            return View(model);
        }        
	}
}