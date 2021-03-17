//adempiere - erp free
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
using System.Net.Mail;
using System.Text;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (VerificaAdministrador.Verificar())
            {
                ViewState["CadastrarADM"] = "S";

                // logn
                tblLogin.Visible = false;
                tblMensagemSenha.Visible = false;

                // cadastro
                tblCadastro.Visible = true;
                tblMensagemAcesso.Visible = true;

                // lembrar
                tblLembrarSenha.Visible = false;
                tblMensagemLembrar.Visible = false;

                lblAdministrador.Visible = true;
                txtNome.Focus();
            }
            else
            {
                ViewState["CadastrarADM"] = "N";
                // login
                tblLogin.Visible = true;
                tblMensagemSenha.Visible = false;

                // cadastro
                tblCadastro.Visible = false;
                tblMensagemAcesso.Visible = false;

                // lembrar
                tblLembrarSenha.Visible = false;
                tblMensagemLembrar.Visible = false;

                lblAdministrador.Visible = false;
                txtLogin.Focus();
            }
        }

        // ViewState criada para que os campos PassWord não se apagem quando 
        // ocorrer um refresh no formulário

        ViewState["senha"] = txtSenha.Text.Trim();
        ViewState["senhaCad"] = txtSenhaCad.Text.Trim();
        ViewState["confSenha"] = txtConfSenha.Text.Trim();
        ViewState["novaSenha"] = txtNovaSenha.Text.Trim();
        ViewState["novaSenhaConf"] = txtNovaSenhaConf.Text.Trim();
    
    }

    protected void btnConfirmar_Click(object sender, ImageClickEventArgs e)
    {
        bool retorno = false;
        bool trocaSenha = false;
        bool verificar = true;
        string novaSenha = string.Empty;
        string novaSenhaConf = string.Empty;

        VerificaAcesso acesso = new VerificaAcesso();

        if (tblAlteraSenha.Visible)
        {
            trocaSenha = true;
            verificar = ValidaForm("A");
            if (!verificar)
            {
                txtSenha.Attributes.Add("value", ViewState["senha"].ToString()); // senha
                txtNovaSenha.Attributes.Add("value", ViewState["novaSenha"].ToString());
                txtNovaSenhaConf.Attributes.Add("value", ViewState["novaSenhaConf"].ToString());

                ExibirMensagem.Exibir(acesso.MensagemErro, this.Page);
                txtLogin.Focus();
            }
        }

        if (verificar)
        {
            if (ViewState["CadastrarADM"].ToString().Equals("S"))
            {
                if (ValidaForm("C"))
                {
                    GruposCTL gruposCTL = new GruposCTL();
                    gruposCTL.InicializarDados();

                    UsuariosCTL administrador = new UsuariosCTL();
                    Usuarios usuarioADM = new Usuarios();
                    usuarioADM.Nome = txtNome.Text;
                    usuarioADM.Email = txtEmail.Text;
                    usuarioADM.Login = txtLoginCad.Text;
                    usuarioADM.Senha = txtSenhaCad.Text;
                    usuarioADM.CodGrupo = 1;
                    usuarioADM.Status = true;
                    usuarioADM.TrocarSenha = false;

                    retorno = administrador.InserirUsuarios(usuarioADM);
                    if (retorno)
                    {
                        acesso.UsuarioLogado = txtLogin.Text;
                        acesso.GrupoUsuario = usuarioADM.CodGrupo;
                        acesso.UsuarioAtivo = true;
                    }
                }
                else
                {
                    // somente dessa forma será possível atribuir valores para os campos PassWord
                    // assim atribuimos via HTML os valores, pois o ASP.Net não permite atribuição direta
                    // do tipo txtSenhaCad.Text = ViewState["senha"].ToString()
                    txtSenhaCad.Attributes.Add("value", ViewState["senhaCad"].ToString());
                    txtConfSenha.Attributes.Add("value", ViewState["confSenha"].ToString());
                }
            }
            else
            {
                retorno = acesso.Verifica_Senha(txtLogin.Text, txtSenha.Text, ViewState["novaSenha"].ToString(), ViewState["novaSenhaConf"].ToString() , trocaSenha);
            }

            if (!acesso.UsuarioAtivo)
            {
                ExibirMensagem.Exibir(acesso.MensagemErro, this.Page);
                txtLogin.Focus();
            }
            else if (acesso.TrocarSenha) // && !tblAlteraSenha.Visible)
            {
                tblAlteraSenha.Visible = true;
                tblMensagemSenha.Visible = true;
                txtSenha.Attributes.Add("value", ViewState["senha"].ToString());
                txtNovaSenha.Focus();
            }
            else
            {
                if (retorno)
                {
                    UsuarioCorrente.Login = acesso.UsuarioLogado;
                    GrupodoUsuarioLogado.CodigodoGrupo = acesso.GrupoUsuario.ToString();

                    if (Session.Count > 0)
                    {
                        FormsAuthentication.SignOut();
                    }

                    if (FormsAuthentication.GetRedirectUrl("SEGURANCA", false) != "Default.aspx")
                    {
                        FormsAuthentication.RedirectFromLoginPage("SEGURANCA", false);
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else if (ViewState["CadastrarADM"].ToString().Equals("N"))
                {
                    txtSenha.Attributes.Add("value", ViewState["senha"].ToString());
                    txtSenhaCad.Attributes.Add("value", ViewState["senhaCad"].ToString());
                    txtConfSenha.Attributes.Add("value", ViewState["confSenha"].ToString());
                    txtNovaSenha.Attributes.Add("value", ViewState["novaSenha"].ToString());
                    txtNovaSenhaConf.Attributes.Add("value", ViewState["novaSenhaConf"].ToString());
                    ExibirMensagem.Exibir(acesso.MensagemErro, this.Page); //"Usuário ou senha inválida."
                    if (acesso.CampoFoco.Equals(EFocoCampo.login))
                        txtLogin.Focus();
                    else if (acesso.CampoFoco.Equals(EFocoCampo.senha))
                        txtSenha.Focus();
                }
            }
        }

    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        ExibirMensagem.FecharFormulario(this.Page);
    }

    public bool ValidaForm(string tipo)
    {
        bool v = true;
        if (tipo.Equals("C")) // cadastro do administrador do sistema
        {
            UsuariosCTL usuariosCTL = new UsuariosCTL();

            if (usuariosCTL.RegistroExiste(txtNome.Text, "I", "0", "Nome"))
            {
                ExibirMensagem.Exibir("Usuário já cadastrado.", this.Page);
                txtNome.Focus();
                v = false;
            }

            if (usuariosCTL.RegistroExiste(txtLogin.Text, "I", "0", "Login"))
            {
                ExibirMensagem.Exibir("Login já cadastrado.", this.Page);
                txtLoginCad.Focus();
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
            }

            if (v)
            {
                v = Validacao.ValidaTextBox(this.Page, txtLoginCad);
                if (!v)
                {
                    ExibirMensagem.Exibir("Favor informar o login do usuário.", this.Page);
                    txtLoginCad.Focus();
                }
            }

            if (v)
            {
                v = Validacao.ValidaTextBox(this.Page, txtSenhaCad);
                if (!v)
                {
                    ExibirMensagem.Exibir("Favor informar a senha do usuário.", this.Page);
                    txtSenhaCad.Focus();
                }
            }

            if (v)
            {
                v = (txtSenhaCad.Text.Equals(txtConfSenha.Text));
                if (!v)
                {
                    ExibirMensagem.Exibir("As senhas do usuário não conferem.", this.Page);
                    txtSenhaCad.Focus();
                }
            }

        }
        else if (tipo.Equals("A")) // Alteração de senha
        {
            if (v)
            {
                v = Validacao.ValidaTextBox(this.Page, txtLogin);
                if (!v)
                {
                    ExibirMensagem.Exibir("Favor informar o login do usuário.", this.Page);
                    txtLogin.Focus();
                }
            }

            if (v)
            {
                v = Validacao.ValidaTextBox(this.Page, txtSenha);
                if (!v)
                {
                    ExibirMensagem.Exibir("Favor informar a senha atual do usuário.", this.Page);
                    txtSenha.Focus();
                }
            }
            if (v)
            {
                v = Validacao.ValidaTextBox(this.Page, txtNovaSenha);
                if (!v)
                {
                    ExibirMensagem.Exibir("Favor informar a nova senha do usuário.", this.Page);
                    txtNovaSenha.Focus();
                }
            }

            if (v)
            {
                v = (txtNovaSenha.Text.Equals(txtNovaSenhaConf.Text));
                if (!v)
                {
                    ExibirMensagem.Exibir("A nova senha não confere.", this.Page);
                    txtNovaSenha.Focus();
                }
            }
        }

        return v;
    }

    protected void lbtAlterarSenha_Click(object sender, EventArgs e)
    {
        tblAlteraSenha.Visible = true;
        txtSenha.Attributes.Add("value", ViewState["senha"].ToString());

        if (txtLogin.Text.Trim().Equals(string.Empty))
            txtLogin.Focus();
        else if (txtLogin.Text.Trim().Equals(string.Empty))
            txtSenha.Focus();
        else if (!txtLogin.Text.Trim().Equals(string.Empty) && !txtSenha.Text.Trim().Equals(string.Empty))
            txtNovaSenha.Focus();

    }
    protected void lbtLembrarSenha_Click(object sender, EventArgs e)
    {
        txtEmailLembrar.Focus();   
        HabilitarLembrarSenha(true);
    }
    protected void btnCancelaLembrar_Click(object sender, ImageClickEventArgs e)
    {
        HabilitarLembrarSenha(false);
    }

    public void HabilitarLembrarSenha(bool status)
    {
        // logn
        tblLogin.Visible = !status;
        tblMensagemSenha.Visible = false;

        // cadastro
        tblCadastro.Visible = false;
        tblMensagemAcesso.Visible = false;

        // lembrar
        tblLembrarSenha.Visible = status;
        tblMensagemLembrar.Visible = status;
    }

    protected void btnConfirmaLembrar_Click(object sender, ImageClickEventArgs e)
    {
        string retornoEmail = Validacao.ValidaEmail(this.Page, txtEmailLembrar);
        bool v = retornoEmail.Equals(string.Empty) ? true : false;
        if (!v)
        {
            ExibirMensagem.Exibir(retornoEmail, this.Page);
            txtEmailLembrar.Focus();
        }
        else
        {
            UsuariosCTL usuariosCTL = new UsuariosCTL();
            Usuarios quemSolicitou = usuariosCTL.LembrarSenha(txtEmailLembrar.Text.Trim());

            if (quemSolicitou.CodUsuario.Equals(0))
            {
                ExibirMensagem.Exibir("E-Mail não encontrado.", this.Page);
            }
            else
            {
                SmtpClient smtpMail = new SmtpClient();
                smtpMail.Host = ConfigurationManager.AppSettings["smtpEmail"]; // "localhost" - servidor smtp 

                MailMessage email = new MailMessage();
                email.From = new MailAddress(ConfigurationManager.AppSettings["emailOrigem"]);
                email.To.Add(txtEmailLembrar.Text.Trim()); // E-Mail do usuário que o solicitou
                email.Subject = "Senha do Programa - SegurancaWeb";
                email.IsBodyHtml = true;

                StringBuilder corpoEmail = new StringBuilder();

                corpoEmail.Append("Olá " + quemSolicitou.Nome.Trim() + ",<br><br>");
                corpoEmail.Append("Sua senha é : " + quemSolicitou.Senha + "<br><br>");
                corpoEmail.Append("e deverá ser alterada no próximo login."+ "<br>");
                corpoEmail.Append("E-mail : " + quemSolicitou.Email + "<br>");
                corpoEmail.Append("Login : " + quemSolicitou.Login + "<br><br><br>");
                corpoEmail.Append("E-Mail enviado pelo programa SegurancaWeb.");

                email.Body = corpoEmail.ToString();
                email.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                email.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                try
                {
                    smtpMail.Send(email);
                    ExibirMensagem.Exibir("Senha enviada com sucesso.", this.Page);
                }
                catch(Exception ex)
                {
                    ExibirMensagem.Exibir("Ocorreu um erro ao enviar a senha para o e-mail solicitado.", this.Page);
                }
            }
        }
    }
}

