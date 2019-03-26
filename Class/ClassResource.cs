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
using System.Text;
using System.Security.Cryptography;

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
        public String GetAlert(String txt)
        {
            

            //var alert_bt = "<script>alertModal_Popup('" + title + "','" + alertType + "','" + txt + "');</script>";
            var alert_bt = "<script>alert('"+ txt +"');</script>";
            //var alert_bts = "<script>alertModal_Popup('Hello','danger','Text');</script>";

            return alert_bt;
           


        }

        public string EncodeHMAC_SHA512(string input)
        {
            string key = "inventech";

            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] keyByte = encoding.GetBytes(key);

            HMACSHA512 myhmacsha512 = new HMACSHA512(keyByte);

            byte[] byteArray = Encoding.UTF8.GetBytes(input);

            var hashValue = myhmacsha512.ComputeHash(byteArray);

            return Convert.ToBase64String(hashValue);

        }

        public string EncryptSHA512(string data)
        {
            SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
            Byte[] strx = System.Text.Encoding.UTF8.GetBytes(data);
            Byte[] HashValue = SHA512.ComputeHash(strx);
            return System.Convert.ToBase64String(HashValue);
        }




        //Check Task is over Due Date
        public void CheckTaskDueDate(int user_id,int hpDown)
        {
            String cDate = GetDateNow("");
            String cTime = GetTimeNow("");

            String TimeNow = cTime.Substring(0, 4);


            var user = _context.User.Where(i => i.User_ID == user_id).SingleOrDefault();
            var tree = _context.Trees.Where(i => i.User_ID == user_id && i.Tree_Status == "S").SingleOrDefault();

            //จะหาเจอแค่ Task ที่มีเงื่อนไขตามนี้ ถ้าเช็คครั้งต่อไปจะไม่ลบ ID ซ้ำๆ
            var task = _context.ToDo_Task.Where(i => i.User_ID == user_id && i.Task_isComplete == "N" && i.Task_isFail == "N" && i.Task_Status == "Y" && i.Task_Parent_ID == 0).ToList();




            //check task due date and time
            foreach (var item in task)
            {
                //Task over due date.
                if (Convert.ToInt32(cDate) > Convert.ToInt32(item.Task_Due_Date))
                {
                    tree.Tree_HP = tree.Tree_HP - hpDown;

                    if (tree.Tree_HP <= 0)
                    {
                        tree.Tree_isDead = "Y";
                        //tree.Tree_Status = "N";

                    }


                    //Task inComplete
                    item.Task_isFail = "Y";
                    item.Task_isComplete = "N";


                    _context.Update(tree);
                    _context.Update(item);
                    _context.SaveChanges();

                }
                //On Date but Time is up.
                else if (Convert.ToInt32(item.Task_Due_Date) == Convert.ToInt32(cDate) &&  Convert.ToInt32(TimeNow) > Convert.ToInt32(item.Task_Due_Time))
                {
                    tree.Tree_HP = tree.Tree_HP - hpDown;

                    if (tree.Tree_HP <= 0)
                    {
                        tree.Tree_Level = 0;
                        //tree.Tree_Status = "N";
                        
                    }

                    //Task inComplete
                    item.Task_isFail = "Y";
                    item.Task_isComplete = "N";

                    _context.Update(tree);
                    _context.Update(item);
                    _context.SaveChanges();
                }
                else
                {

                }

                
            }
        }



        //Main Function

        //EXP_UP
        public bool Exp_Up(int user_id,float exp_input)
        {

            String cDate = GetDateNow("");
            String cTime = GetTimeNow("");

            var user = _context.User.Where(i => i.User_ID == user_id).SingleOrDefault();
            var tree = _context.Trees.Where(i => i.User_ID == user_id && i.Tree_Status == "S").SingleOrDefault();

            var user_tree_count = _context.Trees.Where(i => i.User_ID == user_id).Count();

            if (user_id != 0)
            {
                tree.Tree_EXP = tree.Tree_EXP + exp_input;

                if (tree.Tree_Level < 3 && tree.Tree_EXP > 100)
                {
                    var remainEXP = tree.Tree_EXP - 100;

                    tree.Tree_EXP = remainEXP;
                    tree.Tree_Level = tree.Tree_Level + 1;

                    if (tree.Tree_Level == 3)
                    {
                        //ถ้าต้นไม้เดิม Level ขึ้นเท่ากับ 3 ให้เปลี่ยนสถานะจาก 'S' (Selected) กลายเป็น 'G(x)' (Growth + ตามด้วยจำนวนต้นไม้)
                        
                        tree.Tree_Status = "G" + user_tree_count;
                        

                        //ต้นแรกปลูกสำเร็จ โตแล้ว !!
                        if (tree.Tree_Status == "G1")
                        {

                            //new Tree Created with Type Tree == 2
                            Trees basic_Tree = new Trees();

                            basic_Tree.User_ID = user_id;
                            basic_Tree.Tree_Level = 1;
                            basic_Tree.Tree_EXP = 0;

                            //Tree Type == 2++
                            basic_Tree.Tree_Type_ID = 2;
                            basic_Tree.Tree_Name = "Tree_LV2";
                            basic_Tree.Tree_HP = 80;
                            basic_Tree.Plant_Date = cDate;
                            basic_Tree.Create_Date = cDate;
                            basic_Tree.Update_Date = cDate;
                            basic_Tree.Tree_Status = "S";
                            basic_Tree.Tree_isDead = "N";

                            _context.Add(basic_Tree);
                        }
                        //ต้นที่สองปลูกสำเร็จ
                        else if (tree.Tree_Status == "G2")
                        {
                            //new Tree Created with Type Tree == 3
                            //new Tree Created with Type Tree == 2
                            Trees basic_Tree = new Trees();

                            basic_Tree.User_ID = user_id;
                            basic_Tree.Tree_Level = 1;
                            basic_Tree.Tree_EXP = 0;

                            //Tree Type == 2++
                            basic_Tree.Tree_Type_ID = 3;
                            basic_Tree.Tree_Name = "Tree_LV3";
                            basic_Tree.Tree_HP = 60;
                            basic_Tree.Plant_Date = cDate;
                            basic_Tree.Create_Date = cDate;
                            basic_Tree.Update_Date = cDate;
                            basic_Tree.Tree_Status = "S";
                            basic_Tree.Tree_isDead = "N";

                            _context.Add(basic_Tree);
                        }
                        //ต้นที่สามปลูกสำเร็จ
                        else if (tree.Tree_Status == "G3")
                        {
                            //new Tree Created with Type Tree == 4
                            //new Tree Created with Type Tree == 3
                            //new Tree Created with Type Tree == 2
                            Trees basic_Tree = new Trees();

                            basic_Tree.User_ID = user_id;
                            basic_Tree.Tree_Level = 1;
                            basic_Tree.Tree_EXP = 0;

                            //Tree Type == 2++
                            basic_Tree.Tree_Type_ID = 3;
                            basic_Tree.Tree_Name = "Tree_LV4";
                            basic_Tree.Tree_HP = 40;
                            basic_Tree.Plant_Date = cDate;
                            basic_Tree.Create_Date = cDate;
                            basic_Tree.Update_Date = cDate;
                            basic_Tree.Tree_Status = "S";
                            basic_Tree.Tree_isDead = "N";

                            _context.Add(basic_Tree);
                        }
                        //ต้นที่สี่ปลูกสำเร็จ !! +  Reward 
                        else if (tree.Tree_Status == "G4")
                        {
                            
                        }
                        //ERROR
                        else
                        {

                        }
                    



                    }
                }

                _context.Update(tree);
                _context.SaveChanges();

                return true;




            }
            else
            {
                //ERROR USER ID == 0
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
