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
/// Summary description for CidadesControl
/// </summary>
public class UsuariosCTL
{
    public UsuariosCTL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet ObterUsuariosPorCodigo(int codigo)
    {
        UsuariosDAO usuariosDAO = new UsuariosDAO();
        return usuariosDAO.ObterUsuarioPorCodigo(codigo);
    }

    public DataSet ObterUsuariosFiltradosPorNome(string nome)
    {
        UsuariosDAO usuariosDAO = new UsuariosDAO();
        return usuariosDAO.ObterUsuariosFiltradosPorNome(Utilitarios.RetiraAcentos(nome.ToUpper()));
    }

    public DataSet ObterListaUsuarios()
    {
        UsuariosDAO usuariosDAO = new UsuariosDAO();
        return usuariosDAO.ObterListaUsuarios();
    }

    public bool InserirUsuarios(Usuarios usuarios)
    {
        UsuariosDAO usuariosDAO = new UsuariosDAO();
        return usuariosDAO.InserirUsuario(usuarios);
    }

    public void AlterarUsuarios(Usuarios usuarios)
    {
        UsuariosDAO usuariosDAO = new UsuariosDAO();
        usuariosDAO.AlterarUsuario(usuarios);
    }

    public void ExcluirUsuarios(Usuarios usuarios)
    {
        UsuariosDAO usuariosDAO = new UsuariosDAO();
        usuariosDAO.ExcluirUsuario(usuarios);
    }

    public bool RegistroExiste(string descricao, string operacao, string codUsuario, string campo)
    {
        return UsuariosDAO.RegistroExiste(descricao, operacao, codUsuario, campo);
    }


    public Usuarios LembrarSenha(string email)
    {
        UsuariosDAO usuariosDAO = new UsuariosDAO();
        return usuariosDAO.LembrarSenha(email);
    }


}
