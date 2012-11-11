using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3.Control
{
    /// <summary>
    /// CxCloseButton.xaml 的交互逻辑
    /// </summary>
    public partial class CxCloseButton : UserControl
    {
        public CxCloseButton()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Border MouseEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091029</date>
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            border.Background = (Brush)Application.Current.Resources["HotRedBrush"];
            line1.Stroke = (Brush)Application.Current.Resources["WhiteBrush"];
            line2.Stroke = (Brush)Application.Current.Resources["WhiteBrush"];
        }


        /// <summary>
        /// Border MouseLeftButtonDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091029</date>
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            border.Background = (Brush)Application.Current.Resources["HotRedBrush"];
            line1.Stroke = (Brush)Application.Current.Resources["WhiteBrush"];
            line2.Stroke = (Brush)Application.Current.Resources["WhiteBrush"];
        }

        /// <summary>
        /// Border MouseLeftButtonUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091029</date>
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            border.Background = (Brush)Application.Current.Resources["HotRedBrush"];
            line1.Stroke = (Brush)Application.Current.Resources["WhiteBrush"];
            line2.Stroke = (Brush)Application.Current.Resources["WhiteBrush"];
        }

        /// <summary>
        /// Mouse Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            border.Background = new SolidColorBrush(Colors.Transparent);
            line1.Stroke =  (Brush)Application.Current.Resources["NavigationPanelArrowBrush"];
            line2.Stroke =  (Brush)Application.Current.Resources["NavigationPanelArrowBrush"];
        }
    }
}
