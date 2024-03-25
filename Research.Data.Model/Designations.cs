using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class Designations
    {
        [Key]
        public int Designation_ID { get; set; }
        public string Designation_Value { get; set; } = string.Empty;
    }
}
