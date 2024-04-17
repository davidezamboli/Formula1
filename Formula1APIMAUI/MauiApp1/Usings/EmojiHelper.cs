using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiApp1.Usings
{
    public class EmojiHelper
    {
        public EmojiHelper() { }

        private static readonly Dictionary<string, string> NationalityToEmojiMap = new Dictionary<string, string>
        {
            {"Thai", "\U0001F1F9\U0001F1ED" }, 
            {"Spanish", "\U0001F1EA\U0001F1F8" }, 
            {"British", "\U0001F1EC\U0001F1E7" }, 
            {"Finnish", "\U0001F1EB\U0001F1EE" }, 
            {"French", "\U0001F1EB\U0001F1F7" }, 
            {"Mexican", "\U0001F1F2\U0001F1FD" },
            {"German", "\U0001F1E9\U0001F1EA" }, 
            {"Monegasque", "\U0001F1F2\U0001F1E8" },
            {"Danish", "\U0001F1E9\U0001F1F0" }, 
            {"Australian", "\U0001F1E6\U0001F1FA" }, 
            {"American", "\U0001F1FA\U0001F1F8" }, 
            {"Canadian", "\U0001F1E8\U0001F1E6" }, 
            {"Japanese", "\U0001F1EF\U0001F1F5" }, 
            {"Dutch", "\U0001F1F3\U0001F1F1" }, 
            {"Chinese", "\U0001F1E8\U0001F1F3" }, 
            {"Italian", "\U0001F1EE\U0001F1F9" },
            {"Brazilian", "\U0001F1E7\U0001F1F7" },
            {"Indian", "\U0001F1EE\U0001F1F3" },
            {"South Korean", "\U0001F1F0\U0001F1F7" }, 
            {"Russian", "\U0001F1F7\U0001F1FA" }, 
            {"Swiss", "\U0001F1E8\U0001F1ED" }, 
            {"Swedish", "\U0001F1F8\U0001F1EA" }, 
            {"Norwegian", "\U0001F1F3\U0001F1F4" }
        };

        private static readonly Dictionary<string, string> NationToEmojiMap = new Dictionary<string, string>
        {
            {"united states", "\U0001F1FA\U0001F1F8" },
            {"usa", "\U0001F1FA\U0001F1F8" },
            {"united kingdom", "\U0001F1EC\U0001F1E7" },
            {"uk", "\U0001F1EC\U0001F1E7" },
            {"canada", "\U0001F1E8\U0001F1E6" },
            {"france", "\U0001F1EB\U0001F1F7" },
            {"germany", "\U0001F1E9\U0001F1EA" },
            {"italy", "\U0001F1EE\U0001F1F9" },
            {"australia", "\U0001F1E6\U0001F1FA" },
            {"japan", "\U0001F1EF\U0001F1F5" },
            {"brazil", "\U0001F1E7\U0001F1F7" },
            {"china", "\U0001F1E8\U0001F1F3" },
            {"india", "\U0001F1EE\U0001F1F3" },
            {"south korea", "\U0001F1F0\U0001F1F7" },
            {"russia", "\U0001F1F7\U0001F1FA" },
            {"spain", "\U0001F1EA\U0001F1F8" },
            {"mexico", "\U0001F1F2\U0001F1FD" },
            {"argentina", "\U0001F1E6\U0001F1F7" },
            {"switzerland", "\U0001F1E8\U0001F1ED" },
            {"sweden", "\U0001F1F8\U0001F1EA" },
            {"norway", "\U0001F1F3\U0001F1F4" },
            {"denmark", "\U0001F1E9\U0001F1F0" },
            {"finland", "\U0001F1EB\U0001F1EE" }
        };

        public static string GetEmojiFlag(string nation)
        {
            string lowerCaseNation = nation.ToLowerInvariant();
            
            if (NationToEmojiMap.ContainsKey(lowerCaseNation))
            {
                return NationToEmojiMap[lowerCaseNation];
            }
            else
            {
                return "🏁";
            }
        }

        public static string GetEmojiNationalityFlag(string nationality)
        {
            if (NationalityToEmojiMap.ContainsKey(nationality))
            {
                return NationalityToEmojiMap[nationality];
            }
            else
            {
                return "🏁";
            }
        }
    }
}
