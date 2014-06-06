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
    public partial class inicioUser : System.Web.UI.Page
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
                string strSQL = "SELECT * FROM categoria";
                SqlCommand comando = new SqlCommand(strSQL, conexion);
                myReader = comando.ExecuteReader();
                String label = "", id = "";

                while (myReader.Read())
                {
                    int temas = 0, comentarios = 0;
                    label = "Categoria: " + myReader["nombre"].ToString() + "  | Descripcion: " + myReader["descripcion"].ToString() + " | ";
                    id = myReader["id_categoria"].ToString();

                    string strSQL2 = "select id_tema from tema where id_categoria=" + id;
                    SqlCommand comando2 = new SqlCommand(strSQL2, conexion);
                    SqlDataReader myReader2 = comando2.ExecuteReader();

                    while (myReader2.Read())
                    {
                        string strSQL3 = "select count(*) as cantidad from comentario where id_tema=" + myReader2["id_tema"].ToString();
                        SqlCommand comando3 = new SqlCommand(strSQL3, conexion);
                        SqlDataReader myReader3 = comando3.ExecuteReader();

                        while (myReader3.Read())
                        {
                            comentarios += Convert.ToInt32(myReader3["cantidad"].ToString());
                        }
                        temas++;

                    }

                    label += "temas: " + temas.ToString() + " | comentarios " + comentarios.ToString() + " | ";
                    Label txt = new Label();
                    txt.ID = "lab" + id;
                    txt.Text = label;
                    txt.ForeColor = System.Drawing.Color.Black;
                    txt.Font.Size = 12;
                    Panel1.Controls.Add(txt);
                    LinkButton btn = new LinkButton();
                    btn.ID = id;
                    btn.Text = "Entrar";
                    btn.OnClientClick = "Categoria_Clic";
                    btn.Click += new EventHandler(Categoria_Clic);

                    Panel1.Controls.Add(new LiteralControl("  "));
                    Panel1.Controls.Add(btn);
                    if (Session["tipoUser"].ToString() == "1" || Session["tipoUser"].ToString() == "2")
                    {
                        Panel1.Controls.Add(new LiteralControl("<b>"));
                        LinkButton btn2 = new LinkButton();
                        btn2.ID = "cd " + myReader["id_categoria"].ToString();
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
            catch (Exception em)
            {
                // Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
            }
        }

        protected void Categoria_Clic(object sender, EventArgs e)
        {
            try
            {
                LinkButton a = (LinkButton)sender;
                Session.Add("id_categoria", a.ID.ToString());
                Response.Redirect("tema.aspx");

            }
            catch (Exception em)
            {
                //Response.Redirect("tema.aspx");
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            //try
            //{
            LinkButton a = (LinkButton)sender;
            string[] array = a.ID.ToString().Split();
            Session.Add("id_categoria", array[1]);

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conexion.Open();
            String strSQL = "SELECT id_tema FROM tema WHERE id_categoria=" + Session["id_categoria"].ToString();
            SqlCommand comando = new SqlCommand(strSQL, conexion);
            SqlDataReader myReader = comando.ExecuteReader();
            while (myReader.Read())
            {
                String strSQL2 = "DELETE comentario WHERE id_tema=" + myReader["id_tema"] + ";";
                SqlCommand cmd2 = new SqlCommand(strSQL2, conexion);
                cmd2.ExecuteNonQuery();
            }
            String strSQL3 = "DELETE tema WHERE id_categoria=" + Session["id_categoria"].ToString() + ";";
            SqlCommand cmd3 = new SqlCommand(strSQL3, conexion);
            cmd3.ExecuteNonQuery();
            String strSQL4 = "DELETE categoria WHERE id_categoria=" + Session["id_categoria"].ToString() + ";";
            SqlCommand cmd4 = new SqlCommand(strSQL4, conexion);
            cmd4.ExecuteNonQuery();
            conexion.Close();
            Response.Write("<script>window.alert('Eliminacion exitosa de: " + Session["id_categoria"].ToString() + "');</script>");
            /*}
            catch (Exception em)
            {
                 Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
            }*/
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