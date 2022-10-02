using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using System.ComponentModel;
using KrkrNovelist.Models;
using KrkrNovelist.ViewModels.PageMaterial;
using KrkrNovelist.Commands;

namespace KrkrNovelist.ViewModels.PageMaterial
{
    public class CharacterViewModel : IMaterialViewModel<Character>, INotifyPropertyChanged
    {
        public ReactiveProperty<Character> Data { get; set; } = new();

        public RemoveMaterialCommand<Character> RemoveCharacterCmd { get; set; }

        public CharacterViewModel(Character character)
        {
            Data.Value = character;
            RemoveCharacterCmd = new RemoveMaterialCommand<Character>(this);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
