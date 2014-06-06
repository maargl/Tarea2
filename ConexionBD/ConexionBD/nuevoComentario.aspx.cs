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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            string body = Request.Params["txtComentario"].ToString();
            if (body == "")
                Response.Write("<script lenguaje=javascript>alert('Comentario en blanco');</script>");
            else
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                String strSQL = "INSERT INTO comentario(id_tema,id_usuario,mensaje) VALUES (" + Session["id_tema"].ToString() + "," + Session["idUser"].ToString() + ",'" + body + "');";
                SqlCommand comando = new SqlCommand(strSQL, conexion);
                //try
                //{
                comando.ExecuteNonQuery();
                Response.Write("<script>window.alert('Insercion de comentario exitosa!');</script>");
                /*}
                catch (Exception msj)
                {
                    Response.Write("<script>window.alert('Error');</script>");
                }*/
                conexion.Close();
                Response.AddHeader("REFRESH", "0.001 ;URL=comentario.aspx");
            }
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