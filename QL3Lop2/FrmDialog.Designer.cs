namespace QL3Lop2
{
    partial class FrmDialog
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
            this.gridControlNgheNghiep = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNgheNghiep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlNgheNghiep
            // 
            this.gridControlNgheNghiep.Location = new System.Drawing.Point(1, 1);
            this.gridControlNgheNghiep.MainView = this.gridView1;
            this.gridControlNgheNghiep.Name = "gridControlNgheNghiep";
            this.gridControlNgheNghiep.Size = new System.Drawing.Size(195, 266);
            this.gridControlNgheNghiep.TabIndex = 0;
            this.gridControlNgheNghiep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControlNgheNghiep;
            this.gridView1.Name = "gridView1";
            // 
            // Id
            // 
            this.Id.Caption = "ID";
            this.Id.FieldName = "line";
            this.Id.Name = "Id";
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 32;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nghề Nghiệp";
            this.gridColumn1.FieldName = "name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 88;
            // 
            // FrmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 266);
            this.Controls.Add(this.gridControlNgheNghiep);
            this.Name = "FrmDialog";
            this.Text = "FrmDialog";
            this.Load += new System.EventHandler(this.FrmDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNgheNghiep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlNgheNghiep;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}