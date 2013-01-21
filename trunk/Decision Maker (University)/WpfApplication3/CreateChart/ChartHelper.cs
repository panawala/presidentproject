using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visifire.Charts;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication3.CreateChart
{
    class ChartHelper
    {
        public ChartHelper()
        {

        }


        public Chart CreateChart(ChartInformation ci)
        {
            Chart m_chart = new Chart();
            m_chart.BorderThickness = ci.m_BorderThickness;
            m_chart.Theme = ci.m_Theme;
            m_chart.View3D = ci.m_View3D;

            Axis m_axisX = new Axis();
            m_axisX.Title = ci.m_axisXTitle;
            m_chart.AxesX.Add(m_axisX);

            Axis m_asixY = new Axis();
            m_asixY.Title = ci.m_axisYTitle;
            m_asixY.Enabled = true;
            m_asixY.StartFromZero = true;
            m_asixY.AxisType = AxisTypes.Primary;
            m_asixY.AxisMaximum = ci.m_axisYMaximum;
            m_asixY.Interval = ci.m_axisYInterval;
            m_chart.AxesY.Add(m_asixY);
            for(int i = 0;i<ci.dsc.Count;i++)
            {
                DataSeries ds = new DataSeries();
                ds.LegendText = ci.dsc[i].LegendText;
                ds.RenderAs = ci.dsc[i].RenderAs;
                ds.AxisYType = ci.dsc[i].AxisYType;
                ds.DataPoints = new DataPointCollection(ci.dsc[i].DataPoints);
                m_chart.Series.Add(ds);
            }
            m_chart.Rendered+=new EventHandler(chart_Rendered);
            return m_chart;
        }

        void chart_Rendered(object sender, EventArgs e)
        {
            Chart c = sender as Chart;
            Legend legend = c.Legends[0];
            Grid root = legend.Parent as Grid;
            int i = root.Children.Count;
            root.Children.RemoveAt(i-6);
            root.Children.RemoveAt(i-6);
        }


    }
}
