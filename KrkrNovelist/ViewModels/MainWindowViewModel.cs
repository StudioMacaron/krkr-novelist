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

namespace KrkrNovelist.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand AddCharaCmd { get; set; }

        public ICommand AddBackgroundCmd { get; set; }

        public ICommand AddBGMCmd { get; set; }

        public ICommand AddSECmd { get; set; }

        public ICommand OpenProjectCmd { get; set; }

        public ICommand SaveProjectCmd { get; set; }

        public ICommand SaveProjectAsNewNameCmd { get; set; }

        public ICommand OperatePageCmd { get; set; }

        public ReactiveProperty<string> Title { get; set; }

        public ReactiveProperty<ProjectIO> Project { get; set; } = new ReactiveProperty<ProjectIO>();

        public ReactiveCollection<CharacterThumbViewModel> CharacterThumbs { get; set; } = new ReactiveCollection<CharacterThumbViewModel>();

        public ReactiveCollection<CharacterThumbViewModel> LeftCharacterThumbs { get; set; }

        public ReactiveCollection<CharacterThumbViewModel> RightCharacterThumbs { get; set; }

        public ReactiveCollection<BackgroundThumbViewModel> BackgroundThumbs { get; set; } = new ReactiveCollection<BackgroundThumbViewModel>();

        public ReactiveCollection<BackgroundThumbViewModel> LeftBackgroundThumbs { get; set; }

        public ReactiveCollection<BackgroundThumbViewModel> RightBackgroundThumbs { get; set; }

        public ReactiveProperty<Pages.Page> Page { get; set; }

        public Pages.Paginator Paginator;

        public MainWindowViewModel()
        {
            this.AddCharaCmd = new AddCharacterCommand(this);
            this.AddBackgroundCmd = new AddBackgroundCommand(this);
            this.AddBGMCmd = new AddBGMCommand();
            this.AddSECmd = new AddSECommand();
            this.OpenProjectCmd = new OpenProjectCommand(this);
            this.SaveProjectCmd = new SaveProjectCommand(this, true);
            this.SaveProjectAsNewNameCmd = new SaveProjectCommand(this);
            this.OperatePageCmd = new OperatePageCommand(this);

            this.LeftCharacterThumbs = this.CharacterThumbs.ToObservable()
                                                           .Where((chara, index) => index % 2 == 0)
                                                           .ToReactiveCollection();

            this.RightCharacterThumbs = this.CharacterThumbs.ToObservable()
                                                            .Where((chara, index) => index % 2 != 0)
                                                            .ToReactiveCollection();

            this.LeftBackgroundThumbs = this.BackgroundThumbs.ToObservable()
                                                             .Where((background, index) => index % 2 == 0)
                                                             .ToReactiveCollection();

            this.RightBackgroundThumbs = this.BackgroundThumbs.ToObservable()
                                                              .Where((background, index) => index % 2 != 0)
                                                              .ToReactiveCollection();

            this.Title = this.Project.Select(s => "KrkrNovelist " + s?.Path).ToReactiveProperty();

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

            Pages.Page page = new Pages.Page()
            {
                Scenario = "",
                LeftCharacter = defaultCharacter,
                CenterCharacter = defaultCharacter,
                RightCharacter = defaultCharacter,
                HasChangedBackground = true,
                Background = defaultBackground,
                HasChangedBGM = false
            };
            this.Page = new ReactiveProperty<Pages.Page>(page);
            this.Paginator = new Pages.Paginator(Page);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}