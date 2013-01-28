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
using System.Windows.Shapes;

namespace WpfApplication3.ResourcesAndManpower
{
    /// <summary>
    /// Interaction logic for WindowFacultyMember.xaml
    /// </summary>
    public partial class WindowFacultyMember : Window
    {
        DataSetFacultyMember.T_FacultyMemberRow row;
        public WindowFacultyMember(int FacultyStructureId)
        {
            InitializeComponent();
            //暂用   之后记得删了  转到相应的人的主页
            switch (FacultyStructureId)
            {
                case 3:
                    wb_person.Source = new Uri("http://www.tongji-arch.org/person_detail.asp?id=46");
                    break;
                case 4:
                    wb_person.Source = new Uri("http://www.tongji-arch.org/person_detail.asp?id=31");
                    break;
                case 5:
                    wb_person.Source = new Uri("http://www.tongji-arch.org/person_detail.asp?id=48");
                    break;
                default:
                    wb_person.Source = new Uri("http://www.tongji-caup.org/intro.php?cid=22");
                    break;
            }
            wnd_FacultyMemberPhoto.Source = new BitmapImage(new Uri("/Images/Photos/FacultyMemberPhoto_" + FacultyStructureId + ".jpg", UriKind.Relative));
            DataSetFacultyMemberTableAdapters.T_FacultyMemberTableAdapter adapter = new DataSetFacultyMemberTableAdapters.T_FacultyMemberTableAdapter();
            try
            {
                row = adapter.GetRowByFacultyId(FacultyStructureId)[0];
                lblTitle1.Content = row.Title1;
                lblTitle2.Content = row.Title2;
                lblName.Content = row.Name;
                lblProfessionalTitle.Content = row.ProfessionalTitle;
                lblEmail.Content += row.email;
                lblFax.Content += row.fax;
                lblTel.Content += row.tel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
