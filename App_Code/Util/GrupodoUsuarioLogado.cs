using System.Web;

/// <summary>
/// Summary description for GrupodoUsuarioLogado.
/// </summary>
public class GrupodoUsuarioLogado
{
	public static string CodigodoGrupo
	{
		get
		{
			return HttpContext.Current.Session["grupodoUsuarioLogado"].ToString();
		}
		set
		{
            HttpContext.Current.Session["grupodoUsuarioLogado"] = value;
		}
		}
}

