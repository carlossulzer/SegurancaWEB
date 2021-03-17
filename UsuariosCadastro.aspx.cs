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

public partial class UsuariosCadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.ConfirmarEvento += new EventoBotoes(ConfirmarClick);
        this.Master.CancelarEvento += new EventoBotoes(CancelarClick);

        ImageButton salvar = (ImageButton)Master.FindControl("ibntConfirmar");
        salvar.Visible = true;

        ImageButton cancelar = (ImageButton)Master.FindControl("ibtnCancelar");
        cancelar.Visible = true;

        Master.Page.Form.DefaultButton = "ibntConfirmar";

        if (!Page.IsPostBack)
        {
            ViewState["codigo"] = Request["codigo"].Trim();
            ViewState["operacao"] = Request["operacao"].Trim();

            if (ViewState["operacao"].ToString().Equals("A")) // alterar
            {
                Master.Titulo = "ALTERAÇÃO DE USUÁRIOS";
                this.CarregaDadosGrupos();
                CarregaDadosUsuarios();
                this.StatusCampos(true);
                salvar.Attributes.Add("onclick", "return confirm('Deseja mesmo alterar o registro ?')");
            }
            else if (ViewState["operacao"].ToString().Equals("I")) // inclusao
            {
                Master.Titulo = "INCLUSÃO DE USUÁRIOS";
                this.StatusCampos(true);
                this.CarregaDadosGrupos();
            }
            else if (ViewState["operacao"].ToString().Equals("E")) // excluir
            {
                Master.Titulo = "EXCLUSÃO DE USUÁRIOS";
                this.CarregaDadosGrupos();
                CarregaDadosUsuarios();
                this.StatusCampos(false);
                salvar.Attributes.Add("onclick", "return confirm('Deseja mesmo excluir o registro ?')");
            }
            else if (ViewState["operacao"].ToString().Equals("C")) // consulta
                Master.Titulo = "CONSULTA USUARIOS";

            txtNome.Focus();
        }
    }

    private void limpaCampos()
    {
        txtNome.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtLogin.Text = string.Empty;
        txtSenha.Text = string.Empty;
        txtConfSenha.Text = string.Empty;
        ddlGrupo.SelectedValue = "1";
        ckbxStatus.Checked = false;
        ckbxTrocarSenha.Checked = false;

        txtNome.Focus();
    }

    public void CarregaDadosGrupos()
    {
        DataSet dadosGrupos;
        GruposCTL gruposCTL = new GruposCTL();
        dadosGrupos = gruposCTL.ObterListaGrupos();
        ddlGrupo.DataValueField = "CodGrupo";
        ddlGrupo.DataTextField = "Descricao";
        ddlGrupo.DataSource = dadosGrupos;
        ddlGrupo.SelectedValue = "1"; // Administrador
        ddlGrupo.DataBind();
    }

    
    private void StatusCampos(bool status)
    {
        txtNome.Enabled = status;
        txtEmail.Enabled = status;
        txtLogin.Enabled = status;
        txtSenha.Enabled = status;
        txtConfSenha.Enabled = status;
        ddlGrupo.Enabled = status;
        ckbxStatus.Enabled = status;
        ckbxTrocarSenha.Enabled = status;

        if (ViewState["operacao"].ToString().Equals("A"))
        {
            txtSenha.ReadOnly = true;
            txtConfSenha.ReadOnly = true;
            txtSenha.TextMode = TextBoxMode.SingleLine;
            txtConfSenha.TextMode = TextBoxMode.SingleLine;
            txtSenha.ForeColor = Color.Red;
            txtConfSenha.ForeColor = Color.Red;
            txtSenha.Text = "não pode ser alterada";
            txtConfSenha.Text = "não pode ser alterada";
        }
        else
        {
            txtSenha.ForeColor = Color.Black;
            txtConfSenha.ForeColor = Color.Black;
            txtSenha.TextMode = TextBoxMode.Password;
            txtConfSenha.TextMode = TextBoxMode.Password;
        }

    }

    public void retornaParaConsulta()
    {
        Response.Redirect("~/UsuariosLista.aspx");
    }


    private void ConfirmarClick(object sender, EventArgs e)
    {
        bool tudoOk = true;

        try
        {
            Usuarios usuarios = new Usuarios(Convert.ToInt32(ViewState["codigo"]), txtNome.Text, txtEmail.Text, txtLogin.Text, txtSenha.Text, Convert.ToInt32(ddlGrupo.SelectedItem.Value), ckbxStatus.Checked, ckbxTrocarSenha.Checked);
            UsuariosCTL usuariosCTL = new UsuariosCTL();

            if (ViewState["operacao"].ToString().Equals("I")) // incluir
            {
                tudoOk = ValidaForm();
                if (tudoOk)
                {
                    usuariosCTL.InserirUsuarios(usuarios);
                    this.limpaCampos();
                }
            }
            else if (ViewState["operacao"].ToString().Equals("A")) // alterar
            {
                tudoOk = ValidaForm();
                if (tudoOk)
                {
                    usuariosCTL.AlterarUsuarios(usuarios);
                    this.retornaParaConsulta();
                }
            }
            else if (ViewState["operacao"].Equals("E")) // excluir
            {
                usuariosCTL.ExcluirUsuarios(usuarios);
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

        if (UsuariosDAO.RegistroExiste(txtNome.Text, ViewState["operacao"].ToString(), ViewState["codigo"].ToString(), "Nome" ))
        {
            ExibirMensagem.Exibir("Usuário já cadastrado.", this.Page);
            txtNome.Focus();
            v = false;
        }

        if (UsuariosDAO.RegistroExiste(txtLogin.Text, ViewState["operacao"].ToString(), ViewState["codigo"].ToString(), "Login"))
        {
            ExibirMensagem.Exibir("Login já cadastrado.", this.Page);
            txtLogin.Focus();
            v = false;
        }

        if (v)
        {
            v = Validacao.ValidaTextBox(this.Page, txtNome);
            if (!v)
            {
                ExibirMensagem.Exibir("Favor informar o nome do usuário.", this.Page);
                txtNome.Focus();
            }
        }

        if (v)
        {
            string retornoEmail = Validacao.ValidaEmail(this.Page, txtEmail);
            v = retornoEmail.Equals(string.Empty) ? true : false;
            if (!v)
            {
                ExibirMensagem.Exibir(retornoEmail, this.Page);
                txtEmail.Focus();
            }
            else if (UsuariosDAO.RegistroExiste(txtEmail.Text, ViewState["operacao"].ToString(), ViewState["codigo"].ToString(), "Email"))
            {
                ExibirMensagem.Exibir("E-Mail já cadastrado.", this.Page);
                txtEmail.Focus();
                v = false;
            }
        }


        if (v)
        {
            v = Validacao.ValidaTextBox(this.Page, txtLogin);
            if (!v)
            {
                ExibirMensagem.Exibir("Favor informar o login do usuário.", this.Page);
                txtLogin.Focus();
            }
        }

        if (!ViewState["operacao"].ToString().Equals("A"))
        {
            if (v)
            {
                v = Validacao.ValidaTextBox(this.Page, txtSenha);
                if (!v)
                {
                    ExibirMensagem.Exibir("Favor informar a senha do usuário.", this.Page);
                    txtSenha.Focus();
                }
            }

            if (v)
            {
                v = (txtSenha.Text.Equals(txtConfSenha.Text));
                if (!v)
                {
                    ExibirMensagem.Exibir("As senha do usuário não conferem.", this.Page);
                    txtSenha.Focus();
                }
            }
        }
        return v;

    }

    public void CarregaDadosUsuarios()
    {
        DataSet dadosUsuarios;
        UsuariosCTL usuariosCTL = new UsuariosCTL();

        dadosUsuarios = usuariosCTL.ObterUsuariosPorCodigo(Convert.ToInt32(ViewState["codigo"].ToString()));
        txtNome.Text = dadosUsuarios.Tables[0].Rows[0]["nome"].ToString();
        txtEmail.Text = dadosUsuarios.Tables[0].Rows[0]["email"].ToString();
        txtLogin.Text = dadosUsuarios.Tables[0].Rows[0]["login"].ToString();
        ddlGrupo.SelectedValue = dadosUsuarios.Tables[0].Rows[0]["CodGrupo"].ToString();
        ckbxStatus.Checked = Convert.ToBoolean(dadosUsuarios.Tables[0].Rows[0]["status"].ToString());
        ckbxTrocarSenha.Checked = Convert.ToBoolean(dadosUsuarios.Tables[0].Rows[0]["trocarsenha"].ToString());
    }
}
