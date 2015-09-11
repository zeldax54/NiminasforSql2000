namespace Conector
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWaitingBar1.ForeColor = System.Drawing.Color.Green;
            this.radWaitingBar1.Location = new System.Drawing.Point(39, 252);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.ShowText = true;
            this.radWaitingBar1.Size = new System.Drawing.Size(433, 24);
            this.radWaitingBar1.TabIndex = 1;
            this.radWaitingBar1.Text = "Cargando Datos...";
            this.radWaitingBar1.ThemeName = "TelerikMetro";
            this.radWaitingBar1.WaitingStep = 4;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Throbber;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingStep = 4;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Throbber;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).ForeColor = System.Drawing.Color.Green;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Transcargo.Properties.Resources.transc;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(39, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 215);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(39, 292);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(450, 17);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = resources.GetString("radLabel1.Text");
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 332);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radWaitingBar1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;

        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}