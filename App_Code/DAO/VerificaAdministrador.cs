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
/// Summary description for VerificaAdministrador
/// </summary>
public class VerificaAdministrador
{
	public VerificaAdministrador()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static bool Verificar()
    {
        AcessoaBancoDados dados = new AcessoaBancoDados();
        string sql = "select count(CodUsuario) from usuarios where CodGrupo = 1 ";
        return (dados.ObterValorInteiro(sql) < 1);
    }




}
