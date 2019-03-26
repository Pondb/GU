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

namespace GU.Controllers
{
    public class HomeController : Controller
    {
        private readonly GU_DB _context;
        private ClassResource _CLSR;
        private readonly String _Module = "Home";

        public HomeController(GU_DB context, IConfiguration configuration)
        {
            _context = context;
            _CLSR = new ClassResource(_context, configuration);

        }

        //SET SESSION (KEY,Value)
        //HttpContext.Session.SetString("userid", user.userid.ToString());

        
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");




        }

       
        

        [HttpPost]
        public ActionResult auth_login(string email, string password)
        {

            

            var user = _context.User.Where(i => i.Email == email).SingleOrDefault();
            var returnData = "";

            if (user != null)
            {
                if (password != null)
                {
                    password = _CLSR.EncodeHMAC_SHA512(password);

                    //Login success
                    if (email.Equals(user.Email) && password.Equals(user.Password) && user.Wrong_Password_Count < 5 && user.User_Status == "Y" && user.User_isLock == "N")
                    {

                        returnData = "AUTH_PASS";
                        Login(email, password);


                    }
                    //Email==Email, Pass== Pass but Account locked
                    else if (email.Equals(user.Email) && password.Equals(user.Password) && user.Wrong_Password_Count >= 5)
                    {
                        returnData = "AUTH_LOCK";
                        using (IDbContextTransaction dbTran = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                user.User_Status = "N";
                                user.User_isLock = "Y";

                                _context.Update(user);
                                _context.SaveChanges();

                                dbTran.Commit();
                            }
                            catch (Exception e)
                            {
                                TempData["msg"] = _CLSR.GetAlert("Error: " + e.Message);
                                return RedirectToAction("Index", "Home");
                            }
                        }

                    }
                    //Email == email but Pass is not and password count 5+
                    else if (email.Equals(user.Email) && password != user.Password && user.Wrong_Password_Count >= 5)
                    {
                        returnData = "AUTH_LOCK";
                    }
                    //Email != email, Pass != pass
                    else
                    {
                        returnData = "AUTH_NOT";
                        using (IDbContextTransaction dbTran = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                user.Wrong_Password_Count = user.Wrong_Password_Count + 1;

                                _context.Update(user);
                                _context.SaveChanges();

                                dbTran.Commit();
                            }
                            catch (Exception e)
                            {
                                TempData["msg"] = _CLSR.GetAlert("Error: " + e.Message);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
                else
                {



                }
                

                
            }
            else
            {
                returnData = "USER_NOT_FOUND";
            }

            return Json(returnData);
        }



        [HttpPost]
        public IActionResult Login(string input_Email, string input_Password)
        {
            String cDate = _CLSR.GetDateNow("");
            String cTime = _CLSR.GetTimeNow("");


            var user = _context.User.Where(i => i.Email == input_Email).SingleOrDefault();

            if (user != null)
            {
                //found user in db.

                //check password.
                if (input_Email.Equals(user.Email) && input_Password.Equals(user.Password))
                {
                    HttpContext.Session.SetString("User_ID", user.User_ID.ToString());

                    user.Last_Login = cDate;

                    _context.Update(user);
                    _context.SaveChanges();

                    string user_id_string = HttpContext.Session.GetString("User_ID");
                    int user_id;

                    try
                    {
                        user_id = Convert.ToInt32(user_id_string);
                    }
                    catch
                    {
                        user_id = 0;
                    }

                    _CLSR.CheckTaskDueDate(user_id, 20);

                    ViewData["isLogIn"] = 1;
                    //TempData["msg"] = _CLSR.GetScriptAlertPopUp("Success", "Login Successfully!", "", "S");
                    return RedirectToAction("Add_Task", "Todo_Task");
                }
                else
                {
                    TempData["msg"] = _CLSR.GetScriptAlertPopUp("Invalid", "Invalid Email or Password", "", "E");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {

                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Invalid", "Invalid Email or Password", "", "E");
                return RedirectToAction("Index", "Home");
            }


        }


        public IActionResult Index()
        {

            string user_id = HttpContext.Session.GetString("User_ID");
            int user_id_int = Convert.ToInt32(user_id);

            String cDate = _CLSR.GetDateNow("");
            String cTime = _CLSR.GetTimeNow("");

            if (user_id != null)
            {
                ViewData["isLogIn"] = 1;

                

            }
            else
            {
                ViewData["isLogIn"] = 0;
            }

            


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            //TempData["alert_msg"] = _CLSR.GetAlertBar("TEST", "This is my Text", "success");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
