<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="editarPerfil.aspx.cs" Inherits="ConexionBD.editarPerfil" %>
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <table align="center" >
        <br/>
        <tr>
            <td>Contraseña</td>
            <td >
                <asp:TextBox ID="contr" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Repetir Contraseña</td>
            <td>
                <asp:TextBox ID="contr2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fecha Nacimiento</td>
            <td>
                <asp:TextBox ID="fecha" runat="server" TextMode="Date">YYYY/MM/DD</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Avatar Url</td>
            <td>
                <asp:TextBox ID="avatar" runat="server" AutoPostBack="false"></asp:TextBox>
            </td>
        </tr>
        <%
            if (Session["tipoUser"].ToString() == "1")
            {%>
        <tr>
            <td>Tipo (1: admin,2: moderador,3: comun)</td>
            <td>
                <asp:TextBox ID="tipo" runat="server" Text="ingrese numero" AutoPostBack="false"></asp:TextBox>
            </td>
        </tr>

           <% }
            
          %>
    </table>
    <br/>
    <br/>
    <asp:Button ID="editar" runat="server" Text="Editar" OnClick="editar_Click" />
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder4">
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
            
        </ul>
    </div>
    <!-- End Menu -->	 
	</asp:Content>
<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder3">
            <h1 class="title">Editar</h1>
        </asp:Content>

