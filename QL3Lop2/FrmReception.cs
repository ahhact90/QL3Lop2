using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL3Lop2
{
    public partial class FrmReception : Form
    {
        private string backvalue;
        public string BackedValu
        {
            get
            {
                return backvalue;
            }
            set { backvalue = value; }
        }
        #region Variable
        DAL.ReceptionDAL Reception = new DAL.ReceptionDAL();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        public FrmReception()
        {
            InitializeComponent();
            txtBenhNhan.Focus();
            
            
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dte_tungay_EditValueChanged(object sender, EventArgs e)
        {

        }
        public string Tachten(string s)
        {
           
            string[] arrayStr = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries); //=>> chỗ này nó sẽ split ra 1 mảng 3 phần tử 
            string firstName = arrayStr[0]; //=> Lấy họ 
            string lastName = arrayStr[arrayStr.Length - 1]; //=> Lấy tên 
            StringBuilder midleName = new StringBuilder(); //Lấy tên đệm 
            for (int i = 1; i < arrayStr.Length - 1; i++) 
                { midleName.Append(arrayStr[i] + " "); }

            return firstName;
        }
        public string TachChuLot(string s)
        {
            
            string[] arrayStr = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries); //=>> chỗ này nó sẽ split ra 1 mảng 3 phần tử 
            string firstName = arrayStr[0]; //=> Lấy họ 
            string lastName = arrayStr[arrayStr.Length - 1]; //=> Lấy tên 
            StringBuilder midleName = new StringBuilder(); //Lấy tên đệm 
            for (int i = 1; i < arrayStr.Length - 1; i++)
            { midleName.Append(arrayStr[i] + " "); }
            string midleName1 = midleName.ToString();
            return  midleName1;
        }
        public string TachHo(string s)
        {
            
            string[] arrayStr = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries); //=>> chỗ này nó sẽ split ra 1 mảng 3 phần tử 
            string firstName = arrayStr[0]; //=> Lấy họ 
            string lastName = arrayStr[arrayStr.Length - 1]; //=> Lấy tên 
            StringBuilder midleName = new StringBuilder(); //Lấy tên đệm 
            for (int i = 1; i < arrayStr.Length - 1; i++)
            { midleName.Append(arrayStr[i] + " "); }

            return lastName;
        }

        private void FrmReception_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {

                if (e.KeyCode.Equals(Keys.S))//= Ctrl + S
                {
                    //button1_Click(sender, e);
                    string chulot = TachChuLot(txtBenhNhan.Text.ToString());
                    txtBenhNhan.Text.Trim();
                    txtNgheNghiep.Text = chulot.Trim();
                    MessageBox.Show("Đã gửi tách chữ lót thành công");
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chulot = TachChuLot(txtBenhNhan.Text.ToString());
            txtNgheNghiep.Text = chulot;

            MessageBox.Show("Đã gửi tách chữ lót thành công");
        }

        private void txtBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dteNamsinh.Focus();
                txtBenhNhan.Text = txtBenhNhan.Text.ToUpper().Trim();
            }
        }

        private void dteNamsinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboSex.Focus();
            }
        }

        private void comboSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDanToc.Focus();
            }
        }

        private void txtDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNgheNghiep.Focus();
            }
        }


        private void FrmReception_Load(object sender, EventArgs e)
        {
            //txtNgheNghiep.Text = FrmDialog.a;
            dte_now.Time = DateTime.Now;
            
            string[] sexs = { "Nam", "Nữ" };
            foreach (string sex in sexs)
            {
                comboSex.Properties.Items.Add(sex.ToString());
            }
            txtBenhNhan.Select();
            txtBenhNhan.Focus();
            this.KeyPreview = true;
        }

        private void txtNgheNghiep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*
                //Application.Run(new FrmDialog());
                FrmDialog frm = new FrmDialog();
                //frm.MdiParent = this;
                //  this.Hide();
                frm.StartPosition = FormStartPosition.CenterScreen; 
                //frm.Left = 525;
                //frm.Top = 330;
                frm.ShowDialog(this);
                txtNgheNghiep.Text = FrmDialog.a;
               
                txtSoNha.Focus();
                 * */
                FrmNgheNghiep frm = new FrmNgheNghiep();
                frm.ShowDialog();
                txtNgheNghiep.Text = frm.Passvalue;
                txtSoNha.Focus();
            }
                        
        }

        private void txtSoNha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiachi.Focus();
            }
        }

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKieuKham.Focus();
            }
        }

        private void txtKieuKham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhongKham.Focus();
            }
        }

        private void txtNgheNghiep_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNgheNghiep_EditValueChanged(object sender, EventArgs e)
        {
            

        }

        private void txtNgheNghiep_Click(object sender, EventArgs e)
        {
            //txtNgheNghiep.MaskBox.AutoCompleteCustomSource.Clear();
            //dt = Reception.SearchTextbox();
         
            //foreach (DataRow r in dt.Rows)
            //{
            //    //getting all rows in the specific field|Column
            //    var rw = r.Field<string>("name");       

            //    //Set the properties of a textbox to make it auto suggest and append.
            //    txtNgheNghiep.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    txtNgheNghiep.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    //adding all rows into the textbox
            //    txtNgheNghiep.MaskBox.AutoCompleteCustomSource.Add(rw);

            //} 
        }
    }
}
