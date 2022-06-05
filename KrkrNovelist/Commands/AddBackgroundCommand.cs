using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.Diagnostics;
using KrkrNovelist.IO;
using KrkrNovelist.Models;
using KrkrNovelist.Pages;
using KrkrNovelist.Map;
using KrkrNovelist.ViewModels;

namespace KrkrNovelist.Commands
{
    public class AddBackgroundCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        public AddBackgroundCommand(MainWindowViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "画像ファイル|*.png;*.bmp;*.jpg";

            if (dialog.ShowDialog() == true)
            {
                InputNameWindowViewModel vm = new InputNameWindowViewModel();
                Window window = new InputNameWindow()
                {
                    DataContext = vm
                };

                if (window.ShowDialog() == true)
                {
                    Background bg = new Background()
                    {
                        Path = dialog.FileName,
                        Name = vm.Name.Value
                    };
                    BackgroundMap.Add(bg);

                    this._vm.BackgroundThumbs.Add(new BackgroundThumbViewModel(bg));

                    if (this._vm.BackgroundThumbs.Count % 2 == 0)
                    {
                        this._vm.RightBackgroundThumbs.Add(new BackgroundThumbViewModel(bg));
                    }
                    else
                    {
                        this._vm.LeftBackgroundThumbs.Add(new BackgroundThumbViewModel(bg));
                    }

                    MessageBox.Show(vm.Name.Value + " を追加しました。");
                }
            }
        }
    }
}
