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
    class MovePageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        public MovePageCommand(MainWindowViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MovePageParameter kind = (MovePageParameter)Enum.Parse(typeof(MovePageParameter), (string)parameter, true);
            switch (kind)
            {
                case MovePageParameter.PREV:
                    this._vm.Paginator.MovePrev();
                    break;
                case MovePageParameter.NEXT:
                    this._vm.Paginator.MoveNext();
                    break;
            }
        }
    }
}

public enum MovePageParameter
{
    PREV, NEXT
}
