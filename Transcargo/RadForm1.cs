using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Transcargo;


namespace Conector
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        private List<string> servidores;
        private string server;
        private string bd;
        private string user;
        private string pass;
        private Conexion c;
        public RadForm1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            #region locals
            comboBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                Thread T = new Thread(LlenarLocales);
                T.Start();
                while (!T.IsAlive)
                    Thread.Sleep(1);
                T.Join();
                if (servidores.Count == 0)
                {
                    MessageBox.Show("No hemos encontrado Servidores SQL instalados en su PC.Contacte al administrador del sistema, vuela a intertarlo mas tarde o teclee el servidor manualmente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    button2.Enabled = true;
                }
                else
                {
                    comboBox1.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    button2.Enabled = true;
                    for (int i = 0; i < servidores.Count; i++)
                    {
                        comboBox1.Items.Add(servidores[i]);
                    }
                }
                comboBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button2.Enabled = true;
            }
            #endregion
           
            Cursor=Cursors.Arrow;
        }

        public void LlenarLista()
        {
            Conexion c = new Conexion();
            servidores = c.GetServersNet();

        }

        public void LlenarLocales()
        {
            Conexion c = new Conexion();
            servidores = c.Locals();
        }

       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            #region Remotos
            if (radioButton2.Checked)
            {
                comboBox4.Enabled = false;
                comboBox4.Items.Clear();
                panel1.Visible = true;
                panel2.Visible = true;
                Thread T = new Thread(LlenarLista);
                T.Start();
                while (!T.IsAlive)
                    Thread.Sleep(1);
                T.Join();
                if (servidores.Count == 0)
                {
                    MessageBox.Show("No hemos encontrado Servidores SQL en la red.Contacte al administrador del sistema, vuela a intertarlo mas tarde o teclee el servidor manualmente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox4.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button1.Enabled = true;

                }
                else
                {
                    comboBox4.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button1.Enabled = true;
                    for (int i = 0; i < servidores.Count; i++)
                    {
                        comboBox4.Items.Add(servidores[i]);
                    }
                }


            }
            #endregion
            Cursor = Cursors.Arrow;
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            comboBox3.KeyPress += comboBox3_KeyPress;
            textBox3.KeyPress += textBox3_KeyPress;
            comboBox2.KeyPress += comboBox2_KeyPress;
            textBox2.KeyPress += textBox2_KeyPress;
           

        }

        void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button4.PerformClick();
            }
        }

        void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2.PerformClick();
            }
        }

        void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3.PerformClick();
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                comboBox2.Items.Clear();
                if (textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
                    throw new Exception("Ingrese el Usuario y la Contraseña");
                Conexion c = new Conexion();
                comboBox2.Enabled = true;
                List<string> bases = new List<string>();
                if (comboBox1.SelectedIndex == -1)
                    server = comboBox1.Text;
                else
                    server = comboBox1.SelectedItem.ToString();
                bases = c.BasesDatos(server, textBox4.Text, textBox3.Text);
                for (int i = 0; i < bases.Count; i++)
                {
                    comboBox2.Items.Add(bases[i]);
                }
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                comboBox1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = true;
                user = textBox4.Text;
                pass = textBox3.Text;
                comboBox1.Items.Clear();
            }

            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Text = new Processor().Test();
            bd = comboBox2.SelectedItem.ToString();
            new Conexion().Check_Owner(server, bd, user, pass);
            f.Servidor = server;
            f.BD = bd;
            f.Usuario = user;
            f.Pass = pass;
            Hide();
            f.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Test();
                comboBox3.Items.Clear();
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                    throw new Exception("Ingrese el Usuario y la Contraseña");
                Conexion c = new Conexion();
                comboBox3.Enabled = true;
                List<string> bases = new List<string>();
                if (comboBox4.SelectedIndex == -1)
                    server = comboBox4.Text;
                else
                    server = comboBox4.SelectedItem.ToString();

                bases = c.BasesDatos(server, textBox1.Text, textBox2.Text);
                for (int i = 0; i < bases.Count; i++)
                {
                    comboBox3.Items.Add(bases[i]);
                }

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                comboBox4.Enabled = false;
                button1.Enabled = false;
                user = textBox1.Text;
                pass = textBox2.Text;
                button3.Enabled = true;
                comboBox4.Items.Clear();

            }

            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Text=new Processor().Test();
          
            c = new Conexion();
            bd = comboBox3.SelectedItem.ToString();
            new Conexion().Check_Owner(server, bd, user, pass); 
            f.Servidor = server;
            f.BD = bd;
          
            f.Usuario = user;
            f.Pass = pass;
            Hide();
            f.ShowDialog();

           

        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {

        }


       

        private void radMenuItem2_Click_1(object sender, EventArgs e)
        {
            new Processor().WriteLic();
        }

        
       
   
    
    
    
    }
}
