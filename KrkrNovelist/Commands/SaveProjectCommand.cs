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

        private bool _overwrite;

        public SaveProjectCommand(MainWindowViewModel vm, bool overwrite = false)
        {
            this._vm = vm;
            this._overwrite = overwrite;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (this._overwrite && this._vm.Project != null)
            {
                this._vm.Project.Value.Write(new PageStorage());
                MessageBox.Show("保存しました。");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "KrkrNovelistプロジェクト|*.knp";

            if (dialog.ShowDialog() == true)
            {
                this._vm.Project.Value = new ProjectIO(dialog.FileName);
                this._vm.Project.Value.Write(new PageStorage()); // TODO : PageStorageの実装
            }
        }
    }
}
