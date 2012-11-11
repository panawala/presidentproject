using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataLib
{
    public class DA_Index
    {
      

        /// <summary>
        /// Query Index By Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091208</date>
        public static IQueryable<DataLib.I_INDEX> QueryIndex(int year, string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX.Where(c => c.FromDate.Year == year && c.I_ZONE.City == cityName);
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
        public static IQueryable<DataLib.I_INDEX> QueryIndex(string indexName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX.Where(c => c.Name == indexName);
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
        public static IQueryable<DataLib.I_INDEX> QueryIndex(string name, string cityName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_INDEX.Where(c => c.Name.Equals(name) && c.I_ZONE.City == cityName);
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
        public static IQueryable<DataLib.I_INDEX> Query12Index(string cityName, bool isYiwu)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                if (isYiwu)
                {
                    return db.I_INDEX.Where(c => c.Group == 11 && c.I_ZONE.Township == cityName).OrderBy(c => c.Name).OrderBy(c => c.Class);
                }
                else
                {
                    return db.I_INDEX.Where(c => c.Group == 11 && c.I_ZONE.District == cityName).OrderBy(c => c.Name).OrderBy(c => c.Class);
                }
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
        public static IQueryable<DataLib.I_INDEX> QueryIndexByZone(string zoneName)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();

                if (db.I_INDEX.Where(c => c.I_ZONE.Township.Contains(zoneName)).Count() > 0)
                {
                    return db.I_INDEX.Where(c => c.I_ZONE.Township.Contains(zoneName)).OrderBy(c => c.FromDate.Year).OrderBy(c => c.Group);
                }
                else
                {
                    return db.I_INDEX.Where(c => c.I_ZONE.District.Contains(zoneName)).OrderBy(c => c.FromDate.Year).OrderBy(c => c.Group);
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
                var yearCollect = (from y in db.I_INDEX where y.Name.Contains(name) && y.I_ZONE.City == cityName select y.FromDate.Year).Distinct();
                return yearCollect.ToList();
            }
            catch (Exception ex)
            {
           
                return null;
            }
        }

        public static void InitiaDb()
        {
            TownDBDataContext db = new TownDBDataContext();
            if(db.I_INDEX.Where(c=>c.Name=="中等教育人数比重").First().Group==8)
            {
                var q = from p in db.I_INDEX
                        where (p.Name == "中等教育人数比重" || p.Name == "水环境综合污染指数" || p.Name == "非建成用地比重变化率"
                        || p.Name == "GDP三产比重增长率" || p.Name == "人均GDP增长率" || p.Name == "地均GDP"
                        || p.Name == "城乡收入差距" || p.Name == "城镇居民人均住房使用面积" || p.Name == "千人拥有病床数"
                        || p.Name == "万元GDP综合能耗变化率" || p.Name == "人均建成用地面积" || p.Name == "净迁移率")
                        select p;
                foreach (var p in q)  
                {
                    p.Group = 11;
                }
                db.SubmitChanges();
            }
            
        }

    }
}
