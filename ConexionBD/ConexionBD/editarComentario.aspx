<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="editarComentario.aspx.cs" Inherits="ConexionBD.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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
    <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Columns="50" Rows="10" Height="189px" Width="474px" OnInit="txtLoad"></asp:TextBox>
    <br />
    <asp:Button ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" Text="Finalizar" />
&nbsp; 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h1 class="title">Editar Comentario</h1>
</asp:Content>