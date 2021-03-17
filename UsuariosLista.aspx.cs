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

public partial class UsuariosLista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ImageButton salvar = (ImageButton)Master.FindControl("ibntConfirmar");
            salvar.Visible = false;

            ImageButton cancelar = (ImageButton)Master.FindControl("ibtnCancelar");
            cancelar.Visible = false;
  
            Master.Titulo = "CADASTRO DE USUÁRIOS (LISTA)";
            this.CarregaUsuarios(string.Empty);
            txtPesquisa.Focus();
        }
    }
    protected void btnNovo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/UsuariosCadastro.aspx?codigo=0&operacao=I");
    }

    protected void grvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUsuarios.PageIndex = e.NewPageIndex;
        this.CarregaUsuarios(txtPesquisa.Text);
    }

    protected void CarregaUsuarios(string informa)
    {
        try
        {
            UsuariosCTL ctlUsuarios = new UsuariosCTL();
            grvUsuarios.DataSource = ctlUsuarios.ObterUsuariosFiltradosPorNome(informa);
            grvUsuarios.DataBind();
        }
        catch (ApplicationException ex)
        {
            ExibirMensagem.Exibir(ex.Message, this.Page);
        }

    }


    protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
    {
        if (!txtPesquisa.Text.Equals(String.Empty))
        {
            this.CarregaUsuarios(txtPesquisa.Text);
        }
        else
        {
            ExibirMensagem.Exibir("Favor digitar o nome da cidade a ser pesquisado.", this.Page);
        }

    }
    protected void btnListar_Click(object sender, ImageClickEventArgs e)
    {
        this.CarregaUsuarios(string.Empty);
    }
}
