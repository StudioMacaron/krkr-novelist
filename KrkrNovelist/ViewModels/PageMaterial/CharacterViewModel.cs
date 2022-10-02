using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using System.ComponentModel;
using KrkrNovelist.Models;
using KrkrNovelist.ViewModels.PageMaterial;

namespace KrkrNovelist.ViewModels.PageMaterial
{
    public class CharacterViewModel : IMaterialViewModel<Character>, INotifyPropertyChanged
    {
        public ReactiveProperty<Character> Data { get; set; } = new();

        public CharacterViewModel(Character character)
        {
            this.Data.Value = character;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
