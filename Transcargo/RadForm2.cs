using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Transcargo
{
    public partial class RadForm2 : Telerik.WinControls.UI.RadForm
    {

       

       

        public RadForm2()
        {
            InitializeComponent();
        }

      

      

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            radWaitingBar1.StopWaiting();
        }

        private void RadForm2_Load(object sender, EventArgs e)
        {
            radWaitingBar1.StartWaiting();
        }
    }
}
