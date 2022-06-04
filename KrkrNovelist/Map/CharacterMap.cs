using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrkrNovelist.Models;

namespace KrkrNovelist.Map
{
    public sealed class CharacterMap
    {

        public static Dictionary<string, Character> map = new Dictionary<string, Character>();

        public static bool Add(Character chara)
        {
            string name = chara.Name;

            if (CharacterMap.map.ContainsKey(name))
            {
                return false;
            }

            CharacterMap.map.Add(name, chara);
            return true;
        }

        public static Character Get(string name)
        {
            if (CharacterMap.map.ContainsKey(name))
            {
                return CharacterMap.map[name];
            }

            return null;
        }

        public static List<Character> GetAll()
        {
            List<Character> list = new List<Character>();

            foreach (var chara in CharacterMap.map)
            {
                list.Add(chara.Value);
            }

            return list;
        }

        public static void Clear()
        {
            CharacterMap.map.Clear();
        }
    }
}
