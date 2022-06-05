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
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using KrkrNovelist.Commands;

namespace KrkrNovelist.ViewModels
{
    public class InputNameWindowViewModel : INotifyPropertyChanged
    {
        private readonly CompositeDisposable _cd = new CompositeDisposable();

        public ReactiveProperty<string> Name { get; set; }

        public ReactiveCommand CloseWindowCommand { get; } = new ReactiveCommand();

        public InputNameWindowViewModel()
        {
            this.Name = new ReactiveProperty<string>().AddTo(this._cd);
            this.CloseWindowCommand.Subscribe((x) =>
                {
                    ((Window)x).DialogResult = true;
                    ((Window)x).Close();
                }
            );
        }

        public void Dispose() => this._cd.Dispose();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}