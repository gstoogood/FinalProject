﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _421FinalProject.Models;

namespace _421FinalProject.Models
{
    public class RoleUserVM
    {
        public ApplicationUser AppUser { get; set; }
        public List<string> UserRoles { get; set; }
        public List<string> AllRoles { get; set; }
    }
}
