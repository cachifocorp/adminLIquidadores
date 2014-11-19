using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                 sql = "insert into regulations(date,issuingauthority,postdate,file,subject,timestamp,numero,tipo) values " +
                               "('" + objNormatividad.Fecha + "'," +
                               "'" + objNormatividad.EntidadEmite + "'," +
                               "'" + objNormatividad.FechaPublicacion + "'," +
                               "'" + objNormatividad.Archivo + "'," +
                               "'" + objNormatividad.Asunto + "'," +
                               "getdate()," +
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
                        ",file='"+objNormatividad.Archivo+"'"+
                        ",subject='"+objNormatividad.Asunto+"'"+
                        ",timestamp=getdate()"+
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

}