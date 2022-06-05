using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrkrNovelist.Pages
{
    public class PageStorage
    {
        public List<Page> pages = new List<Page>();

        public void Add(Page page)
        {
            this.pages.Add(page);
        }

        public Page Get(int index)
        {
            if (index < pages.Count)
            {
                return this.pages[index];
            }

            return null;
        }
    }
}
