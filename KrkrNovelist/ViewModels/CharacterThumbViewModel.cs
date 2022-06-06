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
    public class CharacterThumbViewModel : INotifyPropertyChanged
    {
        private readonly CompositeDisposable _cd = new CompositeDisposable();

        public ReactiveProperty<Character> Character { get; set; }

        public ReadOnlyReactiveProperty<string> Path { get; }

        public ReadOnlyReactiveProperty<string> Name { get; }

        public ReadOnlyReactiveProperty<string> Expression { get; }

        public ReadOnlyReactiveProperty<string> DisplayName { get; }

        public CharacterThumbViewModel Instance { get; }

        public MainWindowViewModel OwnerViewModel { get; }

        public ICommand SetCharacterCmd { get; set; }

        public CharacterThumbViewModel(MainWindowViewModel owner, Character chara)
        {
            this.Character = new ReactiveProperty<Character>(chara).AddTo(this._cd);
            this.Path = this.Character.Select(chara => chara.Path).ToReadOnlyReactiveProperty().AddTo(this._cd);
            this.Name = this.Character.Select(chara => chara.Name).ToReadOnlyReactiveProperty().AddTo(this._cd);
            this.Expression = this.Character.Select(chara => chara.Expression).ToReadOnlyReactiveProperty().AddTo(this._cd);
            this.DisplayName = this.Name.CombineLatest(
                this.Expression,
                (name, expression) => name + "（" + expression + "）").ToReadOnlyReactiveProperty().AddTo(this._cd);
            this.Instance = this;
            this.OwnerViewModel = owner;
            this.SetCharacterCmd = new SetCharacterCommand(owner, chara);
        }

        public void Dispose() => this._cd.Dispose();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
