<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Foro.inicio" %>
<% @Import Namespace="System.Data" %>
<% @Import Namespace="System.Data.SqlClient" %>
<% @Import Namespace="System.Configuration" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
    Usuario:
    <asp:TextBox ID="usuario" runat="server"></asp:TextBox>
    <br />
    <br />
    Contraseña:
    <asp:TextBox ID="Contraseña" runat="server" AutoPostBack="False" EnableViewState="True" TextMode="Password" Visible="True"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Entrar" runat="server" Text="Entrar" OnClick="Entrar_Clic"/>
    <br />
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
             <li><a href="registro.aspx">Registro</a></li>
        </ul>
    </div>
    <!-- End Menu -->	 
	</asp:Content>



