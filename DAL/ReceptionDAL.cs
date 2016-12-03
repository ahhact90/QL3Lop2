using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class ReceptionDAL : BaseDAL, UTL.IBaseDAL
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
        public DataTable SearchTextbox()
        {
            var sql = "select name,line from hms_selection  where sector = 'occupation' ";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }

        #endregion

       
    }
}
