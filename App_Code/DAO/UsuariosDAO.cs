using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UsuariosDAO
/// </summary>
public class UsuariosDAO
{
	public UsuariosDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool InserirUsuario(Usuarios usuarios)
    {
        try
        {
            StringBuilder sqlInsert = new StringBuilder();

            sqlInsert.Append("INSERT INTO USUARIOS (nome, email, login, senha, codgrupo, status, trocarsenha)");
            sqlInsert.Append(" VALUES(");
            sqlInsert.Append(FormatarString.Formatar(usuarios.Nome)+", ");
            sqlInsert.Append(FormatarString.Formatar(usuarios.Email) + ", ");
            sqlInsert.Append(FormatarString.Formatar( usuarios.Login) + ", ");
            sqlInsert.Append(FormatarString.Formatar( Criptografia.encriptar(usuarios.Senha)) + ", ");
            sqlInsert.Append(FormatarString.Formatar(usuarios.CodGrupo) + ", ");
            sqlInsert.Append(FormatarString.Formatar(usuarios.Status) + ", ");
            sqlInsert.Append(FormatarString.Formatar(usuarios.TrocarSenha));
            sqlInsert.Append(" )");

            return (AcessoaBancoDados.ManterDados(sqlInsert.ToString()) > 0);

        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados"+ex.Message.ToString());
        }
    }

