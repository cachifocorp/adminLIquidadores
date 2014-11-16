using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_menuPages
/// </summary>
public class man_menuPages
{
    clsDb db = new clsDb();
	public man_menuPages()
	{}

    public menu[] getInfoMenuDependence(int id_dependence) {
        String SQL = "Select * from Menu where id_dependence = "+id_dependence;
        List<menu> lMenu = new List<menu>();
        try {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                menu me = new menu();
                me.Id = Convert.ToInt32(reader["id"]);
                me.Name = reader["name"].ToString();
                me.Id_parent = Convert.ToInt32(reader["id_parent"]);
                me.Url = reader["url"].ToString();
                me.Activated = Convert.ToInt32(reader["activated"]);
                me.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                lMenu.Add(me);
            }
        }
        catch (Exception e) {
            return lMenu.ToArray();
        }

       return lMenu.ToArray();
    }


    public menu getInfoMenuDep(int idItem)
    {
        String SQL = "Select * from Menu where id = " + idItem;
         menu me = new menu();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
               
                me.Id = Convert.ToInt32(reader["id"]);
                me.Name = reader["name"].ToString();
                me.Id_parent = Convert.ToInt32(reader["id_parent"]);
                me.Url = reader["url"].ToString();
                me.Activated = Convert.ToInt32(reader["activated"]);
                me.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                 
            }
        }
        catch (Exception e)
        {
            return me;
        }

        return me;
    }

    public Boolean deleteMenuItem( int id_item) {
        String SQL = "DELETE FROM  Menu   where  id = "+id_item;
        return db.ejecutar(SQL);
    }

    public Boolean UpdateMenuItem(menu me) {
        String SQL = "UPDATE  Menu "+
                     "  SET [name] = '"+me.Name+"', [id_parent] = "+me.Id_parent+", [url] = '"+me.Url+"', [activated] = "+me.Activated+", [id_dependence] =  "+me.Id_dependence+
                     " WHERE  id = "+me.Id;
        return db.ejecutar(SQL);
    }

    public Boolean saveMenu(menu men) {
        String SQL = "INSERT INTO  Menu ([name],[id_parent],[url],[activated],[id_dependence])" +
                    " VALUES('"+men.Name+"',"+men.Id_parent+",'"+men.Url+"',"+men.Activated+","+men.Id_dependence+")";
       return  db.ejecutar(SQL);
    
    }

    public String TableDataOptions(int id, Users usr, profile pf, String page)
        {
        menu[] me = getInfoMenuDependence(id);
        String ListData = "";
        for (int i = 0; i < me.Length; i++)
        {
            ListData += "<tr>" +
                            "<td>"+genericFunctions.OptionsRoleBasicActions(usr,pf,page,me[i].Id)+"</td>" +
                            "<td>" + me[i].Name + "</td>" +
                            "<td>" + me[i].Url + "</td>" +
                        "</tr>";
        }

        return ListData;
    }
}