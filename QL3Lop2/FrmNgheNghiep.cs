﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace QL3Lop2
{
    public partial class FrmNgheNghiep : Form
    {
        public static string a;
        public string Nm;
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }
        #region Variable
        DAL.ReceptionChiTietDAL ReceptionChiTiet = new DAL.ReceptionChiTietDAL();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        #endregion
        public FrmNgheNghiep()
        {
            InitializeComponent();
            
        }

        private void FrmDialog_Load(object sender, EventArgs e)
        {
            dt = ReceptionChiTiet.NgheNghiep();
            gridControlNgheNghiep.DataSource = dt;

        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }


        }



        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //  string value = gridView1.GetFocusedRowCellValue("Username").ToString();
            //  MessageBox.Show(value);
            string cellValue;
            //string cellValue1;
            cellValue = gridView1.GetFocusedRowCellValue("name").ToString();
            //cellValue1 = gridView1.GetFocusedRowCellValue("id").ToString();
            //  MessageBox.Show(cellValue);
            a = cellValue;
            Passvalue = cellValue;
            this.Hide();


        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string cellValue;
                //cellValue = gridView1.GetFocusedRowCellValue("name").ToString();
                cellValue = gridView1.GetFocusedRowCellValue("name").ToString();
                //MessageBox.Show(cellValue1);
                a = cellValue;
                Passvalue = cellValue;
                this.Hide();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.SeaShell;
                e.Appearance.ForeColor = Color.Green;
                e.HighPriority = true;

            }
            else
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
                e.Appearance.ForeColor = Color.IndianRed;
                e.HighPriority = true;
            }
        }


    }
}
    