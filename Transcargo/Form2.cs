using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;
using Conector;
using Telerik.WinControls.UI;
using Transcargo.Properties;

namespace Transcargo
{
    public partial class Form2 : Telerik.WinControls.UI.RadForm
    {
        private string servidor;
        public string Servidor;
        private string bd;
        public string BD;
        private string usuario;
        public string Usuario;
        private string pass;
        public string Pass;
       
        private Processor p;
        private BackgroundWorker worker=new BackgroundWorker() ;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            servidor = Servidor;
            bd = BD;
            usuario = Usuario;
            pass = Pass;
            p = new Processor();
            radDateTimePicker1.Format =DateTimePickerFormat.Short;
            radGridView1.CellClick += radGridView1_CellClick;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
           
            
        }

       

       

       
       
      

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

    

       

        private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            List<object[]> nominas = c.Nominas(servidor, bd, usuario, pass, radDateTimePicker1.Value);
            if (nominas.Count > 1)
            {
                FillGrid(nominas,radGridView1,true);
                OcultarColum(new[] { radGridView1.Columns[0].Name }, radGridView1);
            }
        }
        public void FillGrid(List<object[]> objs, RadGridView r,bool band=false)//LLenar Grid Con array Objetos
        {
            r.Columns.Clear();
            r.Rows.Clear();
            foreach (object objectse in objs[0])
            {
                r.Columns.Add(objectse.ToString());
            }
            Image img = Resources.agenda.ToBitmap();
            if (band)
            {

                GridViewImageColumn imageColumn = new GridViewImageColumn("Imprimir");
                imageColumn.MaxWidth = 80;
                imageColumn.MinWidth = 80;
                imageColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
                imageColumn.HeaderText = "Imprimir";

                r.Columns.Add(imageColumn);
                
            
            }
           
            for (int i = 1; i < objs.Count; i++)
            {
                if (band)
                {
                    object[] objsnnew = new object[objs[i].Length + 1];
                    for (int j = 0; j < objs[i].Length; j++)
                    {
                        objsnnew[j] = objs[i][j];
                    }


                    objsnnew[objs[0].Length] = img;
                    r.Rows.Add(objsnnew);
                }
                else
                {
                    r.Rows.Add(objs[i]);
                }
               
            }

            r.TableElement.RowHeight = 55; 
            r.TableElement.TableHeaderHeight = 35; 
            
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private string columna = "";
        private string id = "";
        private string numdoc="";
        private string nombdoc;
        private string periodop;
        private string fecha;
       
        RadForm2 f2;
        RadForm3 rf3;
        
        void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            columna = e.Column.Name;
            id = e.Row.Cells[0].Value.ToString();
            numdoc = e.Row.Cells[1].Value.ToString();
            nombdoc = e.Row.Cells[2].Value.ToString();
            periodop = e.Row.Cells[4].Value.ToString();
            fecha = DateTime.Parse(e.Row.Cells[3].Value.ToString()).ToShortDateString();
            
            f2 = new RadForm2();
            rf3 = new RadForm3();
            worker.RunWorkerAsync();           
            f2.Show();
          
            
        }

   
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (columna == "Imprimir")
            {                        

                Conexion c = new Conexion();
                Form3 f = new Form3();
             
                rf3.Nominas = c.Imp(id, servidor, bd, usuario, pass);
                rf3.Enc1 = c.Enc1(servidor, bd, usuario, pass) + "\n" + c.DatosUnidad(servidor, bd, usuario, pass)+
                    "\n"+numdoc+"-"+nombdoc+"\n"+"Periodo de Pago: "+periodop;
                rf3.Enc2 = "INSTRUM. DE PAGO: No.__  Fecha:______________" + fecha + "\n" + c.DatosElab(servidor, bd, usuario, pass);
                rf3.Areas = c.areas;
                rf3.Text =Text;
                rf3.Bonificaciones = c.Bonificaciones(servidor, bd, usuario, pass);


                //f.Nominas = c.Imp(id, servidor, bd, usuario, pass);
                // f.Areas = c.areas;
                //f.ShowDialog();

            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!f2.IsDisposed)
                f2.Hide();
            rf3.ShowDialog();
        }

      

        public void OcultarColum(string[] args,RadGridView r)
        {
            foreach (var c in args)
            {
                for (int i = 0; i < r.Columns.Count; i++)
                {
                    if (r.Columns[i].Name == c)
                    {
                        r.Columns[i].IsVisible = false;
                        break;
                    }
                }
            }
            r.MasterTemplate.Refresh(null);
        }




    }
}
