using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLib
{
    public class DA_Zone
    {
       
        /// <summary>
        /// Get Township List
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static List<string> GetTownshipList(string city)
        {
            try
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                TownDBDataContext db = new TownDBDataContext();
                if (city == "金华市")
                {
                    List<string> townshipList = (from z in db.I_ZONE where z.Layer == "Township" && z.City == city select z.Township).Distinct().ToList();
                    return townshipList;
                }
                else if (city == "南充市")
                {
                    List<string> townshipList = (from z in db.I_ZONE where z.Layer == "District" && z.City == city select z.District).Distinct().ToList();
                    return townshipList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
          
                return null;
            }
        }
    }
}
