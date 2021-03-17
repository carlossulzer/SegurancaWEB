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
/// Summary description for Global
/// </summary>
public class Utilitarios
{
	public Utilitarios()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string RetiraAcentos(string strTexto)
    {
        if (strTexto == null)
            strTexto = string.Empty;

        if (!strTexto.Equals(string.Empty))
        {
            string strComAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string strSemAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
            for (int i = 0; i < strComAcentos.Length; i++)
            {
                strTexto = strTexto.Replace(strComAcentos[i].ToString(), strSemAcentos[i].ToString()).ToUpper();
            }
        }
        return strTexto;
    }


    public static DateTime ObterDataBanco()
    {
        string sql = "select getdate()";
        return AcessoaBancoDados.GetDate(sql);
    }

    public static void Set_Focus(System.Web.UI.Page page, Control controle)
    {
        //ScriptManager focus = ScriptManager.GetCurrent(page);
        //focus.SetFocus(controle);
    }

    public static void validaForm(Control controle, string valor, System.Web.UI.Page objPagina) //"verificaVazio(txtUsuario,'"+txtUsuario.Text+"');"
    {
        //ScriptManager.RegisterClientScriptBlock(objPagina, objPagina.GetType(), "@MSG", "<script>return valida(" + objPagina.ClientID + ");</script>", false);

    }



}
