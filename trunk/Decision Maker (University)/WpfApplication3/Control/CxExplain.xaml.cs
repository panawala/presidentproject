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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class CxExplain : UserControl
    {
        private static CxExplain instance = null;
        private Window _thisParent = new Window();
        public Window ThisParent
        {
            get { return _thisParent; }
        }
        private void SetWindowProperty()
        {
            this.ThisParent.AllowsTransparency = true;
            this.ThisParent.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.ThisParent.WindowStyle = WindowStyle.None;
            this.ThisParent.Topmost = true;
            this.ThisParent.ShowInTaskbar = false;
            this.ThisParent.Background = null;
            this.ThisParent.SizeToContent = SizeToContent.WidthAndHeight;
            this.ThisParent.Content = this;
            this.ThisParent.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Window1_MouseLeftButtonDown);
        }

        private CxExplain()
        {
            InitializeComponent();
            SetWindowProperty();
        }
        private void closeButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ThisParent.Visibility = Visibility.Hidden;
        }
        void Window1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (sender as Window).DragMove();
        }
        public void SetContent(string explainContent)
        {
            title.Text = "       " + explainContent+"   数据来源：";
            Run run1 = new Run("www.baidu.com");
            Hyperlink hl = new Hyperlink(run1);
            hl.NavigateUri = new Uri("http://www.baidu.com");
            hl.RequestNavigate += new RequestNavigateEventHandler(hl_RequestNavigate);
            title.Inlines.Add(hl);
        }

        void hl_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
        public void SetContent(string explainContent, int year)
        {
            title.Text = "       " + year + "年" + explainContent;
        }
        //public void SetContent(string content)
        //{

        //}
        public void Show()
        {
            this.ThisParent.ShowDialog();
            this.ThisParent.Topmost = true;
        }
        public static CxExplain getInstance()
        {
            if (instance == null)
            {
                instance = new CxExplain();
            }
            return instance;
        }
    }
}
