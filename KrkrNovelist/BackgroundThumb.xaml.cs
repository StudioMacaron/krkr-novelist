using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using KrkrNovelist.Commands;
using KrkrNovelist.ViewModels;
using KrkrNovelist.Models;

namespace KrkrNovelist
{
    /// <summary>
    /// BackgroundThumb.xaml の相互作用ロジック
    /// </summary>
    public partial class BackgroundThumb : Thumb
    {
        public BackgroundThumb()
        {
            InitializeComponent();
        }

        private Thumb _selectedBackgroundThumb;

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var border = thumb.Template.FindName("Background_Thumb_Border", thumb) as Border;
                if (border != null)
                {
                    if (_selectedBackgroundThumb != null)
                    {
                        var selectedBorder = _selectedBackgroundThumb.Template.FindName("Background_Thumb_Border", _selectedBackgroundThumb) as Border;
                        selectedBorder.BorderThickness = new Thickness(0);
                    }
                    border.BorderThickness = new Thickness(1);
                    _selectedBackgroundThumb = thumb;
                }
            }
        }
    }
}
