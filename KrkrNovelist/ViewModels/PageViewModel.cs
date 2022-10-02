using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Helpers;
using Reactive.Bindings.Extensions;
using KrkrNovelist.Commands;
using KrkrNovelist.IO;
using KrkrNovelist.Models;
using KrkrNovelist.ViewModels;
using KrkrNovelist.Pages;

namespace KrkrNovelist.ViewModels
{
    public class PageViewModel : INotifyPropertyChanged
    {
        public ReactiveProperty<string> Scenario { get; set; }

        public Character LeftCharacter { get; set; }

        public Character CenterCharacter { get; set; }

        public Character RightCharacter { get; set; }

        public bool HasChangedBackground { get; set; }

        public ReactiveProperty<Background> Background { get; set; }

        public bool HasChangedBGM { get; set; }

        public ReactiveProperty<BGM> BGM { get; set; }

        public ReactiveProperty<SE> SE { get; set; }

        public PageViewModel(
            string scenario = default,
            Character leftCharacter = default,
            Character centerCharacter = default,
            Character rightCharacter = default,
            Background background = default,
            BGM bgm = default,
            SE se = default
        )
        {
            Scenario.Value = scenario;
            LeftCharacter = leftCharacter;
            CenterCharacter = centerCharacter;
            RightCharacter = rightCharacter;
            Background.Value = background;
            BGM.Value = bgm;
            SE.Value = se;

            if (string.IsNullOrEmpty(Background?.Value.Path))
            {
                HasChangedBackground = true;
            }
            if (!string.IsNullOrEmpty(BGM?.Value.Path))
            {
                HasChangedBGM = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
