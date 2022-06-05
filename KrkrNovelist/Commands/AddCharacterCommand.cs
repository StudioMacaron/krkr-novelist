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
    public class AddCharacterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        public AddCharacterCommand(MainWindowViewModel vm)
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
                AddCharacterWindowViewModel vm = new AddCharacterWindowViewModel();
                Window window = new AddCharacterWindow()
                {
                    DataContext = vm
                };

                if (window.ShowDialog() == true)
                {
                    Character chara = new Character()
                    {
                        Path = dialog.FileName,
                        Name = vm.Name.Value,
                        Expression = vm.Expression.Value
                    };
                    
                    if (CharacterMap.Add(chara))
                    {
                        this._vm.CharacterThumbs.Add(new CharacterThumbViewModel(chara));
                        if (this._vm.CharacterThumbs.Count % 2 == 0)
                        {
                            this._vm.RightCharacterThumbs.Add(new CharacterThumbViewModel(chara));
                        }
                        else
                        {
                            this._vm.LeftCharacterThumbs.Add(new CharacterThumbViewModel(chara));
                        }

                        MessageBox.Show(chara.Name + " を追加しました。");
                    }
                    else
                    {
                        MessageBox.Show("既にキャラクターが追加されています。");
                    }
                }
            }
        }
    }
}
