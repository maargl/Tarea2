<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="verMensaje.aspx.cs" Inherits="ConexionBD.verMensaje" %>
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
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Responder" />
        <br />
    </p>
    &nbsp;
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder3">
            <h1 class="title">Mensaje</h1>
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


