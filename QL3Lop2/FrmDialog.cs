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
    public partial class FrmDialog : Form
    {
        #region Variable
        DAL.ReceptionChiTietDAL ReceptionChiTiet = new DAL.ReceptionChiTietDAL();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();       

        #endregion
        public FrmDialog()
        {
            InitializeComponent();
        }

        private void FrmDialog_Load(object sender, EventArgs e)
        {
            dt = ReceptionChiTiet.SearchTextbox();
            gridControlNgheNghiep.DataSource = dt;
            
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
