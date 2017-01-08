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
            this.dtGridView = new System.Windows.Forms.DataGridView();
            this.dte_tungay = new DevExpress.XtraEditors.TimeEdit();
            this.btIn2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btTimes = new System.Windows.Forms.Button();
            this.dte_denngay = new DevExpress.XtraEditors.TimeEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.btnMau20 = new System.Windows.Forms.Button();
            this.btnMau19QN = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
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
            // dtGridView
            // 
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.Location = new System.Drawing.Point(12, 122);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.Size = new System.Drawing.Size(898, 275);
            this.dtGridView.TabIndex = 1;
            // 
            // dte_tungay
            // 
            this.dte_tungay.EditValue = new System.DateTime(2016, 11, 13, 22, 16, 26, 0);
            this.dte_tungay.Location = new System.Drawing.Point(281, 33);
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
            this.btIn2.Location = new System.Drawing.Point(12, 74);
            this.btIn2.Name = "btIn2";
            this.btIn2.Size = new System.Drawing.Size(167, 37);
            this.btIn2.TabIndex = 4;
            this.btIn2.Text = "Xem Trang In";
            this.btIn2.UseVisualStyleBackColor = true;
            this.btIn2.Click += new System.EventHandler(this.btIn2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(241, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 20);
            this.textBox1.TabIndex = 5;
            // 
            // btTimes
            // 
            this.btTimes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimes.Location = new System.Drawing.Point(453, 69);
            this.btTimes.Name = "btTimes";
            this.btTimes.Size = new System.Drawing.Size(248, 41);
            this.btTimes.TabIndex = 6;
            this.btTimes.Text = "Mẫu 21 QN Theo Thời Gian";
            this.btTimes.UseVisualStyleBackColor = true;
            this.btTimes.Click += new System.EventHandler(this.btTimes_Click);
            // 
            // dte_denngay
            // 
            this.dte_denngay.EditValue = new System.DateTime(2016, 11, 13, 0, 0, 0, 0);
            this.dte_denngay.Location = new System.Drawing.Point(442, 33);
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
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2016, 11, 12, 16, 15, 43, 102);
            this.dateEdit1.Location = new System.Drawing.Point(12, 403);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/mm/yyyy HH:mm:ss tt";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "dd/mm/yyyy HH:mm:ss tt ";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEdit1.Properties.Mask.EditMask = "dd/mm/yyyy HH:mm:ss tt";
            this.dateEdit1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit1.Size = new System.Drawing.Size(153, 20);
            this.dateEdit1.TabIndex = 7;
            // 
            // btnMau20
            // 
            this.btnMau20.Location = new System.Drawing.Point(281, 431);
            this.btnMau20.Name = "btnMau20";
            this.btnMau20.Size = new System.Drawing.Size(192, 51);
            this.btnMau20.TabIndex = 8;
            this.btnMau20.Text = "Mẫu 20 Theo Thời Gian";
            this.btnMau20.UseVisualStyleBackColor = true;
            this.btnMau20.Click += new System.EventHandler(this.btnMau20_Click);
            // 
            // btnMau19QN
            // 
            this.btnMau19QN.Location = new System.Drawing.Point(510, 429);
            this.btnMau19QN.Name = "btnMau19QN";
            this.btnMau19QN.Size = new System.Drawing.Size(191, 53);
            this.btnMau19QN.TabIndex = 9;
            this.btnMau19QN.Text = "Mẫu 19 QN Theo Thời Gian";
            this.btnMau19QN.UseVisualStyleBackColor = true;
            this.btnMau19QN.Click += new System.EventHandler(this.btnMau19QN_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(191, 555);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(90, 50);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 681);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnMau19QN);
            this.Controls.Add(this.btnMau20);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.btTimes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btIn2);
            this.Controls.Add(this.dte_denngay);
            this.Controls.Add(this.dte_tungay);
            this.Controls.Add(this.dtGridView);
            this.Controls.Add(this.btIn);
            this.Controls.Add(this.btConnect);
            this.Name = "FrmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dte_denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btIn;
        private System.Windows.Forms.DataGridView dtGridView;
        private DevExpress.XtraEditors.TimeEdit dte_tungay;
        private System.Windows.Forms.Button btIn2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btTimes;
        private DevExpress.XtraEditors.TimeEdit dte_denngay;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Button btnMau20;
        private System.Windows.Forms.Button btnMau19QN;
        private System.Windows.Forms.Button btnTest;
    }
}

