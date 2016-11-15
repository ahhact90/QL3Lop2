﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UTL;

namespace DAL
{
    //this.f = new UTL();
    public class Mau21DAL : BaseDAL, UTL.IBaseDAL
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
            //Select(DateTime fromdate, DateTime todate)
            var sql = "select * from his_insurance_service_detail_get('2016-07-01 0:0:0|2016-07-31 23:59:59|21|3')";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
            // throw new NotImplementedException();
        }
        public DataSet Select_non()
        {
            //Select(DateTime fromdate, DateTime todate)
            var sql = "select * from his_insurance_service_detail_get('2016-07-01 0:0:0|2016-09-30 23:59:59|21|3')";
            sql = string.Format(sql);
            return ExecuteDataset(sql);
            // throw new NotImplementedException();
        }
        public DataSet Select_non3(DateTime to,DateTime from)
        {
            //var sql = "select * from his_insurance_service_detail_get('2016-04-01 0:0:0|2016-04-30 23:59:59|21|1')";
            //sql = string.Format(sql);
            //return ExecuteDataset(sql);

            var sql = "select * from his_insurance_service_detail_get('{0}|{1}|21|3')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd hh:mm:ss"), from.ToString("yyyy-MM-dd hh:mm:ss"));
            return ExecuteDataset(sql);
        }
        public DataSet Select_non2(string so)
        {
            //var sql = "select * from his_insurance_service_detail_get(' '{0}'|'{1}'|21|1')";
            //sql = string.Format(sql, From.ToString("dd-MM-yyyy hh:mm:ss"), tden.ToString("dd-MM-yyyy hh:mm:ss"));
            //return ExecuteDataset(sql);
            var sql = "select * from his_insurance_service_detail_get('2016-07-01 0:0:0|2016-09-30 23:59:59|{0}|3')";
            sql = string.Format(sql,so);
            return ExecuteDataset(sql);
        }


        public bool Update(object obj)
        {
            throw new NotImplementedException();
        }
        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion




    }
}
