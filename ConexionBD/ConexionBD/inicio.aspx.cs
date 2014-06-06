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
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
                Response.Redirect("inicioUser.aspx");
            else
                Session.Add("tipoUser", "0");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                SqlDataReader myReader = null;
                string strSQL = "SELECT * FROM categoria WHERE publico=1";
                SqlCommand comando = new SqlCommand(strSQL, conexion);
                myReader = comando.ExecuteReader();
                String label = "", id = "";

                
                while (myReader.Read())
                {
                    int temas = 0, comentarios = 0;
                    label ="Categoria: " +myReader["nombre"].ToString() +"  | Descripcion: "+myReader["descripcion"].ToString()+ " | ";
                    id = myReader["id_categoria"].ToString();

                   string strSQL2 = "select id_tema from tema where id_categoria="+id;
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

                    label += "temas: " + temas.ToString() + " | comentarios "+comentarios.ToString()+" | ";
                    Label txt = new Label();
                    txt.ID = "lab" + id;
                    txt.Text = label;
                    txt.ForeColor = System.Drawing.Color.Black;
                    txt.Font.Size = 12;
                    Panel1.Controls.Add(txt);
                    LinkButton btn = new LinkButton();
                    btn.ID = id;
                    btn.Text = "Entrar";
                    //btn.OnClientClick = "Categoria_Clic";
                    btn.Click += new EventHandler(Categoria_Clic);
                   
                    Panel1.Controls.Add(new LiteralControl("  "));
                    Panel1.Controls.Add(btn);
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
                LinkButton a=(LinkButton)sender;
                Session.Add("id_categoria", a.ID.ToString());
                Response.Redirect("tema.aspx");
                
            }
            catch (Exception em)
            {
                //Response.Redirect("tema.aspx");
            }
                    
        }

        protected void Entrar_Clic(object sender, EventArgs e)
        {
            if (usuario.Text == "" || Contraseña.Text == "")
            {
                Response.Write("<script lenguaje=javascript>alert('Nombre y/o contraseña invalidos');</script>");
                return;
            }
            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                SqlDataReader myReader = null;
                string strSQL = "SELECT * FROM USUARIO WHERE NOMBRE='" + usuario.Text.ToString() + "'AND contrasenna='" + Contraseña.Text.ToString() + "'";
                SqlCommand comando = new SqlCommand(strSQL, conexion);

                myReader = comando.ExecuteReader();
                int cont = 0;
                String id = "";
                String tipo = "";
                while (myReader.Read())
                {
                    id = myReader["id_usuario"].ToString();
                    tipo = myReader["id_grupo"].ToString();
                    cont++;
                }

                conexion.Close();


                if (cont > 0)
                {
                    Session.Add("User", usuario.Text.ToString());
                    Session.Add("idUser", id);
                    Session.Add("tipoUser", tipo);
                    Response.Redirect("inicioUser.aspx");
                }
                else
                {
                    Response.Write("<script lenguaje=javascript>alert('Usuario no encontrado');</script>");

                }
            }
            catch (Exception em)
            {
                Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");

            }
        }
    }
}