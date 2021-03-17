using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MenuEstatico2 : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GrupodoUsuarioLogado.CodigodoGrupo.Equals("1")) // administrador
        {
            // Cadastros
            MenuUsuario.Items[0].Enabled = true;
            MenuUsuario.Items[0].ChildItems[0].Enabled = true;
            MenuUsuario.Items[0].ChildItems[1].Enabled = true;
            MenuUsuario.Items[0].ChildItems[2].Enabled = true;
            MenuUsuario.Items[0].ChildItems[3].Enabled = true;

            // Relatórios
            MenuUsuario.Items[1].Enabled = true;
            MenuUsuario.Items[1].ChildItems[0].Enabled = true;
            MenuUsuario.Items[1].ChildItems[1].Enabled = true;

            // Administrador
            MenuUsuario.Items[2].Enabled = true;
            MenuUsuario.Items[2].ChildItems[0].Enabled = true;
            MenuUsuario.Items[2].ChildItems[1].Enabled = true;

            // Sair
            MenuUsuario.Items[3].Enabled = true;
           
        }
        else
        {
            // Cadastros
            MenuUsuario.Items[0].Enabled = true;
            MenuUsuario.Items[0].ChildItems[0].Enabled = true;
            MenuUsuario.Items[0].ChildItems[1].Enabled = true;
            MenuUsuario.Items[0].ChildItems[2].Enabled = true;
            MenuUsuario.Items[0].ChildItems[3].Enabled = true;

            // Relatórios
            MenuUsuario.Items[1].Enabled = true;
            MenuUsuario.Items[1].ChildItems[0].Enabled = true;
            MenuUsuario.Items[1].ChildItems[1].Enabled = true;

            // Administrador
            MenuUsuario.Items[2].Enabled = false;
            MenuUsuario.Items[2].ChildItems[0].Enabled = false;
            MenuUsuario.Items[2].ChildItems[1].Enabled = false;

            // Sair
            MenuUsuario.Items[3].Enabled = true;
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
