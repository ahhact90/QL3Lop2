using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL3Lop2
{
    public partial class FrmDiaChi : Form
    {
        public static string a;
        public string Nm;        
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }
        private string diachichitiet;
        public string Diachichitiet
        {
            get { return diachichitiet; }
            set { diachichitiet = value; }
        }

        #region Variable
        DAL.ReceptionChiTietDAL ReceptionChiTiet = new DAL.ReceptionChiTietDAL();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        #endregion
        public FrmDiaChi()
        {
            InitializeComponent();
        }

        private void FrmDiaChi_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(Diachichitiet);       

            dt = ReceptionChiTiet.DiaChi(Diachichitiet); // goi ham do tim kiem dia chi do
            gridControlDiaChi.DataSource = dt;
        }

        private void gridControlDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridViewDiaChi_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string cellValue;
            cellValue = gridViewDiaChi.GetFocusedRowCellValue("name").ToString();
            //MessageBox.Show(cellValue);
            a = cellValue;
            Passvalue = cellValue;
            this.Hide();
        }

        private void gridViewDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cellValue;
                cellValue = gridViewDiaChi.GetFocusedRowCellValue("name").ToString();
                //MessageBox.Show(cellValue);
                a = cellValue;
                Passvalue = cellValue;
                this.Hide();
            }
        }

        private void FrmDiaChi_SizeChanged(object sender, EventArgs e)
        {

            gridControlDiaChi.Left = ClientSize.Width ;
            gridControlDiaChi.Top = ClientSize.Height ;
        
        }

    }
}
