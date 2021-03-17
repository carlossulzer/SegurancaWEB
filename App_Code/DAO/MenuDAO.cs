using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MenuDAO
/// </summary>
public class MenuDAO
{
	public MenuDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void CarregarMenu(ref Menu objetoView)
    {
        objetoView.Items.Clear();
        StringBuilder sql = new StringBuilder();
        sql.Append(" select menu.CodMenu, menu.ColunaMenu, menu.Descricao, menu.Nivel, menu.URL, menu.Imagem ");
        sql.Append(" from menu, menugrupo ");
        sql.Append(" where menu.codmenu = menugrupo.codmenu and ");
        sql.Append(" menugrupo.codgrupo  = " + GrupodoUsuarioLogado.CodigodoGrupo);

        SqlDataReader drItens = AcessoaBancoDados.BuscaDadosReader(sql.ToString());

        int colunaMenu = 0;
        string descricao = string.Empty;
        int nivel = 0;
        string URL = string.Empty;
        string imagem = string.Empty;
        string itemAtual = string.Empty;

        while (drItens.Read())
        {
            colunaMenu = drItens.GetInt32(1);
            descricao = drItens.GetString(2);
            nivel = drItens.GetInt32(3);
            URL = drItens.GetString(4);
            imagem = drItens.GetString(5);

            CarregarItemMenu(ref objetoView, descricao, nivel, imagem, URL, ref itemAtual);
        }
        drItens.Close();
        drItens.Dispose();
    }


    public static void CarregarTreeView(ref TreeView treeViewMenu)
    {
        treeViewMenu.Nodes.Clear();
        StringBuilder sql = new StringBuilder();
        sql.Append("select CodMenu, ColunaMenu, Descricao, Nivel, URL, Imagem from menu");

        SqlDataReader drItens = AcessoaBancoDados.BuscaDadosReader(sql.ToString());

        int codMenu = 0;
        int colunaMenu = 0;
        string descricao = string.Empty;
        int nivel = 0;
        string URL = string.Empty;
        string imagem = string.Empty;
        string itemAtual = string.Empty;

        while (drItens.Read())
        {
            codMenu = drItens.GetInt32(0);
            colunaMenu = drItens.GetInt32(1);
            descricao = drItens.GetString(2);
            nivel = drItens.GetInt32(3);
            URL = drItens.GetString(4);
            imagem = drItens.GetString(5);

            CarregarItemTreeView(ref treeViewMenu, codMenu, descricao, nivel, URL, imagem, ref itemAtual);
        }
        drItens.Close();
        drItens.Dispose();
    }


    public void CarregarItemMenu(ref Menu programaMenu, string descricao, int nivel, string URL, string imagem, ref string itemAtual)
    {
        if (nivel.Equals(0))
        {
            programaMenu.Items.Add(AdicionarItemMenu(descricao, imagem, URL));
           itemAtual = descricao;
        }
        else
        {
            itemAtual = DescobreMenu(itemAtual, nivel);
            MenuItem atual = programaMenu.FindItem(itemAtual);
            atual.ChildItems.Add(AdicionarItemMenu(descricao, imagem, URL));
            
            itemAtual = atual.ValuePath+"/"+descricao;
        }
    }


    public static void CarregarItemTreeView(ref TreeView treeViewMenu, int codMenu, string descricao, int nivel, string URL, string imagem, ref string itemAtual)
    {
        if (nivel.Equals(0))
        {
            treeViewMenu.Nodes.Add(AdicionarItemTreeView(codMenu, descricao, imagem, URL));
            itemAtual = descricao;
        }
        else
        {
            itemAtual = DescobreMenu(itemAtual, nivel);
            TreeNode atual = treeViewMenu.FindNode(itemAtual);
            atual.ChildNodes.Add(AdicionarItemTreeView(codMenu, descricao, imagem, URL));

            itemAtual = atual.ValuePath + "/" + descricao;
        }
    }

    public static MenuItem AdicionarItemMenu(string descricao, string imagem, string URL)
    {
        MenuItem menu = new MenuItem();
        menu.Text = descricao.Trim();
        menu.Value = descricao.Trim();
        menu.ImageUrl = imagem.Trim();
        menu.NavigateUrl = URL.Trim();
        return menu;
    }

    public static TreeNode AdicionarItemTreeView(int codMenu, string descricao, string imagem, string URL)
    {
        TreeNode menu = new TreeNode();
        menu.Text = descricao.Trim();
        menu.Value = descricao.Trim();
        menu.ImageToolTip = codMenu.ToString();
        menu.ImageUrl = imagem.Trim();
        menu.ToolTip = URL.Trim();  
        // Adiciona a NavigateUrl em ToolTipo para que não seja executada ao
        // clicar em um dos itens do menu para inserir um sub-menu
        return menu;
    }

    public static string DescobreMenu(string menu, int nivelAtual)
    {
        int nivel = 0;
        int barraNivel = 0;
        string menuNovo = string.Empty;
        if (menu.Contains("/"))
        {
            for (int cont = 0; cont < menu.Length; cont++)
            {
                if (menu.Substring(cont, 1).Equals("/") && (nivel < nivelAtual))
                {
                    nivel++;
                    barraNivel = cont;
                }
            }
            if (nivel < nivelAtual)
                menuNovo = menu;
            else
                menuNovo = menu.Substring(0, barraNivel);
        }
        else
        {
            menuNovo = menu;
        }

        return menuNovo;
    }

    public static void GravarItem(int colunaMenu, string descricao, int nivel, string imagem, string URL)
    {
        StringBuilder sqlInsert = new StringBuilder();

        sqlInsert.Append("INSERT INTO MENU(colunaMenu, descricao, nivel, URL, imagem) VALUES (");
        sqlInsert.Append(FormatarString.Formatar(colunaMenu) + ", ");
        sqlInsert.Append(FormatarString.Formatar(descricao) + ", ");
        sqlInsert.Append(FormatarString.Formatar(nivel) + ", ");
        sqlInsert.Append(FormatarString.Formatar(URL) + ", ");
        sqlInsert.Append(FormatarString.Formatar(imagem) + ")");

        AcessoaBancoDados.ManterDados(sqlInsert.ToString());
    }


    public void Excluir()
    {
        StringBuilder sqlExcluir = new StringBuilder();
        sqlExcluir.Append("Delete from MenuGrupo;");            // excluir todas as permissões dos grupos / menus
        sqlExcluir.Append("Delete from Menu;");                 // excluir todos os itens de menu cadastrados
        sqlExcluir.Append("DBCC CHECKIDENT (Menu, RESEED, 0)"); // zera o campo auto-incremental da tabela menu
        AcessoaBancoDados.ManterDados(sqlExcluir.ToString()); 
    }
}


//cadatro                                                             0
//    pessoa juridica     => cadastro/pessoa juridica                 1
//        completa        => cadastro/pessoa juridica/completa        2
//        parcial         => cadastro/pessao juridica/parcial         2
//    pessoa fisica       => cadastro/pessoa fisica                   1