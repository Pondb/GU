using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GU.Models
{
    public class UserMapping
    {
        [Key, ForeignKey("User")]
        public Int32 User_ID { get; set; }

        [Key, ForeignKey("Trees")]
        public Int32 Tree_ID { get; set; }

        public Trees Trees { get; set; }
        public User User { get; set; }


    }
}
