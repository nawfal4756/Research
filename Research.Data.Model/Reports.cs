using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class Reports
    {
        [Key]
        public int Report_ID { get; set; }
        public string Report_Group { get; set; } = string.Empty;
        public string Report_Name { get; set; } = string.Empty;
        public string Report_Key { get; set; } = string.Empty;
        public string? Report_URL { get; set; } = string.Empty;
        public string? Report_Description { get; set; } = string.Empty;
        public int Status_ID { get; set; }
        public string Status_Value { get; set; } = string.Empty;
        public ICollection<User_Report_Map> User_Reports { get; set; } = null!;
    }
}
