﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDARazorApp.Data
{
    public class CustomerTask
    {
        public int TaskId { get; set; }
        public string CustomerId { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public int PriorityId { get; set; }
        public string TaskDescription { get; set; }
    }
}
