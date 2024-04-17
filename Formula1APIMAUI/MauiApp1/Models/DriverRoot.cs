using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class DriverRoot
    {
        [JsonPropertyName("MRData")]
        public MRDataDriver MRDataDriver { get; set; }
    }
}
