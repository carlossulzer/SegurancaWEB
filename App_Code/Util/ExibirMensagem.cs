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

/// <summary>
/// Summary description for ExibirMensagemErro
/// </summary>
public class ExibirMensagem
{
	public ExibirMensagem()
	{
	}

    public static void Exibir(string mensagem, System.Web.UI.Page objPagina)
    {
        objPagina.ClientScript.RegisterStartupScript(objPagina.GetType(), "", @"<script>alert('" + mensagem + "');</script>");
    }

    public static void FecharFormulario(System.Web.UI.Page objPagina)
    {
        objPagina.ClientScript.RegisterStartupScript(objPagina.GetType(), "", @"<script>window.opener = ''; window.close()</script>");
    }


  }
