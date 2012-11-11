using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WpfApplication3
{
    public partial class AdobeReaderControl : UserControl
    {
        public AdobeReaderControl(string strFileName)
        {
            InitializeComponent();
            this.axAcroPDF1.LoadFile(strFileName);
        }
    }
}
