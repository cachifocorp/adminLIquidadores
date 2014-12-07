using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de clsMenu
/// </summary>
public class clsMenu
{
	public clsMenu()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    clsDb objDb = new clsDb();

   
    public bool banner(String nombre, String imagen,String id, String opcion)
    {
        try
        {
            String sql = "";
            if (opcion.Equals("insert"))
            {
                sql = "insert into slider(name,slide,id_dependence,date_register) values('" + nombre + "','" + imagen + "',3,'2014-12-02')";
            }
           
            objDb.ejecutar(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }

   

}