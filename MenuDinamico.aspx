<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuDinamico.aspx.cs" Inherits="MenuDinamico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin: 0px; background-image: url(imagens/fundo7.jpg);">
    <form id="form1" runat="server">
        <div style="width: 738px; height: 44px; background-color: white">
            <div style="padding-left: 8px; float: left; width: 343px; padding-top: 12px; height: 25px">
                <span style="font-size: 14pt; color: #ff0000"><strong>Menu Dinâmico</strong></span></div>
            <div style="float: right; width: 68px; padding-top: 15px; height: 31px; text-align: center">
                <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click">Logout</asp:LinkButton></div>
            <div style="float: right; width: 86px; padding-top: 15px; height: 31px; text-align: center">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagens/voltar.jpg"
                    OnClick="ImageButton1_Click" /></div>
        </div>
        <br />
        <asp:Menu ID="MenuBanco" runat="server" Orientation="Horizontal" Width="131px" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="12pt" ForeColor="#284E98" StaticSubMenuIndent="10px">
                <StaticSelectedStyle BackColor="#507CD1" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            
            </asp:Menu>
    </form>
</body>
</html>
