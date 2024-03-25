using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class User_Report_Map
    {
        [Key]
        public int User_Report_ID { get; set; }
        [ForeignKey("User")]
        public int User_ID { get; set; }
        public string User_Name { get; set; } = "";
        public Users User { get; set; } = null!;
        [ForeignKey("Report")]
        public int Report_ID { get; set; }
        public string Report_Group { get; set; } = "";
        public string Report_Name { get; set; } = "";
        public string Report_Key { get; set; } = "";
        public string Report_URL { get; set; } = "";
        public Reports Report { get; set; } = null!;
        public int Status_ID { get; set; } = 1;
        public string Status_Value { get; set; } = "Active";
    }
}
