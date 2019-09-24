﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.DataModels
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool Status { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<GroupRole> GroupRoles { get; set; }
    }
}
