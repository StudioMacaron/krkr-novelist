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
            PageViewModel page = _vm.Paginator.CurrentPage;
            page.Background.Value = this._bg;
        }
    }
}
