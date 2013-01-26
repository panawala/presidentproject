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
using System.Windows.Media.Animation;
using Visifire.Charts;

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// ComprehensiveIndex.xaml 的交互逻辑
    /// </summary>
    public partial class ComprehensiveIndex : Page
    {
        private double[,] partyedvalue = { { 45.5, 41.5 }, { 40, 34 }, { 30.5, 27.5 }, { 26, 22.5 } };
        private double[] percent;
        private double width;
        public ComprehensiveIndex()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            percent = new double[5];
            width = 280;
            double total=0,totalcompleteness=0;
            for (int i = 0; i < 4; i++)
            {
                totalcompleteness += partyedvalue[i, 1];
                total += partyedvalue[i, 0];
                percent[i] = partyedvalue[i,1] / partyedvalue[i,0];
            }
            percent[4] = totalcompleteness / total;                                          //准备数据
            //totalpercent.Content = String.Format("{0:N1}", percent[4] * 100) + "%";
            //part1percent.Content = String.Format("{0:N1}", percent[0] * 100) + "%";
            //part2percent.Content = String.Format("{0:N1}", percent[1] * 100) + "%";
            //part3percent.Content = String.Format("{0:N1}", percent[2] * 100) + "%";
            //part4percent.Content = String.Format("{0:N1}", percent[3] * 100) + "%";
            //totalvalue.Content = totalcompleteness.ToString() + "/" + total.ToString();
            part1_value.Text = partyedvalue[0, 1].ToString() + "/" + partyedvalue[0, 0];
            part2_value.Text = partyedvalue[1, 1].ToString() + "/" + partyedvalue[1, 0];
            part3_value.Text = partyedvalue[2, 1].ToString() + "/" + partyedvalue[2, 0];
            part4_value.Text = partyedvalue[3, 1].ToString() + "/" + partyedvalue[3, 0];
       

                                                                                    //动画开始
            for (int i = 0; i < 4; i++)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0;
                myDoubleAnimation.To = percent[i] * width;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));

                //DoubleAnimation myOpacityAnimation = new DoubleAnimation();
                //myDoubleAnimation.From = 0;
                //myDoubleAnimation.To = 100;
                //myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));

                Storyboard.SetTargetName(myDoubleAnimation, "part" + (i + 1)+"_copy");
                //Storyboard.SetTargetName(myOpacityAnimation, "part" + (i + 1) + "_value");
                //Storyboard.SetTargetName(myOpacityAnimation, "part" + (i + 1) + "_name");
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
                //Storyboard.SetTargetProperty(myOpacityAnimation, new PropertyPath(TextBlock.OpacityProperty));
                Storyboard myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                //myStoryboard.Children.Add(myOpacityAnimation);
                myStoryboard.AutoReverse = false;
                myStoryboard.Begin(this);
            }

        }
        void chart_Rendered(object sender, EventArgs e)
        {
            Chart c = sender as Chart;
            Legend legend = c.Legends[0];
            Grid root = legend.Parent as Grid;
            int i = root.Children.Count;
            root.Children.RemoveAt(i - 6);
            root.Children.RemoveAt(i - 6);
        }
        //页面跳转函数
        private void tb_tc_edu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Development_performance.TalentCultivation TalentC = new Development_performance.TalentCultivation(1);
            this.NavigationService.Navigate(TalentC);
        }

        private void tb_tc_teachers_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Development_performance.TalentCultivation TalentC = new Development_performance.TalentCultivation(2);
            this.NavigationService.Navigate(TalentC);
        }

        private void tb_tc_train_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Development_performance.TalentCultivation TalentC = new Development_performance.TalentCultivation(3);
            this.NavigationService.Navigate(TalentC);
        }

        private void tb_sr_achievements_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Development_performance.ScientificResearch ScientificR = new Development_performance.ScientificResearch(1);
            this.NavigationService.Navigate(ScientificR);
        }

        private void tb_sr_research_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Development_performance.ScientificResearch ScientificR = new Development_performance.ScientificResearch(2);
            this.NavigationService.Navigate(ScientificR);
        }

        private void tb_sr_project_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Development_performance.ScientificResearch ScientificR = new Development_performance.ScientificResearch(3);
            this.NavigationService.Navigate(ScientificR);
        }

        private void tb_cr_academic_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Development_performance.ComprehensiveReputation ComprehensiveR = new Development_performance.ComprehensiveReputation(1);
            this.NavigationService.Navigate(ComprehensiveR);
        }

        private void tb_cr_donate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Development_performance.ComprehensiveReputation ComprehensiveR = new Development_performance.ComprehensiveReputation(2);
            this.NavigationService.Navigate(ComprehensiveR);
        }

        private void tb_cr_reputation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Development_performance.ComprehensiveReputation ComprehensiveR = new Development_performance.ComprehensiveReputation(3);
            this.NavigationService.Navigate(ComprehensiveR);
        }

        private void tb_cr_schoolfellow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Development_performance.ComprehensiveReputation ComprehensiveR = new Development_performance.ComprehensiveReputation(4);
            this.NavigationService.Navigate(ComprehensiveR);
        }

        private void tb_gc_resource_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Development_performance.GreenCampus GreenC = new Development_performance.GreenCampus(1);
            this.NavigationService.Navigate(GreenC);
        }

        private void tb_cr_environment_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Development_performance.GreenCampus GreenC = new Development_performance.GreenCampus(2);
            this.NavigationService.Navigate(GreenC);

        }

    }
}
