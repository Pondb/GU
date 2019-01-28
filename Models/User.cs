using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GU.Models
{
    public class User
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public Int32 User_ID { get; set; }

        public Int32 Role_ID { get; set; }

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Name")]
        public String First_Name { get; set; }

        [Display(Name = "Lastname")]
        public String Last_Name { get; set; }

        [Display(Name = "Birth Date")]
        public String Birthdate { get; set; }

        [Display(Name = "Gender")]
        public String Gender { get; set; }

        [Display(Name = "Wrong Password Count")]
        public Int32 Wrong_Password_Count { get; set; }

        [Display(Name = "Last Login")]
        public String Last_Login { get; set; }

        [Display(Name = "Last Updated")]
        public String Last_Update { get; set; }

        public String User_Status { get; set; }

        public String User_isLock { get; set; }


        public List<Trees> Trees { get; set; }
    }
}
