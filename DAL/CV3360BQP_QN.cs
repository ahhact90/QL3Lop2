using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTL;

namespace DAL
{
    public class CV3360BQP_QN:  BaseDAL, UTL.IBaseDAL
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
        #region Cv 3360 BQP QN
        /// <summary>
        /// CV 3360 BHYT BQP QN Ngoai Tru
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public DataSet Select_NgTru(DateTime to, DateTime from)
        {
            var sql = "select * from his_bhxh_3360_97_get_bqp_qn('{0}|{1}|1^3^4')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteDataset(sql);
        }
        public DataSet Select_NTru(DateTime to, DateTime from)
        {
            var sql = "select * from his_bhxh_3360_97_get_bqp_qn('{0}|{1}|2')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteDataset(sql);
        }
        /// <summary>
        /// DataGridView QN Ngoai Tru (BQP)
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <returns> DataTable </returns>
        public DataTable Select_QN_NgTru(DateTime to, DateTime from)
        {
            string format = "select * his_bhxh_3360_97_get_bqp_qn('{0}|{1}|1^3^4')";
            format = string.Format(format, to.ToString("yyyy-MM-dd hh:mm:ss"), from.ToString("yyyy-MM-dd hh:mm:ss"));
            return ExecuteQuery(format);
        }
        /// <summary>
        /// DataGridView QN Noi Tru (BQP)
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public DataTable Select_QN_NTru(DateTime to, DateTime from)
        {
            string format = "select * his_bhxh_3360_97_get_bqp_qn('{0}|{1}|2')";
            format = string.Format(format, to.ToString("yyyy-MM-dd hh:mm:ss"), from.ToString("yyyy-MM-dd hh:mm:ss"));
            return ExecuteQuery(format);
        }
        #endregion

    }
}
