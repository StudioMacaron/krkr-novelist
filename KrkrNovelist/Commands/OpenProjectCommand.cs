using System;
using System.Windows.Input;
using Microsoft.Win32;
using System.Reactive.Linq;
using Reactive.Bindings;
using KrkrNovelist.IO;
using KrkrNovelist.Models;
using KrkrNovelist.Map;
using KrkrNovelist.ViewModels;

namespace KrkrNovelist.Commands
{
    public class OpenProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainWindowViewModel _vm;

        public OpenProjectCommand(MainWindowViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "KrkrNovelistプロジェクト|*.knp";

            if (dialog.ShowDialog() == true)
            {
                this._vm.Project.Value = new ProjectIO(dialog.FileName);
                this._vm.Project.Value.Read();
                
                this._vm.CharacterThumbs.Clear();
                this._vm.BackgroundThumbs.Clear();
                this._vm.RightCharacterThumbs.Clear();
                this._vm.LeftCharacterThumbs.Clear();
                this._vm.RightBackgroundThumbs.Clear();
                this._vm.LeftBackgroundThumbs.Clear();

                foreach (Character chara in CharacterMap.GetAll())
                {
                    this._vm.CharacterThumbs.Add(new CharacterThumbViewModel(chara));
                    if (this._vm.CharacterThumbs.Count % 2 == 0)
                    {
                        this._vm.RightCharacterThumbs.Add(new CharacterThumbViewModel(chara));
                    }
                    else
                    {
                        this._vm.LeftCharacterThumbs.Add(new CharacterThumbViewModel(chara));
                    }
                }

                foreach (Background background in BackgroundMap.GetAll())
                {
                    this._vm.BackgroundThumbs.Add(new BackgroundThumbViewModel(this._vm, background));
                    if (this._vm.BackgroundThumbs.Count % 2 == 0)
                    {
                        this._vm.RightBackgroundThumbs.Add(new BackgroundThumbViewModel(this._vm, background));
                    }
                    else
                    {
                        this._vm.LeftBackgroundThumbs.Add(new BackgroundThumbViewModel(this._vm, background));
                    }
                }
            }
        }
    }
}
