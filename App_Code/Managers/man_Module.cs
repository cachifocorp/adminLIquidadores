using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_Module
/// </summary>
public class man_Module
{
    clsDb db = new clsDb();
	public man_Module()	{}


    public itemModule[] getInfoItemModule(int id_profile) {
        String SQL = "select im.*, mo.name as nameModule from itemsModule im inner join  item_module_profile imp  on im.id = imp.id_item inner join module mo on mo.id = im.id_module"+
                     " where imp.id_profile ="+id_profile;
        List<itemModule> lim = new List<itemModule>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                itemModule im = new itemModule();
                im.Id = Convert.ToInt32(reader["id"]);
                im.Id_module = Convert.ToInt32(reader["id_module"]);
                im.Module_name = reader["nameModule"].ToString();
                im.Name = reader["name"].ToString();
                im.Date_register = Convert.ToDateTime(reader["date_register"]);
                im.Url = reader["url"].ToString();
                lim.Add(im);
            }
        }
        catch (Exception e) {
            return lim.ToArray();
        }

        return lim.ToArray();
    }
    public Boolean savePermission(int item, int id_profile, int option) {
        String SQL = "INSERT INTO  item_module_profile ([id_item],[id_profile],[date_register],[options])"+
                     " VALUES( "+item+", "+id_profile+" , GETDATE(), "+option+")";
        return db.ejecutar(SQL);
    }
    public Boolean deletePermissions( int id, int id_profile) {
        String SQL = "DELETE FROM [item_module_profile] WHERE id_item = " + id+" and id_profile = "+id_profile;
        return db.ejecutar(SQL);
    }


    public String TableDataOptions(int id, Users usr, profile pf, String page)
    {
        itemModule[] mod = getInfoItemModule(id);
        String ListData = "";
        for (int i = 0; i < mod.Length; i++)
        {
            ListData += "<tr>" +
                            "<td><a  href=\"permissionsUser.aspx?action=3&id="+id+"&idd="+mod[i].Id+"\"  class=\"btn btn-primary btn-label-left\">Eliminar</a></td>" +
                            "<td>" + mod[i].Module_name + "</td>" +
                             "<td>" + mod[i].Name + "</td>" +
                            "<td>" + mod[i].Date_register + "</td>" +
                            "<td>" + mod[i].Url + "</td>" +
                        "</tr>";
        }

        return ListData;
    }
}