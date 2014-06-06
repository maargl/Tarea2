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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            String body = txtComentario.Text;
            if (body == "")
                Response.Write("<script lenguaje=javascript>alert('Comentario en blanco');</script>");
            else
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                String strSQL = "UPDATE comentario SET mensaje='" + body + "' WHERE id_comentario=" + Session["id_comentario"].ToString() + ";";
                SqlCommand comando = new SqlCommand(strSQL, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                Response.Write("<script>window.alert('Edicion exitosa de: " +body + "');</script>");
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

        protected void txtLoad(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conexion.Open();
            String strSQL2 = "SELECT mensaje FROM comentario WHERE id_comentario=" + Session["id_comentario"].ToString() + ";";
            SqlCommand cmd2 = new SqlCommand(strSQL2, conexion);
            SqlDataReader myReader2 = cmd2.ExecuteReader();
            while (myReader2.Read())
                txtComentario.Text = myReader2["mensaje"].ToString();
            conexion.Close();
        }
    }
}