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

public partial class GruposLista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ImageButton salvar = (ImageButton)Master.FindControl("ibntConfirmar");
            salvar.Visible = false;

            ImageButton cancelar = (ImageButton)Master.FindControl("ibtnCancelar");
            cancelar.Visible = false;
  
            Master.Titulo = "CADASTRO DE GRUPOS (LISTA)";
            this.CarregaGrupos(string.Empty);
            txtPesquisa.Focus();
        }
    }
    protected void btnNovo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/GruposCadastro.aspx?codigo=0&operacao=I");
    }

    protected void grvGrupos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGrupos.PageIndex = e.NewPageIndex;
        this.CarregaGrupos(txtPesquisa.Text);
    }

    protected void CarregaGrupos(string informa)
    {
        try
        {
            GruposCTL ctlGrupos = new GruposCTL();
            grvGrupos.DataSource = ctlGrupos.ObterGruposFiltradosPorNome(informa);
            grvGrupos.DataBind();
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
            this.CarregaGrupos(txtPesquisa.Text);
        }
        else
        {
            ExibirMensagem.Exibir("Favor digitar a descrição do grupo a ser pesquisada.", this.Page);
        }

    }
    protected void btnListar_Click(object sender, ImageClickEventArgs e)
    {
        this.CarregaGrupos(string.Empty);
    }
}
