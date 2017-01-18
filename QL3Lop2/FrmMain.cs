using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.Design.GroupSort;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
//using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QL3Lop2
{
    public partial class FrmMain : Form
    {
        #region Variable
        DAL.Mau21DAL _M21 = new DAL.Mau21DAL();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DAL.Mau20QNDAL _M20 = new DAL.Mau20QNDAL();
        DAL.Mau19QNDAL _M19 = new DAL.Mau19QNDAL();
        DAL.Mau19BQPKhacDAL _M19Khac = new DAL.Mau19BQPKhacDAL();
        DAL.Mau20BQPKhacDAL _M20Khac = new DAL.Mau20BQPKhacDAL();
        DAL.Mau21BQPKhacDAL _M21Khac = new DAL.Mau21BQPKhacDAL();
        DAL.CV3360BQP_QN _cv3360_qn = new DAL.CV3360BQP_QN();
        DAL.CV3360BQP_Khac _cv3360_khac = new DAL.CV3360BQP_Khac();
        
        #endregion

        public FrmMain()
        {
            InitializeComponent();            
            dte_tungay.Time = DateTime.Now;
            dte_denngay.Time = DateTime.Today.AddDays(+1).Date;

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            dt = _M21.Select();
            dtGridView.DataSource = dt;
        }

        private void btIn_Click(object sender, EventArgs e)
        {            
             ds = _M21.Select_non();
             if (ds == null)
             {
                 MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 Close();
             }
             try
             {

             }
             catch (Exception)
             {

                 throw;
             }
            Report.rp_Mau21 f21 = new Report.rp_Mau21();
            f21.DataSource = ds;
            f21.DataMember = ds.Tables[0].TableName;
            f21.ShowPreview();
          
           
        }

        private void btIn2_Click(object sender, EventArgs e)
        {           
            string N = textBox1.Text;
            ds = _M21.Select_non2(N);
           
            try
            {
                if (ds == null)
                {
                    MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }

            }
            catch (Exception)
            {

                //Report.rp_Mau21 f21 = new Report.rp_Mau21();
                //f21.DataSource = ds;
                //f21.DataMember = ds.Tables[0].TableName;
                //f21.ShowPreview();
            }

            Report.rp_Mau21 f21 = new Report.rp_Mau21();
            f21.DataSource = ds;
            f21.DataMember = ds.Tables[0].TableName;
            f21.ShowPreview();
        }
        /// <summary>
        /// Báo cáo mẫu 21 BHYT BQP QN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btTimes_Click(object sender, EventArgs e)
        {
            
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);          
            ds = _M21.Select_non3(FromDate,ToDate1);


            try
            {
                if (ds == null)
                {
                    MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");            
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau21_Time f21 = new Report.rp_Mau21_Time(dateNgayBD1, dateNgaKT1);            
            f21.DataSource = ds;
            f21.DataMember = ds.Tables[0].TableName;
            f21.ShowPreview();
        }

        private void dte_tungay_EditValueChanged(object sender, EventArgs e)
        {
            //dte_tungay = DateTime.No
        }
        /// <summary>
        /// Báo cáo mẫu 20 BHYT BQP QN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMau20_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            ds = _M20.Select_Time(FromDate, ToDate1);
            try
            {
                if (ds == null)
                {
                    MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");           
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau20QN f20 = new Report.rp_Mau20QN(dateNgayBD1, dateNgaKT1);           
            f20.DataSource = ds;
            f20.DataMember = ds.Tables[0].TableName;
            f20.ShowPreview();
        }
        /// <summary>
        /// Báo cáo mẫu 19 BHYT BQP QN 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMau19QN_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            ds = _M19.Select_Time(FromDate, ToDate1);
            try
            {
                if (ds == null)
                {
                    MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau19QN f19 = new Report.rp_Mau19QN(dateNgayBD1, dateNgaKT1);
            f19.DataSource = ds;
            f19.DataMember = ds.Tables[0].TableName;
            f19.ShowPreview();
        }
        /// <summary>
        /// Test tren DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            dt = _M19.Select_Time1();
            dtGridView.DataSource = dt;
        }
        /// <summary>
        /// Báo cáo mẫu 21 BHYT BQP Khac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMau21Khac_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            ds = _M21Khac.Select_Time(FromDate, ToDate1);

            try
            {
                if (ds == null)
                {
                    MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");           
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau21BQPKhac f21 = new Report.rp_Mau21BQPKhac(dateNgayBD1, dateNgaKT1);           
            f21.DataSource = ds;
            f21.DataMember = ds.Tables[0].TableName;
            f21.ShowPreview();

        }
        /// <summary>
        /// Báo cáo mẫu 20 BHYT BQP Khac 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMau20Khac_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            ds = _M20Khac.Select_Time(FromDate, ToDate1);
            try
            {
                if (ds == null)
                {
                    MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau20BQPKhac f20 = new Report.rp_Mau20BQPKhac(dateNgayBD1, dateNgaKT1);
            f20.DataSource = ds;
            f20.DataMember = ds.Tables[0].TableName;
            f20.ShowPreview();

        }
        /// <summary>
        /// Báo cáo mẫu 19 BHYT BQP Khac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMau19Khac_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            ds = _M19Khac.Select_Time(FromDate, ToDate1);
            try
            {
                if (ds == null)
                {
                    MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau19BQPKhac f19 = new Report.rp_Mau19BQPKhac(dateNgayBD1, dateNgaKT1);
            f19.DataSource = ds;
            f19.DataMember = ds.Tables[0].TableName;
            f19.ShowPreview();
        }

        private void cv3360Bqp_QN_NgTru_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            dt = _cv3360_qn.Select_QN_NgTru(FromDate, ToDate1);
            dtGridView.DataSource = dt;
        }
        /// <summary>
        /// Ham xuat ra file excel
        /// </summary>
        /// <param name="g"></param>
        /// <param name="duongDan"></param>
        /// <param name="tenTap"></param>
        private void export2Excel(DataGridView g, string duongDan)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            
            obj.ActiveWorkbook.SaveCopyAs(duongDan);           
            obj.ActiveWorkbook.Saved = true;
        }

        private void exportExcel_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName.ToString();
                    MessageBox.Show(path);
                    export2Excel(dtGridView,path);
                }

            }

            
            
           // export2Excel(dtGridView, @"path", "xuatfileExcel");

            
        }

        private void cv3360Bqp_QN_NTru_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            dt = _cv3360_qn.Select_QN_NTru(FromDate, ToDate1);
            dtGridView.DataSource = dt;
        }

        private void cv3360Bqp_Khac_NgTru_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            dt = _cv3360_khac.Select_QN_NgTru(FromDate, ToDate1);
            dtGridView.DataSource = dt;
        }

        private void cv3360Bqp_Khac_NTru_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            dt = _cv3360_khac.Select_QN_NTru(FromDate, ToDate1);
            dtGridView.DataSource = dt;
        }
       
    }
}


