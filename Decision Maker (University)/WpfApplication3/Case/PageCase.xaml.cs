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
using System.IO;

namespace WpfApplication3.Case
{
    /// <summary>
    /// Interaction logic for PageCase.xaml
    /// </summary>
    public partial class PageCase : Page
    {
        public DataSet_Case.T_CaseDataTable dtSource;
        public PageCase()
        {
            InitializeComponent();
            ShowTreeView();
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = adapter.GetDataFromChengShiFaZhanAnLiKu();
            DataBind(20, 1);
        }

        private void DataBind(int number, int currentSize)
        {
            if (dtSource == null)
            {
                return;
            }
            int iPageSize;
            //DataSetCityCaseTableAdapters.T_CaseTableAdapter adapter = new DataSetCityCaseTableAdapters.T_CaseTableAdapter();
            //DataSetCityCase.T_CaseDataTable dt = adapter.SearchByKeyValue(tbx_JianYanYinJian_Search.Text);
            int count = dtSource.Count;
            if (count % number == 0)
                iPageSize = count / number;
            else
                iPageSize = count / number + 1;
            tbkTotal.Text = iPageSize.ToString();
            tbkCurrentsize.Text = currentSize.ToString();
            dataGridSearchResult.ItemsSource = dtSource.Skip(number * (currentSize - 1)).Take(number).ToList();
        }

        private void ShowTreeView()
        {
            List<ClassCatalogNodeItem> itemList = new List<ClassCatalogNodeItem>();
            ClassCatalogNodeItem node = new ClassCatalogNodeItem() { strText = "城市发展案例", isOpen = true };
            ClassCatalogNodeItem child = new ClassCatalogNodeItem() { strText = "区域规划", isOpen = true };
            node.Children.Add(child);
            child = new ClassCatalogNodeItem() { strText = "总体规划", isOpen = true };
            node.Children.Add(child);
            child = new ClassCatalogNodeItem() { strText = "详细规划", isOpen = true };
            node.Children.Add(child);
            child = new ClassCatalogNodeItem() { strText = "城市设计", isOpen = true };
            node.Children.Add(child);
            child = new ClassCatalogNodeItem() { strText = "专项规划", isOpen = true };
            node.Children.Add(child);
            itemList.Add(node);
            node = new ClassCatalogNodeItem() { strText = "城市百科知识", isOpen = true };
            child = new ClassCatalogNodeItem() { strText = "城镇运营管理", isOpen = true };
            ClassCatalogNodeItem grandChild = new ClassCatalogNodeItem() { strText = "城市发展", isOpen = true };
            child.Children.Add(grandChild);
            grandChild = new ClassCatalogNodeItem() { strText = "城市更新", isOpen = true };
            child.Children.Add(grandChild);
            grandChild = new ClassCatalogNodeItem() { strText = "突发事件处理", isOpen = true };
            child.Children.Add(grandChild);
            node.Children.Add(child);
            itemList.Add(node);
            node = new ClassCatalogNodeItem() { strText = "城市数据知识", isOpen = true };
            itemList.Add(node);
            this.treeViewCatalog.ItemsSource = itemList;
        }

        private void btnPageUp_Click(object sender, RoutedEventArgs e)
        {
            int currentsize = int.Parse(tbkCurrentsize.Text); //获取当前页数  
            if (currentsize > 1)
            {
                DataBind(20, currentsize - 1);   //调用分页方法  
            }
        }

        private void btnPageNext_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbkTotal.Text); //总页数  
            int currentsize = int.Parse(tbkCurrentsize.Text); //当前页数  
            if (currentsize < total)
            {
                DataBind(20, currentsize + 1);   //调用分页方法  
            }
        }

        private void dataGridSearchResult_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGridSearchResult.SelectedItem == null)
            {
                return;
            }
            if (e.OriginalSource.GetType() != typeof(System.Windows.Documents.Hyperlink))
                return;
            //todo:
            int i = dataGridSearchResult.SelectedIndex;
            DataSet_Case.T_CaseRow ThisCase = dataGridSearchResult.SelectedItem as DataSet_Case.T_CaseRow;

            string strFileName = ThisCase.CasePDF;
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + @"/PDF/" + strFileName))
            {
                PDFReader m_PDFReader = new PDFReader();
                m_PDFReader.showPdf(strFileName);
            }
            else
            {
                MessageBox.Show("没有该文件");
            }
        }

        private void btnPageGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pageNum = int.Parse(tbxPageNum.Text);
                int total = int.Parse(tbkTotal.Text); //总页数  
                if (pageNum >= 1 && pageNum <= total)
                {
                    DataBind(20, pageNum);     //调用分页方法  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbxSearch.Text == null || tbxSearch.Text == "")
                return;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = adapter.GetDataByKey(tbxSearch.Text);
            DataBind(20, 1);
        }

        private void dataGridSearchResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.dataGridSearchResult.SelectedItem == null)
            {
                return;
            }
            int i = dataGridSearchResult.SelectedIndex;
            DataSet_Case.T_CaseRow ThisCase = dataGridSearchResult.SelectedItem as DataSet_Case.T_CaseRow;

            string strFileName = ThisCase.CasePDF;
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + @"/PDF/" + strFileName))
            {
                PDFReader m_PDFReader = new PDFReader();
                m_PDFReader.showPdf(strFileName);
            }
            else
            {
                MessageBox.Show("没有该文件");
            }
            dataGridSearchResult.SelectedIndex = -1;
        }

        private void tbxSearch_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	tbxSearch.Clear();// TODO: Add event handler implementation here.
        }

        private void tbxSearchCase_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	tbxSearchCase.Clear();// TODO: Add event handler implementation here.
        }
    }

}
