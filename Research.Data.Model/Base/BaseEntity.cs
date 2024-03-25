using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model.Base
{
    public class BaseEntity
    {
        [NotMapped]
        public int id { get; set; }
        [ForeignKey("Status")]
        public int Status_ID { get; set; } = 1;
        public string Status_Value { get; set; } = "Active";
        public Status Status { get; set; } = null!;
        public int Created_By_ID { get; set; } = 1;
        public string Created_By_Name { get; set; } = "Test User";
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public int? Updated_By_ID { get; set; }
        public string? Updated_By_Name { get; set; }
        public DateTime? Updated_Date { get; set; }
    }
}
