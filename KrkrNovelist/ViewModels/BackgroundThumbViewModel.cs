using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using KrkrNovelist.Commands;
using KrkrNovelist.Models;

namespace KrkrNovelist.ViewModels
{
    public class BackgroundThumbViewModel : INotifyPropertyChanged
    {
        public ICommand SetBackgroundCmd { get; set; }

        private readonly CompositeDisposable _cd = new CompositeDisposable();

        public ReactiveProperty<Background> Background { get; set; }

        public ReadOnlyReactiveProperty<string> Path { get; }

        public ReadOnlyReactiveProperty<string> Name { get; }

        public ReadOnlyReactiveProperty<string> DisplayName { get; }

        public BackgroundThumbViewModel Instance { get; }

        public MainWindowViewModel OwnerViewModel { get; }

        public BackgroundThumbViewModel(MainWindowViewModel owner, Background background)
        {
            this.Background = new ReactiveProperty<Background>(background).AddTo(this._cd);
            this.Path = this.Background.Select(background => background.Path).ToReadOnlyReactiveProperty().AddTo(this._cd);
            this.Name = this.Background.Select(background => background.Name).ToReadOnlyReactiveProperty().AddTo(this._cd);
            this.Instance = this;
            this.OwnerViewModel = owner;
            this.SetBackgroundCmd = new SetBackgroundCommand(this.OwnerViewModel, background);
        }

        public void Dispose() => this._cd.Dispose();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
