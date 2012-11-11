using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WpfApplication3
{
    class GoogleMapHelper
    {
        string strA = "<!DOCTYPE html><!-- saved from url=(0014)about:internet --><html><head><meta name=\"viewport\" content=\"initial-scale=1.0, user-scalable=no\" /><meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\" /><title>Google Maps JavaScript API v3 Example: KmlLayer GeoRSS</title><link href=\"http://code.google.com/apis/maps/documentation/javascript/examples/default.css\" rel=\"stylesheet\" type=\"text/css\" /><script type=\"text/javascript\" src=\"http://ditu.google.cn/maps/api/js?sensor=false\"></script><script type=\"text/javascript\">function initialize() {var myLatlng = new google.maps.LatLng(";
            string strC = ",";
        string strE = ");var myOptions = {zoom: 10,center: myLatlng, mapTypeId: google.maps.MapTypeId.";
        string strG = "};var map = new google.maps.Map(document.getElementById(\"map_canvas\"), myOptions);var trafficLayer = new google.maps.RoadMap();trafficLayer.setMap(map);}window.onerror = function () { return true; }</script></head><body onload=\"initialize()\" scroll=\"no\"><div id=\"map_canvas\"></div></body></html>";
        public void setMap(int i,string strLat, string strLng)
        {
            string strType;
            switch (i)
            {
                case 0:
                    {
                        strType = "SATELLITE";
                        break;
                    }
                case 1:
                    {
                        strType = "ROADMAP";
                        break;
                    }
                case 2:
                    {
                        strType = "TERRAIN";
                        break;
                    }
                default:
                    strType = "ROADMAP";
                    break;
                    
            }
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = di.Parent.Parent.FullName;
            FileStream fs = new FileStream(strPATH + @"\html\GoogleMap.htm", FileMode.OpenOrCreate);
            //获得字节数组
            byte[] data = new UTF8Encoding(false).GetBytes(strA+strLat+strC+strLng+strE + strType + strG);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
}
