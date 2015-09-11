using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Conector
{
    public partial class Form4 : Telerik.WinControls.UI.ShapedForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
          radWaitingBar1.StartWaiting();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadForm1 f = new RadForm1();
            Hide();

         f.Show();
        }


        
    }
}
