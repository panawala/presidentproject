using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication3.Case
{
    class ClassCatalogNodeItem
    {
        public string strText { get; set; }
        public bool isOpen { get; set; }
        public List<ClassCatalogNodeItem> Children { get; set; }
        public ClassCatalogNodeItem()
        {
            Children = new List<ClassCatalogNodeItem>();
        }
    }
}
