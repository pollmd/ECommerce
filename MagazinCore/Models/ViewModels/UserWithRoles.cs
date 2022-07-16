﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Models.ViewModels
{
    public class UserWithRoles
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
