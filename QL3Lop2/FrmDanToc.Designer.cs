namespace QL3Lop2
{
    partial class FrmDanToc
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
            this.gridControlDanToc = new DevExpress.XtraGrid.GridControl();
            this.grdViewDanToc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanToc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDanToc)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlDanToc
            // 
            this.gridControlDanToc.Location = new System.Drawing.Point(1, 1);
            this.gridControlDanToc.MainView = this.grdViewDanToc;
            this.gridControlDanToc.Name = "gridControlDanToc";
            this.gridControlDanToc.Size = new System.Drawing.Size(248, 220);
            this.gridControlDanToc.TabIndex = 0;
            this.gridControlDanToc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewDanToc});
            this.gridControlDanToc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControlDanToc_KeyDown);
            // 
            // grdViewDanToc
            // 
            this.grdViewDanToc.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdViewDanToc.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdViewDanToc.Appearance.EvenRow.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.grdViewDanToc.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdViewDanToc.Appearance.EvenRow.Options.UseBorderColor = true;
            this.grdViewDanToc.Appearance.EvenRow.Options.UseFont = true;
            this.grdViewDanToc.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grdViewDanToc.Appearance.OddRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grdViewDanToc.Appearance.OddRow.Options.UseBackColor = true;
            this.grdViewDanToc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.name});
            this.grdViewDanToc.GridControl = this.gridControlDanToc;
            this.grdViewDanToc.Name = "grdViewDanToc";
            this.grdViewDanToc.OptionsBehavior.Editable = false;
            this.grdViewDanToc.OptionsBehavior.ReadOnly = true;
            this.grdViewDanToc.OptionsView.EnableAppearanceEvenRow = true;
            this.grdViewDanToc.OptionsView.EnableAppearanceOddRow = true;
            this.grdViewDanToc.OptionsView.ShowGroupPanel = false;
            this.grdViewDanToc.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdViewDanToc_RowClick);
            this.grdViewDanToc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdViewDanToc_KeyDown);
            // 
            // Id
            // 
            this.Id.Caption = "ID";
            this.Id.FieldName = "line";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.FixedWidth = true;
            this.Id.OptionsColumn.ReadOnly = true;
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 50;
            // 
            // name
            // 
            this.name.Caption = "Dân Tộc";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.Visible = true;
            this.name.VisibleIndex = 1;
            this.name.Width = 182;
            // 
            // FrmDanToc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 218);
            this.ControlBox = false;
            this.Controls.Add(this.gridControlDanToc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDanToc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDanToc";
            this.Load += new System.EventHandler(this.FrmDanToc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanToc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDanToc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDanToc;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewDanToc;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn name;
    }
}