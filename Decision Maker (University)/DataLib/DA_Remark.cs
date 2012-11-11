using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLib
{
    public class DA_Remark
    {
      
        /// <summary>
        /// Query Remark Text
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rankvalue"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20100324</date>
        static public string QueryRemark(string name, int rankvalue)
        {
            try
            {
                TownDBDataContext db = new TownDBDataContext();
                return db.I_REMARK.Where(c => c.Name == name && c.Rank == rankvalue).First().Reamrk;
            }
            catch (Exception ex)
            {
             
                return "";
            }
        }
    }
}
