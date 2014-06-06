using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConexionBD
{
    public partial class enviarMensaje : System.Web.UI.Page
    {
        static int entro=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (entro==1) Response.Redirect("correo.aspx");
            }

        }
        protected void ir_Perfil(object sender, EventArgs e)
        {
            Session.Add("id_perfil", Session["idUser"].ToString());
            Response.Redirect("Perfil.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String id_destino = "";
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                SqlDataReader myReader = null;

                if ("Nombre de Usuario".Equals(para.Text) && (Session["id_remitente"] == null || Session["id_remitente"] == ""))
                {
                    Response.Write("<script lenguaje=javascript>alert('ingrese nombre de usuario');</script>");
                    conexion.Close();
                    return;
                }
                else if (!"Nombre de Usuario".Equals(para.Text))
                {
                    //remitente = para.Text;
                    string strSQL2 = "Select id_usuario from usuario where nombre='"+para.Text+"'";
                    SqlCommand comando2 = new SqlCommand(strSQL2, conexion);
                    myReader = comando2.ExecuteReader();
                    while (myReader.Read())
                    {
                        id_destino = myReader["id_usuario"].ToString();
                    }
                }
                else
                {
                   id_destino = Session["id_remitente"].ToString();
                }
                
                String id_buzon="";
                string strSQL = "select id_buzon from buzon_entrada where id_usuario="+id_destino;
                SqlCommand comando = new SqlCommand(strSQL, conexion);
                myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    id_buzon = myReader["id_buzon"].ToString();
                }
                
                DateTime thisDay = DateTime.Today;

                strSQL = "insert into mensaje_privado values("+Session["idUser"].ToString()+
                    "," + id_buzon + ",0,'" + mensaje.Text + "',getdate())";//'" + thisDay.ToString("yyyy/MM/dd") + "')";
                comando = new SqlCommand(strSQL, conexion);
                comando.ExecuteReader();

                conexion.Close();
                Response.Write("<script lenguaje=javascript>alert('mensaje enviado');</script>");
                entro = 1;
            }
            catch (Exception em)
            {
                Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
            }

            Session.Add("id_remitente","");
        }
        protected void cerrar_sesion(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Session.Add("User", null);
                Response.Redirect("inicio.aspx");
            }
        }
    }
}