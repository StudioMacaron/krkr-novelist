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
    /// CharacterThumb.xaml の相互作用ロジック
    /// </summary>
    public partial class CharacterThumb : Thumb
    {
        public CharacterThumb()
        {
            InitializeComponent();
        }

        private Thumb _selectedThumb;

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var border = thumb.Template.FindName("Thumb_Border", thumb) as Border;
                if (border != null)
                {
                    if (_selectedThumb != null)
                    {
                        var selectedBorder = _selectedThumb.Template.FindName("Thumb_Border", _selectedThumb) as Border;
                        selectedBorder.BorderThickness = new Thickness(0);
                    }
                    border.BorderThickness = new Thickness(1);
                    _selectedThumb = thumb;
                }
            }
        }
    }
}
