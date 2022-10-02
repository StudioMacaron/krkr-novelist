using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrkrNovelist.ViewModels;

namespace KrkrNovelist.Pages
{
    public class PageStorage
    {
        private List<PageViewModel> pages = new List<PageViewModel>();

        public int Count
        {
            get { return pages.Count; }
        }

        public void Add(PageViewModel page)
        {
            this.pages.Add(page);
        }

        public void Insert(int index, PageViewModel page)
        {
            this.pages.Insert(index, page);
        }

        public PageViewModel Get(int index)
        {
            if (0 <= index && index < pages.Count)
            {
                return this.pages[index];
            }

            return null;
        }

        public void Set(int index, PageViewModel page)
        {
            this.pages[index] = page;
        }

        public void Delete(int index)
        {
            this.pages.RemoveAt(index);
        }

    }
}
