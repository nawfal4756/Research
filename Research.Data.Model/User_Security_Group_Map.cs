using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class User_Security_Group_Map
    {
        [Key]
        public int User_Security_Group_ID { get; set; }
        [ForeignKey("User")]
        public int User_ID { get; set; }
        public string User_Name { get; set; } = "";
        public Users User { get; set; } = null!;
        [ForeignKey("Security_Group")]
        public int Security_Group_ID { get; set; }
        public string Security_Group_Name { get; set; } = "";
        public Security_Groups Security_Group { get; set; } = null!;
    }
}
