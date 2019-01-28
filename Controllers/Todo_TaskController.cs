using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GU.Models;
using GU.Data;
using Microsoft.Extensions.Configuration;
using GU.Class;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GU.Controllers
{
    public class Todo_TaskController : Controller
    {
        
        
        private readonly GU_DB _context;
        private ClassResource _CLSR;
        private IConfiguration _iconfiguration;
        private readonly String _Module = "Todo_Task";

        public Todo_TaskController(GU_DB context, IConfiguration configuration)
        {
            _context = context;
            _iconfiguration = configuration;
            _CLSR = new ClassResource(_context, configuration);

        }

        
        public IActionResult Remove_Task(int id)
        {
            string user_id_string = HttpContext.Session.GetString("User_ID");
            int user_id;

            var test_push = 0;
            var test_visual_studio_push = true;

            if (user_id_string != null)
            {
                try
                {
                    user_id = Convert.ToInt32(user_id_string);
                }
                catch
                {
                    user_id = 0;
                    return RedirectToAction("Index", "Home");
                }

                var task = _context.ToDo_Task.Where(i => i.Task_ID == id).SingleOrDefault();
                _context.Remove(task);
                _context.SaveChangesAsync();

                return RedirectToAction("Add_Task", "Todo_Task");

                //using (IDbContextTransaction dbTran = _context.Database.BeginTransaction())
                //{

                //    try
                //    {
                //        var task = _context.ToDo_Task.Where(i => i.Task_ID == id).SingleOrDefault();
                //        _context.Remove(task);
                //        _context.SaveChangesAsync();

                //        dbTran.Commit();
                //    }
                //    catch(Exception ex)
                //    {
                //        var message = ex.Message;
                //    }



                //    return RedirectToAction("Add_Task","Todo_Task");

                //}





            }
            else
            {
                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Warning", "You have not login yet.", "", "D");
                return RedirectToAction("Index", "Home");
            }


        }


        
        public IActionResult Add_Task()
        {
            string user_id_string = HttpContext.Session.GetString("User_ID");
            int user_id;

            if (user_id_string != null)
            {
                try
                {
                    user_id = Convert.ToInt32(user_id_string);
                }
                catch
                {
                    user_id = 0;
                    return RedirectToAction("Index", "Home");
                }

                List<SelectListItem> Task_ID = new SelectList(_context.ToDo_Task.Where(c => c.User_ID == user_id && c.Task_Status == "Y" && c.Task_Parent_ID == 0 && c.Task_isComplete == "N"), "Task_ID", "Task_Name").ToList();
                Task_ID.Insert(0, (new SelectListItem { Text = "You can select parent task to add subtask.", Value = "0" }));
                ViewData["Task_ID"] = Task_ID;


                var task = _context.ToDo_Task.Where(i => i.User_ID == user_id && i.Task_Parent_ID == 0);




                return View(task.ToList());
            }
            else
            {
                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Warning", "You have not login yet.", "", "D");
                return RedirectToAction("Index", "Home");
            }

           
        }

        //public ActionResult GetTaskList()
        //{

        //    string user_id_string = HttpContext.Session.GetString("User_ID");
        //    int user_id;

        //    try
        //    {
        //        user_id = Convert.ToInt32(user_id_string);
        //    }
        //    catch
        //    {
        //        user_id = 0;
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var user_task = _context.ToDo_Task.Where(i=>i.User_ID == user_id).ToList<ToDo_Task>();

        //    return Json(new { data = user_task });

        //}


        [HttpPost]
        //public ActionResult Add(string Task_Name, string Task_Due_Date, string Task_Due_Time, string Task_Description)
        public ActionResult Add([Bind("Task_ID, Task_Parent_ID, User_ID, Task_Name, Task_Due_Date, Task_Due_Time, Task_Description, Task_isFocus, Task_Create_Date, Task_Update_Date, Task_Status, Task_isComplete")] ToDo_Task ToDo_Task)
        {

            var returnData = "NOT";

            string user_id_string = HttpContext.Session.GetString("User_ID");
            int user_id;

            if (user_id_string == null)
            {
                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Warning", "You have not login yet.", "", "D");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    user_id = Convert.ToInt32(user_id_string);
                }
                catch
                {
                    user_id = 0;
                    return RedirectToAction("Index", "Home");
                }


                String cDate = _CLSR.GetDateNow("");
                String cTime = _CLSR.GetTimeNow("");



                ToDo_Task.User_ID = user_id;
                ToDo_Task.Task_Create_Date = cDate;
                ToDo_Task.Task_Update_Date = cDate;
                ToDo_Task.Task_isComplete = "N";
                ToDo_Task.Task_isFail = "N";
                

                ToDo_Task.Task_Due_Date = _CLSR.ConvertDatePicker(ToDo_Task.Task_Due_Date);
                ToDo_Task.Task_Due_Time = _CLSR.ConvertTimePicker(ToDo_Task.Task_Due_Time, ":");
                ToDo_Task.Task_isFocus = 0;
                ToDo_Task.Task_Status = "Y";




                _context.Add(ToDo_Task);
                _context.SaveChanges();

                returnData = "SUCCESS";

                return Json(returnData);
            }

        }



        
        //public ActionResult Add(string Task_Name, string Task_Due_Date, string Task_Due_Time, string Task_Description)
        public IActionResult Checked_Task(int id,[Bind("Task_ID, Task_Parent_ID, User_ID, Task_Name, Task_Due_Date, Task_Due_Time, Task_Description, Task_isFocus, Task_Create_Date, Task_Update_Date, Task_Status, Task_isComplete")] ToDo_Task ToDo_Task)
        {

            

            string user_id_string = HttpContext.Session.GetString("User_ID");
            int user_id;

            if (user_id_string == null)
            {
                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Warning", "You have not login yet.", "", "D");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    user_id = Convert.ToInt32(user_id_string);
                }
                catch
                {
                    user_id = 0;
                    return RedirectToAction("Index", "Home");
                }

                var todo_task = _context.ToDo_Task.Where(i => i.Task_ID == id).FirstOrDefault();

                String cDate = _CLSR.GetDateNow("");
                String cTime = _CLSR.GetTimeNow("");

                todo_task.Task_isComplete = "Y";
                

                _context.Update(todo_task);
                _context.SaveChanges();








                return RedirectToAction("Add_Task", "Todo_Task");
            }

        }
    }

}