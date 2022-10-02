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
            Page page = new Page()
            {
                Scenario = this._vm.Page.Scenario,
                HasChangedBackground = this._vm.Page.HasChangedBackground,
                HasChangedBGM = this._vm.Page.HasChangedBGM,
                LeftCharacter = this._vm.Page.LeftCharacter,
                CenterCharacter = this._vm.Page.CenterCharacter,
                RightCharacter = this._vm.Page.RightCharacter,
                Background = this._vm.Page.Background,
                BGM = this._vm.Page.BGM,
                SE = this._vm.Page.SE
            };

            SetCharacterParameter position = (SetCharacterParameter)Enum.Parse(typeof(SetCharacterParameter), (string)parameter, true);
            switch (position)
            {
                case SetCharacterParameter.LEFT:
                    page.LeftCharacter = this._chara;
                    break;
                case SetCharacterParameter.CENTER:
                    page.CenterCharacter = this._chara;
                    break;
                case SetCharacterParameter.RIGHT:
                    page.RightCharacter = this._chara;
                    break;
            }

            this._vm.Page = page;
        }
    }
}

public enum SetCharacterParameter
{
    LEFT, CENTER, RIGHT
}