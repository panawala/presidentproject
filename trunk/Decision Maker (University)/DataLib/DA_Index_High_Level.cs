using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLib
{
    public class DA_Index_High_Level
    {
        

        /// <summary>
        /// Query Index By Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091208</date>
        public static IQueryable<DataLib.I_INDEX_HIGH_LEVEL> QueryIndex(int year, string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX_HIGH_LEVELs.Where(c => c.FromDate.Year == year && c.I_ZONE.City == cityName);
            }
            catch (Exception ex)
            {
            
                return null;
            }
        }

        public static IQueryable<DataLib.I_INDEX_HIGH_LEVEL> QueryIndexByCity(string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                if (cityName == "金华市")
                {
                    return db.I_INDEX_HIGH_LEVELs.Where(c => c.Zone == 824).OrderBy(c => c.FromDate.Year).OrderBy(c => c.Group);
                }
                else
                {
                    return db.I_INDEX_HIGH_LEVELs.Where(c => c.Zone == 825).OrderBy(c => c.FromDate.Year).OrderBy(c => c.Group);
                }
            }
            catch (Exception ex)
            {
           
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public static IQueryable<DataLib.I_INDEX_HIGH_LEVEL> QueryIndex(string indexName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX_HIGH_LEVELs.Where(c => c.Name == indexName);
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }
        /// <summary>
        /// Query Index By Name
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091208</date>
        public static IQueryable<DataLib.I_INDEX_HIGH_LEVEL> QueryIndex(string name, string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX_HIGH_LEVELs.Where(c => c.Name.Equals(name) && c.I_ZONE.City == cityName);
            }
            catch (Exception ex)
            {
              
                return null;
            }
        }

        /// <summary>
        /// Query 12 Index By Name
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091208</date>
        public static IQueryable<DataLib.I_INDEX_HIGH_LEVEL> Query12Index(string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX_HIGH_LEVELs.Where(c => c.Group == 11 && c.I_ZONE.City == cityName).OrderBy(c => c.Name).OrderBy(c => c.Class);

            }
            catch (Exception ex)
            {
               
                return null;
            }
        }


        /// <summary>
        /// Query Index By Zone
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091208</date>
        public static IQueryable<DataLib.I_INDEX_HIGH_LEVEL> QueryIndexByZone(string zoneName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX_HIGH_LEVELs.Where(c => c.I_ZONE.City.Contains(zoneName)).OrderBy(c => c.FromDate.Year).OrderBy(c => c.Group);

            }
            catch (Exception ex)
            {
               
                return null;
            }
        }
        public static IQueryable<DataLib.I_INDEX_HIGH_LEVEL> QueryIndexBySZone(string zoneName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                if(zoneName=="义乌市")
                return db.I_INDEX_HIGH_LEVELs.Where(c => c.Zone==824).OrderBy(c => c.FromDate.Year).OrderBy(c => c.Group);
                else
                {
                    return db.I_INDEX_HIGH_LEVELs.Where(c => c.Zone == 825).OrderBy(c => c.FromDate.Year).OrderBy(c => c.Group);
                }
            }
            catch (Exception ex)
            {
           
                return null;
            }
        }

        /// <summary>
        /// Get Available Years of the specific index name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091222</date>
        public static List<int> GetAvailableYear(string name, string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                var yearCollect = (from y in db.I_INDEX_HIGH_LEVELs where y.Name.Contains(name) && y.I_ZONE.City == cityName select y.FromDate.Year).Distinct();
                return yearCollect.ToList();
            }
            catch (Exception ex)
            {
          
                return null;
            }
        }
    }
}
