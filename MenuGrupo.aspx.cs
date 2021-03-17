using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

public partial class MenuGrupo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Para simular o postback quando um elemento da treeview é checado, isso faz com que 
        // o evento TreeNodeCheckChanged funcione corretamente
        trvMenu.Attributes.Add("onClick", "if(window.event.srcElement.tagName=='INPUT'){__doPostBack('', '')};");

        this.Master.ConfirmarEvento += new EventoBotoes(ConfirmarClick);
        this.Master.CancelarEvento += new EventoBotoes(CancelarClick);
        ImageButton salvar = (ImageButton)Master.FindControl("ibntConfirmar");
        salvar.Visible = true;

        ImageButton cancelar = (ImageButton)Master.FindControl("ibtnCancelar");
        cancelar.Visible = true;

        if (!Page.IsPostBack)
        {
            ViewState["CodGrupo"] = 0;
            Master.Titulo = "PERMISSÕES DOS GRUPOS";
            MenuDAO.CarregarTreeView(ref trvMenu);
            CarregarDadosGrupos();
        }
    }

    public void CarregarDadosGrupos()
    {
        try
        {
            GruposCTL ctlGrupos = new GruposCTL();
            grvGrupos.DataSource = ctlGrupos.ObterGruposFiltradosPorNome(string.Empty);
            grvGrupos.DataBind();

            grvGrupos.SelectedIndex = 0;
            grvGrupos_SelectedIndexChanged(grvGrupos, EventArgs.Empty);
        }
        catch (ApplicationException ex)
        {
            ExibirMensagem.Exibir(ex.Message, this.Page);
        }
    }

    protected void grvGrupos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGrupos.PageIndex = e.NewPageIndex;
        this.CarregarDadosGrupos();
    }

    protected void trvMenu_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        if (e.Node.Checked)
        {
            e.Node.Select();

            if (trvMenu.SelectedNode.Depth > 0)
            {
                int final = trvMenu.SelectedNode.Depth;
                for (int i = final; i > 0; i--)
                {
                    string findNo = trvMenu.SelectedNode.Parent.ValuePath;
                    TreeNode noAnterior = new TreeNode();
                    noAnterior = trvMenu.FindNode(findNo);

                    noAnterior.Checked = true;
                    noAnterior.Select();
                }
            }
        }
        else if (!e.Node.Checked)
        {
            DesmarcarNodes(e.Node);
        
        }
    }

    public void DesmarcarNodes(TreeNode noAtual)
    {
        int existeChildNodes = noAtual.ChildNodes.Count;
        noAtual.Checked = false;
        if (existeChildNodes > 0)
        {
            foreach (TreeNode subNoAtual in noAtual.ChildNodes)
            {
                subNoAtual.Checked = false;
                DesmarcarNodes(subNoAtual);
            }
        }
    }

    protected void grvGrupos_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CodGrupo"] = Convert.ToInt32(grvGrupos.SelectedDataKey["CodGrupo"].ToString());

        if (grvGrupos.SelectedRow.RowIndex >= 0)
        {
            trvMenu.Enabled = true;
        }
        else
        {
            trvMenu.Enabled = false;
        }

        CarregaMenuGrupo();
    }

    public void CarregaMenuGrupo()
    {
        StringBuilder sqlMenu = new StringBuilder();
        sqlMenu.Append("SELECT CodMenu FROM MenuGrupo WHERE CodGrupo = " + ViewState["CodGrupo"].ToString());
        SqlDataReader drMenu = AcessoaBancoDados.BuscaDadosReader(sqlMenu.ToString());

        foreach (TreeNode noAtual in trvMenu.Nodes)
        {
            DesmarcarNodes(noAtual);  
        }

       

        int codMenu = 0;
        while (drMenu.Read())
        {
            codMenu = drMenu.GetInt32(0);
            ChecarPermissoes(codMenu);
        }
        drMenu.Close();
        drMenu.Dispose();
    }

    public void ChecarPermissoes(int codMenu)
    {
        TreeNodeCollection nodes = trvMenu.Nodes;
        foreach (TreeNode noPrincipal in nodes)
        {
            ProcuraValor(noPrincipal, codMenu);
        }
    }


    private void ProcuraValor(TreeNode treeNode, int codMenu)
    {
        if (treeNode.ImageToolTip.ToString().Equals(codMenu.ToString()))
            treeNode.Checked = true;

        foreach (TreeNode opcao in treeNode.ChildNodes)
        {
            if (opcao.ImageToolTip.ToString().Equals(codMenu.ToString()))
                opcao.Checked = true;

            ProcuraValor(opcao, codMenu);
        }
    }

    private void ConfirmarClick(object sender, EventArgs e)
    {
        int codMenu = 0;
        try
        {
            MenusGruposCTL menusGruposCTL = new MenusGruposCTL();
            menusGruposCTL.ExcluirMenuGrupo(Convert.ToInt32(ViewState["CodGrupo"]));

            TreeNodeCollection nodes = trvMenu.Nodes;
            foreach (TreeNode noPrincipal in nodes)
            {
                codMenu = Convert.ToInt32(noPrincipal.ImageToolTip);
                if (noPrincipal.Checked)
                {
                    IncluirMenu(codMenu);
                    GravarSubMenu(noPrincipal);
                }
            }
           
            ExibirMensagem.Exibir("Operação realizada com sucesso!", this.Page);
        }
        catch (ApplicationException ex)
        {
            ExibirMensagem.Exibir(ex.Message, this.Page);
        }
    }


    public void IncluirMenu(int codMenu)
    { 
        MenusGrupos menusGrupos = new MenusGrupos(Convert.ToInt32(ViewState["CodGrupo"]), codMenu);
        MenusGruposCTL menusGruposCTL = new MenusGruposCTL();
        menusGruposCTL.InserirMenuGrupo(menusGrupos);
    }

    private void GravarSubMenu(TreeNode subMenu)
    {
        int codMenu = 0;
        foreach (TreeNode menuSub in subMenu.ChildNodes)
        {
            if (menuSub.Checked)
            {
                codMenu = Convert.ToInt32(menuSub.ImageToolTip);
                IncluirMenu(codMenu);
                GravarSubMenu(menuSub);
            }
        }
    }

    private void CancelarClick(object sender, EventArgs e)
    {
          Response.Redirect("~/Default.aspx");
    }
}
