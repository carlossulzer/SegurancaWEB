<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="GruposLista.aspx.cs" Inherits="GruposLista" Title="Cadastro de Grupos - Lista" %>
<%@ MasterType VirtualPath="~/Principal.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 100%; height: 191px">
    <div style="width: 99%; height: 37px; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px;">
        <div style="float: right; width: 346px; height: 37px; text-align: left;">
            <asp:ImageButton ID="btnPesquisar" runat="server" ImageUrl="~/imagens/btn_pesquisar.gif" OnClick="btnPesquisar_Click" />
            &nbsp;
            <asp:ImageButton ID="btnListar" runat="server" ImageUrl="~/imagens/btn_listar_todos.gif" OnClick="btnListar_Click" />
            &nbsp;
            <asp:ImageButton ID="btnNovo" runat="server" ImageUrl="~/imagens/btn_novo.gif" OnClick="btnNovo_Click" />
        </div>
        <div style="float: left; width: 418px; padding-top: 4px; height: 35px; padding-left: 5px;">
        <asp:Label ID="Label1" runat="server" Text="Descrição do Grupo" Font-Bold="True"></asp:Label>&nbsp;
            <asp:TextBox
                ID="txtPesquisa" runat="server" Width="253px"></asp:TextBox></div>
    </div>
    <asp:GridView ID="grvGrupos" runat="server" AutoGenerateColumns="False"
        Width="100%" AllowPaging="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" EmptyDataText="Não existem usuários cadastrados. Pressione o botão Novo para cadastrar um usuário." ForeColor="Black" OnPageIndexChanging="grvGrupos_PageIndexChanging" PageSize="9">
        <Columns>
            <asp:BoundField DataField="CodGrupo" HeaderText="C&#243;digo" Visible="False" />
            <asp:BoundField HeaderText="Descri&#231;&#227;o do Grupo" DataField="Descricao" >
                <ItemStyle Width="300px" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Alterar">
                <ItemStyle Width="40px" HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/imagens/alterar.gif" NavigateUrl='<%# Eval("CodGrupo", "GruposCadastro.aspx?codigo={0}&operacao=A") %>'
                        Width="4px"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Excluir">
                <ItemStyle Width="40px" HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/imagens/excluir.gif" NavigateUrl='<%# Eval("CodGrupo", "GruposCadastro.aspx?codigo={0}&operacao=E") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <EmptyDataRowStyle HorizontalAlign="Center" />
    </asp:GridView>
    </div>
</asp:Content>

