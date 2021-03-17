using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MenuEstatico : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GrupodoUsuarioLogado.CodigodoGrupo.Equals("1")) // administrador
        {
            MenuCadastro.Visible = true;
            MenuRelatorios.Visible = true;
            MenuAdministrador.Visible = true;
            MenuSair.Visible = true;
        }
        else
        {
            MenuCadastro.Visible = true;
            MenuRelatorios.Visible = true;
            MenuAdministrador.Visible = false;
            MenuSair.Visible = false;
        }
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
