using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class Security_Group_Feature_Permissions_Map
    {
        [Key]
        public int Security_Group_Feature_Permission_ID { get; set; }
        [ForeignKey("Security_Groups")]
        public int Security_Group_ID { get; set; }
        public string Security_Group_Name { get; set; } = "";
        public Security_Groups Security_Groups { get; set; } = null!;
        [ForeignKey("Feature_Permissions")]
        public int Feature_Permission_ID { get; set; }
        public string Feature_Permission_Group { get; set; } = "";
        public string Feature_Permission_Header { get; set; } = "";
        public string Feature_Permission_Name { get; set; } = "";
        public string Feature_Permission_Key { get; set; } = "";
        public Feature_Permissions Feature_Permissions { get; set; } = null!;
    }
}
