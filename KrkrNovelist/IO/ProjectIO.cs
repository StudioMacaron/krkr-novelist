using Newtonsoft.Json;
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
            dynamic jsonData;

            using (var sr = new StreamReader(this.Path, System.Text.Encoding.UTF8))
            {
                var json = sr.ReadToEnd();
                jsonData = JsonConvert.DeserializeObject<dynamic>(json);
            }

            CharacterMap.Clear();
            BackgroundMap.Clear();
            BGMMap.Clear();
            SEMap.Clear();

            foreach (var header in jsonData.headers)
            {
                foreach (var character in header.character_list)
                {
                    CharacterMap.Add(new Character()
                    {
                        Path = character.path,
                        Name = character.name,
                        Expression = character.expression
                    });
                }

                foreach (var background in header.background_list)
                {
                    BackgroundMap.Add(new Background()
                    {
                        Path = background.path,
                        Name = background.name
                    });
                }

                foreach (var bgm in header.bgm_list)
                {
                    BGMMap.Add(new BGM()
                    {
                        Path = bgm.path,
                        Name = bgm.name
                    });
                }

                foreach (var se in header.se_list)
                {
                    SEMap.Add(new SE()
                    {
                        Path = se.path,
                        Name = se.name
                    });
                }
            }

            foreach (var page in jsonData.pages)
            {
                
            }

            return storage;
        }

        public void Write(PageStorage storage)
        {
            Dictionary<string, dynamic> jsonData = new Dictionary<string, dynamic>();
            jsonData["header"] = new Dictionary<string, dynamic>();
            jsonData["header"]["character_list"] = new List<Dictionary<string, string>>();
            jsonData["header"]["background_list"] = new List<Dictionary<string, string>>();
            jsonData["header"]["bgm_list"] = new List<Dictionary<string, string>>();
            jsonData["header"]["se_list"] = new List<Dictionary<string, string>>();

            foreach (Character chara in CharacterMap.GetAll())
            {
                Dictionary<string, string> charaDict = new Dictionary<string, string>();
                charaDict.Add("path", chara.Path);
                charaDict.Add("name", chara.Name);
                charaDict.Add("expression", chara.Expression);
                jsonData["header"]["character_list"].Add(charaDict);
            }

            foreach (Background background in BackgroundMap.GetAll())
            {
                Dictionary<string, string> backgroundDict = new Dictionary<string, string>();
                backgroundDict.Add("path", background.Path);
                backgroundDict.Add("name", background.Name);
                jsonData["header"]["background_list"].Add(backgroundDict);
            }

            foreach (BGM bgm in BGMMap.GetAll())
            {
                Dictionary<string, string> bgmDict = new Dictionary<string, string>();
                bgmDict.Add("path", bgm.Path);
                bgmDict.Add("name", bgm.Name);
                jsonData["header"]["bgm_list"].Add(bgmDict);
            }

            foreach (SE se in SEMap.GetAll())
            {
                Dictionary<string, string> seDict = new Dictionary<string, string>();
                seDict.Add("path", se.Path);
                seDict.Add("name", se.Name);
                jsonData["header"]["se_list"].Add(seDict);
            }
            string json = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            Debug.Print(json);
        }
    }
}
