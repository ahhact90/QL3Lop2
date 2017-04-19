using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QL3Lop2.Report
{
    public partial class rp_Mau19WithBA : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_Mau19WithBA(string dateNgayBD, string dateNgaKT)
        {
            InitializeComponent();
            xrlFrom.Text = dateNgayBD;
            xrlTo.Text = dateNgaKT;   
        }

    }
}
