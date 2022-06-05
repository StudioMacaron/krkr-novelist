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
    public class SaveProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        public SaveProjectCommand(MainWindowViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "KrkrNovelistプロジェクト|*.knp";

            if (dialog.ShowDialog() == true)
            {
                ProjectIO projectIO = new ProjectIO(dialog.FileName);
                projectIO.Write(new PageStorage()); // TODO : PageStorageの実装
            }
        }
    }
}
