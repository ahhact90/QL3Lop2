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
            dte_now.Time = DateTime.Now;
            string[] sexs = { "Nam", "Nữ" };
            foreach (string sex in sexs)
            {
                comboBoxSex.Properties.Items.Add(sex.ToString());
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dte_tungay_EditValueChanged(object sender, EventArgs e)
        {

        }
        public void Tachten(string s)
        {
            //string test="Phạm Văn Khánh"; 
            string[] arrayStr=s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries); //=>> chỗ này nó sẽ split ra 1 mảng 3 phần tử 
            string firstName=arrayStr[0]; //=> Lấy họ 
            string lastName = arrayStr[arrayStr.Length - 1]; //=> Lấy tên 
            StringBuilder midleName=new StringBuilder(); //Lấy tên đệm 
            for (int i = 1; i < arrayStr.Length - 1; i++) { midleName.Append(arrayStr[i] + " "); }


        }       
    }
}
