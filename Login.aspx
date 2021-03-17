<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin: 0px" background="imagens/fundo7.jpg">
    <form id="form1" runat="server">
    <div style="text-align: center; width: 100%; height: 100%;">
        <br />
        <br />
        <br />
        <table style="width: 538px; height: 234px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;" id="tblLogin" runat="server">
            <tr>
                <td rowspan="3" style="width: 66px; background-color: white;">
                    <asp:Image ID="Image1" runat="server" BorderColor="Transparent"
                        ImageUrl="~/imagens/login.jpg" Height="120px" />
                </td>
                <td style="width: 192px; height: 8px; background-color: #cc6600; text-align: left;">
                    <br />
                    <table style="width: 316px; height: 59px;">
                        <tr>
                            <td style="width: 148px; text-align: right; height: 27px;">
                                <asp:Label ID="Label1" runat="server" Text="Usuário" ForeColor="#000000"></asp:Label></td>
                            <td style="width: 161px; text-align: left; height: 27px;">
                                <asp:TextBox ID="txtLogin" runat="server" TabIndex="1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 148px; text-align: right; height: 27px;">
                                <asp:Label ID="Label2" runat="server" Text="Senha" ForeColor="#000000"></asp:Label></td>
                            <td style="width: 161px; text-align: left; height: 27px;">
                                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="149px" TabIndex="2"></asp:TextBox></td>
                        </tr>
                    </table>
                     
                    <table style="width: 316px; height: 59px" id="tblAlteraSenha" runat="server" visible="false">
                        <tr>
                            <td style="text-align: right; height: 27px;">
                                <asp:Label ID="Label7" runat="server" ForeColor="Black" Text="Nova Senha" Width="81px"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 27px;">
                                <asp:TextBox ID="txtNovaSenha" runat="server" TabIndex="3" TextMode="Password" Width="149px"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="text-align: right; height: 27px;">
                                <asp:Label ID="Label8" runat="server" ForeColor="Black" Text="Confirmação de Senha" Width="139px"></asp:Label></td>
                            <td style="text-align: left; height: 27px;">
                                <asp:TextBox ID="txtNovaSenhaConf" runat="server" TabIndex="4" TextMode="Password" Width="149px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 350px; height: 48px;">
                        <tr>
                            <td style="width: 175px; text-align: right;">
                                <asp:ImageButton ID="btnConfirmar" runat="server" ImageUrl="~/imagens/btn_conf.gif" OnClick="btnConfirmar_Click" TabIndex="5" /></td>
                            <td style="width: 100px">
                                <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/imagens/btn_canc.gif" OnClick="btnCancelar_Click" TabIndex="6" /></td>
                        </tr>
                    </table>
                    <table style="width: 350px; height: 35px;">
                        <tr>
                            <td style="width: 150px; text-align: right; height: 21px;">
                                <asp:LinkButton ID="lbtAlterarSenha" runat="server" OnClick="lbtAlterarSenha_Click">Alterar Senha</asp:LinkButton></td>
                            <td style="width: 100px; height: 21px;">
                                <asp:LinkButton ID="lbtLembrarSenha" runat="server" OnClick="lbtLembrarSenha_Click">Lembrar Senha</asp:LinkButton></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table><table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
            width: 536px; border-bottom: black 1px solid; height: 45px; background-color: #ffff66" id="tblMensagemSenha" runat="server" visible="false">
            <tr>
                <td style="width: 100px; height: 41px">
                    <asp:Label ID="Label10" runat="server" Font-Size="16pt" ForeColor="#CC0000" Text="Favor alterar sua senha."
                        Width="525px"></asp:Label></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
                
            <table style="width: 640px; height: 210px; padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px;" border="0" cellpadding="0" cellspacing="0" id="tblCadastro" runat="server" visible="false">
            <tr>
                    <td rowspan="1" style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                        border-left: #000000 1px solid; width: 10%; border-bottom: #000000 1px solid; background-color: white;">
                        <asp:Image ID="Image2" runat="server" BorderColor="Transparent" ImageUrl="~/imagens/login.jpg" /></td>
                <td align="center" colspan="2" style="border-right: #000000 1px solid; width: 70%;
                    border-bottom: #000000 1px solid; height: 24px; background-color: #cc6600" valign="middle">
                    <br />
                    <table style="width: 506px; height: 100px">
                        <tr>
                            <td style="text-align: right">
                        <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Nome do Usuário" Width="128px"></asp:Label></td>
                            <td style="width: 328px; text-align: left">
                                <asp:TextBox ID="txtNome" runat="server" Width="288px" TabIndex="1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 26px; text-align: right">
                                <asp:Label ID="Label9" runat="server" ForeColor="Black" Text="E-Mail" Width="128px"></asp:Label></td>
                            <td style="width: 328px; height: 26px; text-align: left">
                                <asp:TextBox ID="txtEmail" runat="server" Width="288px" TabIndex="2" MaxLength="80"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="height: 26px; text-align: right">
                        <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="Login"></asp:Label></td>
                            <td style="width: 328px; height: 26px; text-align: left">
                                <asp:TextBox ID="txtLoginCad" runat="server" Width="149px" TabIndex="3"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                        <asp:Label ID="Label5" runat="server" ForeColor="#000000" Text="Senha"></asp:Label></td>
                            <td style="width: 328px; text-align: left">
                                <asp:TextBox ID="txtSenhaCad" runat="server" TextMode="Password" Width="149px" TabIndex="4"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
            <asp:Label ForeColor="Black" ID="Label6" runat="server" Text="Confirmação de Senha" Width="146px"></asp:Label></td>
                            <td style="width: 328px; text-align: left">
                                <asp:TextBox ID="txtConfSenha" runat="server" TextMode="Password" Width="149px" TabIndex="5"></asp:TextBox>
                </td>
                        </tr>
                    </table>
                    <table style="width: 262px; height: 55px">
                        <tr>
                            <td style="width: 140px; text-align: right">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagens/btn_conf.gif"
                        OnClick="btnConfirmar_Click" TabIndex="6" /></td>
                            <td style="text-align: right">
                            </td>
                            <td style="width: 100px; text-align: left">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/imagens/btn_canc.gif"
                        OnClick="btnCancelar_Click" CausesValidation="False" TabIndex="7" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
         </table>
        <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
            width: 640px; border-bottom: black 1px solid; height: 45px; background-color: #ffff66" id="tblMensagemAcesso" runat="server">
            <tr>
                <td style="width: 100px; height: 41px">
        
        <asp:Label ID="lblAdministrador" runat="server" Font-Size="16pt" ForeColor="#CC0000" Text="1º Acesso ao sistema, favor cadastrar um Administrador." Visible="False" Width="627px"></asp:Label></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <table style="width: 636px; height: 150px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;" id="tblLembrarSenha" runat="server">
            <tr>
                <td style="width: 66px; background-color: white; height: 125px; padding-left: 8px;">
                    <img src="imagens/email.jpg" />&nbsp;</td>
                <td style="width: 192px; height: 125px; background-color: #cc6600; text-align: center;">
                    <br />
                    <table style="width: 478px; height: 59px;">
                        <tr>
                            <td style="width: 47px; text-align: right; height: 27px;">
                                <asp:Label ID="Label12" runat="server" ForeColor="Black" Text="E-Mail"></asp:Label></td>
                            <td style="width: 155px; text-align: left; height: 27px;">
                                <asp:TextBox ID="txtEmailLembrar" runat="server" TabIndex="2" Width="409px" MaxLength="80"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table style="width: 478px; height: 48px;">
                        <tr>
                            <td style="width: 210px; text-align: right;">
                                <asp:ImageButton ID="btnConfirmaLembrar" runat="server" ImageUrl="~/imagens/btn_conf.gif" OnClick="btnConfirmaLembrar_Click" TabIndex="5" /></td>
                            <td style="width: 4px; text-align: right">
                            </td>
                            <td style="width: 193px; text-align: left;">
                                <asp:ImageButton ID="btnCancelaLembrar" runat="server" ImageUrl="~/imagens/btn_canc.gif" OnClick="btnCancelaLembrar_Click" TabIndex="6" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
            width: 632px; border-bottom: black 1px solid; height: 45px; background-color: #ffff66" id="tblMensagemLembrar" runat="server" visible="false">
            <tr>
                <td style="width: 100px; height: 41px">
                    <asp:Label ID="Label15" runat="server" Font-Size="16pt" ForeColor="#CC0000" Text="Receber senha por E-Mail"
                        Width="605px"></asp:Label></td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>

