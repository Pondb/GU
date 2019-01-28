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

namespace GU.Class
{
    public class ClassResource
    {

        private readonly GU_DB _context;
        IConfiguration _iconfiguration;
        private ClassResource _CLSR;

        public ClassResource(GU_DB context, IConfiguration iconfiguration)
        {
            _context = context;
            _iconfiguration = iconfiguration;
        }

        public String ConvertTimePicker(String timeInput,String replaceSign)
        {
            var newTime = timeInput.Replace(replaceSign, String.Empty);

            return newTime;
        }


        //Datepicker Function
        public String ConvertDatePicker(String dateInput)
        {

            var newDate = dateInput.Replace("/", String.Empty);


            var day = newDate.Substring(0, 2);
            var month = newDate.Substring(2, 2);
            var year = newDate.Substring(4, 4);

            int new_Year = Convert.ToInt32(year);

            try
            {
                if (Convert.ToInt32(year) >= 2400)
                {
                    new_Year = Convert.ToInt32(year) - 543;
                }

            }
            catch
            {

            }


            var convertedDate = new_Year.ToString() + month + day;

            return convertedDate;

        }

        //Alert Dialog Function
        public String GetScriptAlertPopUp(String title, String Msg, String PictureName, String TypeDialog)
        {
            if (!PictureName.Equals(""))
            {
                Msg = "<img src=\"images/" + PictureName + "\"/>" + Msg;
            }

            //TypeDialog ..
            //1. D = BootstrapDialog.TYPE_DEFAULT, 
            //2. I = BootstrapDialog.TYPE_INFO, 
            //3. P = BootstrapDialog.TYPE_PRIMARY, 
            //4. S = BootstrapDialog.TYPE_SUCCESS, 
            //5. W = BootstrapDialog.TYPE_WARNING, 
            //6. E = BootstrapDialog.TYPE_DANGER

            if (TypeDialog.Equals("D"))
            {
                return "<script>BootstrapDialog.show({title: '" + title.Replace("'", "")
                    + "',message: '" + Msg.Replace("'", "")
                    + "',type:BootstrapDialog.TYPE_DEFAULT});</script>";
            }
            else if (TypeDialog.Equals("I"))
            {
                return "<script>BootstrapDialog.show({title: '" + title.Replace("'", "")
                    + "',message: '" + Msg.Replace("'", "")
                    + "',type:BootstrapDialog.TYPE_INFO});</script>";
            }
            else if (TypeDialog.Equals("P"))
            {
                return "<script>BootstrapDialog.show({title: '" + title.Replace("'", "")
                    + "',message: '" + Msg.Replace("'", "")
                    + "',type:BootstrapDialog.TYPE_PRIMARY});</script>";
            }
            else if (TypeDialog.Equals("S"))
            {
                return "<script>BootstrapDialog.show({title: '" + title.Replace("'", "")
                    + "',message: '" + Msg.Replace("'", "")
                    + "',type:BootstrapDialog.TYPE_SUCCESS});</script>";
            }
            else if (TypeDialog.Equals("W"))
            {
                return "<script>BootstrapDialog.show({title: '" + title.Replace("'", "")
                    + "',message: '" + Msg.Replace("'", "")
                    + "',type:BootstrapDialog.TYPE_WARNING});</script>";
            }
            else if (TypeDialog.Equals("E"))
            {
                return "<script>BootstrapDialog.show({title: '" + title.Replace("'", "")
                    + "',message: '" + Msg.Replace("'", "")
                    + "',type:BootstrapDialog.TYPE_DANGER});</script>";
            }
            else
            {
                //Primary
                return "<script>BootstrapDialog.show({title: '" + title.Replace("'", "") + "',message: '" + Msg.Replace("'", "") + "'});</script>";
            }


        }



        //Alert Dialog Function
        public String GetAlertBar(String header, String txt, String alertType)
        {
            

            var alert_bt = "<script>alert_bt('" + header + "','" + txt + "','" + alertType + "')</script>";

            return alert_bt;
           


        }

