﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class LogError
    {
        public Guid ErrorId { get; set; }
        public string Message { get; set; }
        public string StrackTrace { get; set; }
        public DateTime Time { get; set; }
    }
}