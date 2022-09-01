using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrkrNovelist.Pages
{
    public class PageStorage
    {
        private List<Page> pages = new List<Page>();

        public int Count
        {
            get { return pages.Count; }
        }

        public void Add(Page page)
        {
            this.pages.Add(page);
        }

        public void Insert(int index, Page page)
        {
            this.pages.Insert(index, page);
        }

        public Page Get(int index)
        {
            if (0 <= index && index < pages.Count)
            {
                return this.pages[index];
            }

            return null;
        }
    }
}
