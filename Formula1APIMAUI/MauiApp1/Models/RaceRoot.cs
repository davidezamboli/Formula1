using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class RaceRoot
    {
        [JsonPropertyName("MRData")]
        public MRDataRace MRDataRace { get; set; }
    }
}
