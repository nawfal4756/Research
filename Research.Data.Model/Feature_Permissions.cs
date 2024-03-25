using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class Feature_Permissions
    {
        [Key]
        public int Feature_Permission_ID { get; set; }
        public string Feature_Permission_Group { get; set; } = string.Empty;
        public string Feature_Permission_Header { get; set; } = string.Empty;
        public string Feature_Permission_Name { get; set; } = string.Empty;
        public string Feature_Permission_Key { get; set; } = string.Empty;
        public string? Feature_Permission_Description { get; set; } = string.Empty;
        [ForeignKey("Status")]
        public int Status_ID { get; set; }
        public Status Status { get; set; } = null!;
        public ICollection<Security_Group_Feature_Permissions_Map> Security_Group_Feature_Permissions { get; set; } = null!;
    }
}
