using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Utilities
{
    public class Enums
    {
        public static readonly string CONTEXT_USER = "User";
        public enum CustomClaimType
        {
            UserName,
            UserId,
            RefreshToken
        }
    }
}
