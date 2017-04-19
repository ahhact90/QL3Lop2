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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Threading;
using System.IO;
//using app = Microsoft.Office.Interop.Excel.Application;
using UTL;

namespace QL3Lop2
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
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
        DAL.Mau21WithBA _Mau21WithBA = new DAL.Mau21WithBA();

        #endregion

        public FrmMain()
        {
            InitializeComponent();            
            dte_tungay.Time = DateTime.Today;
            dte_denngay.Time = DateTime.Today.AddDays(+1).Date;

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            dt = _M21.Select();
           
            gridControl1.DataSource = dt;
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
            ds = _M21.Select_non3(FromDate, ToDate1);


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
            
            gridControl1.DataSource = dt;
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
           
            gridControl1.DataSource = dt;
        }        
        /// <summary>
        /// Xuat ra file excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportExcel_Click(object sender, EventArgs e)
        {

            //using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            //{
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        Thread thread = new Thread(() =>
            //       {
            //           string path = sfd.FileName.ToString(); /*+ "(" + DateTime.Now.ToString("yyyy-MM-dd") + ")";*/
            //           //MessageBox.Show(path);
            //           export2Excel(dtGridView, path);
            //       }
            //       );
            //        thread.Start();
            //    }

            //}

            //// Ham xuat Excel Bang Dev Nhanh
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010-2013-2016) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html|All File (.*)|*.*";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    //MessageBox.Show(exportFilePath);
                    
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridView1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridView1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridView1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridView1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridView1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridView1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }
                  

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            MessageBox.Show("Xuất dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



        }

        private void cv3360Bqp_QN_NTru_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            dt = _cv3360_qn.Select_QN_NTru(FromDate, ToDate1);           
            gridControl1.DataSource = dt;
        }

        private void cv3360Bqp_Khac_NgTru_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            dt = _cv3360_khac.Select_QN_NgTru(FromDate, ToDate1);           
            gridControl1.DataSource = dt;
        }

        private void cv3360Bqp_Khac_NTru_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            dt = _cv3360_khac.Select_QN_NTru(FromDate, ToDate1);           
            gridControl1.DataSource = dt;
           
        }

        private void btnMau21WithBA_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            string n = txtIndex.Text;
            string BA = txtBA.Text;
            txtBA.SelectAll();
            txtBA.Focus();
            ds = _Mau21WithBA.SelectWithMedical(n,BA);

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

               
            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau21WithBA f21 = new Report.rp_Mau21WithBA(dateNgayBD1, dateNgaKT1);
            f21.DataSource = ds;
            f21.DataMember = ds.Tables[0].TableName;
            f21.ShowPreview();

        }

        private void btnMau20WithBA_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            string n = txtIndex.Text;
            string BA = txtBA.Text;
            txtBA.SelectAll();
            txtBA.Focus();
            ds = _Mau21WithBA.SelectWithMedical(n, BA);

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


            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau20WithBA f20 = new Report.rp_Mau20WithBA(dateNgayBD1, dateNgaKT1);
            f20.DataSource = ds;
            f20.DataMember = ds.Tables[0].TableName;
            f20.ShowPreview();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
            string n = txtIndex.Text;
            string BA = txtBA.Text;
            txtBA.SelectAll();
            txtBA.Focus();
            ds = _Mau21WithBA.SelectWithMedical(n, BA);

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


            }
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau19WithBA f19 = new Report.rp_Mau19WithBA(dateNgayBD1, dateNgaKT1);
            f19.DataSource = ds;
            f19.DataMember = ds.Tables[0].TableName;
            f19.ShowPreview();
        }

    }
}



