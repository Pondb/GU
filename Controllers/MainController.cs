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

namespace GU.Controllers
{
    public class MainController : Controller
    {
        private readonly GU_DB _context;
        private ClassResource _CLSR;
        private IConfiguration _iconfiguration;
        private readonly String _Module = "Home";

        public MainController(GU_DB context, IConfiguration configuration)
        {
            _context = context;
            _iconfiguration = configuration;
            _CLSR = new ClassResource(_context, configuration);

        }

        //SET SESSION (KEY,Value)
        //HttpContext.Session.SetString("userid", user.userid.ToString());



        //MainController : PhaserJS ,Tree
        public IActionResult Index()
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

            _CLSR.CheckTaskDueDate(user_id, 20);

            var TimeNow = Convert.ToInt32(_CLSR.GetTimeNow(""));

            //ISO BG
            if (TimeNow >= 000000 && TimeNow <= 060000 || TimeNow > 180000 && TimeNow <= 240000)
            {
                ViewBag.Scene_Time_BG = "../assets/GU_Game/img/BG/Night_BG.png";
                ViewBag.DorN = "Night";


            }
            else
            {
                ViewBag.Scene_Time_BG = "../assets/GU_Game/img/BG/Day_BG.png";
                ViewBag.DorN = "Day";

            }


