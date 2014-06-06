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
    public partial class editarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ir_Perfil(object sender, EventArgs e)
        {
            Session.Add("id_perfil", Session["idUser"].ToString());
            Response.Redirect("Perfil.aspx");
        }

        
        protected void editar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                //SqlDataReader myReader = null;
                String strSQL;
                SqlCommand comando;
                if (contr.Text.Equals(contr2.Text) && contr.Text != "")
                {
                    strSQL = "update usuario set contrasenna='" + contr.Text + "' where id_usuario=" + Session["id_perfil"].ToString();
                    comando = new SqlCommand(strSQL, conexion);
                    comando.ExecuteReader();
                    Response.Write("<script lenguaje=javascript>alert('Contraseña actualizada');</script>");
                }
                if(fecha.Text!="YYYY/MM/DD")
                {
                    strSQL = "update usuario set fecha_nacimiento='" + fecha.Text + "' where id_usuario=" + Session["id_perfil"].ToString();
                    comando = new SqlCommand(strSQL, conexion);
                    comando.ExecuteReader();
                    Response.Write("<script lenguaje=javascript>alert('Fecha actualizada');</script>");
                }

                if (avatar.Text != "")
                {
                    strSQL = "update usuario set avatar_url='" + avatar.Text + "' where id_usuario=" + Session["id_perfil"].ToString();
                    comando = new SqlCommand(strSQL, conexion);
                    comando.ExecuteReader();
                    Response.Write("<script lenguaje=javascript>alert('Avatar actualizado');</script>");
                }
                conexion.Close();

                if (tipo.Text != "ingrese numero")
                {
                    strSQL = "update usuario set id_grupo='" + tipo.Text + "' where id_usuario=" + Session["id_perfil"].ToString();
                    comando = new SqlCommand(strSQL, conexion);
                    comando.ExecuteReader();
                    Response.Write("<script lenguaje=javascript>alert('Tipo actualizado');</script>");
                }
                conexion.Close();


            }
            catch (Exception em)
            {
                Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");

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