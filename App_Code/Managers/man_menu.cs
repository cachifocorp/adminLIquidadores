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

    private menu[] getMenuInformation(int id_dependece)
    {
        String SQL = "select id, name, id_parent, url, activated, id_dependence from Menu  where id_dependence = " + id_dependece;
        List<menu> MasterMenu = new List<menu>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                menu m = new menu();
                m.Id = Convert.ToInt32(reader["id"]);
                m.Name = reader["name"].ToString();
                m.Id_parent = Convert.ToInt32(reader["id_parent"]);
                m.Url = reader["url"].ToString();
                m.Activated = Convert.ToInt32(reader["activated"]);
                m.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                MasterMenu.Add(m);
            }
        }
        catch (Exception e)
        {
            menu m = new menu();
            m.Name = e.Message;
            MasterMenu.Add(m);
        }
        return MasterMenu.ToArray();
    }


    public String getMenu(int id_depedence, String df)
    {
        menu[] m = getMenuInformation(id_depedence);
        String conf = "";
        for (int i = 0; i < m.Length; i++)
        {
            if (i == 0)
            {
                conf += " <li class=\"current\"><a href=\"" + m[i].Url.Replace(df, "") + "\" class=\"trigger\"><span>" + m[i].Name + "</span></a></li>";
            }
            else
            {
                if (m[i].Id_parent == 0)
                {
                    int count = 0;
                    string sub = "";
                    conf += " <li><a href=\"" + m[i].Url.Replace(df, "") + "\" class=\"trigger\"><span>" + m[i].Name + "</span></a>";
                    for (int j = 0; j < m.Length; j++)
                    {
                        if (m[j].Id_parent != 0 && m[i].Id == m[j].Id_parent)
                        {
                            sub += " <li><a href=\"" + m[j].Url.Replace(df, "") + "\"><span>" + m[j].Name + "</span></a>";
                            count++;
                            //treee grade Child
                            int count2 = 0;
                            string sub2 = "";
                            for (int k = 0; k < m.Length; k++)
                            {
                                if (m[k].Id_parent != 0 && m[j].Id == m[k].Id_parent)
                                {
                                    sub2 += " <li><a href=\"" + m[k].Url.Replace(df, "") + "\"><span>" + m[k].Name + "</span></a></li>";
                                    count2++;
                                }
                            }
                            if (count2 > 0)
                            {
                                sub += "<ul>" + sub2 + "</ul>";
                            }
                            sub += "</li>";
                            //end tird grade
                        }
                    }
                    if (count > 0)
                    {
                        conf += "<ul>" + sub + "</ul>";
                    }
                    conf += "</li>";
                }
            }
        }
        return conf;
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