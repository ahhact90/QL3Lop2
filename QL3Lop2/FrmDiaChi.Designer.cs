namespace QL3Lop2
{
    partial class FrmDiaChi
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
            this.gridControlDiaChi = new DevExpress.XtraGrid.GridControl();
            this.gridViewDiaChi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDiaChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDiaChi)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlDiaChi
            // 
            this.gridControlDiaChi.Location = new System.Drawing.Point(1, 1);
            this.gridControlDiaChi.MainView = this.gridViewDiaChi;
            this.gridControlDiaChi.Name = "gridControlDiaChi";
            this.gridControlDiaChi.Size = new System.Drawing.Size(394, 166);
            this.gridControlDiaChi.TabIndex = 0;
            this.gridControlDiaChi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDiaChi});
            this.gridControlDiaChi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControlDiaChi_KeyDown);
            // 
            // gridViewDiaChi
            // 
            this.gridViewDiaChi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.DiaChi});
            this.gridViewDiaChi.GridControl = this.gridControlDiaChi;
            this.gridViewDiaChi.Name = "gridViewDiaChi";
            this.gridViewDiaChi.OptionsView.ShowGroupPanel = false;
            this.gridViewDiaChi.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewDiaChi_RowClick);
            this.gridViewDiaChi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewDiaChi_KeyDown);
            // 
            // Id
            // 
            this.Id.Caption = "ID";
            this.Id.FieldName = "precintid";
            this.Id.Name = "Id";
            this.Id.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 103;
            // 
            // DiaChi
            // 
            this.DiaChi.Caption = "Địa Chỉ";
            this.DiaChi.FieldName = "name";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Visible = true;
            this.DiaChi.VisibleIndex = 1;
            this.DiaChi.Width = 337;
            // 
            // FrmDiaChi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(394, 167);
            this.ControlBox = false;
            this.Controls.Add(this.gridControlDiaChi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDiaChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmDiaChi";
            this.Load += new System.EventHandler(this.FrmDiaChi_Load);
            this.SizeChanged += new System.EventHandler(this.FrmDiaChi_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDiaChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDiaChi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDiaChi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
    }
}