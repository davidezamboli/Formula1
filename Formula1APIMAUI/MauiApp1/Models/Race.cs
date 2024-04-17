using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Race
    {
        public string season { get; set; }
        public string round { get; set; }
        public string url { get; set; }
        public string raceName { get; set; }
        public Circuit Circuit { get; set; }
        public string date { get; set; }
    }
}
