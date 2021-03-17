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
/// Summary description for MenuCTL
/// </summary>
public class MenuCTL
{
	public MenuCTL()
	{
		//
		// TODO: Add constructor logic here
		//

	}

    public void CarregaMenu(ref Menu objetoView)
    {
        MenuDAO menuDAO = new MenuDAO();
        menuDAO.CarregarMenu(ref objetoView);
    }

    public void Excluir()
    {
        MenuDAO menuDAO = new MenuDAO();
        menuDAO.Excluir();
    }

}
