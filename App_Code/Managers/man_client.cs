using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_client
/// </summary>
public class man_client
{
    clsDb db = new clsDb();
	public man_client()
	{
		
	}

    /// <summary>
    /// this function  gets commets of clients 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="limit"></param>
    /// <returns> returns a formated String list ready for print in page</returns>
    public String getCommentsClients(int id_dependence, int limit, String path_image)
    {
        client[] client = getinfoCLients(id_dependence, limit);
        String comments = "";
        for (int i = 0; i < client.Length; i++)
        {
            comments += "<div class=\"testi_inner_wrapper_4 span3\">" +
                     "<div class=\"title_b2\"><h2>" + client[i].Comment + "</h2></div>" +
                     "<div class=\"blog_h_content\">" +
                     "<div class=\"test_detail2\">" +
                         "<div class=\"photo_testi\"><img src=\"" + path_image + "" + client[i].Team_photo + "\" class=\"scale-with-grid\" width=\"50px\" alt=\"\"></div>" +
                         "<div class=\"sub_test_con\">" +
                            "<div class=\"sub_text1\"> " + client[i].Team_name + "</div>" +
                            "<div class=\"sub_text2\"> " + client[i].Position_company + " </div>" +
                         "</div>" +
                     "</div>" +
                     "</div>" +
                 "</div>";
        }
        comments += "<div class=\"clear\"></div>";
        return comments;
    }


