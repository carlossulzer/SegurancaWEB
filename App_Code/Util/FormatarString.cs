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
/// Summary description for FormatarString
/// </summary>
public class FormatarString
{
	public FormatarString()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string Plic(string argumento)
    {
        return "'" + argumento.Replace("'", "''") + "'";
    }

    public static string Formatar(object argumento)
    {
        string tipo = argumento.GetType().ToString();
        string itemFormat = string.Empty;

        switch (tipo)
        {
            case "System.String":
                {
                    string var = (string)argumento;
                    itemFormat = "'" + var.Replace("'", "''") + "'";
                    return itemFormat.Trim().ToUpper();
                }
            case "System.Boolean":
                {
                    if (bool.Parse(argumento.ToString()))
                        itemFormat = "1";
                    else
                        itemFormat = "0";

                    return itemFormat;
                }
            case "System.DateTime":
                {
                    DateTime data = (DateTime)argumento;

                    //itemFormat = "Convert(DATETIME,'" + data.ToString("yyyy-MM-dd hh:mm:ss") + "',120)";
                    itemFormat = "Convert(DATETIME,'" + data.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
                    return itemFormat;
                }
            case "System.Text.StringBuilder":
                {
                    itemFormat = "'" + argumento.ToString().Replace("'", "''") + "'";
                    return itemFormat;
                }
            case "System.Decimal":
                {
                    string var = Convert.ToString(argumento);
                    itemFormat = var.Replace(",", ".");
                    return itemFormat;
                }
            default:
                {
                    itemFormat = argumento.ToString();
                    return itemFormat;
                }

        }
    }

}
