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
        public ActionResult Edit()
        {
            TasksEditVM model = new TasksEditVM();
           TryUpdateModel(model);

            Task task;

            if (model.ID==0)
            {
                task = new Task();
            }
            else
            {
                task = new TasksRepository().GetByID(model.ID);
            }            

            task.ID = model.ID;
            task.Caption = model.Caption;
            task.Body = model.Body;
            task.Date = model.Date;
            task.Time = model.Time;

            new TasksRepository().Save(task);

            return RedirectToAction("List");
            
        }

        
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

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                new TasksRepository().Delete(id.Value);                
            }

            return RedirectToAction("List");
        }
	}
}