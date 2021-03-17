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
public class MenusGruposCTL
{
    public MenusGruposCTL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void InserirMenuGrupo(MenusGrupos menusGrupos)
    {
        MenusGruposDAO menusGruposDAO = new MenusGruposDAO();
        menusGruposDAO.InserirMenuGrupo(menusGrupos);
    }

    public void ExcluirMenuGrupo(int codGrupo)
    {
        MenusGruposDAO menusGruposDAO = new MenusGruposDAO();
        menusGruposDAO.ExcluirMenuGrupo(codGrupo);
    }

}
