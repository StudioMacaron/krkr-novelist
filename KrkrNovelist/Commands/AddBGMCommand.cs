using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.Diagnostics;
using KrkrNovelist.IO;
using KrkrNovelist.Models;
using KrkrNovelist.Pages;
using KrkrNovelist.Map;
using KrkrNovelist.Views;
using KrkrNovelist.ViewModels;

namespace KrkrNovelist.Commands
{
    public class AddBGMCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "音楽ファイル|*.wav;*.mp3;*.ogg";

            if (dialog.ShowDialog() == true)
            {
                InputNameWindowViewModel vm = new InputNameWindowViewModel();
                Window window = new InputNameWindow()
                {
                    DataContext = vm
                };

                if (window.ShowDialog() == true)
                {
                    BGM bgm = new BGM()
                    {
                        Path = dialog.FileName,
                        Name = vm.Name.Value
                    };
                    BGMMap.Add(bgm);
                    MessageBox.Show(vm.Name.Value + " を追加しました。");
                }
            }
        }
    }
}
