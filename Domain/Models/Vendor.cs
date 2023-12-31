﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vendor: BaseEntity
    {
        public required string Name { get; set; }
        public required string EmployeeSerial { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }=new List<Sales>();
    }
}
