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