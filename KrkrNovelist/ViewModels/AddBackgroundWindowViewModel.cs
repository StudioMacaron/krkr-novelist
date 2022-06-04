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
using System.Diagnostics;
using Reactive.Bindings;
using KrkrNovelist.Commands;

namespace KrkrNovelist.ViewModels
{
    public class AddBackgroundWindowViewModel
    {
        public string BackgroundName { get; set; }

        public ReactiveCommand CloseWindowCommand { get; } = new ReactiveCommand();

        public AddBackgroundWindowViewModel()
        {
            CloseWindowCommand.Subscribe((x) =>
                {
                    ((Window)x).DialogResult = true;
                    ((Window)x).Close();
                }
            );
        }

    }
}