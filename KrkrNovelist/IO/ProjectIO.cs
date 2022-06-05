using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using KrkrNovelist.Models;
using KrkrNovelist.Map;
using KrkrNovelist.Pages;

namespace KrkrNovelist.IO
{
    class ProjectIO
    {
        public string Path { get; set; }

        public ProjectIO(string path)
        {
            this.Path = path;
        }

        public PageStorage Read()
        {
            PageStorage storage = new PageStorage();
            JObject jsonData;

            using (var sr = new StreamReader(this.Path, System.Text.Encoding.UTF8))
            {
                var json = sr.ReadToEnd();
                jsonData = JsonConvert.DeserializeObject<JObject>(json);
            }

            CharacterMap.Clear();
            BackgroundMap.Clear();
            BGMMap.Clear();
            SEMap.Clear();

            foreach (JObject character in (JArray)jsonData["headers"]["character_list"])
            {
                CharacterMap.Add(new Character()
                {
                    Path = (string)character["path"],
                    Name = (string)character["name"],
                    Expression = (string)character["expression"]
                });
            }

            foreach (JObject background in (JArray)jsonData["headers"]["background_list"])
            {
                BackgroundMap.Add(new Background()
                {
                    Path = (string)background["path"],
                    Name = (string)background["name"]
                });
            }


            foreach (JObject bgm in (JArray)jsonData["headers"]["bgm_list"])
            {
                BGMMap.Add(new BGM()
                {
                    Path = (string)bgm["path"],
                    Name = (string)bgm["name"]
                });
            }


            foreach (JObject se in (JArray)jsonData["headers"]["se_list"])
            {
                SEMap.Add(new SE()
                {
                    Path = (string)se["path"],
                    Name = (string)se["name"]
                });
            }

            return storage;
        }

        public void Write(PageStorage storage)
        {
            Dictionary<string, dynamic> jsonData = new Dictionary<string, dynamic>();
            jsonData["headers"] = new Dictionary<string, dynamic>();
            jsonData["headers"]["character_list"] = new List<Dictionary<string, string>>();
            jsonData["headers"]["background_list"] = new List<Dictionary<string, string>>();
            jsonData["headers"]["bgm_list"] = new List<Dictionary<string, string>>();
            jsonData["headers"]["se_list"] = new List<Dictionary<string, string>>();

            foreach (Character chara in CharacterMap.GetAll())
            {
                Dictionary<string, string> charaDict = new Dictionary<string, string>();
                charaDict.Add("path", chara.Path);
                charaDict.Add("name", chara.Name);
                charaDict.Add("expression", chara.Expression);
                jsonData["headers"]["character_list"].Add(charaDict);
            }

            foreach (Background background in BackgroundMap.GetAll())
            {
                Dictionary<string, string> backgroundDict = new Dictionary<string, string>();
                backgroundDict.Add("path", background.Path);
                backgroundDict.Add("name", background.Name);
                jsonData["headers"]["background_list"].Add(backgroundDict);
            }

            foreach (BGM bgm in BGMMap.GetAll())
            {
                Dictionary<string, string> bgmDict = new Dictionary<string, string>();
                bgmDict.Add("path", bgm.Path);
                bgmDict.Add("name", bgm.Name);
                jsonData["headers"]["bgm_list"].Add(bgmDict);
            }

            foreach (SE se in SEMap.GetAll())
            {
                Dictionary<string, string> seDict = new Dictionary<string, string>();
                seDict.Add("path", se.Path);
                seDict.Add("name", se.Name);
                jsonData["headers"]["se_list"].Add(seDict);
            }
            string json = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            File.WriteAllText(this.Path, json);
        }
    }
}
