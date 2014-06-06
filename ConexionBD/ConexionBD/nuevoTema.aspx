<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="nuevoTema.aspx.cs" Inherits="ConexionBD.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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
        </ul>
    </div>
    <!-- End Menu -->  
</asp:Content>
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
    <table align="center" style="width: 48%; height: 81px;">
        <tr>
            <td style="text-align: left">Nombre: </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" AutoPostBack="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">Descripcion: </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" AutoPostBack="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">Publico: </td>
            <td>
                <asp:CheckBox ID="chbPublico" runat="server" />
            </td>
            </tr>
        <tr>
            <td style="text-align: left">Mensaje: </td>
            <td>
                <asp:TextBox ID="txtMensaje" runat="server" AutoPostBack="false" Height="49px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" Text="Finalizar" Width="83px" />

</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder3">
            <h1 class="title">Nuevo Tema</h1>
        </asp:Content>

