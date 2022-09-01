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
    class InsertPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        public InsertPageCommand(MainWindowViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._vm.Paginator.Insert();
        }
    }
}

