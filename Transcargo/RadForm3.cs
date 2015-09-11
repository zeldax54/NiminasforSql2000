using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Conector;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Transcargo.Properties;

namespace Transcargo
{
    public partial class RadForm3 : Telerik.WinControls.UI.RadForm
    {

        private DataTable[] nominas;
        public DataTable[] Nominas;

        private IEnumerable<string> areas;
        public IEnumerable<string> Areas;

        private string enc1;
        public string Enc1;

        private string enc2;
        public string Enc2;

        private List<string> bonificaciones;
        public List<string> Bonificaciones; 
 
   
        public RadForm3()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void RadForm3_Load(object sender, EventArgs e)
        {
            nominas = Nominas;
            areas = Areas;
            enc1 = Enc1;
            enc2 = Enc2;
            bonificaciones = Bonificaciones;
            //DataSet d = new DataSet();
            
            //d.Tables.Add(nominas[0]);
            //d.Tables.Add(nominas[1]);
            //d.Relations.Add("Detalle", d.Tables[0].Columns["id"], d.Tables[1].Columns["id"]);
          

            //gridControl1.DataSource = d.Tables[0];            
            //gridView1.Columns["id"].Visible = false;
            
       
            

           FillGrid();
           radGridView1.Columns["id"].IsVisible = false;
           radGridView1.Columns["Area"].IsVisible = false;
            radGridView1.BestFitColumns(BestFitColumnMode.AllCells);
            Formartear();
            //gridView1.RowSeparatorHeight = 5;
            //gridView1.BestFitColumns();

            Conexion c = new Conexion();
            



        }

        void radGridView1_PrintCellFormatting(object sender, PrintCellFormattingEventArgs e)
        {
            if (e.Row.Cells[1].Value != null)
            {
                int res;
                int.TryParse(e.Row.Cells[1].Value.ToString(), out res);
                if (e.Column != null && res != 0 && e.Row is GridViewDataRowInfo)
                {
                    e.PrintCell.BackColor = Color.LightSeaGreen;
                }
                if (e.Column != null && e.Row.Cells[2].Value.ToString().Contains("TOTAL") && e.Row is GridViewDataRowInfo)
                {
                    e.PrintCell.BackColor = Color.Aquamarine;
                    e.PrintCell.Font = italicFont;
                } 
            }
            
        }

       

        


        Font italicFont = new Font("Segoe UI", 9f, FontStyle.Italic); 
        


        public void FillGrid()
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataColumn c in nominas[0].Columns)
            {
                radGridView1.Columns.Add(c.ColumnName);

            }
            foreach (DataRow r in nominas[0].Rows)
            {
                radGridView1.Rows.Add(r.ItemArray);
                for (int i = 0; i < nominas[1].Rows.Count; i++)
                {
                    if (r.ItemArray[16].ToString() == nominas[1].Rows[i].ItemArray[0].ToString())
                    {
                        object[] a = nominas[1].Rows[i].ItemArray;
                        a[0] = null; a[1] = null;
                        radGridView1.Rows.Add(a);
                        nominas[1].Rows[i].Delete();
                        i--;

                    }
                }
              
            }
            Cursor = Cursors.Arrow;
        }

        public void Formartear()
        {
            foreach (GridViewRowInfo t in radGridView1.Rows)
            {
                if (t.Cells[1].Value != null)
                {
                    if (t.Cells[1].Value.ToString() != "")
                    {
                        foreach (GridViewCellInfo c in t.Cells)
                        {
                            
                            c.Style.ForeColor = Color.Lime;
                        }
                    }
                    if (t.Cells[2].Value.ToString().Contains("TOTAL"))
                    {
                        foreach (GridViewCellInfo c in t.Cells)
                        {

                            c.Style.ForeColor = Color.OrangeRed;
                        }
                    }
                  
                }
                
            }
            radGridView1.MasterTemplate.Refresh(null);
        }

        public DataTable ToTable(List<object[]> objs)//LLenar datatable con arreglo de objetos
        {
            DataTable t = new DataTable();
            for (int i = 0; i < objs[0].Length; i++)
            {
                t.Columns.Add(objs[0][i].ToString());
               
            }

            objs.RemoveAt(0);
            foreach (var item in objs)
            {
                
              
            }
            t.Columns.Remove("id");
            return t;

        }

       

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            radGridView1.PrintCellFormatting += radGridView1_PrintCellFormatting;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog(); 
            dialog.ThemeName = this.radGridView1.ThemeName;

            Font italicFont = new Font("Arial", 10f, FontStyle.Bold); 
            radPrintDocument1.LeftHeader =enc1;
            radPrintDocument1.HeaderFont = italicFont;
            radPrintDocument1.HeaderHeight = 100;

            radPrintDocument1.RightHeader = enc2;
           
           
            radPrintDocument1.Landscape = true;
            Margins m = new Margins();
            m.Bottom = 0; m.Top = 1; m.Left = 0; m.Right = 0;
            radPrintDocument1.Margins = m;
            
            dialog.Document = radPrintDocument1; 
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog(); 
        }

       

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
           DataTable r= new Processor().ReporteBon(radGridView1, bonificaciones);
            Form3 f = new Form3();
            f.Nominas = r;
            f.Text = @"Total de Bonificaciones";
            f.ShowDialog();
        }


        //void footerLink_CreateDetailArea(object sender, CreateAreaEventArgs e)
        //{
        //    TextBrick brick = new TextBrick(BorderSide.None, 0, Color.White, Color.Gray, Color.Blue);
        //    brick.Text = "some footer text";
        //    brick.Rect = new RectangleF(0, 0, 400, 20);
        //    e.Graph.DrawBrick(brick);
        //}

        //void headerLink_CreateDetailArea(object sender, CreateAreaEventArgs e)
        //{
        //    e.Graph.DrawString("Some header text"+'\n'+"mads", new RectangleF(0, 0, 1000, 20));
        //}
    
    
    
    
    
    
    
    }
}
