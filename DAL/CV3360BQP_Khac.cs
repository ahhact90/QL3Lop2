using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class CV3360BQP_Khac : BaseDAL, UTL.IBaseDAL
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

        public System.Data.DataTable Search(string name)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Select()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select_non()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select_non2(string n)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select_non3(DateTime to, DateTime from)
        {
            throw new NotImplementedException();
        }

        public bool Update(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Cv 3360 BQP Khac
        /// <summary>
        /// CV 3360 BHYT BQP Khac Ngoai Tru
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public DataSet Select_NgTru(DateTime to, DateTime from)
        {
            var sql = "select * from his_bhxh_3360_97_get_bqp_khac('{0}|{1}|1^3^4')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteDataset(sql);
        }
        public DataSet Select_NTru(DateTime to, DateTime from)
        {
            var sql = "select * from his_bhxh_3360_97_get_bqp_khac('{0}|{1}|2')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteDataset(sql);
        }

        #endregion
    }
}
