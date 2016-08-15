﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
