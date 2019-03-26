using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GU.Models
{
    public class Tree_Type
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 Tree_Type_ID { get; set; }

        public String Tree_LV1_IMG { get; set; }

        public String Tree_LV2_IMG { get; set; }

        public String Tree_LV3_IMG { get; set; }

        //public String Tree_LV4_IMG { get; set; }

        public String Tree_Type_Name { get; set; }

        public String Tree_Type_Description { get; set; }

        public String Tree_LV1_DIE { get; set; }
        public String Tree_LV2_DIE { get; set; }
        public String Tree_LV3_DIE { get; set; }
        public String Tree_LV4_DIE { get; set; }
    }
}
