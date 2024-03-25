using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class Status
    {
        [Key]
        public int Status_ID { get; set; }
        public string Status_Value { get; set; } = string.Empty;
    }
}
