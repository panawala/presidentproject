using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataLib
{
    public class DA_Index_Ex
    {
        

        /// <summary>
        /// Query Index By Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091208</date>
        public static IQueryable<DataLib.I_INDEX_EX> QueryIndex(int year, string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                
                return db.I_INDEX_EX.Where(c => c.FromDate.Year == year && c.I_ZONE.City == cityName);
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
        public static IQueryable<DataLib.I_INDEX_EX> Query12Index(string cityName, bool isYiwu)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                if (isYiwu)
                {
                    return db.I_INDEX_EX.Where(c => c.Group == 11 && c.I_ZONE.Township == cityName).OrderBy(c => c.Name).OrderBy(c => c.Class);
                }
                else
                {
                    return db.I_INDEX_EX.Where(c => c.Group == 11 && c.I_ZONE.District == cityName).OrderBy(c => c.Name).OrderBy(c => c.Class);
                }
            }
            catch (Exception ex)
            {
         
                return null;
            }
        }

        public static IQueryable<DataLib.I_INDEX_EX> QueryIndex(string name, string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                if (cityName == "金华市")
                    return db.I_INDEX_EX.Where(c => c.Name.Equals(name) && c.I_ZONE.ID == 824);
                else
                    return db.I_INDEX_EX.Where(c => c.Name.Equals(name) && c.I_ZONE.ID == 825);
            }
            catch (Exception ex)
            {
           
                return null;
            }
        }

        public static IQueryable<DataLib.I_INDEX_EX> Query12CityIndex(bool isYiWu)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                if(isYiWu)
                    return db.I_INDEX_EX.Where(c => c.Group == 11 && c.I_ZONE.ID == 824).OrderBy(c => c.Name).OrderBy(c => c.Class);
                else
                   return db.I_INDEX_EX.Where(c => c.Group == 11 && c.I_ZONE.ID == 825).OrderBy(c => c.Name).OrderBy(c => c.Class);
            }
            catch (Exception ex)
            {
             
                return null;
            }
        }
    }
}
