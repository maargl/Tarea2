using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionBD
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ir_Perfil(object sender, EventArgs e)
        {
            Session.Add("id_perfil", Session["idUser"].ToString());
            Response.Redirect("Perfil.aspx");
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("editarPerfil.aspx");
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