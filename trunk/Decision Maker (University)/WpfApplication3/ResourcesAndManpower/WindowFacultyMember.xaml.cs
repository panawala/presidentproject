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
