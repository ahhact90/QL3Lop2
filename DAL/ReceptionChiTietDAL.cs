using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ReceptionChiTietDAL: BaseDAL
    {   

        #region Implement

        public DataTable SearchTextbox()
        {
            var sql = "select name,line from hms_selection  where sector = 'occupation'";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }

        #endregion
    }
}
