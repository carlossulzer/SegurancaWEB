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
using System.Drawing;

public partial class GruposCadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.ConfirmarEvento += new EventoBotoes(ConfirmarClick);
        this.Master.CancelarEvento += new EventoBotoes(CancelarClick);

        ImageButton salvar = (ImageButton)Master.FindControl("ibntConfirmar");
        ImageButton cancelar = (ImageButton)Master.FindControl("ibtnCancelar");

        Master.Page.Form.DefaultButton = "ibntConfirmar";

        if (!Page.IsPostBack)
        {
            ViewState["codigo"] = Request["codigo"].Trim();
            ViewState["operacao"] = Request["operacao"].Trim();

            if (ViewState["operacao"].ToString().Equals("A")) // alterar
            {
                Master.Titulo = "ALTERAÇÃO DE GRUPOS";
                this.StatusCampos(true);
                CarregaDadosGrupos();
                salvar.Attributes.Add("onclick", "return confirm('Deseja mesmo alterar o registro ?')");
            }
            else if (ViewState["operacao"].ToString().Equals("I")) // inclusao
            {
                Master.Titulo = "INCLUSÃO DE GRUPOS";
                this.StatusCampos(true);
            }
            else if (ViewState["operacao"].ToString().Equals("E")) // excluir
            {
                Master.Titulo = "EXCLUSÃO DE GRUPOS";
                CarregaDadosGrupos();
                this.StatusCampos(false);
                salvar.Attributes.Add("onclick", "return confirm('Deseja mesmo excluir o registro ?')");
            }
            else if (ViewState["operacao"].ToString().Equals("C")) // consulta
                Master.Titulo = "CONSULTA GRUPOS";

            txtNome.Focus();
        }

        if (Convert.ToInt32(ViewState["codigo"]).Equals(1))
        {
            salvar.Visible = false;
        }
        else
        {
            salvar.Visible = true;
        }
        cancelar.Visible = true;
    }

    private void limpaCampos()
    {
        txtNome.Text = string.Empty;
        txtNome.Focus();
    }

      
    private void StatusCampos(bool status)
    {
        txtNome.Enabled = status;
    }

    public void retornaParaConsulta()
    {
        Response.Redirect("~/GruposLista.aspx");
    }


    private void ConfirmarClick(object sender, EventArgs e)
    {
        bool tudoOk = true;

        try
        {
            Grupos grupos = new Grupos(Convert.ToInt32(ViewState["codigo"]), txtNome.Text);
            GruposCTL gruposCTL = new GruposCTL();

            if (ViewState["operacao"].ToString().Equals("I")) // incluir
            {
                tudoOk = ValidaForm();
                if (tudoOk)
                {
                    gruposCTL.InserirGrupo(grupos);
                    this.limpaCampos();
                }
            }
            else if (ViewState["operacao"].ToString().Equals("A")) // alterar
            {
                tudoOk = ValidaForm();
                if (tudoOk)
                {
                    gruposCTL.AlterarGrupo(grupos);
                    this.retornaParaConsulta();
                }
            }
            else if (ViewState["operacao"].Equals("E")) // excluir
            {
                gruposCTL.ExcluirGrupos(grupos);
                this.retornaParaConsulta();

            }

            if (tudoOk)
                ExibirMensagem.Exibir("Operação realizada com sucesso!", this.Page);
        }
        catch (ApplicationException ex)
        {
            ExibirMensagem.Exibir(ex.Message, this.Page);
        }
    }

    private void CancelarClick(object sender, EventArgs e)
    {
        this.retornaParaConsulta();
    }

    public bool ValidaForm()
    {
        bool v = true;

        if (GruposDAO.RegistroExiste(txtNome.Text, ViewState["operacao"].ToString(), ViewState["codigo"].ToString()))
        {
            ExibirMensagem.Exibir("Grupo já cadastrado.", this.Page);
            txtNome.Focus();
            v = false;
        }
        
        if (v)
        {
            v = Validacao.ValidaTextBox(this.Page, txtNome);
            if (!v)
            {
                ExibirMensagem.Exibir("Favor informar o nome do grupo.", this.Page);
                txtNome.Focus();
            }
        }

        return v;

    }

    public void CarregaDadosGrupos()
    {
        DataSet dadosGrupos;
        GruposCTL gruposCTL = new GruposCTL();

        dadosGrupos = gruposCTL.ObterGruposPorCodigo(Convert.ToInt32(ViewState["codigo"].ToString()));
        txtNome.Text = dadosGrupos.Tables[0].Rows[0]["descricao"].ToString();

        if (Convert.ToInt32(ViewState["codigo"]).Equals(1))
        {
            this.StatusCampos(false);
        }
    }
}
