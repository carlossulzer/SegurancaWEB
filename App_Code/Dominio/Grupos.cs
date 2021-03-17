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
public class Grupos
{
	public Grupos()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int codGrupo;
    private string descricao;


    public Grupos(int codGrupo, string descricao)
    { 
        this.codGrupo = codGrupo;
        this.descricao = descricao;
    }

    public Grupos(int codGrupo)
    {
        this.codGrupo = codGrupo;
    }

    public int CodGrupo
    {
        get { return codGrupo; }
        set { codGrupo = value; }
    }

    public string Descricao
    {
        get { return descricao; }
        set { descricao = value; }
    }

 

}
