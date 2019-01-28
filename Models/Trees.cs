using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GU.Models
{
    public class Trees
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 Tree_ID { get; set; }

        [ForeignKey("UserInfo")]
        public Int32 User_ID{ get; set; }

        [ForeignKey("Tree_Type")]
        public Int32 Tree_Type_ID { get; set; }

        public String Tree_Name { get; set; }

        public Int32 Tree_HP { get; set; }

        

        public Double Tree_EXP { get; set; }

        public Int32 Tree_Level { get; set; }

        public String Plant_Date { get; set; }

        public String Tree_Description { get; set; }

        public String Tree_Status { get; set; }

        public String Create_Date { get; set; }

        public String Update_Date { get; set; }

        public String Tree_isDead { get; set; }


        public User UserInfo { get; set; }
        public Tree_Type Tree_Type { get; set; }
    }
}
