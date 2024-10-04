﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO
{
    public class PagedSearch
    {
        public int? PerPage { get; set; } = 5;
        public int? Page { get; set; } = 1;
    }
}
