using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_AfiliadosAsignados
/// </summary>
public class man_AfiliadosAsignados
{
    clsDb db = new clsDb();
    public man_AfiliadosAsignados() { }

    #region empleador
    public AfiliadosAsignados[] getAfiliadosEmpleador(String nit)
	{
        string SQL = "SELECT a.[AtdAfiTdi],a.[AtdAfiIde],a.[AtdCotTdi],a.[AtdCotIde],"+
                     " a.[AtdApePri],a.[AtdApeSeg],a.[AtdNomPri],a.[AtdNomSeg],a.[EpsAsig],a.[RegCod],  e.EpsNom " +
                      "FROM [dbo].[AFILIADOS ASIGNADOS] a " +
                      "inner join EPS e on e.[EpsCod] = a.EpsAsig" +
                      " where [AtdAfiIde] = '" + nit + "';";
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

    public String AfiliadosEmpleador(String nit){
        AfiliadosAsignados[] afiliado = getAfiliadosEmpleador(nit);
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
    #endregion

    #region consulta para el reporte  AfiliacionEPS
    public AfiliadosAsignados[] getAfiliadosEmpleador(String nit,String nombre)
    {
        string SQL = "SELECT a.[AtdAfiTdi],a.[AtdAfiIde],a.[AtdCotTdi],a.[AtdCotIde]," +
                     " a.[AtdApePri],a.[AtdApeSeg],a.[AtdNomPri],a.[AtdNomSeg],a.[EpsAsig],a.[RegCod],  e.EpsNom, " +
                     " e.[EpsNit],e.[EpsDir],e.[EpsTel],e.[EpsCorEle],e.[EpsLinNac],e.[EpsPagWeb],mu.[MunNom], a.EPSCES" +
                      "FROM [dbo].[AFILIADOS ASIGNADOS] a " +
                      "inner join EPS e on e.[EpsCod] = a.EpsAsig " +
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
                Afiliados.EpsEst = reader["EpsEst"].ToString();
                Afiliados.EpsNit = reader["EpsNit"].ToString();
                Afiliados.EpsDir = reader["EpsDir"].ToString();
                Afiliados.EpsTel = reader["EpsTel"].ToString();
                Afiliados.EpsMunCod = reader["EpsMunCod"].ToString();
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



    public String Afiliadostabla(String nit)
    {
        AfiliadosAsignados[] afiliado = getAfiliadosEmpleador(nit);
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

}