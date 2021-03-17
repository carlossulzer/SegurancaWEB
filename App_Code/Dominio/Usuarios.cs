using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Clientes
/// </summary>
public class Usuarios
{
	public Usuarios()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int codUsuario;
    private string nome;
    private string email;
    private string login;
    private string senha;
    private int codGrupo;
    private bool status;
    private bool trocarSenha;

    public Usuarios(int codUsuario, string nome, string email, string login, string senha, int codGrupo, bool status, bool trocarSenha)
    { 
        this.codUsuario = codUsuario;
        this.nome       = nome;
        this.email      = email;
        this.login      = login;
        this.senha      = senha;
        this.codGrupo   = codGrupo;
        this.status     = status;
        this.trocarSenha = trocarSenha;
    }

    public Usuarios(int codUsuario)
    {
        this.codUsuario = codUsuario;
    }

    public int CodUsuario
    {
        get { return codUsuario; }
        set { codUsuario = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
	
    public string Login
    {
        get { return login; }
        set { login = value; }
    }

    public string Senha
    {
        get { return senha; }
        set { senha = value; }
    }

    public int CodGrupo
    {
        get { return codGrupo; }
        set { codGrupo = value; }
    }

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }

    public bool TrocarSenha
    {
        get { return trocarSenha; }
        set { trocarSenha = value; }
    }
}
