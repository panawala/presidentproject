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
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Ink;

namespace WpfApplication3.Communicate
{
    /// <summary>
    /// Interaction logic for PageDocIssue.xaml
    /// </summary>
    public partial class PageDocIssue : Page
    {
        bool IsRead;
        int DocType;
        DataSetDoc.T_DocDataTable dtDocs;
        DataSetDoc.T_DocDataTable dtLatestDocs;
        DataSetDoc.T_DocDataTable dtCurrent;
        int iCurrent;
        public PageDocIssue()
        {
            InitializeComponent();
            dtDocs = new DataSetDoc.T_DocDataTable();
            dtLatestDocs = new DataSetDoc.T_DocDataTable();
            dtCurrent = new DataSetDoc.T_DocDataTable();
            this.InkCanvasAnnotation1.IsEnabled = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IsRead = false;
            DocType = 1;
            listboxLatestDocsRefresh();
            listboxDocsRefresh();
        }

        private void btnDocShow_Click(object sender, RoutedEventArgs e)
        {
            object obj = listboxDocs.ContainerFromElement((Button)sender);
            iCurrent = listboxDocs.Items.IndexOf(((ListBoxItem)obj).Content);
            dtCurrent = dtDocs;
            showDoc(iCurrent, dtCurrent);
        }

        private void btnLatestDocShow_Click(object sender, RoutedEventArgs e)
        {
            object obj = listboxLatestDocs.ContainerFromElement((Button)sender);
            iCurrent = listboxLatestDocs.Items.IndexOf(((ListBoxItem)obj).Content);
            dtCurrent = dtLatestDocs;
            showDoc(iCurrent, dtCurrent);
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)sender;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                CheckBox m_CheckBox = (CheckBox)m_ComboBox.Items[i];
                if ((bool)m_CheckBox.IsChecked && listboxSend.Items.IndexOf(m_CheckBox.Content.ToString()) == -1)
                    listboxSend.Items.Add(m_CheckBox.Content.ToString());
                else if (!(bool)m_CheckBox.IsChecked && listboxSend.Items.IndexOf(m_CheckBox.Content.ToString()) != -1)
                    listboxSend.Items.Remove(m_CheckBox.Content.ToString());
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)((CheckBox)sender).Parent;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                ((CheckBox)m_ComboBox.Items[i]).IsChecked = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)((CheckBox)sender).Parent;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                ((CheckBox)m_ComboBox.Items[i]).IsChecked = false;
            }
        }

        private void rbtBlackInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(0, 0, 0);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtRedInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(255, 0, 0);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtGreenInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(0, 255, 0);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtBlueInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(0, 0, 255);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtThickInk_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Width = 10;
            inkDA.Height = 10;
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtNormalInk_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Width = 5;
            inkDA.Height = 5;
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtThinInk_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Width = 1;
            inkDA.Height = 1;
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtRubber_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbxSearch.Text != "")
            {
                DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
                dtDocs = adapter.GetDataByKey(tbxSearch.Text);
                listboxDocs.ItemsSource = dtDocs;
            }
        }

        private void btnCommentClear_Click(object sender, RoutedEventArgs e)
        {
            this.InkCanvasAnnotation1.Strokes.Clear();
        }

        private void btnCommentOK_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            string filename = dtCurrent[iCurrent].DocTitle;
            if (Directory.Exists(strPath + @"/Comment") == false)
            {
                Directory.CreateDirectory(strPath + @"/Comment");
            }
            System.IO.FileStream fs = new System.IO.FileStream(strPath + @"/Comment/" + filename + ".isf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.InkCanvasAnnotation1.Strokes.Save(fs);
            fs.Close();
            MessageBox.Show("批示保存成功！");
        }

        private void btnAlready_Click(object sender, RoutedEventArgs e)
        {
            IsRead = true;
            listboxLatestDocsRefresh();
            listboxDocsRefresh();
        }

        private void btnNotyet_Click(object sender, RoutedEventArgs e)
        {
            IsRead = false;
            listboxLatestDocsRefresh();
            listboxDocsRefresh();
        }

        private void btnDocTypeA_Click(object sender, RoutedEventArgs e)
        {
            DocType = 1;
            listboxDocsRefresh();
        }

        private void btnDocTypeB_Click(object sender, RoutedEventArgs e)
        {
            DocType = 2;
            listboxDocsRefresh();
        }

        private void btnDocTypeC_Click(object sender, RoutedEventArgs e)
        {
            DocType = 3;
            listboxDocsRefresh();
        }

        private void listboxLatestDocsRefresh()
        {
            //IsRead
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            dtLatestDocs = adapter.GetLatestDataByState(IsRead);
            listboxLatestDocs.ItemsSource = dtLatestDocs;
        }

        private void listboxDocsRefresh()
        {
            //IsRead&&DocType
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            dtDocs = adapter.GetDataByDocStateAndDocType(IsRead, DocType);
            listboxDocs.ItemsSource = dtDocs;
        }

        private void showDoc(int index, DataSetDoc.T_DocDataTable dt)
        {
            DataSetDoc.T_DocRow row = dt[index];
            string filePDF = row.DocAddress;
            string FileISF = row.DocTitle+".isf";
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + @"/PDF/" + filePDF))
            {
                webbrowserDocContent.Navigate(new Uri(strPath + @"/PDF/" + filePDF,UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("未找到PDF文件");
            }
            if (System.IO.File.Exists(strPath + @"/Comment/" + FileISF))
            {
                System.IO.FileStream fs = new System.IO.FileStream(strPath + @"/Comment/" + FileISF, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection(fs);
                fs.Close();
            }
            else
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection();
            this.InkCanvasAnnotation1.IsEnabled = true;
        }
    }
}
