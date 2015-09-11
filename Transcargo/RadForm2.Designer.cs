namespace Transcargo
{
    partial class RadForm2
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
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Location = new System.Drawing.Point(39, 31);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(275, 24);
            this.radWaitingBar1.TabIndex = 0;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.ThemeName = "TelerikMetro";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(77, 5);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(153, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Calculando.Por favor espere...";
            // 
            // RadForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 65);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radWaitingBar1);
            this.MaximumSize = new System.Drawing.Size(378, 100);
            this.MinimumSize = new System.Drawing.Size(378, 100);
            this.Name = "RadForm2";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(378, 100);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculando";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.RadForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
