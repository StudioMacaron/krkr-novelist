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
                Scenario = this._vm.Page.Data.Value.Scenario,
                HasChangedBackground = this._vm.Page.Data.Value.HasChangedBackground,
                HasChangedBGM = this._vm.Page.Data.Value.HasChangedBGM,
                LeftCharacter = this._vm.Page.Data.Value.LeftCharacter,
                CenterCharacter = this._vm.Page.Data.Value.CenterCharacter,
                RightCharacter = this._vm.Page.Data.Value.RightCharacter,
                Background = this._vm.Page.Data.Value.Background,
                BGM = this._vm.Page.Data.Value.BGM,
                SE = this._vm.Page.Data.Value.SE
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

            this._vm.Page.Data.Value = page;
        }
    }
}

public enum SetCharacterParameter
{
    LEFT, CENTER, RIGHT
}