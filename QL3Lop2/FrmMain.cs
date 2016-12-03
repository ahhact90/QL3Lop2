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

namespace QL3Lop2
{
    public partial class FrmMain : Form
    {
        #region Variable
        DAL.Mau21DAL _M21 = new DAL.Mau21DAL();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
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
            //DataTable dulieu1 = _M21.Select_non();
            //dtGridView.DataSource = dulieu1;
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
            //DateTime FromDate = Convert.ToDateTime(dte_tungay.Text);
            //DateTime ToDate = Convert.ToDateTime(dte_denngay.Text);
           //textBox1.text = FromDate;
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

        private void btTimes_Click(object sender, EventArgs e)
        {
            
            DateTime FromDate = Convert.ToDateTime(dte_tungay.Time);
            DateTime ToDate1 = Convert.ToDateTime(dte_denngay.Time);
           // DateTime toDate = DateTime.ParseExact(dte_denngay, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentUICulture);
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
            //string dateNgayBD = Convert.ToString(dte_tungay.Time);
            string dateNgayBD1 = dte_tungay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            //string dateNgaKT = Convert.ToString(dte_denngay.Time);
            string dateNgaKT1 = dte_denngay.Time.ToString("dd-MM-yyyy HH:mm:ss");
            Report.rp_Mau21_Time f21 = new Report.rp_Mau21_Time(dateNgayBD1, dateNgaKT1);
            //f21.Parameters["To"].Value = ToDate1;
            //f21.Parameters["From"].Value = FromDate;
            f21.DataSource = ds;
            f21.DataMember = ds.Tables[0].TableName;
            f21.ShowPreview();
        }

        private void dte_tungay_EditValueChanged(object sender, EventArgs e)
        {
            //dte_tungay = DateTime.No
        }
    }
}


