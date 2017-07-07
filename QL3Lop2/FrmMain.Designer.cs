namespace QL3Lop2
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.btIn = new System.Windows.Forms.Button();
            this.dte_tungay = new DevExpress.XtraEditors.TimeEdit();
            this.btIn2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMau21QN = new System.Windows.Forms.Button();
            this.dte_denngay = new DevExpress.XtraEditors.TimeEdit();
            this.btnMau20QN = new System.Windows.Forms.Button();
            this.btnMau19QN = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnMau21Khac = new System.Windows.Forms.Button();
            this.btnMau20Khac = new System.Windows.Forms.Button();
            this.btnMau19Khac = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cv3360Bqp_QN_NgTru = new System.Windows.Forms.Button();
            this.cv3360Bqp_Khac_NgTru = new System.Windows.Forms.Button();
            this.cv3360Bqp_QN_NTru = new System.Windows.Forms.Button();
            this.cv3360Bqp_Khac_NTru = new System.Windows.Forms.Button();
            this.exportExcel = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtIndex = new DevExpress.XtraEditors.TextEdit();
            this.btnMau21WithBA = new DevExpress.XtraEditors.SimpleButton();
            this.btnMau20WithBA = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.richtxtbox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dte_tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndex.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConnect.Location = new System.Drawing.Point(12, 30);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(98, 38);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "KetNoi";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btIn
            // 
            this.btIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIn.Location = new System.Drawing.Point(116, 30);
            this.btIn.Name = "btIn";
            this.btIn.Size = new System.Drawing.Size(98, 38);
            this.btIn.TabIndex = 0;
            this.btIn.Text = "In Mau 21";
            this.btIn.UseVisualStyleBackColor = true;
            this.btIn.Click += new System.EventHandler(this.btIn_Click);
            // 
            // dte_tungay
            // 
            this.dte_tungay.EditValue = new System.DateTime(2016, 11, 13, 0, 0, 0, 0);
            this.dte_tungay.Location = new System.Drawing.Point(41, 433);
            this.dte_tungay.Name = "dte_tungay";
            this.dte_tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dte_tungay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dte_tungay.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm:ss tt";
            this.dte_tungay.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.dte_tungay.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.dte_tungay.Properties.Mask.ShowPlaceHolders = false;
            this.dte_tungay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dte_tungay.Size = new System.Drawing.Size(155, 20);
            this.dte_tungay.TabIndex = 2;
            this.dte_tungay.EditValueChanged += new System.EventHandler(this.dte_tungay_EditValueChanged);
            // 
            // btIn2
            // 
            this.btIn2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIn2.Location = new System.Drawing.Point(220, 31);
            this.btIn2.Name = "btIn2";
            this.btIn2.Size = new System.Drawing.Size(167, 37);
            this.btIn2.TabIndex = 4;
            this.btIn2.Text = "Xem Trang In";
            this.btIn2.UseVisualStyleBackColor = true;
            this.btIn2.Click += new System.EventHandler(this.btIn2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(516, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 21);
            this.textBox1.TabIndex = 5;
            // 
            // btnMau21QN
            // 
            this.btnMau21QN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMau21QN.Location = new System.Drawing.Point(421, 416);
            this.btnMau21QN.Name = "btnMau21QN";
            this.btnMau21QN.Size = new System.Drawing.Size(137, 51);
            this.btnMau21QN.TabIndex = 6;
            this.btnMau21QN.Text = "Mẫu 21 QN Theo Thời Gian";
            this.btnMau21QN.UseVisualStyleBackColor = true;
            this.btnMau21QN.Click += new System.EventHandler(this.btTimes_Click);
            // 
            // dte_denngay
            // 
            this.dte_denngay.EditValue = new System.DateTime(2016, 11, 13, 0, 0, 0, 0);
            this.dte_denngay.Location = new System.Drawing.Point(249, 433);
            this.dte_denngay.Name = "dte_denngay";
            this.dte_denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dte_denngay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dte_denngay.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss tt";
            this.dte_denngay.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.dte_denngay.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.dte_denngay.Properties.Mask.ShowPlaceHolders = false;
            this.dte_denngay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dte_denngay.Size = new System.Drawing.Size(158, 20);
            this.dte_denngay.TabIndex = 2;
            // 
            // btnMau20QN
            // 
            this.btnMau20QN.Location = new System.Drawing.Point(572, 416);
            this.btnMau20QN.Name = "btnMau20QN";
            this.btnMau20QN.Size = new System.Drawing.Size(107, 51);
            this.btnMau20QN.TabIndex = 8;
            this.btnMau20QN.Text = "Mẫu 20 QN Theo Thời Gian";
            this.btnMau20QN.UseVisualStyleBackColor = true;
            this.btnMau20QN.Click += new System.EventHandler(this.btnMau20_Click);
            // 
            // btnMau19QN
            // 
            this.btnMau19QN.Location = new System.Drawing.Point(686, 416);
            this.btnMau19QN.Name = "btnMau19QN";
            this.btnMau19QN.Size = new System.Drawing.Size(125, 53);
            this.btnMau19QN.TabIndex = 9;
            this.btnMau19QN.Text = "Mẫu 19 QN Theo Thời Gian";
            this.btnMau19QN.UseVisualStyleBackColor = true;
            this.btnMau19QN.Click += new System.EventHandler(this.btnMau19QN_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(30, 459);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(90, 50);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMau21Khac
            // 
            this.btnMau21Khac.Location = new System.Drawing.Point(421, 479);
            this.btnMau21Khac.Name = "btnMau21Khac";
            this.btnMau21Khac.Size = new System.Drawing.Size(137, 46);
            this.btnMau21Khac.TabIndex = 11;
            this.btnMau21Khac.Text = "Mẫu 21 BQP Khác";
            this.btnMau21Khac.UseVisualStyleBackColor = true;
            this.btnMau21Khac.Click += new System.EventHandler(this.btnMau21Khac_Click);
            // 
            // btnMau20Khac
            // 
            this.btnMau20Khac.Location = new System.Drawing.Point(572, 479);
            this.btnMau20Khac.Name = "btnMau20Khac";
            this.btnMau20Khac.Size = new System.Drawing.Size(104, 47);
            this.btnMau20Khac.TabIndex = 12;
            this.btnMau20Khac.Text = "Mẫu 20 BQP Khác";
            this.btnMau20Khac.UseVisualStyleBackColor = true;
            this.btnMau20Khac.Click += new System.EventHandler(this.btnMau20Khac_Click);
            // 
            // btnMau19Khac
            // 
            this.btnMau19Khac.Location = new System.Drawing.Point(686, 479);
            this.btnMau19Khac.Name = "btnMau19Khac";
            this.btnMau19Khac.Size = new System.Drawing.Size(124, 46);
            this.btnMau19Khac.TabIndex = 13;
            this.btnMau19Khac.Text = "Mẫu 19 BQP Khác";
            this.btnMau19Khac.UseVisualStyleBackColor = true;
            this.btnMau19Khac.Click += new System.EventHandler(this.btnMau19Khac_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Đến:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Chọn Mẫu Báo Cáo:";
            // 
            // cv3360Bqp_QN_NgTru
            // 
            this.cv3360Bqp_QN_NgTru.Location = new System.Drawing.Point(817, 416);
            this.cv3360Bqp_QN_NgTru.Name = "cv3360Bqp_QN_NgTru";
            this.cv3360Bqp_QN_NgTru.Size = new System.Drawing.Size(75, 53);
            this.cv3360Bqp_QN_NgTru.TabIndex = 17;
            this.cv3360Bqp_QN_NgTru.Text = "3360 BQP QN Ngoại Trú";
            this.cv3360Bqp_QN_NgTru.UseVisualStyleBackColor = true;
            this.cv3360Bqp_QN_NgTru.Click += new System.EventHandler(this.cv3360Bqp_QN_NgTru_Click);
            // 
            // cv3360Bqp_Khac_NgTru
            // 
            this.cv3360Bqp_Khac_NgTru.Location = new System.Drawing.Point(817, 479);
            this.cv3360Bqp_Khac_NgTru.Name = "cv3360Bqp_Khac_NgTru";
            this.cv3360Bqp_Khac_NgTru.Size = new System.Drawing.Size(79, 47);
            this.cv3360Bqp_Khac_NgTru.TabIndex = 18;
            this.cv3360Bqp_Khac_NgTru.Text = "3360 BQP Khác Ngoại Trú";
            this.cv3360Bqp_Khac_NgTru.UseVisualStyleBackColor = true;
            this.cv3360Bqp_Khac_NgTru.Click += new System.EventHandler(this.cv3360Bqp_Khac_NgTru_Click);
            // 
            // cv3360Bqp_QN_NTru
            // 
            this.cv3360Bqp_QN_NTru.Location = new System.Drawing.Point(900, 416);
            this.cv3360Bqp_QN_NTru.Name = "cv3360Bqp_QN_NTru";
            this.cv3360Bqp_QN_NTru.Size = new System.Drawing.Size(85, 53);
            this.cv3360Bqp_QN_NTru.TabIndex = 19;
            this.cv3360Bqp_QN_NTru.Text = "3360 BQP QN Nội Trú";
            this.cv3360Bqp_QN_NTru.UseVisualStyleBackColor = true;
            this.cv3360Bqp_QN_NTru.Click += new System.EventHandler(this.cv3360Bqp_QN_NTru_Click);
            // 
            // cv3360Bqp_Khac_NTru
            // 
            this.cv3360Bqp_Khac_NTru.Location = new System.Drawing.Point(903, 479);
            this.cv3360Bqp_Khac_NTru.Name = "cv3360Bqp_Khac_NTru";
            this.cv3360Bqp_Khac_NTru.Size = new System.Drawing.Size(82, 46);
            this.cv3360Bqp_Khac_NTru.TabIndex = 20;
            this.cv3360Bqp_Khac_NTru.Text = "3360 BQP Khác Nội Trú";
            this.cv3360Bqp_Khac_NTru.UseVisualStyleBackColor = true;
            this.cv3360Bqp_Khac_NTru.Click += new System.EventHandler(this.cv3360Bqp_Khac_NTru_Click);
            // 
            // exportExcel
            // 
            this.exportExcel.Location = new System.Drawing.Point(421, 537);
            this.exportExcel.Name = "exportExcel";
            this.exportExcel.Size = new System.Drawing.Size(137, 46);
            this.exportExcel.TabIndex = 21;
            this.exportExcel.Text = "Xuất File Excel";
            this.exportExcel.UseVisualStyleBackColor = true;
            this.exportExcel.Click += new System.EventHandler(this.exportExcel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(7, 89);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1010, 268);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 589);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "Chọn Mẫu BC:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 634);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Số BA:";
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(96, 586);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(118, 20);
            this.txtIndex.TabIndex = 26;
            // 
            // btnMau21WithBA
            // 
            this.btnMau21WithBA.Location = new System.Drawing.Point(572, 537);
            this.btnMau21WithBA.Name = "btnMau21WithBA";
            this.btnMau21WithBA.Size = new System.Drawing.Size(107, 46);
            this.btnMau21WithBA.TabIndex = 27;
            this.btnMau21WithBA.Text = "Mẫu 21 BA";
            this.btnMau21WithBA.Click += new System.EventHandler(this.btnMau21WithBA_Click);
            // 
            // btnMau20WithBA
            // 
            this.btnMau20WithBA.Location = new System.Drawing.Point(686, 537);
            this.btnMau20WithBA.Name = "btnMau20WithBA";
            this.btnMau20WithBA.Size = new System.Drawing.Size(124, 46);
            this.btnMau20WithBA.TabIndex = 29;
            this.btnMau20WithBA.Text = "Mẫu 20 BA";
            this.btnMau20WithBA.Click += new System.EventHandler(this.btnMau20WithBA_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(817, 535);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(97, 48);
            this.simpleButton1.TabIndex = 30;
            this.simpleButton1.Text = "Mẫu 19 BA";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // richtxtbox
            // 
            this.richtxtbox.Location = new System.Drawing.Point(96, 631);
            this.richtxtbox.Name = "richtxtbox";
            this.richtxtbox.Size = new System.Drawing.Size(949, 130);
            this.richtxtbox.TabIndex = 31;
            this.richtxtbox.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 862);
            this.Controls.Add(this.richtxtbox);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnMau20WithBA);
            this.Controls.Add(this.btnMau21WithBA);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.exportExcel);
            this.Controls.Add(this.cv3360Bqp_Khac_NTru);
            this.Controls.Add(this.cv3360Bqp_QN_NTru);
            this.Controls.Add(this.cv3360Bqp_Khac_NgTru);
            this.Controls.Add(this.cv3360Bqp_QN_NgTru);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMau19Khac);
            this.Controls.Add(this.btnMau20Khac);
            this.Controls.Add(this.btnMau21Khac);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnMau19QN);
            this.Controls.Add(this.btnMau20QN);
            this.Controls.Add(this.btnMau21QN);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btIn2);
            this.Controls.Add(this.dte_denngay);
            this.Controls.Add(this.dte_tungay);
            this.Controls.Add(this.btIn);
            this.Controls.Add(this.btConnect);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dte_tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndex.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btIn;
        private DevExpress.XtraEditors.TimeEdit dte_tungay;
        private System.Windows.Forms.Button btIn2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMau21QN;
        private DevExpress.XtraEditors.TimeEdit dte_denngay;
        private System.Windows.Forms.Button btnMau20QN;
        private System.Windows.Forms.Button btnMau19QN;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnMau21Khac;
        private System.Windows.Forms.Button btnMau20Khac;
        private System.Windows.Forms.Button btnMau19Khac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cv3360Bqp_QN_NgTru;
        private System.Windows.Forms.Button cv3360Bqp_Khac_NgTru;
        private System.Windows.Forms.Button cv3360Bqp_QN_NTru;
        private System.Windows.Forms.Button cv3360Bqp_Khac_NTru;
        private System.Windows.Forms.Button exportExcel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtIndex;
        private DevExpress.XtraEditors.SimpleButton btnMau21WithBA;
        private DevExpress.XtraEditors.SimpleButton btnMau20WithBA;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.RichTextBox richtxtbox;
    }
}

