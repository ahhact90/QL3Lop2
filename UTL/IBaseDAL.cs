using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UTL
{
    public interface IBaseDAL
    {
        /// <summary>
        /// Count all of records
        /// </summary>
        /// <returns>Number of records</returns>
        int Count();

        /// <summary>
        /// Select all data from table in database
        /// </summary>
        /// <returns>Data</returns>
        DataSet Select_non();

        ///// <summary>
        ///// Select all data from table in database
        ///// </summary>
        ///// <returns>Data</returns>
        //DataTable Select_2Cot();

        /// <summary>
        /// Select data by object from table in database
        /// </summary>
        /// <param name="obj">Condition</param>
        /// <returns>Data</returns>
        DataTable Select(object obj);

        /// <summary>
        /// Select khong co tham so
        /// </summary>
        /// <returns></returns>
        DataTable Select();
        /// <summary>
        /// LAY BAO CAO TRUYEN loai bao cao  mau 21 mau 20
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        DataSet Select_non2(string n);
        /// <summary>
        /// Truyen tham so thoi gian
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        DataSet Select_non3(DateTime to,DateTime from);

        /// <summary>
        /// Get a object by key
        /// </summary>
        /// <param name="key">Key need to get</param>
        /// <returns>Object</returns>
        object GetByKey(object key);

        /// <summary>
        /// Delete data by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>True is successfull else false</returns>
        bool Delete(string id);

        /// <summary>
        /// Insert object to table in database
        /// </summary>
        /// <param name="obj">Object need to insert</param>
        /// <returns>True is successfull else false</returns>
        bool Insert(object obj);

        /// <summary>
        /// Update object to table in database
        /// </summary>
        /// <param name="obj">Object need to update</param>
        /// <returns>True is successfull else false</returns>
        bool Update(object obj);

        /// <summary>
        /// Find & fillter by name
        /// </summary>
        /// <param name="name"> name </param>
        /// <returns> Datatable </returns>
        DataTable Search(string name);

        
    }
}
