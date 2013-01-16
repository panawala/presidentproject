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

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// ComprehensiveIndex.xaml 的交互逻辑
    /// </summary>
    public partial class ComprehensiveIndex : Page
    {
        private double[,] partyedvalue = { { 45.5, 41.5 }, { 40, 34 }, { 30.5, 27.5 }, { 26, 22.5 } };
        private double[] percent;
        private double[] width;
        public ComprehensiveIndex()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            percent = new double[5];
            width = new double[5];
            double total=0,totalcompleteness=0;
            for (int i = 0; i < 4; i++)
            {
                totalcompleteness += partyedvalue[i, 1];
                total += partyedvalue[i, 0];
                percent[i] = partyedvalue[i,1] / partyedvalue[i,0];
            }
            percent[4] = totalcompleteness / total;                                          //准备数据
            totalpercent.Content = String.Format("{0:N1}", percent[4] * 100) + "%";
            part1percent.Content = String.Format("{0:N1}", percent[0] * 100) + "%";
            part2percent.Content = String.Format("{0:N1}", percent[1] * 100) + "%";
            part3percent.Content = String.Format("{0:N1}", percent[2] * 100) + "%";
            part4percent.Content = String.Format("{0:N1}", percent[3] * 100) + "%";
            totalvalue.Content = totalcompleteness.ToString() + "/" + total.ToString();
            part1value.Content = partyedvalue[0, 1].ToString() + "/" + partyedvalue[0, 0];
            part2value.Content = partyedvalue[1, 1].ToString() + "/" + partyedvalue[1, 0];
            part3value.Content = partyedvalue[2, 1].ToString() + "/" + partyedvalue[2, 0];
            part4value.Content = partyedvalue[3, 1].ToString() + "/" + partyedvalue[3, 0];
                            
            //宽度设定
            width[4] = totalTarget.Width;
            part1.Width = totalTarget.Width * partyedvalue[0, 0] / total;
            width[0] = part1.Width;
            part2.Width = totalTarget.Width * partyedvalue[1, 0] / total;
            width[1] = part2.Width;
            part3.Width = totalTarget.Width * partyedvalue[2, 0] / total;
            width[2] = part3.Width;
            part4.Width = totalTarget.Width * partyedvalue[3, 0] / total;
            width[3] = part4.Width;
                                                                                            //位置设定
            Thickness tlable;
            totalpercent.Margin = totalTarget.Margin;
            tlable = totalTarget.Margin;
            tlable.Left = totalTarget.Margin.Left+totalTarget.Width;
            totalvalue.Margin = tlable;

            Thickness tRec = part1.Margin;
            tRec.Left = totalTarget.Margin.Left;
            part1percent.Margin = tRec;
            part1.Margin = tRec;
            part1_copy.Margin = part1.Margin;
            tlable = part1.Margin;
            tlable.Left = part1.Margin.Left + part1.Width;
            part1value.Margin = tlable;

            tRec = part2.Margin;
            tRec.Left = part1.Margin.Left + part1.Width;
            part2percent.Margin = tRec;
            part2.Margin = tRec;
            part2_copy.Margin = part2.Margin;
            tlable = part2.Margin;
            tlable.Left = part2.Margin.Left + part2.Width;
            part2value.Margin = tlable;

            tRec = part3.Margin;
            tRec.Left = part2.Margin.Left + part2.Width;
            part3percent.Margin = tRec;
            part3.Margin = tRec;
            part3_copy.Margin = part3.Margin;
            tlable = part3.Margin;
            tlable.Left = part3.Margin.Left + part3.Width;
            part3value.Margin = tlable;

            tRec = part4.Margin;
            tRec.Left = part3.Margin.Left + part3.Width;
            part4percent.Margin = tRec;
            part4.Margin = tRec;
            part4_copy.Margin = part4.Margin;
            tlable = part4.Margin;
            tlable.Left = part4.Margin.Left + part4.Width;
            part4value.Margin = tlable;
            //设置垂直线
            tlable = totalTarget.Margin;
            tlable.Top = totalTarget.Margin.Top + totalTarget.Height;
            verline1.Margin = tlable;
            tlable.Left += width[0] - 1;
            verline2.Margin = tlable;
            tlable.Left += width[1];
            verline3.Margin = tlable;
            tlable.Left += width[2];
            verline4.Margin = tlable;
            tlable.Left += width[3];
            verline5.Margin = tlable;

                                                                                    //动画开始
            for (int i = 0; i < 4; i++)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0;
                myDoubleAnimation.To = percent[i] * width[i];
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));

                Storyboard.SetTargetName(myDoubleAnimation, "part" + (i + 1)+"_copy");

                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
                Storyboard myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                myStoryboard.AutoReverse = false;
                myStoryboard.Begin(this);
            }

            DoubleAnimation mytotalAnimation = new DoubleAnimation();
            mytotalAnimation.From = 0;
            mytotalAnimation.To = percent[4] *totalTarget.Width;
            mytotalAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));

            Storyboard.SetTargetName(mytotalAnimation, "totalTarget_copy");

            Storyboard.SetTargetProperty(mytotalAnimation, new PropertyPath(Rectangle.WidthProperty));
            Storyboard myTotalStoryboard = new Storyboard();
            myTotalStoryboard.Children.Add(mytotalAnimation);
            myTotalStoryboard.AutoReverse = false;
            myTotalStoryboard.Begin(this);
		
        }
    }
}
