<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="inicioUser.aspx.cs" Inherits="ConexionBD.inicioUser" %>
<% @Import Namespace="System.Data" %>
<% @Import Namespace="System.Data.SqlClient" %>
<% @Import Namespace="System.Configuration" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
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

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
            <p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" OnInit="actualizar_Click">
    <ContentTemplate>
        <br />
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
<br />
<br />
        <br />
<br />
    </ContentTemplate>
</asp:UpdatePanel>
<p>
    <br />
</p>
        
            
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder4">
         <!-- Begin Menu -->
    <div id="menu" class="menu-v">
        <ul>
            <li><a href="inicio.aspx" class="active">Home</a> </li>
            <li><asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="irPerfil" OnClick="ir_Perfil"  >Perfil</asp:LinkButton>
               <ul>
                    <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="ir_Perfil" >Mi Perfil</asp:LinkButton></li>
                    <li><a href="Perfil.aspx">Editar mi perfil</a></li>
                </ul>
            </li>
            <li><a href="correo.aspx" class="active">Correo</a> </li>
        </ul>
    </div>
    <!-- End Menu --> 
	</asp:Content>


