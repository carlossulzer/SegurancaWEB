using System;
using System.Configuration;
using System.Text;
using System.Data;

/// <summary>
/// Summary description for Login.
/// </summary>
public class VerificaAcesso
{
    private string usuarioLogado;
	private int grupoUsuario;
    private string mensagemErro;
    private bool trocarSenha;
    private EFocoCampo campoFoco;
    private bool usuarioAtivo;
   
 	public VerificaAcesso()
	{
	}

	public bool Verifica_Senha(string login, string senha, string novaSenha, string novaSenhaConf, bool trocaSenha)
	{
        bool usuarioOK = false;
        AcessoaBancoDados dados = new AcessoaBancoDados();
        StringBuilder sql = new StringBuilder();

        sql.Append("select senha, codgrupo, status, trocarsenha from usuarios where login = " + FormatarString.Formatar(login));


        DataSet dsUsuario = AcessoaBancoDados.BuscaDados(sql.ToString());

        if (dsUsuario.Tables[0].Rows.Count > 0)
        {

            string senhaBanco= dsUsuario.Tables[0].Rows[0]["senha"].ToString();
            GrupoUsuario = Convert.ToInt32(dsUsuario.Tables[0].Rows[0]["codgrupo"].ToString());
            UsuarioAtivo = Convert.ToBoolean(dsUsuario.Tables[0].Rows[0]["status"].ToString());
            TrocarSenha = Convert.ToBoolean(dsUsuario.Tables[0].Rows[0]["trocarsenha"].ToString());

            if (!UsuarioAtivo)
            {
                MensagemErro = "Login desativado.";
                campoFoco = EFocoCampo.login;
                usuarioOK = false;
            }

            else if (Criptografia.encriptar(senha).Equals(senhaBanco))
            {
                UsuarioLogado = login;
                usuarioOK = true;
            }
            else
            {
                MensagemErro = "Senha inválida.";
                campoFoco = EFocoCampo.senha;
                usuarioOK = false;
            }
        }
        else
        {
            MensagemErro = "Login inválido.";
            campoFoco = EFocoCampo.login;
            usuarioOK = false;
        }

        if (usuarioOK && trocaSenha)
        { 
            StringBuilder sqlTrocaSenha = new StringBuilder();
            sqlTrocaSenha.Append("Update usuarios set senha ="+FormatarString.Formatar(Criptografia.encriptar(novaSenha)));
            sqlTrocaSenha.Append(" , trocarsenha = 0"); 
            sqlTrocaSenha.Append(" Where login = "+FormatarString.Formatar(login));
            try
            {
                AcessoaBancoDados.ManterDados(sqlTrocaSenha.ToString());
                TrocarSenha = false;
                usuarioOK = true;
            }
            catch
            {
                mensagemErro = "Erro ao tentar alterar a senha do usuário.";
                usuarioOK = false;
            }
        }
        return usuarioOK;
	}

	public string UsuarioLogado
	{
		get { return usuarioLogado; }
		set { usuarioLogado = value; }
	}

	public int GrupoUsuario
	{
		get { return grupoUsuario; }
		set { grupoUsuario = value; }
	}

    public string MensagemErro
    {
        get { return mensagemErro; }
        set { mensagemErro = value; }
    }

    public bool TrocarSenha
    {
        get { return trocarSenha; }
        set { trocarSenha = value; }
    }

    public bool UsuarioAtivo
    {
        get { return usuarioAtivo; }
        set { usuarioAtivo = value; }
    }
	
    public EFocoCampo CampoFoco
    {
        get { return campoFoco; }
        set { campoFoco = value; }
    }
}




