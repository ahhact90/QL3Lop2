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
        /// <summary>
        /// Dialog Nghề nghiệp trong Form Tiếp đoán bệnh nhân
        /// </summary>
        /// <returns></returns>
        public DataTable NgheNghiep()
        {
            var sql = "select name,line from hms_selection  where sector = 'occupation' order by line ";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }
        public DataTable DanToc()
        {
            var sql = "select name,line from hms_selection  where sector = 'ethnic'";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }
        #endregion
    }
}
