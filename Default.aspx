<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body background="imagens/fundo7.jpg">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-size: 24pt">&nbsp;<br />
                <br />
                <br />
            </span>
        <table style="width: 500px; height: 252px">
            <tr>
                <td style="width: 250px; background-color: #ffff00">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="X-Large"
                        NavigateUrl="~/MenuEstatico.aspx" Width="201px">Menu Estático (1)</asp:HyperLink></td>
                <td style="width: 250px; background-color: #ffcc00; text-align: center;">
                    <asp:HyperLink ID="HyperLink7" runat="server" Font-Bold="True" Font-Size="X-Large"
                        NavigateUrl="~/MenuEstatico2.aspx" Width="201px">Menu Estático (2)</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 250px; background-color: #00cc99; text-align: center;">
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Size="X-Large"
            NavigateUrl="~/MenuDinamico.aspx" Width="190px" ForeColor="#000000">Menu Dinâmico</asp:HyperLink></td>
                <td style="width: 250px; background-color: #000099; text-align: center;">
                    <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" Font-Size="X-Large"
                        NavigateUrl="~/UsuariosLista.aspx" ForeColor="#FFFF00">Usuários</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 250px; background-color: #ff0000; text-align: center;">
                    <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" Font-Size="X-Large"
                        ForeColor="White" NavigateUrl="~/GruposLista.aspx">Grupos</asp:HyperLink></td>
                <td style="width: 250px; background-color: white; text-align: center;">
                    <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="True" Font-Size="X-Large"
                        ForeColor="#CC0000" NavigateUrl="~/CadastroMenu.aspx">Menus</asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 250px; background-color: #00ff00; text-align: center">
                    <asp:HyperLink ID="HyperLink6" runat="server" Font-Bold="True" Font-Size="X-Large"
                        ForeColor="Black" NavigateUrl="~/MenuGrupo.aspx">Permissões</asp:HyperLink></td>
                <td style="width: 250px; background-color: #993300; text-align: center">
                    <asp:LinkButton ID="lbtnLogout" runat="server" Font-Bold="True" Font-Size="X-Large"
                        OnClick="lbtnLogout_Click" ForeColor="#FFFFFF">Logout</asp:LinkButton></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
