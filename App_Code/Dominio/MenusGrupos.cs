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
public class MenusGrupos
{
	public MenusGrupos()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int codGrupo;
    private int codMenu;


    public MenusGrupos(int codGrupo, int codMenu)
    { 
        this.codGrupo = codGrupo;
        this.codMenu = codMenu;
    }

    public int CodGrupo
    {
        get { return codGrupo; }
        set { codGrupo = value; }
    }

    public int CodMenu
    {
        get { return codMenu; }
        set { codMenu = value; }
    }

 

}
