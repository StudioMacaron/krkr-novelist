using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrkrNovelist.Models;

namespace KrkrNovelist.Pages
{
    public class Page
    {
        public string Scenario { get; set; }

        public Character LeftCharacter { get; set; }

        public Character CenterCharacter { get; set; }

        public Character RightCharacter { get; set; }

        public bool HasChangedBackground { get; set; }

        public Background Background { get; set; }

        public bool HasChangedBGM { get; set; }

        public BGM BGM { get; set; }

        public SE SE { get; set; }
    }
}
