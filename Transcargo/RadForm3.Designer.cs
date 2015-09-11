namespace Transcargo
{
    partial class RadForm3
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark1 = new Telerik.WinControls.UI.RadPrintWatermark();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
            this.class1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radMenuItem5 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radPrintDocument1 = new Telerik.WinControls.UI.RadPrintDocument();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.radMenuItem4 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.radMenuItem6 = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.class1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.AccessibleDescription = "Archivo";
            this.radMenuItem1.AccessibleName = "Archivo";
            this.radMenuItem1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem3});
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Archivo";
            this.radMenuItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuItem3
            // 
            this.radMenuItem3.AccessibleDescription = "Salir";
            this.radMenuItem3.AccessibleName = "Salir";
            this.radMenuItem3.Name = "radMenuItem3";
            this.radMenuItem3.Text = "Salir";
            this.radMenuItem3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuItem3.Click += new System.EventHandler(this.radMenuItem3_Click);
            // 
            // radMenuItem5
            // 
            this.radMenuItem5.AccessibleDescription = "Imprimir";
            this.radMenuItem5.AccessibleName = "Imprimir";
            this.radMenuItem5.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuSeparatorItem1,
            this.radMenuItem2});
            this.radMenuItem5.Name = "radMenuItem5";
            this.radMenuItem5.Text = "Imprimir";
            this.radMenuItem5.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.AccessibleDescription = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.AccessibleName = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.AccessibleDescription = "Vista Previa";
            this.radMenuItem2.AccessibleName = "Vista Previa";
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Vista Previa";
            this.radMenuItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuItem2.Click += new System.EventHandler(this.radMenuItem2_Click);
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem5,
            this.radMenuItem4});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.radMenu1.Size = new System.Drawing.Size(815, 27);
            this.radMenu1.TabIndex = 2;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "TelerikMetro";
            // 
            // radGridView1
            // 
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 27);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(815, 411);
            this.radGridView1.TabIndex = 4;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "VisualStudio2012Dark";
            // 
            // radPrintDocument1
            // 
            this.radPrintDocument1.AssociatedObject = this.radGridView1;
            this.radPrintDocument1.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument1.Watermark = radPrintWatermark1;
            // 
            // radMenuItem4
            // 
            this.radMenuItem4.AccessibleDescription = "Reportes";
            this.radMenuItem4.AccessibleName = "Reportes";
            this.radMenuItem4.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuSeparatorItem2,
            this.radMenuItem6});
            this.radMenuItem4.Name = "radMenuItem4";
            this.radMenuItem4.Text = "Reportes";
            this.radMenuItem4.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.AccessibleDescription = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.AccessibleName = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuItem6
            // 
            this.radMenuItem6.AccessibleDescription = "Bonificaciones";
            this.radMenuItem6.AccessibleName = "Bonificaciones";
            this.radMenuItem6.Name = "radMenuItem6";
            this.radMenuItem6.Text = "Bonificaciones";
            this.radMenuItem6.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuItem6.Click += new System.EventHandler(this.radMenuItem6_Click);
            // 
            // RadForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 438);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radMenu1);
            this.Name = "RadForm3";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm3";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.RadForm3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.class1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private System.Windows.Forms.BindingSource class1BindingSource;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem5;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadPrintDocument radPrintDocument1;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem4;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem6;
    }
}
