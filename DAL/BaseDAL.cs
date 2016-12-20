using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using System.Configuration;

namespace DAL
{
    public abstract class BaseDAL
    {
        #region Contansts
        protected const string STR_BACKUP = @"BACKUP DATABASE {0} " +
            @"TO DISK = N'{1}' WITH NOFORMAT, NOINIT, " +
            @"NAME = N'{2}', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

        protected const string STR_RESTOR = @"USE MASTER; DROP DATABASE {0}; RESTORE DATABASE {0} " +
            @"FROM  DISK = N'{1}' WITH  FILE = 1, NOUNLOAD, STATS = 10";

        protected const string STR_CREATE = @"CREATE DATABASE {0} " +
            @"ON  PRIMARY (NAME = N'{0}', FILENAME = N'{1}\{0}.mdf', SIZE = 3072KB, FILEGROWTH = 1024KB) " +
            @"LOG ON (NAME = N'{0}_log', FILENAME = N'{1}\{0}_log.ldf', SIZE = 1024KB, FILEGROWTH = 10%) " +
            @"COLLATE VIETNAMESE_CI_AI";

        protected const string STR_DBNAME = "master";

        protected const string STR_DFO = "set dateformat dmy";
        #endregion

        #region Default objects
        #endregion

        #region More objects
        #endregion

        #region Properties
        protected NpgsqlConnection Cnn { get; set; }
        protected NpgsqlCommand Cmd { get; set; }
        protected NpgsqlDataAdapter Da { get; set; }

        public static string FileDb { set; get; }
        public static string DbName { set; get; }
        #endregion

        #region Implements
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseDAL()
        {
            //Cnn = new NpgsqlConnection(string.Format(DAL.Properties.Settings.Default.Setting)); // default connection string
            //Cnn = new NpgsqlConnection("server = localhost; port = 5432; user id = postgres; password = P@$121# ; Database = HMIS");
            Cnn = new NpgsqlConnection("server = 172.251.110.3; port = 5432; user id = bv121; password = @bv121@ ; Database = HMIS");
            Cmd = new NpgsqlCommand() { Connection = Cnn };
            //Da = new NpgsqlDataAdapter();
        }

        public BaseDAL(string connectString)
        {
            Cnn = new NpgsqlConnection(connectString);
            Cmd = new NpgsqlCommand() { Connection = Cnn };
            Da = new NpgsqlDataAdapter();

        }
        #endregion

        #region Events
        #endregion

        #region Methods
        /// <summary>
        /// Open connection
        /// </summary>
        /// <returns>True is open successfull else false</returns>
        protected bool Open()
        {
            try
            {
                if (Cnn.State == ConnectionState.Closed)
                    Cnn.Open();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        protected void Close()
        {
            if (Cnn.State != ConnectionState.Closed)
                Cnn.Close();
        }

        /// <summary>
        /// Execute query SQL command text
        /// </summary>
        /// <param name="sqlCommand">T-SQL</param>
        /// <param name="tableName">table name</param>
        /// <returns>data</returns>
        protected DataTable ExecuteQuery(string sqlCommand, string tableName = "Tmp")
        {
            try
            {
                Open();
                Cmd.CommandText = sqlCommand;
                var tbl = new DataTable(tableName);
                tbl.Load(Cmd.ExecuteReader());

                return tbl;
            }
            catch { return null; }
            finally { Close(); }
        }

        /// <summary>
        /// Execute non query SQL command text
        /// </summary>
        /// <param name="sqlCommand">T-SQL</param>
        /// <returns>number of records affect</returns>
        protected int ExecuteNonQuery(string sqlCommand)
        {
            try
            {
                Open();
                Cmd.CommandText = sqlCommand;
                return Cmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally { Close(); }
        }
        /// <summary>
        /// Return Dataset
        /// </summary>
        /// <param name="que"></param>
        /// <returns></returns>
        protected DataSet ExecuteDataset(string que)
        {
            try
            {
                Open();
                NpgsqlDataAdapter Da = new NpgsqlDataAdapter(que, Cnn);
                DataSet ds = new DataSet();
                Da.Fill(ds);
                return ds;
            }
            catch { return null; }
            finally { Close(); }
        }

        #endregion

        #region More
        #endregion
    }
}

