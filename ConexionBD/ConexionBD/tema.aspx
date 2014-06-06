<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="tema.aspx.cs" Inherits="ConexionBD.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<br />
            <asp:Panel ID="Panel1" runat="server" OnLoad="actualizar_Click">
            </asp:Panel>
<br />
<br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <%
            if (Session["User"] != null)
            {%>
                <asp:Button ID="Button1" runat="server" OnClick="btnNuevo_Click" style="text-align: left" Text="Nuevo Tema" />
            <%} %>
        <br />
    </p>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder3">
            <h1 class="title">Temas de Categoria</h1>
        </asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder4">
      <!-- Begin Menu -->
    <div id="menu" class="menu-v">
        <ul>
            <li><a href="inicio.aspx" class="active">Home</a> </li>
            <%if (Session["idUser"] != null)
                {
                 %>
            <li><asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="irPerfil" OnClick="ir_Perfil"  >Perfil</asp:LinkButton>
               <ul>
                    <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="ir_Perfil" >Mi Perfil</asp:LinkButton></li>
                    <li><a href="Perfil.aspx">Editar mi perfil</a></li>
                </ul>
            </li>
            <%}
                     
                   else
                {
            %>
            <li><a href="registro.aspx">Registro</a></li>
            <%
                }
              %>
            
        </ul>
    </div>
    <!-- End Menu -->	 

	</asp:Content>

