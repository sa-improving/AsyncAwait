using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Async_Thing_Module.Models;

namespace Async_Thing_Module.ViewModel
{
    public class RandomNumberViewModel
    {
        public int RandomNumber { get; set; }
        public string ChuckNorrisFact { get; set; }
        public List<Seleucid> Seleucids { get; set; }
        public Teacher Teacher { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
