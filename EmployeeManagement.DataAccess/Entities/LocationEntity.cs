﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Entities
{
    public class LocationEntity
    {
        public required int LocationEntityId { get; set; }
        public required int LocationId { get; set; }
        public required string LocationName { get; set; }
    }
}
