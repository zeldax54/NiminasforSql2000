using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Excel = Microsoft.Office.Interop.Excel;
namespace Transcargo
{
    public partial class Form3 : Telerik.WinControls.UI.RadForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private DataTable nominas;
        public DataTable Nominas;


        private void Form3_Load(object sender, EventArgs e)
        {
            nominas = Nominas;
            radGridView1.DataSource = nominas;

            radGridView1.BestFitColumns(BestFitColumnMode.AllCells);
            Formartear();
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            Reporte();
        }


        public void Formartear()
        {
            foreach (GridViewRowInfo t in radGridView1.Rows)
            {
                if (t.Cells[1].Value != null)
                {
                    if (t.Cells[0].Value.ToString().Contains("TOTAL"))
                    {
                        foreach (GridViewCellInfo c in t.Cells)
                        {

                            c.Style.ForeColor = Color.LimeGreen;
                        }
                    }

                }

            }
            radGridView1.MasterTemplate.Refresh(null);
        }

        private void Reporte()
        {
            Cursor = Cursors.WaitCursor;
            Excel._Application oExcel = new Excel.Application();

            oExcel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (GridViewDataColumn col in radGridView1.Columns)
            {

                ColumnIndex++;

                oExcel.Cells[1, ColumnIndex] = col.HeaderText;

            }

            int rowIndex = 0;

            foreach (GridViewRowInfo row in radGridView1.Rows)
            {

                rowIndex++;

                ColumnIndex = 0;

                foreach (GridViewDataColumn col in radGridView1.Columns)
                {

                    ColumnIndex++;

                    oExcel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;

                }

            }

            oExcel.Visible = true;

            Excel.Worksheet worksheet = (Excel.Worksheet)oExcel.ActiveSheet;

            worksheet.Activate();
            Cursor = Cursors.Arrow;
        }

}
}
