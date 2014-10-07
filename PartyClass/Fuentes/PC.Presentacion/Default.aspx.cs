namespace PC
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using Comun.EntidadesNegocio;
    using Comun.Session;
    using Comun.TO;
    using System.Net;
    using System.IO;
    //using Datos;

    
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        static void leerPaginaWeb(string laUrl)
        {
            // Cear la solicitud de la URL.
            WebRequest request = WebRequest.Create(laUrl);

            // Obtener la respuesta.
            WebResponse response = request.GetResponse();

            // Abrir el stream de la respuesta recibida.
            StreamReader reader =
                new StreamReader(response.GetResponseStream());

            // Leer el contenido.
            string res = reader.ReadToEnd();

            // Mostrarlo.
            Console.WriteLine(res);

            // Cerrar los streams abiertos.
            reader.Close();
            response.Close();
        }

        static void leerPaginaWeb2(string laUrl)
        {
            // Cear la solicitud de la URL.
            HttpWebRequest hRequest = ((HttpWebRequest)WebRequest.Create(laUrl));

            // para que lo devuelva como si accediéramos con un chrome
            hRequest.UserAgent =
                "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.13 (KHTML, like Gecko) Chrome/0.2.149.29 Safari/525.13";

            // Obtener la respuesta y abrir el stream de la respuesta recibida.
            StreamReader reader =
                new StreamReader(hRequest.GetResponse().GetResponseStream());

            string res = reader.ReadToEnd();

            // Mostrarlo.
            Console.WriteLine(res);

            // Cerrar el stream abierto.
            reader.Close();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                leerPaginaWeb2("https://www.compraspublicas.gob.ec/ProcesoContratacion/tab.php?tab=1&id=xQGTNSfo85oVsNh2wkiNEacjT_OZ3mEEdhP-R6q8lUs");
                //using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                //{
                //    client.DownloadFile("https://www.contratos.gov.co/consultas/detalleProceso.do?numConstancia=14-13-2952437", @"C:\localfile.html");

                //    // Or you can get the file content without saving it:
                //    string htmlCode = client.DownloadString("https://www.contratos.gov.co/consultas/detalleProceso.do?numConstancia=14-13-2952437");
                //    //...
                //}

                List<string> lstResultado = new List<string>();
                Usuario oUsuario = new Usuario();
                oUsuario.Username = this.txtUsuario.Text;
                oUsuario.Password = this.txtPassword.Text;

                Datos.Autenticacion oFTC = new Datos.Autenticacion();
                oUsuario = oFTC.validarUsuario(oUsuario, ref lstResultado);
                if (lstResultado[1] == "0")
                {
                    throw new Exception(lstResultado[2]);
                }

                //lblError.Text = oUsuario.Nombres;
            
                Contexto.TIMEOUT = 30;
                Contexto.idUsuario = oUsuario.idUsuario;
                Contexto.nombreUsuario = oUsuario.Username;
                Contexto.cargo = oUsuario.Cargo;
            
                //Response.Write("<script type=\"text/javascript\"> alert(\"" + lstResultado[2] + "\") </script>");    
                this.Response.Redirect("~/Welcome.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
