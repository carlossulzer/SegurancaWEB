using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for AcessoaBancoDados
/// </summary>
/// 
public class AcessoaBancoDados : System.Web.UI.Page
{
    private static SqlConnection conn;
    public AcessoaBancoDados()
    {
    }

    public static void AbreConexao()
    {
        try
        {
            if (conn == null)
            {
                string conexao = ConfigurationManager.ConnectionStrings["Seguranca"].ConnectionString;
                conn = new SqlConnection(conexao);
                conn.Open();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Não foi possível fazer Conexão com Bando de Dados \n (" + ex.Message.ToString()+")");
        }
    }

    public static void FechaConexao()
    {
        conn.Close();
    }


    public static SqlConnection RecuperaConexao()
    {
        return conn;
    }

    public static int ManterDados(string comandoSql)
    {
        AbreConexao();

        SqlCommand cmd = new SqlCommand(comandoSql, conn);
        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Não foi possível executar esta ação." + ex.Message.ToString());
        }
    }

    public static DataSet BuscaDados(string comandoSql)
    {
        AbreConexao();
        DataSet ds = new DataSet();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(comandoSql, conn);
            da.Fill(ds);
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso ao Banco de Dados" + ex.Message.ToString());
        }
        return ds;
    }



    public static SqlDataReader BuscaDadosReader(string comandoSql)
    {
        AbreConexao();
        SqlCommand cmd = new SqlCommand(comandoSql, conn);

        SqlDataReader dr;
        try
        {
            dr = (SqlDataReader)cmd.ExecuteReader();
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso ao Banco de Dados" + ex.Message.ToString());
        }
        return dr;
    }

    public static DateTime GetDate(string sql)
    {
        DataSet ds;
        DateTime datetime = new DateTime();
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            ds = new DataSet();
            adapter.Fill(ds);
            datetime = (System.DateTime)ds.Tables[0].Rows[0].ItemArray.GetValue(0);
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Erro de acesso ao Banco de Dados - "+ex.Message.ToString());
        }
        return datetime;

    }


    public int ObterValorInteiro(string comandoSql)
    {
        return Convert.ToInt32("0" + ObterValor(comandoSql));
    }


    public object ObterValor(string comandoSql)
    {
        AbreConexao();

        SqlCommand cmd = new SqlCommand(comandoSql, conn);
        try
        {
            object retorno = cmd.ExecuteScalar();
            if (retorno == null)
                retorno = string.Empty;

            return retorno;
        }
        catch (SqlException ex)
        {
            throw new ApplicationException("Não foi possível executar esta ação." + ex.Message.ToString());
        }
    } 
}
