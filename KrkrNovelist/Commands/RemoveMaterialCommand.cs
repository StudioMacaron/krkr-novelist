using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.Diagnostics;
using KrkrNovelist.IO;
using KrkrNovelist.Models;
using KrkrNovelist.Pages;
using KrkrNovelist.Map;
using KrkrNovelist.ViewModels.PageMaterial;

namespace KrkrNovelist.Commands
{
    /// <summary>
    /// IMaterialViewModelを継承しているViewModelからDataを削除する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RemoveMaterialCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private IMaterialViewModel<T> _vm;

        public RemoveMaterialCommand(IMaterialViewModel<T> vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.Data.Value = default;
        }
    }
}