    public String getClientsFormatMedium(int id_dependence, int limit, String imagePath)
    {
        client[] client = getinfoCLients(id_dependence, limit);
        String cl = "";
        for (int i = 0; i < client.Length; i++)
        {
            cl += "<li class=\"b_wrapper span6\" style=\"text-align:center; width: 460px;\">" +
                      "<div class=\"home_b_holder_wrapper\">" +
                        "<div class=\"home_b_holder\">" +
                           "<img src=\"" + imagePath + "" + client[i].Logo_client + "\" height=\"81\" width=\"128\" alt=\"\"/>" +
                        "<span class=\"clear\"></span>" +

                      "</div>" +
                       "<div class=\"clear\"></div>" +
                     "</li>";
        }

        return cl;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cli"></param>
    /// <returns></returns>
    public Boolean saveClient(client cli) {
        String SQL = "INSERT INTO client ([name], [description], [logo_client], [comment], [id_dependence], [team_photo], [team_name], [position_company], [state])"+
                      "VALUES ('"+cli.Name+"', '"+cli.Description+"', '"+cli.Logo_client+"', '"+cli.Comment+"', "+cli.Id_dependence+", '"+cli.Team_photo+"', '"+cli.Team_name+"', '"+cli.Position_company+"', "+cli.State+")";
        if (db.ejecutar(SQL))
        {
            return true;
        }
        else {
            return false;
        }
    }

    /// <summary>
    /// this method gets information of  clients 
    /// </summary>
    /// <param name="id_dependence"> identification Dependence</param>
    /// <returns>Object vector of client class</returns>
    private client[] getinfoCLients(int id_dependence, int limit)
    {
        String SQL = "select TOP " + limit + " * from client where id_dependence = " + id_dependence + " and state = 1 ORDER BY NEWID()";
        List<client> cli = new List<client>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                client c = new client();
                c.Id = Convert.ToInt32(reader["id"]);
                c.Name = reader["name"].ToString();
                c.Description = reader["description"].ToString();
                c.Logo_client = reader["logo_client"].ToString();
                c.Comment = reader["comment"].ToString();
                c.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                c.Team_photo = reader["team_photo"].ToString();
                c.Team_name = reader["team_name"].ToString();
                c.Position_company = reader["position_company"].ToString();
                cli.Add(c);
            }
            con.Close();
        }
        catch { }
        return cli.ToArray();
    }



    /// <summary>
    /// this method get photos of clients 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="limit">formated string whith photos of clients</param>
    /// <returns></returns>
    public String getClientsFormatPhoto(int id_dependence, int limit, String path)
    {
        client[] client = getinfoCLients(id_dependence, limit);
        String cl = "";
        for (int i = 0; i < client.Length; i++)
        {
            cl += " <li><a href=\"#\" class=\"tool_tipsy\" title=\"" + client[i].Name + "\"><img src=\"" + path + "" + client[i].Logo_client + "\"  width=\"100px\" alt=\"\" class=\"scale-with-grid\"/></a></li>";
        }

        return cl;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_client"></param>
    /// <returns></returns>
    public Boolean deleteClient(int id_client) {
        String SQL = "DELETE FROM  client where id = "+id_client;
        return db.ejecutar(SQL);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cli"></param>
    /// <returns></returns>
    public Boolean UdateClient(client cli, int ver) {

        if (ver == 1)
        {
            String SQL= "";
            if(cli.Logo_client != ""){
                 SQL = "UPDATE client" +
                 "  SET [name] = '" + cli.Name + "',[description] = '" + cli.Description + "',[logo_client] = '" + cli.Logo_client + "',[comment] = '" + cli.Comment + "',[team_name] = '" + cli.Team_name + "',[position_company] = '" + cli.Position_company + "'" +", [state] = "+cli.State+
                 "   WHERE id = " + cli.Id;
            }
            else if (cli.Team_photo != "") {
                SQL = "UPDATE client" +
                "  SET [name] = '" + cli.Name + "',[description] = '" + cli.Description + "',[team_photo] = '" + cli.Team_photo + "',[comment] = '" + cli.Comment + "', [team_name] = '" + cli.Team_name + "',[position_company] = '" + cli.Position_company + "'" + ", [state] = " + cli.State +
                "   WHERE id = " + cli.Id;
            }

            if (cli.Logo_client != "" && cli.Team_photo != "") {
                SQL = "UPDATE client" +
                "  SET [name] = '" + cli.Name + "',[description] = '" + cli.Description + "',[logo_client] = '" + cli.Logo_client + "' ,[comment] = '" + cli.Comment + "',[team_photo] = '" + cli.Team_photo + "',[team_name] = '" + cli.Team_name + "',[position_company] = '" + cli.Position_company + "'" + ", [state] = " + cli.State +
                "   WHERE id = " + cli.Id;
            }
            return db.ejecutar(SQL);
        }
        else {
            String SQL = "UPDATE client" +
            "  SET [name] = '" + cli.Name + "',[description] = '" + cli.Description + "',[comment] = '" + cli.Comment + "',[team_name] = '" + cli.Team_name + "',[position_company] = '" + cli.Position_company + "'" + ", [state] = " + cli.State +
            "   WHERE id = " + cli.Id;
            return db.ejecutar(SQL);
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <returns></returns>
    private client[] getinfoCLients(int id_dependence)
    {
        String SQL = "select * from client where id_dependence = " + id_dependence;
        List<client> cli = new List<client>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                client c = new client();
                c.Id = Convert.ToInt32(reader["id"]);
                c.Name = reader["name"].ToString();
                c.Description = reader["description"].ToString();
                c.Logo_client = reader["logo_client"].ToString();
                c.Comment = reader["comment"].ToString();
                c.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                c.Team_photo = reader["team_photo"].ToString();
                c.Team_name = reader["team_name"].ToString();
                c.Position_company = reader["position_company"].ToString();
                c.State = Convert.ToInt32(reader["state"]);
                cli.Add(c);
            }
            con.Close();
        }
        catch { }
        return cli.ToArray();
    }


    public client getinfoCLient(int id_client)
    {
        String SQL = "select * from client where id = " + id_client;
        client c = new client();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                
                c.Id = Convert.ToInt32(reader["id"]);
                c.Name = reader["name"].ToString();
                c.Description = reader["description"].ToString();
                c.Logo_client = reader["logo_client"].ToString();
                c.Comment = reader["comment"].ToString();
                c.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                c.Team_photo = reader["team_photo"].ToString();
                c.Team_name = reader["team_name"].ToString();
                c.Position_company = reader["position_company"].ToString();
                c.State = Convert.ToInt32(reader["state"]);
            }
            con.Close();
        }
        catch {
            return c;
        }
        return c;
    }


    public String TableDataOptions(int id_dependence, Users usr, profile pf, String page)
    {
        client[] cli = getinfoCLients(id_dependence);
        String ListData = "";
        for (int i = 0; i < cli.Length; i++)
        {
            ListData += "<tr>" +
                            "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page, cli[i].Id) + "</td>" +
                            "<td>" + cli[i].Name + "</td>" +
                             "<td>" + cli[i].Description + "</td>" +
                            "<td>" + cli[i].Comment + "</td>" +
                        "</tr>";
        }

        return ListData;
    }

}