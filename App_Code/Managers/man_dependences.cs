﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for man_dependences
/// </summary>
public class man_dependences
{
    clsDb db = new clsDb();
    public man_dependences()
    {
    }

    public dependences getDependenceInfo(int id_dependence)
    {
        String SQL = "select dp.*, c.name as nameCity from dependence dp inner join city c on dp.id_city = c.id where dp.id = " + id_dependence;
        dependences dep = new dependences();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                dep.Id = Convert.ToInt32(reader["id"]);
                dep.Name = reader["name"].ToString();
                dep.Dependence_logo = reader["dependence_logo"].ToString();
                dep.Address = reader["address"].ToString();
                dep.Id_city = Convert.ToInt32(reader["id_city"]);
                dep.Name_city = reader["nameCity"].ToString();
                dep.Id_company = Convert.ToInt32(reader["id_company"]);
                dep.Lat = Convert.ToDouble(reader["lat"]);
                dep.Lon = Convert.ToDouble(reader["lon"]);
                dep.Url = reader["url"].ToString();
                dep.Phone = reader["phone"].ToString();
                dep.Email = reader["email"].ToString();
            }
            con.Close();
            return dep;
        }
        catch (Exception ex)
        {
            return dep;
        }

    }


    public String getDependenceLogo(int id_dependence, String path)
    {
        dependences dep = getDependenceInfo(id_dependence);
        String men = "<img src=\"" + path + dep.Dependence_logo + "\" style=\"width:200px;\" />";
        return men;
    }

    public String getContactDependences(String pathImage)
    {
        dependences[] dep = getDependencesInfo();
        String men = "";
        for (int i = 0; i < dep.Length; i++)
        {
            if (i == 0)
            {
                men += "<div class=\"contDep\">\n";
                men += "<h2>" + dep[i].Name_Contry + "</h2>";
                men += "<div class=\"cont\"><div class=\"depe\">\n" +
                      " <div class=\"logDep\"><a href=\"" + dep[i].Url + dep[i].Id + "\"><img id=\"Img" + i + "\" src=\"" + pathImage + dep[i].Dependence_logo + "\"   alt=\"\"></a></div>\n" +
                   "</div></div>\n";
            }
            else
            {
                if (dep[i].Name_Contry == dep[i - 1].Name_Contry)
                {
                    men += "<div class=\"cont\"><div class=\"depe\">\n" +
                         " <div class=\"logDep\"><a href=\"" + dep[i].Url + dep[i].Id + "\"><img id=\"Img" + i + "\" src=\"" + pathImage + dep[i].Dependence_logo + "\"   alt=\"\"></a></div>\n" +
                      "</div></div>\n";
                }
                else
                {
                    men += "</div>\n";
                    men += "<div class=\"contDep\">\n";
                    men += "<h2>" + dep[i].Name_Contry + "</h2>";
                    men += "<div class=\"cont\"><div class=\"depe\">\n" +
                         " <div class=\"logDep\"><a href=\"" + dep[i].Url + dep[i].Id + "\"><img id=\"Img" + i + "\" src=\"" + pathImage + dep[i].Dependence_logo + "\"  alt=\"\"></a></div>\n" +
                      "</div></div>\n";
                }

            }


        }
        return men;
    }


    public String getDependenceLogo(String pathImage)
    {
        dependences[] dep = getDependencesInfo();
        String men = "";

        for (int i = 0; i < dep.Length; i++)
        {
            men += "<li><a href=\"" + dep[i].Url + "\"><img src=\"" + pathImage + dep[i].Dependence_logo + "\"  height=\"41\" width=\"180\" style=\"margin:5px;\" /></a></li>";
        }
        return men;

    }

    public dependences[] getDependencesInfo()
    {
        String SQL = "select d.*, c.name as name_company ,cnt.name as namecontry " +
                    "from dependence d inner join company c on c.id = d.id_company " +
                    "inner join city ci on ci.id = d.id_city inner join [state] st on ci.id_state = st.id " +
                    "inner join contry cnt on st.id_contry = cnt.id " +
                    "order by cnt.id";
        List<dependences> listDep = new List<dependences>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                dependences dep = new dependences();
                dep.Id = Convert.ToInt32(reader["id"]);
                dep.Name = reader["name"].ToString();
                dep.Dependence_logo = reader["dependence_logo"].ToString();
                dep.Address = reader["address"].ToString();
                dep.Id_city = Convert.ToInt32(reader["id_city"]);
                dep.Name_city = reader["namecontry"].ToString();
                dep.Name_Contry = reader["namecontry"].ToString();
                dep.Id_company = Convert.ToInt32(reader["id_company"]);
                dep.Company_name = reader["name_company"].ToString();
                dep.Lat = Convert.ToDouble(reader["lat"]);
                dep.Lon = Convert.ToDouble(reader["lon"]);
                dep.Url = reader["url"].ToString();
                dep.Phone = reader["phone"].ToString();
                dep.Email = reader["email"].ToString();
                listDep.Add(dep);
            }
            con.Close();
            return listDep.ToArray();
        }
        catch (Exception ex)
        {
            return listDep.ToArray();
        }

    }



    

  

    public Boolean saveDependence(dependences dependence) {
        String SQL = "INSERT INTO dependence ([name], [dependence_logo], [address], [id_city], [id_company], [lat], [lon], [url], [phone], [email])"+
                     " VALUES ('"+dependence.Name+"', '"+dependence.Dependence_logo+"', '"+dependence.Address+"', "+dependence.Id_city+", 1, "+dependence.Lat+", "+dependence.Lon+", '"+dependence.Url+"', '"+dependence.Phone+"', '"+dependence.Email+"')";
        return db.ejecutar(SQL);
    }

    public Boolean deleteDependence(int id_dependence) {
        String SQl = "DELETE FROM dependence where id = "+id_dependence;
        return db.ejecutar(SQl);
    }

    public Boolean updateDependece(dependences dep, int ver) {
        if (ver == 1)
        {
            String SQL = "UPDATE dependence " +
                          " SET [name] = '" + dep.Name + "' , [dependence_logo] = '" + dep.Dependence_logo + "' , [address] = '" + dep.Address + "' , [id_city] = " + dep.Id_city + ", [lat] = " + dep.Lat + " , [lon] = " + dep.Lon + " , [url] = '" + dep.Url + "' , [phone] = '" + dep.Phone + "' , [email] =  '" + dep.Email + "'" +
                          " WHERE  id = " + dep.Id; ;
            return db.ejecutar(SQL);
        }
        else {
            String SQL = "UPDATE dependence " +
                          " SET [name] = '" + dep.Name + "' , [address] = '" + dep.Address + "' , [id_city] = " + dep.Id_city + ", [lat] = " + dep.Lat + " , [lon] = " + dep.Lon + " , [url] = '" + dep.Url + "' , [phone] = '" + dep.Phone + "' , [email] =  '" + dep.Email + "'" +
                          " WHERE  id = " + dep.Id; ;
            return db.ejecutar(SQL);
        }

    }

    public String TableDataOptions( Users usr, profile pf, String page)
    {
        dependences[] dep = getDependencesInfo();
        String ListData = "";
        for (int i = 0; i < dep.Length; i++)
        {
            ListData += "<tr>" +
                            "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page, dep[i].Id) + "</td>" +
                            "<td>" + dep[i].Name + "</td>" +
                             "<td>" + dep[i].Address + "</td>" +
                            "<td><img src=\"" +Resources.patchDependence.DomainDependence+Resources.Resource.pathUploadDependence+dep[i].Dependence_logo + "\"></td>" +
                            "<td> <a href=\"" + dep[i].Url + "\">"+ dep[i].Url + "</a></td>" +
                        "</tr>";
        }

        return ListData;
    }

    public void configddls(DropDownList contry,DropDownList state, DropDownList city, int id_city) {
        String SQlState = "Select id_state from city where id ="+id_city;
        String [] states  = db.returnVector(SQlState);
        String SQLContry = "select id_contry from state where id =  "+states[0];
        String[] Contries = db.returnVector(SQLContry);
        //initialization ddl's
        SetDDLs(contry, Contries[0]);
        state.DataBind();
        SetDDLs(state, states[0]);
        city.DataBind();
        SetDDLs(city, "" + id_city);
    }

    private void SetDDLs(DropDownList d, String val)
    {
        try
        {
            ListItem li;
            for (int i = 0; i < d.Items.Count; i++)
            {
                li = d.Items[i];
                if (li.Value == val)
                {
                    d.SelectedIndex = i;
                    i = d.Items.Count;
                    break;
                }
            }
        }
        catch (Exception ext)
        {
            String error = ext.Message;
        }
    }
}