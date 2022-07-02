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
    class OperatePageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        public OperatePageCommand(MainWindowViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OperatePageParameter kind = (OperatePageParameter)Enum.Parse(typeof(OperatePageParameter), (string)parameter, true);
            switch (kind)
            {
                case OperatePageParameter.MOVE_PREV:
                    this._vm.Paginator.MovePrev();
                    break;
                case OperatePageParameter.MOVE_NEXT:
                    this._vm.Paginator.MoveNext();
                    break;
                case OperatePageParameter.INSERT:
                    this._vm.Paginator.Insert();
                    break;
            }
        }
    }
}

public enum OperatePageParameter
{
    MOVE_PREV, MOVE_NEXT, INSERT
}