    public void ExcluirUsuario(Usuarios usuarios)
    {
        try
        {
            StringBuilder sqlExcluir = new StringBuilder();
            sqlExcluir.Append("Delete from usuarios where CodUsuario = " + usuarios.CodUsuario);

            AcessoaBancoDados.ManterDados(sqlExcluir.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
    }


    public void AlterarUsuario(Usuarios usuarios)
    {
        try
        {
            StringBuilder sqlAlterar = new StringBuilder();
            sqlAlterar.Append(" UPDATE usuarios SET ");
            sqlAlterar.Append("   nome = " + FormatarString.Formatar(usuarios.Nome) + ", ");
            sqlAlterar.Append("   email = " + FormatarString.Formatar(usuarios.Email) + ", ");
            sqlAlterar.Append("   login = " + FormatarString.Formatar(usuarios.Login) + ", ");

            //sqlAlterar.Append("   senha = " + FormatarString.Formatar(Criptografia.encriptar(usuarios.Senha)) + ", ");
            sqlAlterar.Append("   codgrupo = " + FormatarString.Formatar(usuarios.CodGrupo) + ", ");
            sqlAlterar.Append("   status = " + FormatarString.Formatar(usuarios.Status) + ", ");
            sqlAlterar.Append("   trocarsenha = " + FormatarString.Formatar(usuarios.TrocarSenha));
            sqlAlterar.Append(" where CodUsuario = " + usuarios.CodUsuario.ToString());
            AcessoaBancoDados.ManterDados(sqlAlterar.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
    }


    public DataSet ObterUsuarioPorCodigo(int codigo)
    {
        DataSet dsUsuarios = new DataSet();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT usuarios.CodUsuario, usuarios.Nome, usuarios.Email, usuarios.Login, ");
            sql.Append(" usuarios.Senha, usuarios.CodGrupo, usuarios.status, usuarios.trocarsenha, grupo.descricao ");
            sql.Append(" FROM usuarios, grupo ");
            sql.Append(" WHERE usuarios.CodGrupo = grupo.CodGrupo and ");
            sql.Append(" usuarios.CodUsuario = " + codigo.ToString());
            dsUsuarios = AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
        return dsUsuarios;
    }

    public DataSet ObterUsuariosFiltradosPorNome(string nome)
    {
        DataSet dsUsuarios = new DataSet();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT usuarios.CodUsuario, usuarios.Nome, usuarios.Email, usuarios.Login, ");
            sql.Append(" usuarios.Senha, usuarios.CodGrupo, usuarios.status, usuarios.trocarsenha, grupo.descricao ");
            sql.Append(" FROM usuarios, grupo ");
            sql.Append(" WHERE usuarios.CodGrupo = grupo.CodGrupo ");

            if (!nome.Equals(string.Empty))
                sql.Append("and Nome LIKE '%" + nome + "%'");

            sql.Append(" ORDER BY usuarios.Nome");

            dsUsuarios = AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados"+ex.Message.ToString());
        }
        return dsUsuarios;
    }

    public DataSet ObterListaUsuarios()
    {
        DataSet dsUsuarios = new DataSet();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT usuarios.CodUsuario, usuarios.Nome, , usuarios.Email, usuarios.Login, ");
            sql.Append(" usuarios.Senha, usuarios.CodGrupo, usuarios.status, usuarios.trocarsenha, grupo.descricao ");
            sql.Append(" FROM usuarios, grupo ");
            sql.Append(" WHERE usuarios.CodGrupo = grupo.CodGrupo ");
            sql.Append(" ORDER BY Nome");

            dsUsuarios = AcessoaBancoDados.BuscaDados(sql.ToString());

        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
        return dsUsuarios;
    }


    public static bool RegistroExiste(string descricao, string operacao, string codUsuario, string campo)
    {
        bool existente = true;
        string codigo = "0";

        AcessoaBancoDados objbanco = new AcessoaBancoDados();
        StringBuilder sqlExiste = new StringBuilder();
        sqlExiste.Append(" SELECT codUsuario FROM usuarios " );
        sqlExiste.Append(" WHERE "+campo+" = " + FormatarString.Plic(descricao.ToString().Trim()));
        codigo = objbanco.ObterValorInteiro(sqlExiste.ToString()).ToString();

        if (operacao.Equals("A"))
        {
            if (codUsuario.Equals(codigo) || codigo.Equals("0"))
            {
                existente = false;
            }
            else
            {
                existente = true;
            }
        }
        else if (operacao.Equals("I"))
        {
            if (!codigo.Equals("0"))
                existente = true;
            else
                existente = false;
        }

        return existente;
    }

    public Usuarios LembrarSenha(string email)
    {
        DataSet dsUsuarios = new DataSet();
        Usuarios alteraSenha = new Usuarios();

        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT codusuario, Nome, Email, Login, status, trocarsenha ");
            sql.Append(" FROM usuarios ");
            sql.Append(" WHERE email = "+FormatarString.Formatar(email));


            dsUsuarios = AcessoaBancoDados.BuscaDados(sql.ToString());

            if (dsUsuarios.Tables[0].Rows.Count > 0)
            {
                string novaSenha = DateTime.Now.Year.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Millisecond.ToString("00");
               
                alteraSenha.CodUsuario = Convert.ToInt32(dsUsuarios.Tables[0].Rows[0]["codUsuario"].ToString());
                alteraSenha.Nome = dsUsuarios.Tables[0].Rows[0]["nome"].ToString();
                alteraSenha.Login = dsUsuarios.Tables[0].Rows[0]["login"].ToString();
                alteraSenha.Email = dsUsuarios.Tables[0].Rows[0]["email"].ToString();
                alteraSenha.Senha = novaSenha;
                alteraSenha.Status = Convert.ToBoolean(dsUsuarios.Tables[0].Rows[0]["status"].ToString());
                alteraSenha.TrocarSenha = true;

                StringBuilder sqlTrocaSenha = new StringBuilder();
                sqlTrocaSenha.Append("Update usuarios set senha =" + FormatarString.Formatar(Criptografia.encriptar(novaSenha)));
                sqlTrocaSenha.Append(" , trocarsenha = 1");
                sqlTrocaSenha.Append(" Where email = " + FormatarString.Formatar(email));

                try
                {
                    AcessoaBancoDados.ManterDados(sqlTrocaSenha.ToString());
                }
                catch
                {
                   throw new ApplicationException("Erro ao tentar alterar a senha do usuário.");
                }
            }
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }

        return alteraSenha;
    }



}
