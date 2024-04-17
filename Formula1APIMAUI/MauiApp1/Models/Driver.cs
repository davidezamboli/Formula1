﻿using MauiApp1.Usings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Driver
    {
        public string driverId { get; set; }
        public string url { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string dateOfBirth { get; set; }
        public string nationality { get; set; }
        public string permanentNumber { get; set; }
        public string code { get; set; }
        public string emojiFlag
        {
            get
            {
                return EmojiHelper.GetEmojiNationalityFlag(nationality);
            }
        }
    }
}
