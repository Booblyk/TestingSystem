﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Entities
{
    public class UserInRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }


        public Role Role { get; set; }
        public User User { get; set; }
    }
}
