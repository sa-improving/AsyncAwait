﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Thing_Module.Models
{
    public class SeleucidResponse
    {
        public List<Seleucid> Seleucids { get; set; }
    }

    public class Seleucid
    {
        public string Name { get; set; }
        public int StartReign { get; set; }
        public int EndReign { get; set; }
        public string[] Consorts { get; set; }
    }
}
