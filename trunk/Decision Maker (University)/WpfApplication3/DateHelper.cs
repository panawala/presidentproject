using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication3
{
    class DateHelper
    {
        public string getDayofWeek()
        {
            string dayofweek = DateTime.Now.DayOfWeek.ToString(); //获取星期   // Thursday->Thu.
            dayofweek = dayofweek.Substring(0, 3) + ".";
            return dayofweek;
        }
        public string getDayofWeekzh()
        {
            string dayofweek = DateTime.Now.DayOfWeek.ToString(); //获取星期   // Thursday->星期四
            switch(dayofweek){
                case "Monday":
                   dayofweek ="星期一" ;
                   break;
                case "Tuesday":
                   dayofweek = "星期二";
                   break;
                case "Wensday":
                   dayofweek = "星期三";
                   break;
                case "Thursday":
                   dayofweek = "星期四";
                   break;
                case "Friday":
                   dayofweek = "星期五";
                   break;
                case "Saturday":
                   dayofweek = "星期六";
                   break;
                case "Sunday":
                   dayofweek = "星期日";
                   break;
            }
            return dayofweek;
        }
        public string getMonth()
        {
            string month = DateTime.Now.Month.ToString(); 
            switch (month){
                case "1":
                    month = "Jan.";
                    break;
                case "2":
                    month = "Feb.";
                    break;
                case "3":
                    month = "Mar.";
                    break;
                case "4":
                    month = "Apr.";
                    break;
                case "5":
                    month = "May.";
                    break;
                case "6":
                    month = "June.";
                    break;
                case "7":
                    month = "July.";
                    break;
                case "8":
                    month = "Aug.";
                    break;
                case "9":
                    month = "Sept.";
                    break;
                case "10":
                    month = "Oct.";
                    break;
                case "11":
                    month = "Nov.";
                    break;
                case "12":
                    month = "Dec.";
                    break;
            }
            return month;  //月份;
        }
        public string getMonthzh()
        {
            string month = DateTime.Now.Month.ToString();
            switch (month)
            {
                case "1":
                    month = "一月";
                    break;
                case "2":
                    month = "二月";
                    break;
                case "3":
                    month = "三月";
                    break;
                case "4":
                    month = "四月";
                    break;
                case "5":
                    month = "五月";
                    break;
                case "6":
                    month = "六月";
                    break;
                case "7":
                    month = "七月";
                    break;
                case "8":
                    month = "八月";
                    break;
                case "9":
                    month = "九月";
                    break;
                case "10":
                    month = "十月";
                    break;
                case "11":
                    month = "十一月";
                    break;
                case "12":
                    month = "十二月";
                    break;
            }
            return month;  //月份;
        }
        public string getDay() {
            return DateTime.Now.Day.ToString();     //日期
        }
        public string getTime() {
            return DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();        //"获取时间  hh：mm"
        }
    }
}
