using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrkrNovelist.Models;

namespace KrkrNovelist.Map
{
    public sealed class SEMap
    {

        public static Dictionary<string, SE> map = new Dictionary<string, SE>();

        public static bool Add(SE se)
        {
            string name = se.Name;

            if (SEMap.map.ContainsKey(name))
            {
                return false;
            }

            SEMap.map.Add(name, se);
            return true;
        }

        public static SE Get(string name)
        {
            if (SEMap.map.ContainsKey(name))
            {
                return SEMap.map[name];
            }

            return null;
        }

        public static List<SE> GetAll()
        {
            List<SE> list = new List<SE>();

            foreach (var se in SEMap.map)
            {
                list.Add(se.Value);
            }

            return list;
        }

        public static void Clear()
        {
            SEMap.map.Clear();
        }
    }
}
