using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Reactive.Bindings;
using KrkrNovelist.ViewModels;
using KrkrNovelist.Models;

namespace KrkrNovelist.Pages
{
    public class Paginator
    {
        private int _currentIndex;

        public int CurrentIndex
        {
            get { return _currentIndex; }
        }

        private ReactiveProperty<PageViewModel> _page = new();

        public PageViewModel CurrentPage
        {
            get { return Storage.Get(_currentIndex); }
            set { Storage.Set(_currentIndex, value); }
        }

        private Background _defaultBackground;

        private Character _defaultCharacter;

        public PageStorage Storage = new();

        public Paginator(
            ReactiveProperty<PageViewModel> page,
            Background background,
            Character character
        )
        {
            _currentIndex = 0;
            _page = page;
            Storage.Add(page.Value);

            _defaultBackground = background;
            _defaultCharacter = character;
        }

        public void MoveNext()
        {
            if (_currentIndex >= Storage.Count - 1)
            {
                return;
            }
            _currentIndex++;
            _page.Value = Storage.Get(_currentIndex);
        }

        public void MovePrev()
        {
            if (_currentIndex <= 0)
            {
                return;
            }
            _currentIndex--;
            _page.Value = Storage.Get(_currentIndex);
        }

        public void Insert()
        {
            var page = Storage.Get(_currentIndex);
            PageViewModel newPage = new(
                leftCharacter: page.LeftCharacter.Data.Value,
                centerCharacter: page.CenterCharacter.Data.Value,
                rightCharacter: page.RightCharacter.Data.Value,
                background: page.Background.Value
            );
            _currentIndex++;
            Storage.Insert(_currentIndex, newPage);
            _page.Value = newPage;
        }

        public void Delete()
        {
            Storage.Delete(_currentIndex);
            if (_currentIndex == 0)
            {
                PageViewModel newPage = new(
                    leftCharacter: _defaultCharacter,
                    centerCharacter: _defaultCharacter,
                    rightCharacter: _defaultCharacter,
                    background: _defaultBackground
                );
                Storage.Add(newPage);
            }
            else
            {
                _currentIndex--;
            }
            _page.Value = Storage.Get(_currentIndex);
        }
    }
}

