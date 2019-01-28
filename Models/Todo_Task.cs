using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GU.Models
{
    public class ToDo_Task
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 Task_ID { get; set; }

        public Int32 Task_Parent_ID { get; set; }

        [ForeignKey("UserInfo")]
        public Int32 User_ID { get; set; }

        //[ForeignKey("Tree")]
        //public Int32 Tree_ID { get; set; }

        public String Task_Name { get; set; }

        public String Task_Due_Date { get; set; }

        public String Task_Due_Time { get; set; }

        public String Task_Description { get; set; }

        public Int32 Task_isFocus { get; set; }

        public String Task_Create_Date { get; set; }

        public String Task_Update_Date { get; set; }

        public String Task_Status { get; set; }

        public String Task_isComplete { get; set; }

        public String Task_isFail { get; set; }


        public User UserInfo { get; set; }

        //public Trees Tree { get; set; }
        

    }
}
