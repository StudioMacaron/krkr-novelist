using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string hash = Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes("name=" + chara.Name + "expression=" +chara.Expression)));

            if (CharacterMap.map.ContainsKey(hash))
            {
                return false;
            }

            CharacterMap.map.Add(hash, chara);
            return true;
        }

        public static Character Get(string name, string expression)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string hash = Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes("name=" + name + "expression=" + expression)));

            if (CharacterMap.map.ContainsKey(hash))
            {
                return CharacterMap.map[hash];
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
