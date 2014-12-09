using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for man_AfiliadosAsignados
/// </summary>
public class man_AfiliadosAsignados
{
    clsDb db = new clsDb();
    public man_AfiliadosAsignados() { }

    #region empleador
    public AfiliadosAsignados[] getAfiliadosEmpleador(String nit,String nom1,String nom2,String apll1,String apll2)
	{
        string SQL = "declare @ID varchar(100) ,@nom1 varchar(100), @nom2 varchar(100), @apll1 varchar(100),@apll2 varchar(100) " +
                      "  SET @ID	= " +   (nit.Length != 0 ? "'"+nit+"'" : "NULL")  +"  " +
                      "  SET @nom1	= " + (nom1.Length > 0 ? "'" + nom1 + "'" : "NULL") + "  " +
                      "  SET @nom2	= " + (nom2.Length > 0 ? "'" + nom2 + "'" : "NULL") + " " +
                      "  SET @apll1	= " + (apll1.Length > 0 ? "'" + apll1 + "'" : "NULL") + "  " +
                      "  SET @apll2  = " + (apll2.Length > 0 ? "'" + apll2 + "'" : "NULL") + " " +
                      "  SELECT a.[AtdAfiTdi],a.[AtdAfiIde],a.[AtdCotTdi],a.[AtdCotIde], " +
                      "  a.[AtdApePri],a.[AtdApeSeg],a.[AtdNomPri],a.[AtdNomSeg],a.[EpsAsig],a.[RegCod],  e.EpsNom  " +
                      "  FROM [dbo].[AFILIADOS ASIGNADOS] a  " +
                      "  inner join EPS e on e.[EpsCod] = a.EpsAsig " +
                      "  where a.[AtdAfiIde]		= ISNULL(@ID,a.[AtdAfiIde]) " +
                      "  and upper(a.[AtdApePri])	like ISNULL(upper(@nom1),a.[AtdApePri]) " +
                      "  and upper(a.[AtdApePri])	like ISNULL(upper(@nom2),a.[AtdApePri]) " +
                      "  and upper(a.[AtdNomPri])	like ISNULL(upper(@apll1),a.[AtdNomPri]) " +
                      "  and upper(a.[AtdNomSeg])	like ISNULL(upper(@apll2),a.[AtdNomSeg]) ";

        List<AfiliadosAsignados> lAsignado = new List<AfiliadosAsignados>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                AfiliadosAsignados Afiliados = new AfiliadosAsignados();
                Afiliados.AtdAfiTdi = reader["AtdAfiTdi"].ToString();
                Afiliados.AtdAfiIde = reader["AtdAfiIde"].ToString();
                Afiliados.AtdCotIde = reader["AtdCotIde"].ToString();
                Afiliados.AtdApePri = reader["AtdApePri"].ToString();
                Afiliados.AtdApeSeg = reader["AtdApeSeg"].ToString();
                Afiliados.AtdNomPri = reader["AtdNomPri"].ToString();
                Afiliados.AtdNomSeg = reader["AtdNomSeg"].ToString();
                Afiliados.EpsAsig = reader["EpsAsig"].ToString();
                Afiliados.RegCod = reader["RegCod"].ToString();
                Afiliados.EpsNom = reader["EpsNom"].ToString();
                lAsignado.Add(Afiliados);
            }
            con.Close();
            return lAsignado.ToArray();
            
        }
        catch (Exception ex) {
            return lAsignado.ToArray();
        }
        
	}

    public String AfiliadosEmpleador(String nit, String nom1, String nom2, String apll1, String apll2)
    {
        AfiliadosAsignados[] afiliado = getAfiliadosEmpleador(nit,nom1,nom2,apll1,apll2);
        String listTable = "";
        if (afiliado.Length > 0)
        {
            
            for (int i = 0; i < afiliado.Length; i++)
            {
                listTable += "<tr >";
                listTable += "<td>" + afiliado[i].AtdAfiTdi + "</td>";
                listTable += "<td>" + afiliado[i].AtdAfiIde + "</td>";
                listTable += "<td>" + afiliado[i].AtdApePri + " " + afiliado[i].AtdApeSeg + " " + afiliado[i].AtdNomPri + " " + afiliado[i].AtdNomSeg + "</td>";
                listTable += "<td>" + afiliado[i].EpsNom + "</td>";
                listTable += "</tr>";
            }
            
            return listTable;
        }
        else {
            return "<p><strong> No se encontraron datos, Revise la información Ingresada</strong></p>";
        }

    }

    public void AfiliacionEmpleadorGrid(String nit, GridView grid, String nom1, String nom2, String apll1, String apll2)
    {
        try
        {
            SqlConnection cone = db.conexion();
            cone.Open();

            string SQL = "declare @ID varchar(100) ,@nom1 varchar(100), @nom2 varchar(100), @apll1 varchar(100),@apll2 varchar(100) " +
                      "  SET @ID	= " + (nit.Length != 0 ? "'" + nit + "'" : "NULL") + "  " +
                      "  SET @nom1	= " + (nom1.Length > 0 ? "'" + nom1 + "'" : "NULL") + "  " +
                      "  SET @nom2	= " + (nom2.Length > 0 ? "'" + nom2 + "'" : "NULL") + " " +
                      "  SET @apll1	= " + (apll1.Length > 0 ? "'" + apll1 + "'" : "NULL") + "  " +
                      "  SET @apll2  = " + (apll2.Length > 0 ? "'" + apll2 + "'" : "NULL") + " " +
                      "  SELECT a.[AtdAfiTdi] as TIPO,a.[AtdAfiIde] as IDENTIFICACION, " +
                      "  a.[AtdApePri]+' '+a.[AtdApeSeg]+' '+a.[AtdNomPri]+' '+a.[AtdNomSeg] as 'NOMBRE COMPLETO',a.[EpsNom] as EPS, e.EpsNom as 'EPS CEDIDA' " +                     
                      "  inner join EPS e on e.[EpsCod] = a.EpsAsig " +
                      "  where a.[AtdAfiIde]		= ISNULL(@ID,a.[AtdAfiIde]) " +
                      "  and upper(a.[AtdApePri])	like ISNULL(upper(@nom1),a.[AtdApePri]) " +
                      "  and upper(a.[AtdApePri])	like ISNULL(upper(@nom2),a.[AtdApePri]) " +
                      "  and upper(a.[AtdNomPri])	like ISNULL(upper(@apll1),a.[AtdNomPri]) " +
                      "  and upper(a.[AtdNomSeg])	like ISNULL(upper(@apll2),a.[AtdNomSeg]) ";

            SqlCommand objComand = new SqlCommand(SQL, cone);
            SqlDataReader objReader = objComand.ExecuteReader();
            grid.DataSource = objReader;
             
            grid.DataBind();

            cone.Close();
        }
        catch { }
        
    }
    
    
    #endregion

    #region consulta para el reporte  AfiliacionEPS
    public AfiliadosAsignados[] getAfiliadosEmpleador(String nit,String nombre)
    {
        string SQL = "SELECT a.[AtdAfiTdi],a.[AtdAfiIde],a.[AtdCotTdi],a.[AtdCotIde]," +
                     " a.[AtdApePri],a.[AtdApeSeg],a.[AtdNomPri],a.[AtdNomSeg],a.[EpsAsig],a.[RegCod],  e.EpsNom, " +
                     " e.[EpsNit],e.[EpsDir],e.[EpsTel],e.[EpsCorEle],e.[EpsLinNac],e.[EpsPagWeb],mu.[MunNom], a.EPSCES " +
                      " FROM [dbo].[AFILIADOS ASIGNADOS] a " +
                      " inner join EPS e on e.[EpsCod] = a.EpsAsig " +
                      " inner join MUNICIPI mu on mu.MunCod = e.EpsMunCod " +
                     "  where a.[AtdAfiIde] =  ISNULL('"+nit+"',a.[AtdAfiIde]) ";
                    

        List<AfiliadosAsignados> lAsignado = new List<AfiliadosAsignados>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                AfiliadosAsignados Afiliados = new AfiliadosAsignados();
                Afiliados.AtdAfiTdi = reader["AtdAfiTdi"].ToString();
                Afiliados.AtdAfiIde = reader["AtdAfiIde"].ToString();
                Afiliados.AtdCotIde = reader["AtdCotIde"].ToString();
                Afiliados.AtdApePri = reader["AtdApePri"].ToString();
                Afiliados.AtdApeSeg = reader["AtdApeSeg"].ToString();
                Afiliados.AtdNomPri = reader["AtdNomPri"].ToString();
                Afiliados.AtdNomSeg = reader["AtdNomSeg"].ToString();
                Afiliados.EpsAsig = reader["EpsAsig"].ToString();
                Afiliados.RegCod = reader["RegCod"].ToString();
                Afiliados.EpsNom = reader["EpsNom"].ToString();
                
                Afiliados.EpsNit = reader["EpsNit"].ToString();
                Afiliados.EpsDir = reader["EpsDir"].ToString();
                Afiliados.EpsTel = reader["EpsTel"].ToString();
                 
                Afiliados.EpsCorEle = reader["EpsCorEle"].ToString();
                Afiliados.EpsLinNac = reader["EpsLinNac"].ToString();
                Afiliados.EpsPagWeb = reader["EpsPagWeb"].ToString();
                Afiliados.MunNom = reader["MunNom"].ToString();
                Afiliados.EPSCES = reader["EPSCES"].ToString();

                lAsignado.Add(Afiliados);
            }
            con.Close();
            return lAsignado.ToArray();

        }
        catch (Exception ex)
        {
            return lAsignado.ToArray();
        }

    }



    public String Afiliadostabla(String nit,String nom1,String nom2,String apll1,String apll2)
    {
        AfiliadosAsignados[] afiliado = getAfiliadosEmpleador(nit, nom1, nom2, apll1, apll2);
        String listTable = "";
        if (afiliado.Length > 0)
        {

            for (int i = 0; i < afiliado.Length; i++)
            {
                listTable += "<tr >";
                listTable += "<td>" + afiliado[i].AtdAfiTdi + "</td>";
                listTable += "<td>" + afiliado[i].AtdAfiIde + "</td>";
                listTable += "<td>" + afiliado[i].AtdApePri + " " + afiliado[i].AtdApeSeg + " " + afiliado[i].AtdNomPri + " " + afiliado[i].AtdNomSeg + "</td>";
                listTable += "<td>" + afiliado[i].EpsNom + "</td>";
                if (afiliado[i].EPSCES == afiliado[i].EpsNom)
                {
                    listTable += "<td></td>";
                }
                else
                {
                    listTable += "<td>" + afiliado[i].EPSCES + "</td>";
                }
                listTable += "<td> <a href=\"reporte/AfiliacionEPS.aspx?id=" + afiliado[i].AtdAfiIde + "\"  target='_blank'> DESCARGAR </a></td>";                
                listTable += "</tr>";
            }

            return listTable;
        }
        else
        {
            return "<p><strong> No se encontraron datos, Revise la información Ingresada</strong></p>";
        }

    }


    #endregion

    #region fondos pensiones

    public void fondospensiones(String nit, GridView grid) {
        try
        {
            SqlConnection cone = db.conexion();
            cone.Open();

            String sql = " select asi.[AtdAfiTdi] as TIPO,asi.[AtdAfiIde],asi.[AtdApePri]+' '+asi.[AtdApeSeg]+' '+asi.[AtdNomPri]+' '+asi.[AtdNomSeg] as NOMBRE,ep.epsNom  as EPS " +
                         " from [AFILIADOS ASIGNADOS] asi  inner join  EPS ep on ep.EpsCod = asi.EpsAsig "+
                         "  where asi.[AtdCotIde] = '"+nit+"'";

            SqlCommand objComand = new SqlCommand(sql, cone);
            SqlDataReader objReader = objComand.ExecuteReader();
            grid.DataSource = objReader;
            grid.DataBind();

            cone.Close();
        }
        catch { }
    }


    #endregion

    #region certificado 
    
        public void certificadoList(String nit, GridView grid)
        {
            try
            {
                SqlConnection cone = db.conexion();
                cone.Open();

                String sql = " select asi.[AtdAfiTdi] as TIPO,asi.[AtdAfiIde],asi.[AtdApePri]+' '+asi.[AtdApeSeg]+' '+asi.[AtdNomPri]+' '+asi.[AtdNomSeg] as NOMBRE,ep.epsNom  as EPS " +
                             
                             " from [AFILIADOS ASIGNADOS] asi  inner join  EPS ep on ep.EpsCod = asi.EpsAsig " +
                             "  where asi.[AtdAfiIde] = '" + nit + "'";

                SqlCommand objComand = new SqlCommand(sql, cone);
                SqlDataReader objReader = objComand.ExecuteReader();
                grid.DataSource = objReader;
                grid.DataBind();

                cone.Close();
            }
            catch { }
        }



        public AfiliadosAsignados[] getAfiliado(String nit, String nombre)
        {
            string SQL = "SELECT a.[AtdAfiTdi],a.[AtdAfiIde],a.[AtdCotTdi],a.[AtdCotIde]," +
                         " a.[AtdApePri],a.[AtdApeSeg],a.[AtdNomPri],a.[AtdNomSeg],a.[EpsAsig],a.[RegCod],  e.EpsNom, " +
                         " e.[EpsNit],e.[EpsDir],e.[EpsTel],e.[EpsCorEle],e.[EpsLinNac],e.[EpsPagWeb],mu.[MunNom], a.EPSCES,[AtdFecStm],[AtdfecEps] " +
                          " FROM [dbo].[AFILIADOS ASIGNADOS] a " +
                          " inner join EPS e on e.[EpsCod] = a.EpsAsig " +
                          " inner join MUNICIPI mu on mu.MunCod = e.EpsMunCod " +
                         "  where a.[AtdAfiIde] =  ISNULL('" + nit + "',a.[AtdAfiIde]) ";


            List<AfiliadosAsignados> lAsignado = new List<AfiliadosAsignados>();
            try
            {
                SqlConnection con = db.conexion();
                con.Open();
                SqlCommand com = new SqlCommand(SQL, con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    AfiliadosAsignados Afiliados = new AfiliadosAsignados();
                    Afiliados.AtdAfiTdi = reader["AtdAfiTdi"].ToString();
                    Afiliados.AtdAfiIde = reader["AtdAfiIde"].ToString();
                    Afiliados.AtdCotIde = reader["AtdCotIde"].ToString();
                    Afiliados.AtdApePri = reader["AtdApePri"].ToString();
                    Afiliados.AtdApeSeg = reader["AtdApeSeg"].ToString();
                    Afiliados.AtdNomPri = reader["AtdNomPri"].ToString();
                    Afiliados.AtdNomSeg = reader["AtdNomSeg"].ToString();
                    Afiliados.EpsAsig = reader["EpsAsig"].ToString();
                    Afiliados.RegCod = reader["RegCod"].ToString();
                    Afiliados.EpsNom = reader["EpsNom"].ToString();
                    Afiliados.EpsNit = reader["EpsNit"].ToString();
                    Afiliados.EpsDir = reader["EpsDir"].ToString();
                    Afiliados.EpsTel = reader["EpsTel"].ToString();                   ;
                    Afiliados.MunNom = reader["MunNom"].ToString();
                    Afiliados.EPSCES = reader["EPSCES"].ToString();
                    Afiliados.AtdFecStm = reader["AtdFecStm"].ToString();
                    Afiliados.AtdfecEps = reader["AtdfecEps"].ToString();

                    lAsignado.Add(Afiliados);
                }
                con.Close();
                return lAsignado.ToArray();

            }
            catch (Exception ex)
            {
                return lAsignado.ToArray();
            }

        }



    #endregion

}