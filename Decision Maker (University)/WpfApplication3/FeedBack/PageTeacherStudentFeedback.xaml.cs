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

namespace WpfApplication3.FeedBack
{
    /// <summary>
    /// Interaction logic for PageTeacherStudentFeedback.xaml
    /// </summary>
    public partial class PageTeacherStudentFeedback : Page
    {
        DataSetFeedback.T_FeedBackDataTable dtCurrent;
        int iCurrentItem;
        List<string> lstrSend;
        public PageTeacherStudentFeedback()
        {
            InitializeComponent();
            DataSetFeedbackTableAdapters.T_FeedBackTableAdapter adapter = new DataSetFeedbackTableAdapters.T_FeedBackTableAdapter();
            dtCurrent = adapter.GetData(1);
            listboxFeedback.ItemsSource = dtCurrent;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            lstrSend = new List<string>();
            iCurrentItem = -1;
            this.InkCanvasAnnotation1.IsEnabled = false;
        }

        private void btnFeedbackShow_Click(object sender, RoutedEventArgs e)
        {
            object obj = listboxFeedback.ContainerFromElement((Button)sender);
            iCurrentItem = listboxFeedback.Items.IndexOf(((ListBoxItem)obj).Content);
			
            ShowFeedBack(iCurrentItem);
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbxSearch.Text != "")
            {
                DataSetFeedbackTableAdapters.T_FeedBackTableAdapter adapter = new DataSetFeedbackTableAdapters.T_FeedBackTableAdapter();
                dtCurrent = adapter.GetDataByKey(1, tbxSearch.Text);
                listboxFeedback.ItemsSource = dtCurrent;
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            iCurrentItem--;
            ShowFeedBack(iCurrentItem);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            iCurrentItem++;
            ShowFeedBack(iCurrentItem);
        }

        private void listboxFeedback_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listboxFeedback.SelectedIndex = -1;
        }

        private void ShowFeedBack(int index)
        {
            if (iCurrentItem == 0)
                btnPrevious.IsEnabled = false;
            else
                btnPrevious.IsEnabled = true;
            if (iCurrentItem == listboxFeedback.Items.Count - 1)
                btnNext.IsEnabled = false;
            else
                btnNext.IsEnabled = true;
            DataSetFeedback.T_FeedBackRow row = dtCurrent[index];
            tbxFeedbackContent.Text = row.FeedbackContent;
            labelName.Content = row.Name;
            labelContact.Content = row.Contact;
            labelDate.Content = row.SubmissionDate;

            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            string filename = row.FeedbackTitle;
            if (System.IO.File.Exists(strPath + @"/Comment/" + filename + ".isf"))
            {
                System.IO.FileStream fs = new System.IO.FileStream(strPath + @"/Comment/" + filename + ".isf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection(fs);
                fs.Close();
            }
            else
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection();
            this.InkCanvasAnnotation1.IsEnabled = true;
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

        private void btnCommentOK_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            string filename = dtCurrent[iCurrentItem].FeedbackTitle;
            if (Directory.Exists(strPath + @"/Comment") == false)
            {
                Directory.CreateDirectory(strPath + @"/Comment");
            }
            System.IO.FileStream fs = new System.IO.FileStream(strPath+@"/Comment/"+filename + ".isf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.InkCanvasAnnotation1.Strokes.Save(fs);
            fs.Close();
            MessageBox.Show("批示保存成功！");
        }

        private void btnCommentClear_Click(object sender, RoutedEventArgs e)
        {
            this.InkCanvasAnnotation1.Strokes.Clear();
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

        private void ListBoxItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			object obj = listboxFeedback.ContainerFromElement((Button)sender);
            iCurrentItem = listboxFeedback.Items.IndexOf(((ListBoxItem)obj).Content);
			
            ShowFeedBack(iCurrentItem);
			
        }

        private void tbxSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (tbxSearch.Text != "")
            {
                DataSetFeedbackTableAdapters.T_FeedBackTableAdapter adapter = new DataSetFeedbackTableAdapters.T_FeedBackTableAdapter();
                dtCurrent = adapter.GetDataByKey(1, tbxSearch.Text);
                listboxFeedback.ItemsSource = dtCurrent;
            }
        }

        private void tbxSearch_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	tbxSearch.Clear();// TODO: Add event handler implementation here.
        }
    }
}
