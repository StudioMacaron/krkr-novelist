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
    class SetCharacterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        private Character _chara;

        public SetCharacterCommand(MainWindowViewModel vm, Character chara)
        {
            this._vm = vm;
            this._chara = chara;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PageViewModel page = _vm.Paginator.CurrentPage;
            SetCharacterParameter position = (SetCharacterParameter)Enum.Parse(typeof(SetCharacterParameter), (string)parameter, true);
            switch (position)
            {
                case SetCharacterParameter.LEFT:
                    page.LeftCharacter.Data.Value = this._chara;
                    break;
                case SetCharacterParameter.CENTER:
                    page.CenterCharacter.Data.Value = this._chara;
                    break;
                case SetCharacterParameter.RIGHT:
                    page.RightCharacter.Data.Value = this._chara;
                    break;
            }
        }
    }
}

public enum SetCharacterParameter
{
    LEFT, CENTER, RIGHT
}