            if (user_id != 0)
            {

                String cDate = _CLSR.GetDateNow("");
                String cTime = _CLSR.GetTimeNow("");

                String timeWithoutSecond = cTime.Substring(0,4);

                var userTree_01 = _context.Trees
                .Include(i => i.UserInfo)
                .Include(i => i.Tree_Type)
                .Where(c => c.User_ID == user_id && c.Tree_Status == "S").SingleOrDefault();

                var userTree_G1 = _context.Trees.Include(i => i.UserInfo)
                    .Include(i => i.Tree_Type)
                    .Where(c => c.User_ID == user_id && c.Tree_Status == "G1").SingleOrDefault();

                var userTree_G2 = _context.Trees.Include(i => i.UserInfo)
                    .Include(i => i.Tree_Type)
                    .Where(c => c.User_ID == user_id && c.Tree_Status == "G2").SingleOrDefault();


                var userTree_G3 = _context.Trees.Include(i => i.UserInfo)
                    .Include(i => i.Tree_Type)
                    .Where(c => c.User_ID == user_id && c.Tree_Status == "G3").SingleOrDefault();


                //ต้องเพิ่ม ไม่นับ Task ที่เฟลไปแล้ว
                var task_all_count = _context.ToDo_Task.Where(i => i.User_ID == user_id && i.Task_Parent_ID == 0 && i.Task_Status == "Y" && i.Task_isFail == "N").Count();
                var task_complete_count = _context.ToDo_Task.Where(i => i.User_ID == user_id && i.Task_isComplete == "Y" &&  i.Task_Parent_ID == 0 && i.Task_Status == "Y").Count();

                var task = _context.ToDo_Task.Where(i => i.User_ID == user_id && i.Task_isComplete == "N" && i.Task_Status == "Y" && i.Task_Parent_ID == 0).ToList();
                int taskTodayCount = 0;


                //check task due date and time
                foreach (var item in task)
                {
                    if (Convert.ToInt32(item.Task_Due_Date) == Convert.ToInt32(cDate) && Convert.ToInt32(timeWithoutSecond) < Convert.ToInt32(item.Task_Due_Time))
                    {
                        taskTodayCount += 1;
                    }
                }





                var tree_hp = userTree_01.Tree_HP;

                ViewBag.task_count = task_all_count;
                ViewBag.task_finished = task_complete_count;
                ViewBag.Tree_HP = tree_hp;
                ViewBag.task_today = taskTodayCount;
                ViewBag.tree_exp = userTree_01.Tree_EXP;

                //Fully Grow Tree to ViewBag
                ViewBag.G1 = userTree_G1;
                ViewBag.G2 = userTree_G2;
                ViewBag.G2 = userTree_G3;


                //G1
                if (userTree_G1 != null)
                {
                    //G1 Tree Level IMG
                    if (userTree_G1.Tree_Level == 1)
                    {
                        if (userTree_G1.Tree_isDead == "Y")
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV1_DIE;
                        }
                        else
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV1_IMG;
                        }
                    }
                    else if (userTree_G1.Tree_Level == 2)
                    {
                        if (userTree_G1.Tree_isDead == "Y")
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV2_DIE;
                        }
                        else
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV2_IMG;
                        }
                    }
                    else if (userTree_G1.Tree_Level == 3)
                    {
                        if (userTree_G1.Tree_isDead == "Y")
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV3_DIE;
                        }
                        else
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV3_IMG;
                        }
                    }
                    else if (userTree_G1.Tree_Level == 4)
                    {
                        if (userTree_G1.Tree_isDead == "Y")
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV4_DIE;
                        }
                        else
                        {
                            ViewBag.G1_IMG = userTree_G1.Tree_Type.Tree_LV4_IMG;
                        }
                    }

                }

                //G2
                if (userTree_G2 != null)
                {
                    //G2 Tree Level IMG
                    if (userTree_G2.Tree_Level == 1)
                    {
                        if (userTree_G2.Tree_isDead == "Y")
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV1_DIE;
                        }
                        else
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV1_IMG;
                        }
                    }
                    else if (userTree_G2.Tree_Level == 2)
                    {
                        if (userTree_G2.Tree_isDead == "Y")
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV2_DIE;
                        }
                        else
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV2_IMG;
                        }
                    }
                    else if (userTree_G2.Tree_Level == 3)
                    {
                        if (userTree_G2.Tree_isDead == "Y")
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV3_DIE;
                        }
                        else
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV3_IMG;
                        }
                    }
                    else if (userTree_G2.Tree_Level == 4)
                    {
                        if (userTree_G2.Tree_isDead == "Y")
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV4_DIE;
                        }
                        else
                        {
                            ViewBag.G2_IMG = userTree_G2.Tree_Type.Tree_LV4_IMG;
                        }
                    }

                }

                //G3
                if (userTree_G3 != null)
                {
                    //G3 Tree Level IMG
                    if (userTree_G3.Tree_Level == 1)
                    {
                        if (userTree_G3.Tree_isDead == "Y")
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV1_DIE;
                        }
                        else
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV1_IMG;
                        }
                    }
                    else if (userTree_G3.Tree_Level == 2)
                    {
                        if (userTree_G3.Tree_isDead == "Y")
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV2_DIE;
                        }
                        else
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV2_IMG;
                        }
                    }
                    else if (userTree_G3.Tree_Level == 3)
                    {
                        if (userTree_G3.Tree_isDead == "Y")
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV3_DIE;
                        }
                        else
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV3_IMG;
                        }
                    }
                    else if (userTree_G3.Tree_Level == 4)
                    {
                        if (userTree_G3.Tree_isDead == "Y")
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV4_DIE;
                        }
                        else
                        {
                            ViewBag.G3_IMG = userTree_G3.Tree_Type.Tree_LV4_IMG;
                        }
                    }

                }



                //Main Tree Image
                if (userTree_01 != null)
                {
                    if (userTree_01.Tree_Level == 1)
                    {

                        if (userTree_01.Tree_isDead == "Y")
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV1_DIE;
                        }
                        else
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV1_IMG;
                        }

                    }
                    else if (userTree_01.Tree_Level == 2)
                    {
                        if (userTree_01.Tree_isDead == "Y")
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV2_DIE;
                        }
                        else
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV2_IMG;
                        }
                    }
                    else if (userTree_01.Tree_Level == 3)
                    {
                        if (userTree_01.Tree_isDead == "Y")
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV3_DIE;
                        }
                        else
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV3_IMG;
                        }
                    }
                    else if (userTree_01.Tree_Level == 4)
                    {
                        if (userTree_01.Tree_isDead == "Y")
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV4_DIE;
                        }
                        else
                        {
                            ViewBag.TreeIMG = userTree_01.Tree_Type.Tree_LV4_IMG;
                        }
                    }
                    else
                    {

                    }





                    return View(userTree_01);
                }

                return View(userTree_01);
                
               
            }
            else
            {
                return View();
            }

            
            






            
        }

       



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
