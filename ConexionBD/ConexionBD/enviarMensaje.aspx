<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="enviarMensaje.aspx.cs" Inherits="ConexionBD.enviarMensaje" %>
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
            if (Session["id_remitente"] != null && Session["id_remitente"] != "")
            {
            }
            else
            {%>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Label" style="color: #333333">Para: </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="para" text="Nombre de Usuario" runat="server"></asp:TextBox>
            </td>
        </tr>
                
            <%}
             %>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label" style="color: #333333">Asunto: </asp:Label>
            </td>
            <td><%
                    if (Session["id_remitente"] != null && Session["id_remitente"] != "")
                    {%>
                <asp:TextBox ID="asunto" text="Re:" runat="server"></asp:TextBox>
                    <%}
                    else
                    {%>
                <asp:TextBox ID="asunto2" runat="server"></asp:TextBox>
                    <%}            
                    

             %></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label" style="color: #333333">Mensaje:  </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="mensaje"  runat="server" TextMode="MultiLine" Height="50" ></asp:TextBox>
            </td>
        </tr>


    </table>
    
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
        <br />
    </p>
    &nbsp;
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder3">
            <h1 class="title">Nuevo mensaje</h1>
        </asp:Content>

<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder4">
        <!-- Begin Menu -->
    <div id="menu" class="menu-v">
        <ul>
            <li><a href="inicio.aspx" class="active">Home</a> </li>
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="irPerfil" OnClick="ir_Perfil"  >Perfil</asp:LinkButton>
                <ul>
                    <li>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="ir_Perfil" >Mi Perfil</asp:LinkButton>
                    </li>
                    <li><a href="Perfil.aspx">Editar mi perfil</a></li>
                </ul>
            </li>
            <li><a href="correo.aspx" class="active">Correo</a> </li>
            
        </ul>
    </div>
    <!-- End Menu -->	 
	</asp:Content>

