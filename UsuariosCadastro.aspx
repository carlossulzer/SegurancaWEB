<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="UsuariosCadastro.aspx.cs" Inherits="UsuariosCadastro" Title="Cadastro de Usuários" %>
<%@ MasterType VirtualPath="~/Principal.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 30%; text-align: right">
                Nome do Usuário</td>
            <td style="width: 50%; text-align: left">
                <asp:TextBox ID="txtNome" runat="server" Width="316px" TabIndex="1" MaxLength="70"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 30%; height: 26px; text-align: right">
                E-Mail</td>
            <td style="width: 50%; height: 26px; text-align: left">
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="80" TabIndex="1" Width="316px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 30%; text-align: right; height: 26px;">
                Login</td>
            <td style="width: 50%; text-align: left; height: 26px;">
                <asp:TextBox ID="txtLogin" runat="server" TabIndex="2" MaxLength="15" Width="155px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 30%; text-align: right">
                Senha</td>
            <td style="width: 50%; text-align: left">
                <asp:TextBox ID="txtSenha" runat="server" TabIndex="3" TextMode="Password" MaxLength="15" Width="155px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 30%; text-align: right">
                Confirmação de&nbsp; Senha</td>
            <td style="width: 50%; text-align: left">
                <asp:TextBox ID="txtConfSenha" runat="server" TabIndex="4" TextMode="Password" MaxLength="15" Width="155px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 30%; text-align: right">
                Grupo</td>
            <td style="width: 50%; text-align: left">
                <asp:DropDownList ID="ddlGrupo" runat="server" Width="140px" TabIndex="5">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 30%; text-align: right">
                Status</td>
            <td style="width: 50%; text-align: left">
                <asp:CheckBox ID="ckbxStatus" runat="server" Checked="True" Text="Ativo" Width="103px" /></td>
        </tr>
        <tr>
            <td style="width: 30%; text-align: right">
                Trocar senha no próximo login</td>
            <td style="width: 50%; text-align: left">
                <asp:CheckBox ID="ckbxTrocarSenha" runat="server" Text="Sim" /></td>
        </tr>
    </table>
    <br />
</asp:Content>

