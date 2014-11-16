using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_menu
/// </summary>
public class man_menu
{
    clsDb db = new clsDb();
	public man_menu()
	{
	}

    


    public module[] getInfoModules() {
        String SQL = " select * from module";
        List<module> mod = new List<module>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                module m = new module();
                m.Id = Convert.ToInt32(reader["id"]);
                m.Name = reader["name"].ToString();
                m.Url = reader["url"].ToString();
                m.Icon = reader["icon"].ToString();
              // mod.Add( new module(Convert.ToInt32(reader["id"]), reader["name"].ToString(), Convert.ToDateTime(reader["date_register"]), reader["url"].ToString()));
                mod.Add(m);
            }
        }
        catch (Exception e)
        {
            module m = new module();
            m.Name = e.Message;
            mod.Add(m);
        }

        return mod.ToArray();
    }

    public itemModule[] get_infoItemModule(int id_profile) {
        String SQL = "select im.* from itemsmodule im inner join item_module_profile imp on im.id = imp.id_item where imp.id_profile =  " + id_profile;
        List<itemModule> im = new List<itemModule>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                itemModule m = new itemModule();
                m.Id = Convert.ToInt32(reader["id"]);
                m.Name =  reader["name"].ToString();
                m.Id_module = Convert.ToInt32(reader["id_module"]);
                m.Date_register = Convert.ToDateTime(reader["date_register"]);
                m.Url = reader["url"].ToString();
                im.Add(m);
            }
        }
        catch (Exception e)
        {
            itemModule m = new itemModule();
            m.Name = e.Message;
            im.Add(m);
        }

        return im.ToArray();

    }

    public String  getMenuAdmin(int id_profile,String df){
        module[] md = getInfoModules();
        itemModule[] im = get_infoItemModule(id_profile);
        String modules ="";
        String items = "";
        String menu = "";
        String men = "";

        if (md.Length > 0)
        {
            for (int i = 0; i < md.Length; i++)
            {
                men = "";
                items = "";
                for (int j = 0; j < im.Length; j++)
                {
                    if (im[j].Id_module == md[i].Id)
                    {
                        items += " <li><a class=\"\" href=\"#\" onclick=\"getPage('" + im[j].Url.Replace(df, "") + "?idmod="+im[j].Id+"')\">" + im[j].Name + "</a></li>";
                    }
                }

                if (items.Length > 0)
                {
                    modules = " <li class=\"dropdown\"><a href=\"" + md[i].Url.Replace(df, "") + "\" class=\"dropdown-toggle\"><i class=\""+md[i].Icon+"\"></i><span class=\"hidden-xs\">" + md[i].Name + "</span></a>";
                    men = modules + "<ul class=\"dropdown-menu\">" + items + "</ul></li>";
                    menu += men;
                }
                else {

                    modules = "<li><a href=\"" + md[i].Url.Replace(df, "") + "\" class=\"ajax-link\"><iclass=\"" + md[i].Icon + "\"></i><span class=\"hidden-xs\">" + md[i].Name + "</span></a></li>";
                    menu += modules;
                }
            }
        }
        else {
            menu = "<li>No hay datos</li>";
        }
      //  menu = "<ul>" + men + "</ul>";

        return menu;
        
    }
   

}