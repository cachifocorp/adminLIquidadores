using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de man_normatividad
/// </summary>
public class man_normatividad
{

    clsDb db = new clsDb();

	public man_normatividad()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    public bool AddNormatividad(normatividad objNormatividad,String tipo)
    {
        try
        {
            String sql = "";
            if (tipo.Equals("insert"))
            {
                 sql = "insert into regulations(date,issuingauthority,postdate,[file],subject,numero,tipo) values " +
                               "('" + objNormatividad.Fecha + "'," +
                               "'" + objNormatividad.EntidadEmite + "'," +
                               "'" + objNormatividad.FechaPublicacion + "'," +
                               "'" + objNormatividad.Archivo + "'," +
                               "'" + objNormatividad.Asunto + "'," +
                               "'" + objNormatividad.Numero + "'," +
                               "'" + objNormatividad.Tipo + "'" +
                               " )";

            }
            else if (tipo.Equals("update"))
            {
                sql = "update regulations set "+
                        "date='"+objNormatividad.Fecha+"'"+
                        ", issuingauthority='"+objNormatividad.EntidadEmite+"'"+
                        ",postdate='"+objNormatividad.FechaPublicacion+"'"+
                        ",[file]='"+objNormatividad.Archivo+"'"+
                        ",subject='"+objNormatividad.Asunto+"'"+
                        ""+
                        ",numero='"+objNormatividad.Numero+"' where id="+objNormatividad.Id
                        ;
            }
            else
            {
                sql = "delete from regulations where id=" + objNormatividad.Id;
            }
            db.ejecutar(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public String GetNormatividad(String tipo,String page)
    {
        try
        {
            String sql = "Select id,numero,date,issuingauthority,subject from regulations where tipo=" + tipo;
            String[,] resul = db.RetornarMatriz(sql);
            String resultString = "";
            for (int i = 0; i < resul.GetLength(0); i++)
            {

                resultString += "<tr>" +
                            "<td><a  href=\"" + page + "&accion=modificar&idNormatividad=" + resul[i,0] + "\" class=\"btn btn-warning\">Editar</a>"
                + " <!--<a  href=\"" + page + "&idItem=" + resul[i, 0] + "\" class=\"btn btn-danger\">Eliminar</a>--> </td>" +
                            "<td>" + resul[i, 1] + "</td>" +
                            "<td>" + resul[i, 2] + "</td>" +
                            "<td>" + resul[i, 3] + "</td>" +
                            "<td>" + resul[i, 4] + "</td>" +
                            
                        "</tr>";
                
            }
            

            return resultString;

        }
        catch
        {
            return "";
        }

    }

    public String[] getNormatividad(String tipo, String id)
    {
        String sql = "Select id,numero,date,issuingauthority,subject,[file],postdate from regulations where id=" + id;
        return db.returnVector(sql);


    }

    public void mostrarNormatividad(GridView Grilla, String tipo, String filtro)
    {
        try
        {
            SqlConnection cone = db.conexion();
            cone.Open();

            String sql = "SELECT [numero] as NUMERO, [date] as FECHA,[subject] AS ASUNTO, [Issuingauthority] AS [AUTORIDAD QUE LA EXPIDE], [postDate] AS [FECHA PUBLICACION WEB], '../../../normatividad/'+[file] as [ARCHIVO] FROM [regulations]";

            SqlCommand objComand = new SqlCommand(sql, cone);
            SqlDataReader objReader = objComand.ExecuteReader();
            Grilla.DataSource = objReader;
            Grilla.DataBind();

            cone.Close();
        }
        catch { }
    }


}