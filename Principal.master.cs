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

public delegate void EventoBotoes(object sender, EventArgs e);

public partial class Principal : System.Web.UI.MasterPage
{
    private string titulo = string.Empty;
    public event EventoBotoes ConfirmarEvento;
    public event EventoBotoes CancelarEvento;
    EventoBotoes ConfirmarFuncao;
    EventoBotoes CancelarFuncao;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblTitulo.Text = titulo;
        ConfirmarFuncao = ConfirmarEvento;
        CancelarFuncao = CancelarEvento;
        lblUsuarioCorrente.Text = UsuarioCorrente.Login;
    }

    public string Titulo
    {
        set
        {
            titulo = value;
        }
    }

    protected void ibntConfirmar_Click(object sender, ImageClickEventArgs e)
    {
        if (ConfirmarFuncao != null)
            ConfirmarFuncao(sender, e);
    }
    protected void ibtnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        if (CancelarFuncao != null)
            CancelarFuncao(sender, e);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
}
