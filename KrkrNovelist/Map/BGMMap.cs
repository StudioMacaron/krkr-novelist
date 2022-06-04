using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrkrNovelist.Models;

namespace KrkrNovelist.Map
{
    public sealed class BGMMap
    {

        public static Dictionary<string, BGM> map = new Dictionary<string, BGM>();

        public static bool Add(BGM bgm)
        {
            string name = bgm.Name;

            if (BGMMap.map.ContainsKey(name))
            {
                return false;
            }

            BGMMap.map.Add(name, bgm);
            return true;
        }

        public static BGM Get(string name)
        {
            if (BGMMap.map.ContainsKey(name))
            {
                return BGMMap.map[name];
            }

            return null;
        }

        public static List<BGM> GetAll()
        {
            List<BGM> list = new List<BGM>();

            foreach (var bgm in BGMMap.map)
            {
                list.Add(bgm.Value);
            }

            return list;
        }

        public static void Clear()
        {
            BGMMap.map.Clear();
        }
    }
}
