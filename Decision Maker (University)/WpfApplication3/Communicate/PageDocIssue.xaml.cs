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
//        DataSetDoc.T_DocDataTable dtCurrent;
//		DataSetDoc.T_DocDataTable dtLatestCurrent;
		string fileCurrentPDF;
		
        int iCurrent;
        public PageDocIssue()
        {
            InitializeComponent();
            dtDocs = new DataSetDoc.T_DocDataTable();
            dtLatestDocs = new DataSetDoc.T_DocDataTable();
//            dtCurrent = new DataSetDoc.T_DocDataTable();
            this.InkCanvasAnnotation1.IsEnabled = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IsRead = false;
            for(DocType = 1;DocType<4;DocType++)
			{
				listboxLatestDocsRefresh(IsRead);
            	listboxDocsRefresh(IsRead,DocType);
			}
			IsRead=true;
			for(DocType = 1;DocType<4;DocType++)
			{
				listboxLatestDocsRefresh(IsRead);
            	listboxDocsRefresh(IsRead,DocType);
			}

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
            string filename = fileCurrentPDF;
            if (Directory.Exists(strPath + @"/Comment") == false)
            {
                Directory.CreateDirectory(strPath + @"/Comment");
            }
            System.IO.FileStream fs = new System.IO.FileStream(strPath + @"/Comment/" + filename + ".isf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.InkCanvasAnnotation1.Strokes.Save(fs);
            fs.Close();
            MessageBox.Show("批示保存成功！");
        }

        private void listboxLatestDocsRefresh(bool Isread)
        {
            //IsRead
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            dtLatestDocs = adapter.GetLatestDataByState(Isread);
//			dtLatestCurrent=dtLatestDocs;
			if(Isread==true)
            	listboxLatestDocsIsRead.ItemsSource = dtLatestDocs;
			else
				listboxLatestDocsNotRead.ItemsSource = dtLatestDocs;

        }

        private void listboxDocsRefresh(bool Isread,int Doctype)
        {
            //IsRead&&DocType
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            dtDocs = adapter.GetDataByDocStateAndDocType(Isread, Doctype);
//			dtCurrent=dtDocs;
			if(Isread==true)
			{
				if(Doctype==1)
				{
					listboxDocsType1.ItemsSource = dtDocs;
				}
				else if(Doctype==2)
				{
					listboxDocsType2.ItemsSource = dtDocs;
				}
				else
				{
					listboxDocsType2.ItemsSource = dtDocs;
				}
			}

			else
			{
				if(Doctype==1)
				{
					listboxDocsType4.ItemsSource = dtDocs;
				}
				else if(Doctype==2)
				{
					listboxDocsType5.ItemsSource = dtDocs;
				}
				else
				{
					listboxDocsType6.ItemsSource = dtDocs;
				}
			}

        }
       private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("发送成功！");
        }
		

        private void GridDocType1_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			listboxDocsRefresh(true,1);
        }

        private void GridDocType2_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			listboxDocsRefresh(true,2);
        }

        private void GridDocType3_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			listboxDocsRefresh(true,3);
        }

        private void GridDocType4_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			listboxDocsRefresh(false,1);
        }

        private void GridDocType5_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			listboxDocsRefresh(false,2);
        }

        private void GridDocType6_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			listboxDocsRefresh(false,3);
        }

        private void GridAlready_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			listboxLatestDocsRefresh(true);
            listboxDocsRefresh(true,1);
        }

        private void GridNotYet_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			listboxLatestDocsRefresh(false);
            listboxDocsRefresh(false,1);
        }

        private void tbxSearch_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	tbxSearch.Clear();// TODO: Add event handler implementation here.
        }

        private void tbxSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (tbxSearch.Text != "")
            {
                DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
                dtDocs = adapter.GetDataByKey(tbxSearch.Text);
                listboxDocs.ItemsSource = dtDocs;
            }
        }

        private void btnDocSearchShow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			Button btn = sender as Button;
            string content = btn.Content as string;
			string filePDF = content + ".pdf";
			string FileISF = content+".isf";
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
			fileCurrentPDF=content;
//            PDFReader pdfReader = new PDFReader();
//            pdfReader.showPdf(content + ".pdf");
        }
		
    }
}
