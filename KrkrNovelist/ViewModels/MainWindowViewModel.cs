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
using KrkrNovelist.Models;
using KrkrNovelist.ViewModels;

namespace KrkrNovelist.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand AddCharaCmd { get; set; }

        public ICommand AddBackgroundCmd { get; set; }

        public ICommand AddBGMCmd { get; set; }

        public ICommand AddSECmd { get; set; }

        public ReactiveCollection<CharacterThumbViewModel> CharacterThumbs { get; set; } = new ReactiveCollection<CharacterThumbViewModel>();

        public ReactiveCollection<CharacterThumbViewModel> LeftCharacterThumbs { get; set; }

        public ReactiveCollection<CharacterThumbViewModel> RightCharacterThumbs { get; set; }

        public MainWindowViewModel()
        {
            this.AddCharaCmd = new AddCharacterCommand(this);
            this.AddBackgroundCmd = new AddBackgroundCommand();
            this.AddBGMCmd = new AddBGMCommand();
            this.AddSECmd = new AddSECommand();

            this.LeftCharacterThumbs = this.CharacterThumbs.ToObservable()
                                                           .Where((chara, index) => index % 2 == 0)
                                                           .ToReactiveCollection();

            this.RightCharacterThumbs = this.CharacterThumbs.ToObservable()
                                                            .Where((chara, index) => index % 2 != 0)
                                                            .ToReactiveCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}