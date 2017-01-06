using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UTL;

namespace DAL
{
    public class Mau19QNDAL: BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public object GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string name)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public DataSet Select_non()
        {
            throw new NotImplementedException();
        }

        public DataSet Select_non2(string n)
        {
            throw new NotImplementedException();
        }

        public DataSet Select_non3(DateTime to, DateTime from)
        {
            throw new NotImplementedException();
        }

        public bool Update(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Mau 19 BQP_QN
        /// <summary>
        /// Mau 19 BQP QN
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public DataSet Select_Time(DateTime to, DateTime from)
        {
            var sql = "select * from his_insurance_service_detail_get_bqp_khac('{0}|{1}|19|3')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteDataset(sql);
        }

         public DataTable Select_Time1()
         {
             var sql = "select * from his_insurance_service_detail_get('2016-12-01 00:00:00|2016-12-31 23:59:59|19|3')";
             sql = string.Format(sql);
             return ExecuteQuery(sql);
         }

        #endregion

    }
}
