﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPoliceBlazor.Shared
{
    public class officers
    {
        [Key]
        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
