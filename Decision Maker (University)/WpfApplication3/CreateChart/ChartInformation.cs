using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Visifire.Charts;

namespace WpfApplication3.CreateChart
{
    class ChartInformation
    {
        public Thickness m_BorderThickness;
        public string m_Theme;
        public bool m_View3D;
        public string m_axisXTitle;
        public string m_axisYTitle;
        public int m_axisYMaximum;
        public int m_axisYInterval;
        public DataSeriesCollection dsc;
        public ChartInformation() { }
    }
}
