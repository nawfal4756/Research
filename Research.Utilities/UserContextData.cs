﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Utilities
{
    public class UserContextData
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = null!;
    }
}
