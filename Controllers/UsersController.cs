using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GU.Data;
using GU.Models;
using GU.Class;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Http;

namespace GU.Controllers
{
    public class UsersController : Controller
    {
        private readonly GU_DB _context;
        private ClassResource _CLSR;
        private readonly String _Module = "Users";

        public UsersController(GU_DB context, IConfiguration configuration)
        {
            _context = context;
            _CLSR = new ClassResource(_context, configuration);

        }



        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        public IActionResult Create()
        {
            return View();
        }



        public ActionResult check_Email(string email)
        {

            var user = _context.User.Where(i => i.Email == email).Count();
            var notiString = "";

            if (user > 0)
            {
                notiString = "HAVE";
            }
            else
            {
                notiString = "NOT";
            }

            return Json(notiString);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            string user_id_string = HttpContext.Session.GetString("User_ID");
            var user_id = 0;

            try
            {
                user_id = Convert.ToInt32(user_id_string);
            }
            catch
            {
                user_id = 0;
            }

            var user = _context.User.Where(i => i.User_ID == user_id).SingleOrDefault();


            return View(user);
        }

        [HttpPost]
        public IActionResult ChangePassword(string Password, string Password2)
        {

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

            //เช็คจากฝั่ง Server ถ้า Password ไม่ตรงกัน
            if (Password != Password2)
            {
                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Error", "Please contact Administrator", "", "E");
                return RedirectToAction("ChangePassword", "Users");
            }
            else
            {
                var user = _context.User.Where(i => i.User_ID == user_id).SingleOrDefault();

                using (IDbContextTransaction dbTran = _context.Database.BeginTransaction())
                {
                    String cDate = _CLSR.GetDateNow("");
                    String cTime = _CLSR.GetTimeNow("");


                    user.Password = Password;
                    user.Last_Update = cDate;




                    _context.Update(user);
                    _context.SaveChanges();

                    //ถ้าบันทึกข้อมูลเสร็จ ให้ Commit เพื่อยืนยันการเซฟข้อมูล
                    dbTran.Commit();

                    //ถ้าไม่สำเร็จให้ RollBack();


                    //Temp Message เพื่อขึ้น Alert ป๊อปอัพแสดง
                    

                    TempData["msg"] = _CLSR.GetScriptAlertPopUp("Success", "Password changed successfully.", "", "D");
                    return RedirectToAction("Index", "Home");
                }


                
            }
            
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_ID,Role_ID,Email,Password,First_Name,Last_Name,Birthdate,Wrong_Password_Count,Last_Login,Last_Update,Gender,User_Status,User_isLock")] User user)
        {
            if (ModelState.IsValid)
            {
                int userID = 1;
                try
                {
                    userID = _context.User.Max(p => p.User_ID) + 1;
                }
                catch
                {
                    //ไม่เจอ ID สักอันแสดงว่า Table นี้ว่างอยู่ให้เริ่มที่ 1
                    userID = 1;
                }

                var checkUserIsAlready = _context.User.Where(i => i.Email == user.Email).Count();

                //Email is already exist!
                if (checkUserIsAlready > 0)
                {
                    TempData["msg"] = _CLSR.GetScriptAlertPopUp("Error", "Please contact Administrator", "", "E");
                    return RedirectToAction("Create", "Users");
                }
                else
                {
                    if (user.Email != null && user.Password != null && user.First_Name != null)
                    {

                        //ควรเปิด Transaction ทุกครั้งที่มีการเปลี่ยนแปลงข้อมูลใน Table
                        using (IDbContextTransaction dbTran = _context.Database.BeginTransaction())
                        {
                            String cDate = _CLSR.GetDateNow("");
                            String cTime = _CLSR.GetTimeNow("");

                            Trees basic_Tree = new Trees();

                            basic_Tree.User_ID = userID;
                            basic_Tree.Tree_Level = 1;
                            basic_Tree.Tree_EXP = 0;
                            basic_Tree.Tree_Type_ID = 1;
                            basic_Tree.Tree_Name = "Basic Tree";
                            basic_Tree.Tree_HP = 100;
                            basic_Tree.Plant_Date = cDate;
                            basic_Tree.Create_Date = cDate;
                            basic_Tree.Update_Date = cDate;
                            basic_Tree.Tree_Status = "S";
                            basic_Tree.Tree_isDead = "N";

                            //ROLE ID 1 คือ Admin
                            //ROLE ID 2 คือ Normal User
                            user.Role_ID = 2;
                            user.Birthdate = _CLSR.ConvertDatePicker(user.Birthdate);
                            user.Wrong_Password_Count = 0;
                            user.Last_Login = cDate;
                            user.Last_Update = cDate;
                            user.User_Status = "Y";
                            user.User_isLock = "N";





                            _context.Add(basic_Tree);
                            _context.Add(user);
                            await _context.SaveChangesAsync();

                            //ถ้าบันทึกข้อมูลเสร็จ ให้ Commit เพื่อยืนยันการเซฟข้อมูล
                            dbTran.Commit();

                            //ถ้าไม่สำเร็จให้ RollBack();


                            //Temp Message เพื่อขึ้น Alert ป๊อปอัพแสดง
                            TempData["msg"] = _CLSR.GetScriptAlertPopUp("Success", "Register Successfully!", "", "S");
                            return RedirectToAction("Index", "Home");
                        }



                    }
                    else
                    {
                        TempData["msg"] = _CLSR.GetScriptAlertPopUp("Error", "Please contact Administrator", "", "E");
                        return RedirectToAction("Create", "Users");
                    }
                }

                

                
            }
            return View(user);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_id_string = HttpContext.Session.GetString("User_ID");
            var user_id = 0;

            try
            {
                user_id = Convert.ToInt32(user_id_string);
            }
            catch
            {
                user_id = 0;
            }


            var user = await _context.User.FindAsync(id);
            if (user == null || user_id == 0)
            {
                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Error", "Please contact Administrator", "", "D");
                return RedirectToAction("Index", "Home");
            }

            if (user_id != id)
            {
                TempData["msg"] = _CLSR.GetScriptAlertPopUp("Error", "Please contact Administrator", "", "D");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);
            }

            
            
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_ID,Role_ID,Email,Password,First_Name,Last_Name,Birthdate,Wrong_Password_Count,Last_Login,Last_Update,Gender,User_Status,User_isLock")] User user)
        {



            var user_id_string = HttpContext.Session.GetString("User_ID");
            var user_id = 0;

            try
            {
                user_id = Convert.ToInt32(user_id_string);
            }
            catch
            {
                user_id = 0;
            }

             if (id != user_id)
            {
                return NotFound();
            }


            var originalUser = _context.User.Where(i => i.User_ID == user_id).SingleOrDefault();
            originalUser.First_Name = user.First_Name; 
            originalUser.Last_Name = user.Last_Name; 
            originalUser.Birthdate = _CLSR.ConvertDatePicker(user.Birthdate); 
            originalUser.Gender = user.Gender; 

           

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(originalUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.User_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["getAlert"] = _CLSR.GetAlert("Update profile successfull");
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.User_ID == id);
        }
    }
}
