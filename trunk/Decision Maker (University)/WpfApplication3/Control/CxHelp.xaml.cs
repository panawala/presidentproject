
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
    /// CxHelp.xaml 的交互逻辑
    /// </summary>
    public partial class CxHelp : UserControl
    {
        public CxHelp()
        {
            InitializeComponent();
        }



        /// <summary>
        /// HelpButton  Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>ZhangMiao</author>
        /// <date>20090407</date>


        /*private void helpButtonBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CxExplain helpcontent = CxExplain.getInstance();
            helpcontent.SetContent("该球的三维坐标分别代表生态、经济、社会的指标或者发展趋势，其中的一个点定位一个综合指标值");
            helpcontent.Show();
           
        }*/
        /// <summary>
        /// HelpButton Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>ZhangMiao</author>
        /// <date>20090407</date>

        private void helpButtonBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            helpButtonBorder.Background = (Brush)Application.Current.Resources["HotRedBrush"];
        }
        /// <summary>
        /// HelpButton  Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>ZhangMiao</author>
        /// <date>20090407</date>
        private void helpButtonBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            helpButtonBorder.Background = new SolidColorBrush(Colors.Transparent);
        }
    }
}
