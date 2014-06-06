<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Foro.Registro" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <p>
    <table align="center" style="width: 48%; height: 81px;">
        <tr>
            <td style="text-align: left">Nombre: </td>
            <td>
                <asp:TextBox ID="Nombre" runat="server" AutoPostBack="false" style="text-align: left; margin-left: 0px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">Contraseña:</td>
            <td>
                <asp:TextBox ID="pass1" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Repetir Contraseña</td>
            <td>
                <asp:TextBox ID="pass2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fecha Nacimiento</td>
            <td>
                <asp:TextBox ID="fecha" runat="server" TextMode="Date">DD/MM/YYYY</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Sexo</td>
            <td>
                <asp:DropDownList ID="sexo" runat="server">
                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Avatar Url</td>
            <td>
                <asp:TextBox ID="avatar" runat="server" AutoPostBack="false"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="Enviar" runat="server" Text="Finalizar" OnClick="Enviar_Clic" />
    <br />
</p>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder4">
        <!-- Begin Menu -->
    <div id="menu" class="menu-v">
        <ul>
            <li><a href="inicio.aspx" class="active">Home</a> </li>
            
           
            <li><a href="registro.aspx">Registro</a></li>
        </ul>
    </div>
    <!-- End Menu -->	 
	</asp:Content>


