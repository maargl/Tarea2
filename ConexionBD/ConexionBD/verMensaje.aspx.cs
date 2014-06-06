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
    public partial class verMensaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ir_Perfil(object sender, EventArgs e)
        {
            Session.Add("id_perfil", Session["idUser"].ToString());
            Response.Redirect("Perfil.aspx");
        }
        protected void actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                SqlDataReader myReader = null;
                String strSQL;
                strSQL = "SELECT * FROM mensaje_privado WHERE id_mensaje=" + Session["id_mensaje"].ToString();

                SqlCommand comando = new SqlCommand(strSQL, conexion);

                myReader = comando.ExecuteReader();

                TextBox a = new TextBox();
                Label b = new Label();
                Label c = new Label();
                b.ForeColor = System.Drawing.Color.Black;
                c.ForeColor = System.Drawing.Color.Black;
                //b.Text = Session["remit"].ToString();
                b.Text = Session["datos_mensaje"].ToString();
                c.Text="Mensaje:";
                
                while (myReader.Read())
                {
                    Panel1.Controls.Add(b);
                    Panel1.Controls.Add(new LiteralControl("<br/><br/>") );
                    Panel1.Controls.Add(c);
                    Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                    a.Text = myReader["mensaje"].ToString();
                    a.Font.Size = 12;
                    a.ForeColor = System.Drawing.Color.Black;
                    Panel1.Controls.Add(a);
                    Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                    Session.Add("id_remit", myReader["id_remitente"].ToString());
                    
                }

                strSQL = "UPDATE mensaje_privado SET leido=1 where id_mensaje=" + Session["id_mensaje"].ToString();
                comando = new SqlCommand(strSQL, conexion);
                comando.ExecuteReader();              

                conexion.Close();
            }
            catch (Exception em)
            {
                // Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Add("id_remitente", Session["id_remit"].ToString());
            Response.Redirect("enviarMensaje.aspx");
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