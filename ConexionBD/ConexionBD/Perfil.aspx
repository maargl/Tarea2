<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ConexionBD.Perfil" %>
<% @Import Namespace="System.Data" %>
<% @Import Namespace="System.Data.SqlClient" %>
<% @Import Namespace="System.Configuration" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <%
        if (Session["User"] != null)
        {
            String nombre = Session["User"].ToString();
            Response.Write("Usuario: "+nombre);%>
<br />
<br />
<asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="cerrar_sesion" />
<br />
        <%}%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <%
        if (Session["id_perfil"] != null)
        {
            String id = Session["id_perfil"].ToString();
            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexion.Open();
                SqlDataReader myReader = null;
                string strSQL = "SELECT * FROM USUARIO WHERE id_usuario='" + id + "'";
                SqlCommand comando = new SqlCommand(strSQL, conexion);

                myReader = comando.ExecuteReader();
                 while (myReader.Read())
                {
                    Response.Write("<tr><td> Nombre: </td>");
                    Response.Write("<td>"+myReader["nombre"].ToString()+"</td></tr>");
                    Response.Write("<tr><td> Avatar: </td>");
                    Response.Write("<td>" + myReader["avatar_url"].ToString() + "</td></tr>");
                    Response.Write("<tr><td> Fecha de nacimiento: </td>");
                    Response.Write("<td>" + myReader["fecha_nacimiento"].ToString() + "</td></tr>");
                    Response.Write("<tr><td> Sexo: </td>");
                    Response.Write("<td>" + myReader["sexo"].ToString() + "</td></tr>");
                    if (myReader["id_grupo"].ToString() == "1")
                    {
                        Response.Write("<tr><td> Tipo Usuario: </td>");
                        Response.Write("<td>Administrador</td></tr>");  
                    }
                    else if (myReader["id_grupo"].ToString() == "2")
                    {
                        Response.Write("<tr><td> Tipo Usuario: </td>");
                        Response.Write("<td>Moderador</td></tr>");
                    }
                    else if (myReader["id_grupo"].ToString() == "3")
                    {
                        Response.Write("<tr><td> Tipo Usuario: </td>");
                        Response.Write("<td>Usuario Común</td></tr>");
                    }
                }

                conexion.Close();


            }
            catch (Exception em)
            {
                Response.Write("<script lenguaje=javascript>alert('error al accesar a base de datos');</script>");
                
            }
        }
        
        
     
     %>
        
        </table><br/><br/>
    <table>
       <%
           if (Session["id_perfil"] != null)
           {
               String id = Session["id_perfil"].ToString();
               try
               {
                   SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                   conexion.Open();
                   SqlDataReader myReader = null;
                   String strSQL = "SELECT nombre FROM View_temas_creados WHERE id_usuario=" + id ;
                   SqlCommand comando = new SqlCommand(strSQL, conexion);

                   myReader = comando.ExecuteReader();
                   Response.Write("<tr><td><h2> Temas Creados </h2></td></tr>");
                   while (myReader.Read())
                   {

                       Response.Write("<tr><td>" + myReader["nombre"].ToString() + "</td></tr>");
                   }

                   conexion.Close();
               }
               catch (Exception em)
               {
               }
           }
           
        %>
    </table><br/><br/>
    <table>
       <%
           if (Session["id_perfil"] != null)
           {
               String id = Session["id_perfil"].ToString();
               try
               {
                   SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                   conexion.Open();
                   SqlDataReader myReader = null;
                   String strSQL = "SELECT mensaje FROM View_ultimos_comentarios WHERE id_usuario=" + id ;
                   SqlCommand comando = new SqlCommand(strSQL, conexion);

                   myReader = comando.ExecuteReader();
                   Response.Write("<tr><td><h2> Ultimos Comentarios </h2></td></tr>");
                   while (myReader.Read())
                   {

                       Response.Write("<tr><td>" + myReader["mensaje"].ToString() + "</td></tr>");
                   }

                   conexion.Close();
               }
               catch (Exception em)
               {
               }
           }
           
        %>
    </table><br/><br/>
    <%
        if (Session["id_perfil"].Equals(Session["idUser"]) || Session["tipoUser"].ToString()=="1")
        {%>
    <asp:Button ID="edit" runat="server" Text="Editar Perfil" OnClick="edit_Click" />
        <%}
        
         %>


</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder4">
        <!-- Begin Menu -->
    <div id="menu" class="menu-v">
        <ul>
            <li><a href="inicio.aspx" class="active">Home</a> </li>
            
            
            <%
                if (Session["idUser"] != null)
                {
            %>
            <li><asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="irPerfil" OnClick="ir_Perfil"  >Perfil</asp:LinkButton>
               <ul>
                    <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="ir_Perfil" >Mi Perfil</asp:LinkButton></li>
                    <li><a href="Perfil.aspx">Editar mi perfil</a></li>
                </ul>
            </li>
            <%
                }
                else
                {
                    %>
            <li><a href="registro.aspx">Registro</a></li>
               <% }
              %>
            
        </ul>
    </div>
    <!-- End Menu -->	 
	</asp:Content>

<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder3">
            <h1 class="title">Perfil</h1>
        </asp:Content>