        public void CheckTaskDueDate(int user_id)
        {
            String cDate = _CLSR.GetDateNow("");
            String cTime = _CLSR.GetTimeNow("");

            String TimeNow = cTime.Substring(0, 4);

            var user = _context.User.Where(i => i.User_ID == user_id).SingleOrDefault();
            var tree = _context.Trees.Where(i => i.User_ID == user_id && i.Tree_Status == "Y").SingleOrDefault();
            var task = _context.ToDo_Task.Where(i => i.User_ID == user_id && i.Task_isComplete == "N" && i.Task_Status == "Y" && i.Task_Parent_ID == 0).ToList();



            //check task due date and time
            foreach (var item in task)
            {
                //Task over due date.
                if (Convert.ToInt32(item.Task_Due_Date) > Convert.ToInt32(cDate))
                {
                    tree.Tree_HP = tree.Tree_HP - 20;

                    if (tree.Tree_HP <= 0)
                    {
                        tree.Tree_isDead = "Y";
                        //tree.Tree_Status = "N";

                    }


                    _context.Update(tree);
                    _context.SaveChanges();

                }
                //On Date but Time is up.
                else if (Convert.ToInt32(item.Task_Due_Date) == Convert.ToInt32(cDate) &&  Convert.ToInt32(TimeNow) > Convert.ToInt32(item.Task_Due_Time))
                {
                    tree.Tree_HP = tree.Tree_HP - 20;

                    if (tree.Tree_HP <= 0)
                    {
                        tree.Tree_Level = 0;
                        //tree.Tree_Status = "N";
                        
                    }

                    _context.Update(tree);
                    _context.SaveChanges();
                }
                else
                {

                }

                
            }
        }



        //Main Function

        //EXP_UP
        public bool Exp_Up(int User_ID,int Tree_ID,float exp_input)
        {
            //Int32 user_current = Convert.ToInt32(HttpContext.Session.GetString("userid"));

            Int32 user_current = 1;

            var searchMapping = user_current + 1;
            

            if (searchMapping != 0)
            {
                //select tree context
                //plus exp

                var tree_exp = 999;
                Double exp_sum;

                try
                {
                    exp_sum = exp_input + Convert.ToDouble(tree_exp);
                }
                catch
                {
                    exp_sum = 0;
                }

            

                if (exp_sum >= 1000)
                {
                    //level up and the remaining to add
                    //level + 1
                    Double remaining_exp = 0;
                    remaining_exp = exp_sum - 1000;

                    //Update EXP Field with Remaining

                    return true;

                }
                else if (exp_sum < 1000)
                {
                    //Select EXP + exp_sum;
                    return true;
                }
                else
                {
                    //ERROR
                    return false;
                }

            
                
            }
            else
            {
                return false;

            }

            
           
           
        }













        //Date Function
        public String GetDateNow(String sSeperate = "")
        {
            string DOut;
            Int32 DYear;

            DYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            if (DYear > 2500)
            { DYear = DYear - 543; }

            DOut = Convert.ToString(DYear) + sSeperate + DateTime.Now.ToString("MM") + sSeperate + DateTime.Now.ToString("dd");

            return DOut;
        }


        

        public String GetTimeNow(String sSeperate = "")
        {
            string TOut;

            TOut = DateTime.Now.ToString("HH") + sSeperate + DateTime.Now.ToString("mm") + sSeperate + DateTime.Now.ToString("ss");

            return TOut;
        }


        public String ConvertDatePicker(String dateInput,String symbol)
        {

            var newDate = dateInput.Replace(symbol, String.Empty);


            var day = newDate.Substring(0, 2);
            var month = newDate.Substring(2, 2);
            var year = newDate.Substring(4, 4);

            int new_Year = Convert.ToInt32(year);

            try
            {
                if (Convert.ToInt32(year) >= 2400)
                {
                    new_Year = Convert.ToInt32(year) - 543;
                }

            }
            catch
            {

            }


            var convertedDate = new_Year.ToString() + month + day;

            return convertedDate;

        }


    }
}
