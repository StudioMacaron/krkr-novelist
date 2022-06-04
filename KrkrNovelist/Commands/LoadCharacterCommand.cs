using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using KrkrNovelist.IO;
using KrkrNovelist.Models;
using KrkrNovelist.Pages;
using KrkrNovelist.Map;

namespace KrkrNovelist.Commands
{
    public class LoadCharacterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // デバッグ用
            ProjectIO project = new ProjectIO("a");
            Character chara = new()
            {
                Path = "test.png",
                Name = "恋鞠",
                Expression = "困り"
            };
            Background bg = new()
            {
                Path = "a.png",
                Name = "富嶽三十六景"
            };
            BGM bgm = new()
            {
                Path = "a.wav",
                Name = "testbgm"
            };
            SE se = new()
            {
                Path = "b.wav",
                Name = "testse"
            };
            CharacterMap.Add(chara);
            BackgroundMap.Add(bg);
            BGMMap.Add(bgm);
            SEMap.Add(se);

            project.Write(new PageStorage());
            MessageBox.Show("TestCommand!");
        }
    }
}
