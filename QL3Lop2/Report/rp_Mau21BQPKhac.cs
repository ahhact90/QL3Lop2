﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QL3Lop2.Report
{
    public partial class rp_Mau21BQPKhac : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_Mau21BQPKhac(string dateNgayBD, string dateNgaKT)
        {
            InitializeComponent();
            xrlFrom.Text = dateNgayBD;
            xrlTo.Text = dateNgaKT; 
        }

    }
}
