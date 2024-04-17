using MauiApp1.Usings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Circuit
    {
        public string circuitId { get; set; }
        public string url { get; set; }
        public string circuitName { get; set; }
        public Location Location { get; set; }
        public string emojiFlag
        {
            get
            {
                return EmojiHelper.GetEmojiFlag(Location.country);
            }
        }
    }
}
