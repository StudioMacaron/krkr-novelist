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
        public ReactiveProperty<Pages.Page> Data { get; set; } 

        public PageViewModel()
        {
            Background defaultBackground = new Background()
            {
                Name = "Default Background",
                Path = "\\Resources\\default_background.png"
            };
            Character defaultCharacter = new Character()
            {
                Name = "Default Chracter",
                Path = "\\Resources\\transparent.png",
                Expression = ""
            };
            Pages.Page defaultPage = new Pages.Page()
            {
                Scenario = "",
                LeftCharacter = defaultCharacter,
                CenterCharacter = defaultCharacter,
                RightCharacter = defaultCharacter,
                HasChangedBackground = true,
                Background = defaultBackground,
                HasChangedBGM = false
            };

            this.Data = new ReactiveProperty<Pages.Page>(defaultPage);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
