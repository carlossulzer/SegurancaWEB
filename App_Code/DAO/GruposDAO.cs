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
/// Summary description for GruposDAO
/// </summary>
public class GruposDAO
{
	public GruposDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool InserirGrupo(Grupos grupos)
    {
        try
        {
            StringBuilder sqlInsert = new StringBuilder();

            sqlInsert.Append("INSERT INTO GRUPO (descricao)");
            sqlInsert.Append(" VALUES(");
            sqlInsert.Append(FormatarString.Formatar(grupos.Descricao));
            sqlInsert.Append(" )");

            return (AcessoaBancoDados.ManterDados(sqlInsert.ToString()) > 0);

        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados"+ex.Message.ToString());
        }
    }

    public void ExcluirGrupo(Grupos grupos)
    {
        try
        {
            StringBuilder sqlExcluir = new StringBuilder();
            sqlExcluir.Append("Delete from grupo where CodGrupo = " + grupos.CodGrupo);

            AcessoaBancoDados.ManterDados(sqlExcluir.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
    }


    public void AlterarGrupo(Grupos grupos)
    {
        try
        {
            StringBuilder sqlAlterar = new StringBuilder();
            sqlAlterar.Append("UPDATE grupo SET ");
            sqlAlterar.Append("descricao = " + FormatarString.Formatar(grupos.Descricao) );
            sqlAlterar.Append(" where CodGrupo = " + grupos.CodGrupo.ToString());
            AcessoaBancoDados.ManterDados(sqlAlterar.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
    }


    public DataSet ObterGruposPorCodigo(int codigo)
    {
        DataSet dsGrupos = new DataSet();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT CodGrupo, descricao ");
            sql.Append(" FROM grupo ");
            sql.Append(" WHERE CodGrupo = " + codigo.ToString());

            dsGrupos = AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
        return dsGrupos;
    }

    public DataSet ObterGruposFiltradosPorNome(string nome)
    {
        DataSet dsGrupos = new DataSet();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CodGrupo, descricao ");
            sql.Append("FROM grupo ");
            if (!nome.Equals(string.Empty))
                sql.Append("WHERE descricao LIKE '%" + nome + "%'");

            sql.Append("ORDER BY descricao");

            dsGrupos = AcessoaBancoDados.BuscaDados(sql.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados"+ex.Message.ToString());
        }
        return dsGrupos;
    }

    public DataSet ObterListaGrupos()
    {
        DataSet dsGrupos = new DataSet();
        try
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT CodGrupo, descricao ");
            sql.Append(" FROM grupo ");
            sql.Append(" ORDER BY descricao");

            dsGrupos = AcessoaBancoDados.BuscaDados(sql.ToString());

        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
        return dsGrupos;
    }


    public static bool RegistroExiste(string descricao, string operacao, string codGrupo)
    {
        bool existente = true;
        string codigo = "0";

        AcessoaBancoDados objbanco = new AcessoaBancoDados();
        StringBuilder sqlExiste = new StringBuilder();
        sqlExiste.Append("SELECT codGrupo FROM grupo " );
        sqlExiste.Append(" WHERE descricao = " + FormatarString.Plic(descricao.ToString().Trim()));
        codigo = objbanco.ObterValorInteiro(sqlExiste.ToString()).ToString();

        if (operacao.Equals("A"))
        {
            if (codGrupo.Equals(codigo) || codigo.Equals("0"))
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

    public void InicializarDados()
    { 
        // aqui iremos executar 3 comandos SQL, para isso colocamos o ";" no final de cada instrução.
        StringBuilder sqlExcluir = new StringBuilder();
        sqlExcluir.Append("Delete from MenuGrupo;" );            // excluir todas as permissões dos grupos / menus
        sqlExcluir.Append("Delete from Grupo;");                 // excluir todos os grupos cadastrados
        sqlExcluir.Append("DBCC CHECKIDENT (grupo, RESEED, 0)"); // zera o campo auto-incremental da tabela de grupo

        AcessoaBancoDados.ManterDados(sqlExcluir.ToString()); 

        // adiciona o grupo administrador
        this.InserirGrupo(new Grupos(0, "ADMINISTRADOR"));

    }

}
