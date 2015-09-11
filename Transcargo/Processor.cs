using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


using System.Diagnostics;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Transcargo
{
    class Processor
    {
        System.Globalization.CultureInfo oldCI;



        #region seguridad
        public string Encryptar(string cadena)
        {
            string key = "**H0H**D*L";
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] ArrayResultado =
           cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
           0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }
        public string DecryptKey(string clave)
        {
            string key = "**H0H**D*L";
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(clave);


            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
             tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public string GetCPUId()
        {
            string cpuInfo = String.Empty;
            string nombre = "";
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((cpuInfo == String.Empty))
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    nombre = mo.Properties["Name"].Value.ToString();
                }
            } return nombre + cpuInfo;
        }

        public string Test()
        {
            string fin = "Impresion de Nominas Versat. Licencia Completa.";
            try
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//N//lic.hl";
                using (FileStream f = new FileStream(dir, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader lect = new StreamReader(f))
                    {

                        string x = DecryptKey(lect.ReadToEnd());
                        

                        if (x != GetCPUId().GetHashCode().ToString())
                        {
                            int num = int.Parse(x);
                            if (num==0)
                            {
                                throw new Exception();
                            }
                            if (num >0)
                            {


                                fin = num-- + @" Intentos restantes";
                                DialogResult ok = MessageBox.Show(fin, @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                                lect.Close();
                                string d = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                                string archivo = CrearArchivoTmp(d);
                                string e = Encryptar(num--.ToString());

                                if (File.Exists(archivo))
                                {
                                    File.Delete(archivo); 
                                }
                               
                                using (File.Create(archivo)) { }
                                File.WriteAllText(archivo, e);
                            }
                        }

                    }

                }
            }
            catch (Exception E)
            {

                DialogResult ok = MessageBox.Show(@"Usted no esta autorizado a Utilizar este software", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ok == DialogResult.OK)
                {
                    Application.Exit();
                }

            }

            return fin;
        }

        public void WriteLic()
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Archivos hl (.hl)|*.hl";
            d.FilterIndex = 1;
            d.Multiselect = true;
            d.ShowDialog();
            string dir = d.FileName;
            using (FileStream f = new FileStream(dir, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader lect = new StreamReader(f))
                {
                    string d1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string archivo = CrearArchivoTmp(d1);
                    string val = lect.ReadToEnd();
                    if (File.Exists(archivo))
                    {
                        File.Delete(archivo);
                    }

                    using (File.Create(archivo)) { }
                    File.WriteAllText(archivo, val);
                    MessageBox.Show(@"Licencia aplicada con exito", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }


        #endregion

        public List<string> EstandarizarLista(List<string> lista)//Recibe una lista y la devuelve sin los
        {                                                        // los elementos repetidos.
            List<string> final = new List<string>();

            while (lista.Count != 0)
            {
                int cont = 0;
                string x = lista[0];
                while (cont < lista.Count)
                {
                    if (CompararCadenas(x, lista[cont]))
                        lista.RemoveAt(cont);
                    else
                    {
                        cont++;
                    }

                }
                final.Add(x);

            }
            return final;
        }
        public bool CompararCadenas(string x, string y)// Comparar sin importar mayusculas y minusculas.
        {
            if (String.Compare(x, y, true) == 0)
                return true;
            return false;
        }


        public string CrearArchivoTmp(string dir)
        {

            string dirTMp = "";
            string carpetaRaiz = dir;
            string dirtmp = Path.Combine(carpetaRaiz, "N");
            dirTMp = carpetaRaiz;
            Directory.CreateDirectory(dirtmp);
            string nombre = "lic.hl";
            string dirfinal = Path.Combine(dirtmp, nombre);
            return dirfinal;

        }


        public DataTable ReporteBon(Telerik.WinControls.UI.RadGridView r,List<string>bs  )
        {
            DataTable fin = new DataTable();
            fin.Columns.Add("Bonificacion");
            fin.Columns.Add("Total");
            double cont=0;
            foreach (var b in bs)
            {
                double bon = 0;
                foreach (var row in r.Rows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        if (b == row.Cells[2].Value.ToString())
                        {
                            try
                            {
                                bon += double.Parse(row.Cells[3].Value.ToString());
                                cont += bon;
                            }
                            catch (Exception)
                            {

                                MessageBox.Show(@"Hay bonificaciones asignadas sin valor");
                            }
                           
                        }
                    }
                    
                }
                object[] arr = new object[] {b, bon};
                fin.Rows.Add(arr);
            }
            object[] arr1 = new object[] { "TOTAL", cont };
            fin.Rows.Add(arr1);
            return fin;
        }




        #region Complementarios
        public void SetCultura()
        {
            oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


        }
        public void OffCulture()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

        }

        public void Matar_Proceso()
        {

            int idproc = GetIDProcces("EXCEL");//cerrando proceso
            if (idproc != -1)
            {
                Process.GetProcessById(idproc).Kill();
            }
        }

        private int GetIDProcces(string nameProcces)
        {
            try
            {
                Process[] asProccess = Process.GetProcessesByName(nameProcces);
                foreach (Process pProccess in asProccess)
                {
                    if (pProccess.MainWindowTitle == "")
                    {
                        return pProccess.Id;
                    }
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }
        #endregion
    }
}
