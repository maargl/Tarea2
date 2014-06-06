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
    public partial class correo : System.Web.UI.Page
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
                strSQL = "SELECT * FROM buzon_entrada WHERE id_usuario=" + Session["idUser"].ToString();

                SqlCommand comando = new SqlCommand(strSQL, conexion);

                myReader = comando.ExecuteReader();

                Label a = new Label();
                String id_buzon="";
                while (myReader.Read())
                {
                    a.Text = "Mensajes Recibidos: " + myReader["mensajes"].ToString() +
                        " |  Mensajes NO Leidos: " + myReader["mensajes_sin_leer"];
                    a.Font.Size = 14;
                    a.ForeColor = System.Drawing.Color.Black;
                    Panel1.Controls.Add(a);
                    Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                    id_buzon=myReader["id_buzon"].ToString();
                }
                //a.Font.Size = 12;
                //a.ForeColor = System.Drawing.Color.Black;
                strSQL = "SELECT * FROM mensaje_privado WHERE id_buzon=" + id_buzon+
                    "or id_remitente="+ Session["idUser"].ToString();
                comando = new SqlCommand(strSQL, conexion);
                myReader = comando.ExecuteReader();
                int cont = 0;
                while (myReader.Read())
                {
                    SqlDataReader myReader2 = null;
                    String strSQL2;
                    strSQL2 = "SELECT nombre FROM usuario WHERE id_usuario="+ myReader["id_remitente"].ToString();
                    SqlCommand comando2 = new SqlCommand(strSQL2, conexion);
                    myReader2 = comando2.ExecuteReader();
                    String nombre = "";
                    
                    while (myReader2.Read())
                    {
                        nombre = myReader2["nombre"].ToString();
                    }
                    
                    
                    if (!myReader["id_remitente"].ToString().Equals(Session["idUser"].ToString()))
                    {
                        LinkButton btn = new LinkButton();
                        LinkButton btn2 = new LinkButton();
                        Label txt = new Label();
                        txt.Text = "-Recibido  | Remitente:";
                        txt.ForeColor = System.Drawing.Color.Black;
                        btn2.ID = "userid"+cont.ToString()+"?"+myReader["id_remitente"].ToString();
                        btn2.Text = nombre;
                        btn2.Click += new EventHandler(ver_Perfil);
                        btn.ID = "msgid"+cont.ToString()+"?"+myReader["id_mensaje"].ToString();
                        btn.Click += new EventHandler(leer_msg);
                        btn.Text = " | Fecha de envio: " + myReader["fecha_de_envio"].ToString();
                        if ("False" == myReader["leido"].ToString())
                        {
                            btn.Text += " | No leído";
                        }
                        else btn.Text += " | leído";
                        Panel1.Controls.Add(txt);
                        Panel1.Controls.Add(btn2);
                        Panel1.Controls.Add(btn);
                        Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                        cont++;

                    }
                    else
                    {
                        LinkButton btn = new LinkButton();
                        LinkButton btn2 = new LinkButton();
                        Label txt = new Label();
                        txt.Text = "-Enviado  | Remitente:";
                        txt.ForeColor = System.Drawing.Color.Black;
                        btn2.ID = "userid" + cont.ToString() + "?" + myReader["id_remitente"].ToString();
                        btn2.Text = Session["User"].ToString();
                        btn2.Click += new EventHandler(ver_Perfil);
                        btn.ID = "msgid" + cont.ToString() + "?" + myReader["id_mensaje"].ToString();
                        btn.Click += new EventHandler(leer_msg);
                        btn.Text = " | Fecha de envio: " + myReader["fecha_de_envio"].ToString();
                        if ("False"==myReader["leido"].ToString())
                        {
                            btn.Text += " | No leído";
                        }
                        else btn.Text += " | leído";
                        Panel1.Controls.Add(txt);
                        Panel1.Controls.Add(btn2);
                        Panel1.Controls.Add(btn);
                        Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                    }
                   
                }
                conexion.Close();
            }
            catch (Exception em)
            {
                // Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
            }
        }
        protected void leer_msg(object sender, EventArgs e)
        {
            try
            {
                LinkButton a = (LinkButton)sender;
                Session.Add("id_mensaje",a.ID.ToString().Split('?')[1]);
                Session.Add("datos_mensaje", a.Text.ToString());
                Response.Redirect("verMensaje.aspx");
            }
            catch (Exception em)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("enviarMensaje.aspx");
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