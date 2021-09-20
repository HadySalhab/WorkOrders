﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrders.Model
{
    public class Status
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
