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
public class MenusGruposDAO
{
	public MenusGruposDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool InserirMenuGrupo(MenusGrupos menusGrupos)
    {
        try
        {
            StringBuilder sqlInsert = new StringBuilder();

            sqlInsert.Append("INSERT INTO MENUGRUPO (CodGrupo, CodMenu)");
            sqlInsert.Append(" VALUES(");
            sqlInsert.Append(FormatarString.Formatar(menusGrupos.CodGrupo)+", ");
            sqlInsert.Append(FormatarString.Formatar(menusGrupos.CodMenu));
            sqlInsert.Append(" )");

            return (AcessoaBancoDados.ManterDados(sqlInsert.ToString()) > 0);

        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados"+ex.Message.ToString());
        }
    }

    public void ExcluirMenuGrupo(int codGrupo)
    {
        try
        {
            StringBuilder sqlExcluir = new StringBuilder();
            sqlExcluir.Append("Delete from MenuGrupo where CodGrupo = " + codGrupo.ToString());

            AcessoaBancoDados.ManterDados(sqlExcluir.ToString());
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso aos dados" + ex.Message.ToString());
        }
    }
}
