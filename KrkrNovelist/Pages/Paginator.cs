using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Reactive.Bindings;

namespace KrkrNovelist.Pages
{
    public class Paginator
    {
        private int _currentIndex;

        public int CurrentIndex
        {
            get { return _currentIndex; }
        }

        private ReactiveProperty<Page> _page;

        public PageStorage Storage = new PageStorage();

        public Paginator(ReactiveProperty<Page> page)
        {
            _currentIndex = 0;
            _page = page;
            Storage.Add(page.Value);
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
            var currentPage = _page.Value;
            Page newPage = new Page()
            {
                LeftCharacter = currentPage.LeftCharacter,
                CenterCharacter = currentPage.CenterCharacter,
                RightCharacter = currentPage.RightCharacter,
                HasChangedBackground = currentPage.HasChangedBackground,
                Background = currentPage.Background,
            };
            _currentIndex++;
            Storage.Insert(_currentIndex, newPage);
            _page.Value = newPage;
        }
    }
}

