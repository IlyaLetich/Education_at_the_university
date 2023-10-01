using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    public class PageNavigatorRadioButton : RadioButton
    {
        public static DependencyProperty ImagePathProperty;
        public static DependencyProperty SizeImageProperty;

        static PageNavigatorRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PageNavigatorRadioButton), new FrameworkPropertyMetadata(typeof(PageNavigatorRadioButton)));
            ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(DependencyProperty));
            SizeImageProperty = DependencyProperty.Register("SizeImage", typeof(int), typeof(DependencyProperty));
        }

        public string ImagePath
        {
            get
            {
                return (string)GetValue(ImagePathProperty);
            }
            set
            {
                SetValue(ImagePathProperty, value);
            }
        }

        public int SizeImage
        {
            get
            {
                return (int)GetValue(SizeImageProperty);
            }
            set
            {
                SetValue(SizeImageProperty, value);
            }
        }
    }
}
