using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLib
{
    public class DA_Devide
    {
        
        /// <summary>
        /// Get Devide Result
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static Dictionary<int, string> GetDevideResult(int year, string city)
        {
            try
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                TownDBDataContext db = new TownDBDataContext();
                IQueryable<I_DEVIDE> devide = db.I_DEVIDE.Where(c => c.FromDate.Year == year && db.I_ZONE.Single(e=>e.ID==c.Zone).City == city);
                foreach (I_DEVIDE d in devide)
                {
                    result.Add((int)d.Zone,d.Attribute);
                }
                return result;
            }
            catch (Exception ex)
            {
         
                return null;
            }
        }
    }
}
