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
    /// this method gets information of  clients 
    /// </summary>
    /// <param name="id_dependence"> identification Dependence</param>
    /// <returns>Object vector of client class</returns>
    private client[] getinfoCLients( int id_dependence, int limit) {
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
    /// this function  gets commets of clients 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="limit"></param>
    /// <returns> returns a formated String list ready for print in page</returns>
    public String getCommentsClients(int id_dependence, int limit, String path_image) {
        client[] client = getinfoCLients(id_dependence, limit);
        String comments = "";
        for (int i = 0; i < client.Length; i++ )
        {
           comments+= "<div class=\"testi_inner_wrapper_4 span3\">"+
					"<div class=\"title_b2\"><h2>"+client[i].Comment+"</h2></div>"+
					"<div class=\"blog_h_content\">"+ 
					"<div class=\"test_detail2\">"+
					    "<div class=\"photo_testi\"><img src=\""+path_image+""+client[i].Team_photo+"\" class=\"scale-with-grid\" width=\"50px\" alt=\"\"></div>"+
						"<div class=\"sub_test_con\">"+
						   "<div class=\"sub_text1\"> "+client[i].Team_name+"</div>"+ 
						   "<div class=\"sub_text2\"> "+client[i].Position_company  +" </div>"+
                        "</div>"+						
					"</div>"+ 																 
					"</div>"+																	 
				"</div>"; 
        }
        comments+="<div class=\"clear\"></div>";
        return comments;
    }

    /// <summary>
    /// this method get photos of clients 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="limit">formated string whith photos of clients</param>
    /// <returns></returns>
    public String getClientsFormatPhoto(int id_dependence, int limit, String path) {
        client[] client = getinfoCLients(id_dependence, limit);
        String cl = "";
        for (int i = 0; i < client.Length; i++) {
            cl += " <li><a href=\"#\" class=\"tool_tipsy\" title=\""+client[i].Name+"\"><img src=\""+path+""+client[i].Logo_client+"\"  width=\"100px\" alt=\"\" class=\"scale-with-grid\"/></a></li>";
        }

        return cl;
    }

    public String getClientsFormatMedium(int id_dependence, int limit, String imagePath)
    {
        client[] client = getinfoCLients(id_dependence, limit);
        String cl = "";
        for (int i = 0; i < client.Length; i++) {
            cl += "<li class=\"b_wrapper span6\" style=\"text-align:center; width: 460px;\">" +			  
			          "<div class=\"home_b_holder_wrapper\">"+ 
                        "<div class=\"home_b_holder\">"+			  
		                   "<img src=\""+imagePath+""+client[i].Logo_client+"\" height=\"81\" width=\"128\" alt=\"\"/>"+
                        "<span class=\"clear\"></span>"+  
                        
			          "</div>"+
			           "<div class=\"clear\"></div>"+
		             "</li>";
        }

        return cl;
    }


}