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
    public partial class FrmReception : Form
    {
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
                    txtNgheNghiep.Text = chulot;
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
    }
}
