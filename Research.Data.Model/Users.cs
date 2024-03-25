using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research.Data.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Research.Data.Model
{
    [Index(nameof(User_Email), IsUnique = true)]
    public class Users : BaseEntity
    {
        [Key]
        public int User_ID { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string User_Email { get; set; } = string.Empty;
        public string User_Password { get; set; } = string.Empty;
        public bool User_AD_Flag { get; set; }
        public bool User_Reset_Password_Flag { get; set; } = true;
        [ForeignKey("Designation")]
        public int Designation_ID { get; set; }
        public string Designation_Value { get; set; } = "";
        public Designations Designation { get; set; } = null!;
        [ForeignKey("Process")]
        public int Process_ID { get; set; }
        public string Process_Value { get; set; } = "";
        public Process Process { get; set; } = null!;
        public ICollection<User_Security_Group_Map> User_Security_Groups { get; set; } = null!;
        public ICollection<User_Report_Map> User_Reports { get; set; } = null!;        
    }
}
