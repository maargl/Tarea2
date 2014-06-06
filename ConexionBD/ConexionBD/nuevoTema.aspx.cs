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
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ir_Perfil(object sender, EventArgs e)
        {
            Session.Add("id_perfil", Session["idUser"].ToString());
            Response.Redirect("Perfil.aspx");
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            string publico;
            if (chbPublico.Checked == false)
                publico = "0";
            else
                publico = "1";
            if (txtNombre.Text == "")
                Response.Write("<script lenguaje=javascript>alert('Nombre en blanco');</script>");
            else if (txtDescripcion.Text == "")
                Response.Write("<script lenguaje=javascript>alert('Descripcion en blanco');</script>");
            else if (txtMensaje.Text == "")
                Response.Write("<script lenguaje=javascript>alert('Mensaje en blanco');</script>");
            else
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                String strSQL2 = "SELECT id_usuario FROM usuario WHERE nombre='" + Session["User"].ToString() + "';";
                SqlCommand cmd2 = new SqlCommand(strSQL2, conexion);
                SqlDataReader myReader2 = cmd2.ExecuteReader();
                String strSQL = "";
                while (myReader2.Read())
                    strSQL = "INSERT INTO tema(id_categoria,id_usuario,nombre,descripcion,mensaje,publico) VALUES (" + Session["id_categoria"].ToString() + "," + myReader2["id_usuario"].ToString() + ",'" + txtNombre.Text.ToString() + "','" + txtDescripcion.Text.ToString() + "','" + txtMensaje.Text.ToString() + "'," + publico + ");";
                if (strSQL != "")
                {
                    SqlCommand comando = new SqlCommand(strSQL, conexion);
                    try
                    {
                        comando.ExecuteNonQuery();
                        Response.Write("<script>window.alert('Insercion de tema exitosa!');</script>");
                    }
                    catch (Exception msj)
                    {
                        Response.Write("<script>window.alert('Error de formato');</script>");
                    }
                    try
                    {
                        conexion.Close();
                    }
                    catch (Exception msj)
                    {
                        Response.Write("<script>window.alert('No se pudo cerrar la bd');</script>");
                    }
                    Response.AddHeader("REFRESH", "0.001 ;URL=tema.aspx");
                }
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