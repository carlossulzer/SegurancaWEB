<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="GruposCadastro.aspx.cs" Inherits="GruposCadastro" Title="Cadastro de Grupos de Usuários" %>
<%@ MasterType VirtualPath="~/Principal.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 30%; text-align: right">
                Descrição do 
                Grupo</td>
            <td style="width: 50%; text-align: left">
                <asp:TextBox ID="txtNome" runat="server" Width="316px" TabIndex="1" MaxLength="70"></asp:TextBox></td>
        </tr>
    </table>
    <br />
</asp:Content>

