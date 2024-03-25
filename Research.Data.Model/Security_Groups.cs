using Research.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Data.Model
{
    public class Security_Groups : BaseEntity
    {
        [Key]
        public int Security_Group_ID { get; set; }
        public string Security_Group_Name { get; set; } = string.Empty;
        public string Security_Group_Description { get; set; } = string.Empty;
        public ICollection<User_Security_Group_Map> User_Security_Group { get; set; } = null!;
        public ICollection<Security_Group_Feature_Permissions_Map> Security_Group_Feature_Permissions { get; set; } = null!;
    }
}
