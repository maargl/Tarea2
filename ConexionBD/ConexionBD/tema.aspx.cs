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
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            //try
            //{
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                SqlDataReader myReader = null;
                String strSQL;
                if (Session["User"] != null)
                {
                    strSQL = "SELECT * FROM tema WHERE id_categoria=" + Session["id_categoria"].ToString();
                }
                else strSQL = "SELECT * FROM tema WHERE id_categoria=" + Session["id_categoria"].ToString() +" and publico=1";

                SqlCommand comando = new SqlCommand(strSQL, conexion);

                myReader = comando.ExecuteReader();

                SqlDataReader myReader2 = null;
                SqlCommand cmd2 = null;
                while (myReader.Read())
                {
                    String strSQL2 = "SELECT COUNT(*) AS nComentarios FROM tema,comentario WHERE tema.id_tema=" + myReader["id_tema"] + " AND comentario.id_tema = tema.id_tema;";
                    cmd2 = new SqlCommand(strSQL2, conexion);
                    myReader2 = cmd2.ExecuteReader();
                    while (myReader2.Read())
                    {
                        Label a = new Label();
                        a.Text = "ID: "+myReader["id_tema"].ToString() + " | Nombre: " + 
                            myReader["nombre"].ToString() + " | User: " + myReader["id_usuario"].ToString() + " | Decripcion: " + 
                            myReader["descripcion"].ToString() + " | Comentarios: " + myReader2["nComentarios"].ToString()+" | ";
                        a.Font.Size = 12;
                        a.ForeColor = System.Drawing.Color.Black;
                        Panel1.Controls.Add(a);
                        LinkButton btn = new LinkButton();
                        btn.ID = myReader["id_tema"].ToString();
                        btn.Text = "Entrar";
                        btn.Click += new EventHandler(Tema_Click);
                        Panel1.Controls.Add(new LiteralControl("  "));
                        Panel1.Controls.Add(btn);
                        if (Session["tipoUser"].ToString() == "1" || Session["tipoUser"].ToString() == "2")
                        {
                            Panel1.Controls.Add(new LiteralControl("<b>"));
                            LinkButton btn2 = new LinkButton();
                            btn2.ID = "lab " + myReader["id_tema"].ToString();
                            btn2.Text = "Eliminar";
                            btn2.Click += new EventHandler(Eliminar_Click);
                            Panel1.Controls.Add(new LiteralControl("  "));
                            Panel1.Controls.Add(btn2);
                            Panel1.Controls.Add(new LiteralControl("</b>"));
                        }
                        Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                        Panel1.Controls.Add(new LiteralControl("<hr />"));
                    }

                }
                conexion.Close();
            /*}
            catch (Exception em)
            {
               Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
            }*/
        }

        protected void Tema_Click(object sender, EventArgs e)
        {
            //try
            //{
                LinkButton a = (LinkButton)sender;
                Session.Add("id_tema", a.ID.ToString());
                Response.Redirect("comentario.aspx");
            /*}
            catch (Exception em)
            {
                Response.Write("<script lenguaje=javascript>alert('id_tema session');</script>");
            }*/

        }
        protected void ir_Perfil(object sender, EventArgs e)
        {
            Session.Add("id_perfil", Session["idUser"].ToString());
            Response.Redirect("Perfil.aspx");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            //try
            //{
                LinkButton a = (LinkButton)sender;
                string[] array = a.ID.ToString().Split();
                Session.Add("id_tema", array[1]);
                    
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                String strSQL2 = "DELETE comentario WHERE id_tema=" + Session["id_tema"].ToString() + ";";
                String strSQL = "DELETE tema WHERE id_tema=" + Session["id_tema"].ToString() + ";";
                SqlCommand cmd2 = new SqlCommand(strSQL2, conexion);
                cmd2.ExecuteNonQuery();
                SqlCommand comando = new SqlCommand(strSQL, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                Response.Write("<script>window.alert('Eliminacion exitosa de: " + Session["id_tema"].ToString() + "');</script>");
            /*}
            catch (Exception em)
            {
                 Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
            }*/
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("nuevoTema.aspx");
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