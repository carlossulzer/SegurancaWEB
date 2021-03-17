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
public class GruposCTL
{
    public GruposCTL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet ObterGruposPorCodigo(int codigo)
    {
        GruposDAO gruposDAO = new GruposDAO();
        return gruposDAO.ObterGruposPorCodigo(codigo);
    }

    public DataSet ObterGruposFiltradosPorNome(string nome)
    {
        GruposDAO gruposDAO = new GruposDAO();
        return gruposDAO.ObterGruposFiltradosPorNome(Utilitarios.RetiraAcentos(nome.ToUpper()));
    }

    public DataSet ObterListaGrupos()
    {
        GruposDAO gruposDAO = new GruposDAO();
        return gruposDAO.ObterListaGrupos();
    }

    public bool InserirGrupo(Grupos grupos)
    {
        GruposDAO gruposDAO = new GruposDAO();
        return gruposDAO.InserirGrupo(grupos);
    }

    public void AlterarGrupo(Grupos grupos)
    {
        GruposDAO gruposDAO = new GruposDAO();
        gruposDAO.AlterarGrupo(grupos);
    }

    public void ExcluirGrupos(Grupos grupos)
    {
        GruposDAO gruposDAO = new GruposDAO();
        gruposDAO.ExcluirGrupo(grupos);
    }

    public void InicializarDados()
    {
        GruposDAO grupoDAO = new GruposDAO();
        grupoDAO.InicializarDados();
    
    }

}
