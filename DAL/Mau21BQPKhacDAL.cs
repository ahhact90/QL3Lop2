using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Mau21BQPKhacDAL : BaseDAL, UTL.IBaseDAL
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
        #region Mau 21 BQP Khac
        public DataSet Select_Time(DateTime to, DateTime from)
        {
            var sql = "select * from his_insurance_service_detail_get_bqp_khac('{0}|{1}|21|3')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteDataset(sql);
        }
        #endregion
    }
}
