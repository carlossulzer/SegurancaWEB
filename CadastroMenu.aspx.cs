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

public partial class CadastroMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["tipo"] = "0";
            HabilitarCampos(false);
            MenuDAO.CarregarTreeView(ref trvMenu);
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {

        if (ViewState["tipo"].ToString().Equals("0"))
        {
            trvMenu.Nodes.Add(MenuDAO.AdicionarItemTreeView(0, txtNome.Text, fupImagem.FileName, txtURL.Text));
        }
        else
        {
            TreeNode root = trvMenu.SelectedNode;
            root.ChildNodes.Add(MenuDAO.AdicionarItemTreeView(0, txtNome.Text, fupImagem.FileName, txtURL.Text));
        }

        HabilitarCampos(false);
        trvMenu.ExpandAll();
    }


    public void HabilitarCampos(bool status)
    {
        txtNome.Enabled = status;
        txtURL.Enabled = status;
        fupImagem.Enabled = status;
        
        txtNome.Text = string.Empty;
        txtURL.Text = string.Empty;

        btnSalvar.Enabled = status;
        btnCancelar.Enabled = status;
        if (status)
        {
            txtNome.Focus();
        }
    }

    protected void btnNovoMenu_Click(object sender, EventArgs e)
    {
        ViewState["tipo"] = "0";
        HabilitarCampos(true);
    }

    protected void btnNovoSubMenu_Click(object sender, EventArgs e)
    {
        if (trvMenu.SelectedValue.Equals(string.Empty))
        {
            ExibirMensagem.Exibir("Favor selecionar uma opção do menu para inserir um sub-menu.", this.Page); 
        }
        else
        {
            ViewState["tipo"] = "1";
            HabilitarCampos(true);
        }
    }
    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        if (trvMenu.SelectedValue.Equals(string.Empty))
        {
            ExibirMensagem.Exibir("Favor selecionar a opção do menu que deseja excluir.", this.Page);
        }
        else
        {
            trvMenu.Nodes.Remove(trvMenu.SelectedNode);
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // exclui todos os itens do menu
        MenuCTL menuCTL = new MenuCTL();
        menuCTL.Excluir();

        int coluna = 0;
        int nivel = 0;
        foreach (TreeNode item in trvMenu.Nodes)
        {
            if (item.GetType().Equals(typeof(TreeNode)))
            {
                nivel = 0;
                coluna++;
 
                GravarMenu(item, coluna, nivel);
            }
        }
    }

    public void GravarMenu(TreeNode subMenu, int coluna, int nivel)
    {
        MenuDAO.GravarItem(coluna, subMenu.Text, nivel, subMenu.ImageUrl, subMenu.ToolTip); // subMenu.NavigateUrl);

        nivel++;
        foreach (TreeNode subItem in subMenu.ChildNodes)
        {
            GravarMenu(subItem, coluna, nivel);
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
}
