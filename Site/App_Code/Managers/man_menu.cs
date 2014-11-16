using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

    private menu[] getMenuInformation(int id_dependece) {
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
         catch(Exception e) {
             menu m = new menu();
             m.Name = e.Message;
             MasterMenu.Add(m);
         }
         return MasterMenu.ToArray();
    }


    public String getMenu(int id_depedence, String df) {
        menu[] m = getMenuInformation(id_depedence);
        String conf = "";
        for (int i = 0; i < m.Length; i++) {
            if (i == 0)
            {
                conf += " <li class=\"current\"><a href=\"" + m[i].Url.Replace(df,"") + "\" class=\"trigger\"><span>" + m[i].Name + "</span></a></li>";
            }
            else {
                if(m[i].Id_parent == 0){
                    int count = 0;
                    string sub = "";
                    conf += " <li><a href=\"" + m[i].Url.Replace(df, "") + "\" class=\"trigger\"><span>" + m[i].Name + "</span></a>";
                    for (int j = 0; j < m.Length; j++ )
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
                            sub+="</li>";
                        //end tird grade
                        }               
                    }
                    if (count > 0) {
                        conf += "<ul>" + sub + "</ul>";
                        }
                    conf += "</li>";
                }
            }           
        }
        return conf;
    }

}