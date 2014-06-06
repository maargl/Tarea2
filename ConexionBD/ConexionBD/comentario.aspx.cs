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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conexion.Open();
            SqlDataReader myReader = null;
            String strSQL;
            if (Session["User"] != null)
                strSQL = "SELECT id_comentario AS id,id_tema AS tema,id_usuario AS usuario,mensaje AS msj FROM comentario WHERE id_tema=" + Session["id_tema"].ToString();
            else strSQL = "SELECT comentario.id_comentario AS id,comentario.id_tema AS tema,comentario.id_usuario AS usuario,comentario.mensaje AS msj FROM comentario,tema WHERE tema.id_tema=" + Session["id_tema"].ToString() + " AND comentario.id_tema=tema.id_tema AND tema.publico=1";

            SqlCommand comando = new SqlCommand(strSQL, conexion);
            myReader = comando.ExecuteReader();
            int cont = -1;
            while (myReader.Read())
            {
                cont++;
                Label txt = new Label();
                LinkButton btn3 = new LinkButton();
                txt.ID = myReader["id"].ToString();
                String strSQL2 = "SELECT nombre,avatar_url FROM usuario WHERE id_usuario=" + myReader["usuario"].ToString();
                SqlCommand cmd2 = new SqlCommand(strSQL2, conexion);
                SqlDataReader myReader2 = cmd2.ExecuteReader();
                
                while (myReader2.Read())
                {
                    String nombre = myReader2["nombre"].ToString();
                    btn3.ID = "userid" + cont.ToString() + "?" + myReader["usuario"].ToString();
                    btn3.Text = nombre;
                    btn3.Click += new EventHandler(ver_Perfil);
                    txt.Text = " | " + myReader2["avatar_url"] + " | " + myReader["msj"].ToString();
                }
                    
                txt.ForeColor = System.Drawing.Color.Black;
                txt.Font.Size = 12;
                Panel1.Controls.Add(btn3);
                Panel1.Controls.Add(txt);
                if (Session["tipoUser"].ToString() == "1" || Session["tipoUser"].ToString() == "2")
                {
                    LinkButton btn = new LinkButton();
                    btn.ID ="+ " + myReader["id"].ToString(); ;
                    btn.Text = "Editar";
                    btn.Click += new EventHandler(Editar_Click);
                    Panel1.Controls.Add(new LiteralControl("  "));
                    Panel1.Controls.Add(btn);

                    Panel1.Controls.Add(new LiteralControl("<b>"));
                    LinkButton btn2 = new LinkButton();
                    btn2.ID = "- " + myReader["id"].ToString();
                    btn2.Text = "Eliminar";
                    btn2.Click += new EventHandler(Eliminar_Click);
                    Panel1.Controls.Add(new LiteralControl("  "));
                    Panel1.Controls.Add(btn2);
                    Panel1.Controls.Add(new LiteralControl("</b>"));
                }
                Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                Panel1.Controls.Add(new LiteralControl("<hr />"));

            }
            conexion.Close();
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            LinkButton a = (LinkButton)sender;
            string[] array = a.ID.ToString().Split();
            Session.Add("id_comentario", array[1]);
            Response.Redirect("editarComentario.aspx");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton a = (LinkButton)sender;
            string[] array = a.ID.ToString().Split();
            Session.Add("id_comentario", array[1]);

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conexion.Open();
            String strSQL = "DELETE comentario WHERE id_comentario=" + Session["id_comentario"].ToString() + ";";
            SqlCommand comando = new SqlCommand(strSQL, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            //Response.Write("<script>window.alert('Eliminacion exitosa de: " + Session["id_comentario"].ToString() + "');</script>");
            
        }

        protected void ir_Perfil(object sender, EventArgs e)
        {
            Session.Add("id_perfil", Session["idUser"].ToString());
            Response.Redirect("Perfil.aspx");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("nuevoComentario.aspx");
        }
        protected void ver_Perfil(object sender, EventArgs e)
        {
            try
            {
                LinkButton a = (LinkButton)sender;
                Session.Add("id_perfil", a.ID.ToString().Split('?')[1]);
                Response.Redirect("Perfil.aspx");
            }
            catch (Exception em)
            {
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