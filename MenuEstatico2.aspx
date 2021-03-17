<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="MenuEstatico2.aspx.cs" Inherits="MenuEstatico2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menu Estático (2)</title>
</head>
<body style="margin: 0px; background-image: url(imagens/fundo7.jpg);">
    <form id="form1" runat="server">
        <div style="width: 738px; height: 44px; background-color: white">
            <div style="padding-left: 8px; float: left; width: 343px; padding-top: 12px; height: 25px">
                <span style="font-size: 14pt; color: #ff0000"><strong>Menu Estático</strong></span></div>
            <div style="float: right; width: 68px; padding-top: 15px; height: 31px; text-align: center">
                <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click">Logout</asp:LinkButton></div>
            <div style="float: right; width: 86px; padding-top: 15px; height: 31px; text-align: center">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagens/voltar.jpg"
                    OnClick="ImageButton1_Click" /></div>
        </div>
        <br />
        <table style="height: 33px">
            <tr>
                <td style="width: 100px; height: 44px">
            <asp:Menu ID="MenuUsuario" runat="server" Orientation="Horizontal" Width="131px" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="12pt" ForeColor="#284E98" StaticSubMenuIndent="10px">
                <StaticSelectedStyle BackColor="#507CD1" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            <Items>
                <asp:MenuItem Text="Cadastros" Value="Cadastros">
                    <asp:MenuItem Text="Clientes" Value="Clientes" NavigateUrl="~/Clientes.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Fornecedores" Value="Fornecedores" NavigateUrl="~/Fornecedores.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Bairros" Value="Bairros"></asp:MenuItem>
                    <asp:MenuItem Text="Cidades" Value="Cidades"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Relatorios" Value="Relatorios">
                    <asp:MenuItem Text="Rela&#231;&#227;o de Clientes" Value="Rela&#231;&#227;o de Clientes">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Rela&#231;&#227;o de Usu&#225;rios" Value="Rela&#231;&#227;o de Usu&#225;rios">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Administrador" Value="Administrador">
                    <asp:MenuItem NavigateUrl="~/UsuariosLista.aspx" Text="Usu&#225;rios" Value="Usu&#225;rios">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/MenuGrupo.aspx" Text="Permiss&#245;es" Value="Permiss&#245;es">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Sair" Value="Sair"></asp:MenuItem>
            </Items>
            
            </asp:Menu>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
