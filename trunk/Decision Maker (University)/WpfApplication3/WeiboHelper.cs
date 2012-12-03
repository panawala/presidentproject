using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows;

namespace WpfApplication3
{
    class WeiboHelper
    {
        string html = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"><!-- saved from url=(0014)about:internet -->\r\n<html xmlns:wb=\"http://open.weibo.com/wb\">";
        string script = "<head><script src=\"http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=\" type=\"text/javascript\" charset=\"utf-8\"></script></head><title>微博直播</title>";
        string body ="<body style=\"margin-left:-20px;margin-top:-20px;\" scroll=\"no\" >";
		string frame1 ="<iframe frameborder=\"0\" scrolling=\"no\" style=\"width:278px;height:420px;\" src=\"http://widget.weibo.com/livestream/listlive.php?language=zh_cn&width=278&height=310&uid=2389517080&skin=4&refer=1&appkey=&pic=0&titlebar=1&border=1&publish=0&atalk=1&recomm=0&at=0&atopic=";
        string frame2 = "&colordiy=0&dpc=1\"></iframe>";
        string end ="</body></html>";
        public void settopic(string topic) {
            FileStream fs = new FileStream("weibo.htm", FileMode.Create);
            //获得字节数组
            byte[] data = new UTF8Encoding(false).GetBytes(html + script +body+ frame1 + topic + frame2 + end);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
        private XmlElement GetXmlElement(XmlDocument doc, string elementName, string value)
        {
            XmlElement element = doc.CreateElement(elementName);
            element.InnerText = value;
            return element;
        }  
    }
}
