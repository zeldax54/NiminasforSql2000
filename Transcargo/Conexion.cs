using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Conector
{
    public class Conexion
    {
        private SqlConnection con;

        #region Conectividad

        public List<string> GetServersNet()
        {
            List<string> servers = new List<string>();
            try
            {
                DataTable x = null;
                SqlClientFactory fabrica = SqlClientFactory.Instance;
                bool bandera = fabrica.CanCreateDataSourceEnumerator;
                if (bandera)
                {
                    SqlDataSourceEnumerator servidores = SqlDataSourceEnumerator.Instance;
                    x = servidores.GetDataSources();
                    int s = x.Rows.Count;
                    DataRow r = x.NewRow();
                    for (int i = 0; i < x.Rows.Count; i++)
                    {
                        r = x.Rows[i];

                        if (string.IsNullOrEmpty(r["InstanceName"].ToString()))
                            servers.Add(r["ServerName"].ToString());
                        else
                            servers.Add(r["ServerName"].ToString() + "\\" + r["InstanceName"].ToString());

                    }
                }
            }

            catch (Exception)
            {
                throw new Exception("Ha ocurrido un Error Mientras se Accedía a la Red");
            }
            return servers;
        }


        public List<string> Locals()
        {
            List<string> serveres = new List<string>();
            RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Microsoft SQL Server");

            String[] Instancias = (String[]) RegKey.GetValue("InstalledInstances");
            if (Instancias != null)
            {
                if (Instancias.Length > 0)
                {
                    foreach (String Elemento in Instancias)
                    {
                        if (Elemento == "MSSQLSERVER")
                            serveres.Add(Environment.MachineName);
                        else
                            serveres.Add(Environment.MachineName + @"\" + Elemento);
                    }
                }
            }
            return serveres;
        }


        public List<string> BasesDatos(string server, string user, string pass)
        {

            List<string> bases = new List<string>();
            SqlConnection SqlCon =
                new SqlConnection("Server=" + server + ";User ID=" + user + ";Password=" + pass +
                                  ";Trusted_Connection=False");
            SqlCon.Open();
            SqlCommand SqlCom = new SqlCommand();
            SqlCom.Connection = SqlCon;
            SqlCom.CommandType = CommandType.StoredProcedure;
            SqlCom.CommandText = "sp_databases";

            SqlDataReader SqlDReader;
            SqlDReader = SqlCom.ExecuteReader();

            while (SqlDReader.Read())
            {
                bases.Add(SqlDReader.GetString(0));
            }
            return bases;

        }

        private void Conectar(string server, string database, string user, string pass)
        {
            try
            {
                string cadenadconexion = "Server=" + server + "; Database=" + database + ";Uid=" + user + ";Pwd=" + pass +
                                         ";";
                con = new SqlConnection();
                con.ConnectionString = cadenadconexion;
                con.Open();
            }
            catch (SqlException)
            {
                throw new Exception("No se ha podido conectar con la base de datos");
            }


        }

        private void Desconectar()
        {
            con.Close();
        }

        #endregion

        public string formar(DateTime t)
        {
            int dia = t.Day;
            int mes = t.Month;
            int anno = t.Year;

            return dia + "/" + mes + "/" + anno;

        }

        public List<object[]> Nominas(string server, string database, string user, string pass, DateTime fecha)
        {
            Conectar(server, database, user, pass);
            string consulta = "Select idperiodopago from nom_periodopago where (Anho='" + fecha.Year +
                              "')AND( periodo_ini<='" + formar(fecha) + "')AND" +
                              "(periodo_fin>='" + formar(fecha) + "')";
            var comando1 = new SqlCommand(consulta, con);
            SqlDataReader lector1 = comando1.ExecuteReader();
            string periodo = "";
            while (lector1.Read())
            {
                periodo = lector1["idperiodopago"].ToString();
            }
            lector1.Close();

            consulta = "exec nom_get_nominadoc @vwheresentence='nom_documento.idunidad=1 and " +
                       "( nom_documento.idperiodopago=" + periodo + "  and  nom_periodopago.anho=" + fecha.Year + " )'," +
                       "@vordersentence='str_codigo ASC',@vNumtreatment=0";
            var comando2 = new SqlCommand(consulta, con);
            SqlDataReader lector2 = comando2.ExecuteReader();
            List<object[]> fin = new List<object[]>();
            object[] titulos = new object[7];
            titulos[0] = "IdDoc";
            titulos[1] = "Nro";
            titulos[2] = "Descripcion";
            titulos[3] = "Fecha";
            titulos[4] = "Periodo de Pago";
            titulos[5] = "Moneda";
            titulos[6] = "Estado";
            fin.Add(titulos);
            while (lector2.Read())
            {
                object[] noms = new object[7];
                noms[0] = lector2["iddocumento"].ToString();
                noms[1] = lector2["str_codigo"].ToString();
                noms[2] = lector2["str_titulo"].ToString();
                noms[3] = lector2["Fecha"].ToString();
                noms[4] = lector2["str_periodopago"].ToString();
                noms[5] = lector2["sigla"].ToString();
                noms[6] = lector2["str_estado"].ToString();

                fin.Add(noms);
            }
            Desconectar();
            return fin;



        }

        public IEnumerable<string> areas;
        public DataTable[] Imp(string iddoc, string server, string database, string user, string pass)
        {
            List<object[]> final = new List<object[]>();
            Conectar(server, database, user, pass);
            string consulta = "exec nom_get_nominadetail_forprint @vwheresentence='iddocumento=" + iddoc +
                              "', @vordersentence='nom_documento_detalle_pago.idarea, nom_documento_detalle_pago.idactividadtrab, nom_documento_detalle_pago.codigotrabajador'";
            var comando1 = new SqlCommand(consulta, con);
            SqlDataReader lector1 = comando1.ExecuteReader();
            object[] head = new object[18];
         
            head[0] = "Area";          
            head[1] = "Cod";
            head[2] = "Nombre";
            head[3] = "Carnet";
            head[4] = "C";
            head[5] = "Tarif.Sal";
            head[6] = "Dias";
            head[7] = "A Cobrar";
            head[8] = "Bon";
            head[9] = "P.A.T";
            head[10] = "Deven";
            head[11] = "Imp.S";
            head[12] = "Ret";
            head[13] = "Pagado";
            head[14] = "Tiemp";
            head[15] = "Imp";
            head[16] = "id";
            head[17] = "Firma";
          
            final.Add(head);

            while (lector1.Read())
            {
                object[] o = new object[18];
                o[0] = lector1["areatrab"].ToString();
                o[1] = lector1["codigotrabajador"].ToString();
                o[2] = lector1["nombretrabajador"].ToString();
                o[3] = lector1["carnetid"].ToString();
                o[4] = lector1["COcup"].ToString();
                o[5] = lector1["n_tarifasalarial"].ToString();
                o[6] = lector1["n_dias"].ToString();
                o[7] = lector1["n_cobrar"].ToString();
                o[8] = lector1["n_TotalBonificaciones"].ToString();
                o[9] = lector1["n_totalca"].ToString();
                o[10] = lector1["devengado"].ToString();
                o[11] = lector1["n_totalimpsal"].ToString();
                o[12] = lector1["n_TotalRetenciones"].ToString();
                o[13] = lector1["pagado"].ToString();
                o[14] = lector1["n_tiempoacumulado"].ToString();
                o[15] = lector1["n_importeacumulado"].ToString();
                o[16] = lector1["idlinea"].ToString();
                o[17] = "x";
                final.Add(o);        

            }
            lector1.Close();
            Desconectar();

            return Reformar(final, Areas(final), server, database, user, pass);
        }


        public DataTable[] Reformar(List<object[]> a, IEnumerable<string> areas, string server, string database, string user,string pass)

        {
            List<object[]> nueva = new List<object[]>();
            nueva.Add(a[0]);
            int indic = -1;

            double acobf = 0;
            double boniff = 0;
            double PATf = 0;
            double devenf = 0;
            double impsf = 0;
            double retf = 0;
            double pagadof = 0;
            foreach (var ars in areas)
            {
                double acob = 0;
                double bonif = 0;
                double PAT = 0;
                double deven = 0;
                double imps = 0;
                double ret = 0;
                double pagado = 0;



                nueva.Add(new object[] { "", "", ars, "", "", "", "", "", "", "", "", "", "", "", "", "", indic });
                indic--;
                bool band = false;
                int pos = 0;
                for (int i = 1; i < a.Count; i++)
                {
                    if (a[i][0].ToString() == ars)
                    {
                        acob += double.Parse(a[i][7].ToString());
                        bonif += double.Parse(a[i][8].ToString());
                        PAT += double.Parse(a[i][9].ToString());
                        deven += double.Parse(a[i][10].ToString());
                        imps+= double.Parse(a[i][11].ToString());
                        ret += double.Parse(a[i][12].ToString());
                        pagado += double.Parse(a[i][13].ToString());

                        acobf += double.Parse(a[i][7].ToString());
                        boniff += double.Parse(a[i][8].ToString());
                        PATf += double.Parse(a[i][9].ToString());
                        devenf += double.Parse(a[i][10].ToString());
                        impsf += double.Parse(a[i][11].ToString());
                        retf += double.Parse(a[i][12].ToString());
                        pagadof += double.Parse(a[i][13].ToString());
                        
                        
                        a[i][0] = " ";
                        nueva.Add(a[i]);
                        pos = i;
                        band = true;
                    }

                   
                }
                if (band)
                    nueva.Add(new object[] { "", "", "TOTAL POR AREA", "", "", "", "", acob, bonif, PAT, deven, imps, ret, pagado, "", "", indic });

                indic--;
            }
            nueva.Add(new object[] { "", "", "", "TOTAL NOMINA", "", "", "", acobf, boniff, PATf, devenf, impsf, retf, pagadof, "", "", indic });

            DataTable final = new DataTable();
            for (int i = 0; i < nueva[0].Length; i++)
            {
                final.Columns.Add(nueva[0][i].ToString());
            }
            for (int i = 1; i < nueva.Count; i++)
            {
                DataRow r = final.NewRow();
                r.ItemArray = nueva[i];
                final.Rows.Add(r);               

            }

            DataTable last = new DataTable();
            foreach (DataColumn item in final.Columns)
	        {
		    last.Columns.Add(item.ColumnName);
	        }


            List<string> idls = new List<string>();
            List<string> codigos = new List<string>();
            
            foreach (DataRow row in final.Rows)
            {
                //DataRow l = last.NewRow();
                //l.ItemArray = row.ItemArray;
                //last.Rows.Add(l);
                int res;
                if (row.ItemArray.Length > 15)
                {
                    string idL = row.ItemArray[16].ToString();
                   
                    if (int.TryParse(idL, out res))
                    {
                        idls.Add(idL);
                        codigos.Add(row.ItemArray[1].ToString());

                        //DataRow r = last.NewRow();
                        //r.ItemArray=(Bonific(idL, server, database, user, pass));
                        //r.SetParentRow(l);
                        
                        //last.Rows.Add(r);

                      
                    }
                }
            
               
            }
            DataTable bonifics=BonifTable(idls,codigos,server, database, user, pass);
           // last.Columns.Remove("id");

            return new DataTable[] {final,bonifics };
        }
            
        public IEnumerable<string> Areas(List<object[]>asd)
        {
            List<string> fin=new List<string>( );
            foreach (var objs in asd)
            {
                
                if(objs[0]!=null)
                 fin.Add(objs[0].ToString());
            }
            fin.RemoveAt(0);
            return fin.Distinct();

            
        }

        public object[] Bonific(string idl, string server, string database, string user, string pass)
        {
               Conectar(server, database, user, pass);
               List<string> fin = new List<string>();
               string cons ="SELECT nom_bonificaciones.str_descripcion AS Expr2, nom_documento_Bonificaciones.importe FROM nom_documento_Bonificaciones INNER JOIN "+
                      "nom_bonificaciones ON nom_documento_Bonificaciones.idbonificacion = nom_bonificaciones.idbonificacion "+
                  "WHERE (nom_documento_Bonificaciones.idlinea ="+ idl+")";
                var comando1 = new SqlCommand(cons, con);
                SqlDataReader lector = comando1.ExecuteReader();
               
                while (lector.Read())
                {
                    string x = lector["Expr2"].ToString() + ": " + Math.Round(double.Parse(lector["importe"].ToString()),2);                                  
                     fin.Add(x);
                }
           
             
            object[] ret=new object[fin.Count+1];

            int c = 1;
            ret[0] = "Bonifics:";
            foreach (var v in fin)
            {
               
               
                    ret[c] = v;
                    c++;
                
            }
            Desconectar();
            
            return ret;
        }//no

        public DataTable BonifTable(List<string> idl,List<string> codigos, string server, string database, string user, string pass)
        {
            DataTable t = new DataTable();
            t.Columns.Add("id");
            t.Columns.Add("codigo");
            t.Columns.Add("Bonificacion");
            t.Columns.Add("Importe");

            for (int i = 0; i < idl.Count; i++)
            {
                Conectar(server, database, user, pass);
                string cons = "SELECT importe, descripcionbonificacion FROM nom_documento_Bonificaciones WHERE (idlinea = "+idl[i]+")";

                var comando1 = new SqlCommand(cons, con);
                SqlDataReader lector = comando1.ExecuteReader();
                while (lector.Read())
                {
                    object[] o = new object[4];
                    o[0] = idl[i].ToString();
                    o[1] = codigos[i].ToString();
                    o[2] = lector["descripcionbonificacion"].ToString();
                    o[3] = Math.Round(double.Parse(lector["importe"].ToString()),2);
                    DataRow r = t.NewRow();
                    r.ItemArray = o;
                    t.Rows.Add(r);

                }
                Desconectar();
            }
            
               
            

            return t;
        }

        public string Enc1(string server, string database, string user, string pass)
        {
            Conectar(server, database, user, pass);
            string fin="";

            string cons = "SELECT codigo,nombre,organismo FROM gen_empresa";

            var comando1 = new SqlCommand(cons, con);
            SqlDataReader lector = comando1.ExecuteReader();
            while (lector.Read())
            {
                fin += lector["organismo"].ToString();
                fin += '\n';
                fin += lector["codigo"]+ " - " + lector["nombre"];

            }
            Desconectar();
            return fin;
        }

        public string DatosUnidad(string server, string database, string user, string pass)
        {
            Conectar(server, database, user, pass);
            string fin = "";
            string cons = "SELECT * from gen_unidadcontable";
            var comando1 = new SqlCommand(cons, con);
            SqlDataReader lector = comando1.ExecuteReader();
            while (lector.Read())
            {
                fin += lector["codigo"]+"-"+lector["nombre"];
            }
            lector.Close();
            return fin;
        }


        public string DatosElab(string server, string database, string user, string pass)
        {
            Conectar(server, database, user, pass);
            string fin = "";
            string cons = "SELECT * from nom_configuracion_unidad where idunidad='1'";
            var comando1 = new SqlCommand(cons, con);
            SqlDataReader lector = comando1.ExecuteReader();
            while (lector.Read())
            {
                fin += "ELABORADA POR: " + lector["elaborada"]+"______________" + "\n" +
                       "REVISADA POR: " + lector["revisada"] + "______________" + "\n" +
                       "APROBADA POR: " + lector["aprobada"] + "______________";
                     
                if (lector["contabilizada"].ToString() == "")
                {
                    fin += "\n" + "CONTABILIZADA POR: ____________ _____________";
                }
                else
                {
                    fin += "\n" + "CONTABILIZADA POR: " + lector["contabilizada"] + "______________";
                }
            }
            lector.Close();
            Desconectar();
            return fin;
        }

        public List<string> Bonificaciones(string server, string database, string user, string pass)
        {
            
            Conectar(server, database, user, pass);
           List<string>  fin = new List<string>();
            string cons = "SELECT * from nom_bonificaciones";
            var comando1 = new SqlCommand(cons, con);
            SqlDataReader lector = comando1.ExecuteReader();
            while (lector.Read())
            {
                fin.Add(lector["str_descripcion"].ToString());
            }
            return fin;
        }


        public void Check_Owner(string server, string database, string user, string pass)
        {
            Conectar(server, database, user, pass);
            string fin = "-1";
            string cons = "SELECT codigo,nombre from gen_empresa";
            var comando1 = new SqlCommand(cons, con);
            SqlDataReader lector = comando1.ExecuteReader();
            while (lector.Read())
            {
               fin= lector["codigo"].ToString();
            }
            if (fin != "126002243")
            {
              MessageBox.Show(@"Usted no esta autorizado a utilizar este Software", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
               Application.Restart();
            }
            
        }
    }
}
