using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class Process
    {
        [Key]
        public int Process_ID { get; set; }
        public string Process_Value { get; set; } = string.Empty;
        public ICollection<Users> Users { get; set; } = null!;
    }
}
