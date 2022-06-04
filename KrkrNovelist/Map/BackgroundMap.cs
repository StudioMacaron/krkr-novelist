using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrkrNovelist.Models;

namespace KrkrNovelist.Map
{
    public sealed class BackgroundMap
    {

        public static Dictionary<string, Background> map = new Dictionary<string, Background>();

        public static bool Add(Background background)
        {
            string name = background.Name;

            if (BackgroundMap.map.ContainsKey(name))
            {
                return false;
            }

            BackgroundMap.map.Add(name, background);
            return true;
        }

        public static Background Get(string name)
        {
            if (BackgroundMap.map.ContainsKey(name))
            {
                return BackgroundMap.map[name];
            }

            return null;
        }

        public static List<Background> GetAll()
        {
            List<Background> list = new List<Background>();

            foreach (var background in BackgroundMap.map)
            {
                list.Add(background.Value);
            }

            return list;
        }

        public static void Clear()
        {
            BackgroundMap.map.Clear();
        }
    }
}
