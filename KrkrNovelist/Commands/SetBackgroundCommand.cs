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
    class SetBackgroundCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        private Background _bg;

        public SetBackgroundCommand(MainWindowViewModel vm, Background bg)
        {
            this._vm = vm;
            this._bg = bg;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Page page = new Page()
            {
                Scenario = this._vm.Page.Value.Scenario,
                HasChangedBackground = this._vm.Page.Value.HasChangedBackground,
                HasChangedBGM = this._vm.Page.Value.HasChangedBGM,
                LeftCharacter = this._vm.Page.Value.LeftCharacter,
                CenterCharacter = this._vm.Page.Value.CenterCharacter,
                RightCharacter = this._vm.Page.Value.RightCharacter,
                Background = this._bg,
                BGM = this._vm.Page.Value.BGM,
                SE = this._vm.Page.Value.SE
            };
            page.Background = this._bg;
            this._vm.Page.Value = page;
        }
    }
}
