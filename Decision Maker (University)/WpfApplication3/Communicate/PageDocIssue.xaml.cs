﻿using System;
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
        bool IsDesc;
        DataSetDoc.T_DocDataTable dtDocs;
        int iCurrentItem;
//        DataSetDoc.T_DocDataTable dtCurrent;
//		DataSetDoc.T_DocDataTable dtLatestCurrent;
		string fileCurrentPDF;
        public PageDocIssue()
        {
            InitializeComponent();
            dtDocs = new DataSetDoc.T_DocDataTable();
            this.InkCanvasAnnotation1.IsEnabled = false;
            IsRead = false;
            IsDesc = true;
            tabControl1.SelectedIndex = 1;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (dtDocs.Count > 0)
            {
                string content = dtDocs[0].DocTitle;
                string address = dtDocs[0].DocAddress;
                string filePDF = address;
                string FileISF = content + ".isf";
                DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
                string strPath = di.Parent.Parent.FullName;
                if (System.IO.File.Exists(strPath + @"/PDF/" + filePDF))
                {
                    webbrowserDocContent.Navigate(new Uri(strPath + @"/PDF/" + filePDF, UriKind.RelativeOrAbsolute));
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
                fileCurrentPDF = content;
                iCurrentItem = dtDocs[0].Id;
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
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            adapter.UpdateState(true, iCurrentItem);
        }

        private void listboxDocsRefresh(bool Isread,int Doctype)
        {
            //IsRead&&DocType
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
                dtDocs = adapter.GetDataByDocStateAndDocTypeDesc(Isread, Doctype);
//			dtCurrent=dtDocs;
            listboxDocs.ItemsSource = dtDocs;

        }
       private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("发送成功！");
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
            int id = Int32.Parse(btn.Tag.ToString());
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            DataSetDoc.T_DocDataTable dt = adapter.GetDocById(id);
            string address = dt[0].DocAddress;
			string filePDF = address;
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
            iCurrentItem = id;
//            PDFReader pdfReader = new PDFReader();
//            pdfReader.showPdf(content + ".pdf");
        }

        private void lblSend_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
                return;
            object obj = listboxSend.ContainerFromElement((TextBlock)sender);
            int i = listboxSend.Items.IndexOf(((ListBoxItem)obj).Content);
            listboxSend.Items.RemoveAt(i);

        }

        private void btnSortByDate_Click_1(object sender, RoutedEventArgs e)
        {
            if (!IsDesc)
            {

                listboxDocs.ItemsSource = dtDocs.OrderByDescending(s => s.SubmissionDate);
                IsDesc = true;
            }
            else
            {
                listboxDocs.ItemsSource = dtDocs.OrderBy(s => s.SubmissionDate);
                IsDesc = false;
            }
        }
		
		private void ckbDate_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            listboxDocs.ItemsSource = dtDocs.OrderByDescending(s => s.SubmissionDate);
        }

        private void ckbDate_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            listboxDocs.ItemsSource = dtDocs.OrderBy(s => s.SubmissionDate);
        }


        private void TabControl_Selection1Changed_1(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                IsRead = true;
                DocType = tabControlAlready.SelectedIndex + 1;
            }
            else
            {
                IsRead = false;
                DocType = tabControlNotYet.SelectedIndex + 1;
            }
            listboxDocsRefresh(IsRead, DocType);
        }

        private void tabControlAlready_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DocType = tabControlAlready.SelectedIndex + 1;
            listboxDocsRefresh(IsRead, DocType);
        }

        private void tabControlNotYet_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DocType = tabControlNotYet.SelectedIndex + 1;
            listboxDocsRefresh(IsRead, DocType);
        }
		
    }
}
