using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Foro
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Enviar_Clic(object sender, EventArgs e)
        {
            if (Nombre.Text == "")
            {
                Response.Write("<script lenguaje=javascript>alert('Nombre en blanco');</script>");
            }
            else if (pass1.Text != pass2.Text || pass1.Text == "")
            {
                Response.Write("<script lenguaje=javascript>alert('Contraseña invalida');</script>");
            }
            else if (fecha.Text.ToString().Length != 10)
            {
                Response.Write("<script lenguaje=javascript>alert('Ingrese fecha valida');</script>");
            }
            else if (avatar.Text == "")
            {
                Response.Write("<script lenguaje=javascript>alert('Avatar url en blanco');</script>");
            }

            else
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                string strSQL = "INSERT INTO usuario(nombre,contrasenna,fecha_nacimiento,sexo,avatar_url,id_grupo,fecha_registro) VALUES ('" + Nombre.Text.ToString() + "','" + pass1.Text.ToString() + "','" + fecha.Text.ToString() + "','" + sexo.Text.ToString() + "','" + avatar.Text.ToString() + "',3, Cast(getdate() as datetime) )";
                SqlCommand comando = new SqlCommand(strSQL, conexion);
                try
                {
                    conexion.Open();
                }
                catch (Exception msj)
                {
                    Response.Write("<script>window.alert('No se pudo abrir la bd');</script>");
                }
                try
                {
                    comando.ExecuteNonQuery();
                    string id="";
                    strSQL = "select id_usuario from usuario";
                    comando = new SqlCommand(strSQL, conexion);
                    SqlDataReader myReader = comando.ExecuteReader();
                    while (myReader.Read())
                    {
                        id = myReader["id_usuario"].ToString();
                    }
                    strSQL = "insert into buzon_entrada values("+id+",0,0)";
                    comando = new SqlCommand(strSQL, conexion);
                    comando.ExecuteNonQuery();
                    Response.Write("<script>window.alert('Insercion de usuario exitosa!');</script>");
                    //Response.Redirect("inicio.aspx");
                }
                catch (Exception msj)
                {
                    Response.Write("<script>window.alert('Error de formato');</script>");
                }
                finally
                {
                    try { conexion.Close(); }
                    catch (Exception msj) { Response.Write("<script>window.alert('No se pudo cerrar la bd');</script>"); }
                }
                Response.AddHeader("REFRESH", "0.001 ;URL=inicio.aspx");
            }

            
            
        }

    }
}