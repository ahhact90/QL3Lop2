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
        /// <summary>
        ///  Hiển thị dân tộc
        /// </summary>
        /// <returns></returns>
        public DataTable DanToc()
        {
            var sql = "select name,line from hms_selection  where sector = 'ethnic' order by line";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }
        /// <summary>
        ///  Tìm kiếm địa chỉ ở của bệnh nhân
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable DiaChi(string name)
        {
            var sql = "select precintid,name from hms_residentview where abbreviation like N'%{0}%' ";
            sql = string.Format(sql,name);
            return ExecuteQuery(sql);
        }

        #endregion
    }
}
