using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.NetworkInformation;
using System.Windows.Media.Animation;
using System.Threading;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.

        }

        private void pingBaidu()
        {

            try
            {

                Ping p = new Ping();
                PingReply pr = p.Send("www.baidu.com");
                if (pr.Status == IPStatus.Success||true)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("本程序需要网络连接，请先配置好当前网络环境");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("本程序需要网络连接，请先配置好当前网络环境");
                return;
            }

        }

        private void btnLogout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.Close();
        }

        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (userName.Text.Equals("tongji") && passwordBox.Password.Equals("tongji"))
            {
                pingBaidu();
                return;
            }
            else
            {
                MessageBox.Show("User name or Password is wrong!");
                return;
            }

        }

        private void userName_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			userName.Text="";
        }

        private void passwordBox_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			passbg.Text="";
			passwordBox.Clear();
        }

        private void userName_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	userName.Text="";// TODO: Add event handler implementation here.
        }

        private void passwordBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			passbg.Text="";
			passwordBox.Clear();

        }

    }
}