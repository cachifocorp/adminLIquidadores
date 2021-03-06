﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for man_Publication
/// </summary>
public class man_Publication
{
    clsDb db = new clsDb();
    public man_Publication()
    {
    }

    /// <summary>
    /// this id an encapsulation of  one format to print in the vew  the news 
    /// </summary>
    /// <param name="id_tag"></param>
    /// <param name="id_dependence"></param>
    /// <param name="limit"></param>
    /// <returns> returnig the data in html format for print in the vew</returns>
    public String publicationShort(int id_tag, int id_dependence, int limit, String pathPage)
    {
        publications[] pub = getPublication(id_tag, id_dependence, limit);
        string news = "";
        for (int i = 0; i < pub.Length; i++)
        {
            news += " <li class=\"b_wrapper span6\">" +
                         "<div class=\"home_b_holder_wrapper\">" +
                             "<div class=\"home_b_holder\">" +
                                 "<img src=\"" + Resources.paths.news + pub[i].Image + "\" alt=\"\"/>" +
                                 " <span class=\"clear\"></span>" +
                                  "<div class=\"home_time_wrap_holder\" >" +
                                     "<a href=\"" + pathPage + "?idp=" + pub[i].Id + "\">" +
                                         "<h4>" + pub[i].Title[0] + "</h4>" +
                                      "</a>" +
                                     "<div class=\"home_time_wrap\">" +
                                         "<div class=\"date_b_wrapper\">Publicado por: AMV &nbsp; | &nbsp; " + pub[i].Date_publication.ToString("MMMM dd, yyyy") + " </div>" +
                                         "<div class=\"icon_b_wrapper\"><a href=\"" + pathPage + "?idp=" + pub[i].Id + "\"><div class=\"icon_readmore2\"></div></a></div>" +
                                      "<span class=\"clear\"></span> " +
                                     "</div>" +
                                     "<div class=\"clear\"></div>" +
                                     "<div class=\"view_title_b\">" +
                                        "<p>" + pub[i].Description[0].Substring(0, Convert.ToInt32(pub[i].Description[0].Length * 0.2)) + "</p>" +
                                     "</div>" +
                                     "</div>" +
                                   "</div>" +
                                "</div>" +
                       " <div class=\"clear\"></div>	" +
                     "</li> ";
        }
        return news;
    }



    public String getNews(int id_tag, int id_dependence, int limit, int id_page, String pathImage, String pathPage, int lang)
    {
        publications[] pub = getPublicationNews(id_tag, id_dependence, limit, id_page);
        string publication = "";
        for (int i = 0; i < pub.Length; i++)
        {
            try
            {
                publication += "<div class=\"blog_post\">" +
                             "<div class=\"blog_image\">" +
                                " <a href=\"" + pathImage + pub[i].Image + "\"  data-rel=\"prettyPhoto[portfolio]\" class=\"view_image\">" +
                                    "<img src=\"" + pathImage + pub[i].Image + "\" alt=\"\">" +
                                    "<div class=\"link_overlay icon-play\"></div>" +
                                 "</a>" +
                               "<div class=\"clear\"></div>" +
                             "</div>" +
                             "<div class=\"blog_content_wrapper\">" +
                                 "<div class=\"blog_t_d_wrapper\">" +
                                    "<div class=\"home_time_wrap_p\">" +
                                         "<div class=\"icon_b_wrapper_p\"><div class=\"video_icon\"></div></div>" +
                                          "<div class=\"day_b_wrapper_p\">" +
                                            "<span class=\"day_b_wrapper_inner\">" + pub[i].Date_publication.ToString("dd") + "</span>" +
                                          "</div>" +
                                          "<div class=\"date_b_wrapper_b\">" +
                                            "<div class=\"h_month_y\"> " + pub[i].Date_publication.ToString("MMM dd") + " </div>" +
                                          "</div>" +
                                    "</div>	" +
                                    "<div class=\"clear\"></div>" +
                                    "<div class=\"blog_title_wrapper\">" +
                                      "<div class=\"blog_title\"><h4><a href=\"" + pathPage + "?idp=" + pub[i].Id + "\">" + pub[i].Title[lang] + "</a></h4></div>" +
                                      "<div class=\"date_b_wrapper2\"> publicado por EMPRESA  - &nbsp;</div>" +
                                    "</div>" +
                                    "<div class=\"clear\"></div>" +
                                 "</div>" +
                                 "<div class=\"p_content_b\">" +
                                    "<p>" + pub[i].Description[lang].Substring(0, 100) + "</p>" +
                                 "</div>" +
                                 "<div class=\"con_blog\"><a href=\"" + pathPage + "?idp=" + pub[i].Id + "\">Mas..</a></div>" +
                             "</div>" +
                            "<div class=\"clear\"></div>" +
                        "</div>";
            }
            catch { }

        }

        return publication;
    }


    public String getSliderNews(int id_tag, int id_dependence, int limit, String pathImage, String pathPage, int lang)
    {
        publications[] pub = getPublication(id_tag, id_dependence, limit);
        string publication = "";
        for (int i = 0; i < pub.Length; i++)
        {
            try
            {
                publication += " <li>" +
                                    "<article>" +
                                    "<img src=\"" + pathImage + pub[i].Image + "\" alt=\"\" height=\"505\" width=\"500\" alt=\"\" >" +
                                       "<div class=\"flex-caption\">" +
                                            "<header>" +
                                                "<span class=\"entry-met\">&nbsp;|&nbsp;</span>" +
                                                "<span class=\"entry-date\">" + pub[i].Date_publication.ToString("MMMM dd, yyyy") + "</span>" +
                                            "</header>" +
                                            "<a href=\"" + pathPage + "?idp=" + pub[i].Id + "\" ><h2 style=\"font-family: 'Rokkitt';  font-weight:bold; color:white;\">" + pub[i].Title[lang] + "</h2></a>" +
                                            "<p style=\"color: white; font-size:30px;\">" + pub[i].Description[lang].Substring(0, 100) + "</p>" +
                                        "</div>" +
                                    "</article>" +
                                "</li>";
            }
            catch { }
        }
        return publication;
    }


    public String[] getArticle(int id_dependence, int id_pub, String imagePath)
    {
        publications[] pub = getPublication(id_dependence, id_pub);
        String[] content = new String[3];
        content[0] = "<img src=\"" + imagePath + pub[0].Image + "\">";
        String description = "";
        String language = "";

        for (int i = 0; i < pub[0].Description.Length; i++)
        {
            language += "<li><a class=\"clearfix\" href=\"#a" + i + "\">" + pub[0].Language_name[i] + "</a></li>";
            if (i == 0)
            {
                description += "<li id=\"a" + i + "\" class=\" active clearfix\">" +
                        "<div class=\"pb_title_wrapper\">" +
                               " <h2 class=\"pb_title\">" + pub[0].Title[i] + "</h2>" +
                                "<div class=\"clear\"></div>" +
                       " </div>" +
                    "<p>" + pub[0].Description[i] + "</p>" +
                    "</li>";
            }
            else
            {
                description += "<li id=\"a" + i + "\" class=\" active clearfix\">" +
                        "<div class=\"pb_title_wrapper\">" +
                               " <h2 class=\"pb_title\">" + pub[0].Title[i] + "</h2>" +
                                "<div class=\"clear\"></div>" +
                       " </div>" +
                    "<p>" + pub[0].Description[i] + "</p>" +
                    "</li>";
            }
        }
        content[1] = language;
        content[2] = description;
        return content;

    }


    /// <summary>
    /// This method return all publications  for  diferents dependences and tags
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="id_dependence"></param>
    /// <returns>publications</returns>
    public publications[] getPublication(int id_tag, int id_dependence, int limit)
    {
        String SQL = "select TOP " + limit + " pub.*, pr.name +'  '+ pr.last_name as posted_by_name from publications pub inner join  profile pr on pr.id = pub.posted_by where  id_dependence = " + id_dependence + "  and id_tag = " + id_tag + " and pub.state = 1 order by pub.date_publication DESC";
        List<publications> publication = new List<publications>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            int co = 0;
            while (reader.Read())
            {
                publications pub = new publications();
                pub.Id = Convert.ToInt32(reader["id"]);
                pub.Posted_by = Convert.ToInt32(reader["posted_by"]);
                pub.Id_tag = Convert.ToInt32(reader["id_tag"]);
                pub.Date_publication = Convert.ToDateTime(reader["date_publication"]);
                pub.Multilanguage = Convert.ToInt32(reader["multilanguage"]);
                pub.Image = reader["image"].ToString();
                pub.Posted_by_name = reader["posted_by_name"].ToString();
                publication.Add(pub);
            }
            reader.Close();
            for (int i = 0; i < publication.ToArray().Length; i++)
            {
                String SQL2 = "select pl.*, l.name as language_name from pub_lang pl inner join language l on l.id = pl.id_language  where pl.id_publication =" + publication.ToArray()[i].Id;
                Console.WriteLine(SQL2);
                SqlCommand cmd = new SqlCommand(SQL2, con);
                SqlDataReader r = cmd.ExecuteReader();
                co = 0;
                List<String> title = new List<String>();
                List<String> desc = new List<String>();
                List<int> id_lang = new List<int>();
                List<string> language_name = new List<string>();
                while (r.Read())
                {
                    title.Add(r["title"].ToString());
                    desc.Add(WebUtility.HtmlDecode(r["description"].ToString()));
                    id_lang.Add(Convert.ToInt32(r["id_language"]));
                    language_name.Add(r["language_name"].ToString());
                    co++;
                }
                publication.ToArray()[i].Title = title.ToArray();
                publication.ToArray()[i].Description = desc.ToArray();
                publication.ToArray()[i].Id_language = id_lang.ToArray();
                publication.ToArray()[i].Language_name = language_name.ToArray();
                r.Close();
            }
            con.Close();

        }
        catch (Exception ex) { }

        return publication.ToArray();
    }

    /// <summary>
    /// This method return all publications  for  diferents dependences and tags
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="id_dependence"></param>
    /// <returns>publications</returns>
    public publications[] getPublicationNews(int id_tag, int id_dependence, int limit, int page)
    {
        // String SQL = "select TOP " + limit + " pub.*, pr.name +'  '+ pr.last_name as posted_by_name from publications pub inner join  profile pr on pr.id = pub.posted_by where  id_dependence = " + id_dependence + "  and id_tag = " + id_tag;
        String SQL = "Exec newsPub @page = " + page + ", @RowsByPage = " + limit + ",	@id_dependence =  " + id_dependence + ", @category = " + id_tag;
        List<publications> publication = new List<publications>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            int co = 0;
            while (reader.Read())
            {
                publications pub = new publications();
                pub.Id = Convert.ToInt32(reader["id"]);
                pub.Posted_by = Convert.ToInt32(reader["posted_by"]);
                pub.Id_tag = Convert.ToInt32(reader["id_tag"]);
                pub.Date_publication = Convert.ToDateTime(reader["date_publication"]);
                pub.Multilanguage = Convert.ToInt32(reader["multilanguage"]);
                pub.Image = reader["image"].ToString();
                pub.Posted_by_name = reader["posted_by_name"].ToString();
                publication.Add(pub);
            }
            reader.Close();
            for (int i = 0; i < publication.ToArray().Length; i++)
            {
                String SQL2 = "select pl.*, l.name as language_name from pub_lang pl inner join language l on l.id = pl.id_language  where pl.id_publication =" + publication.ToArray()[i].Id;
                Console.WriteLine(SQL2);
                SqlCommand cmd = new SqlCommand(SQL2, con);
                SqlDataReader r = cmd.ExecuteReader();
                co = 0;
                List<String> title = new List<String>();
                List<String> desc = new List<String>();
                List<int> id_lang = new List<int>();
                List<string> language_name = new List<string>();
                while (r.Read())
                {
                    title.Add(r["title"].ToString());
                    desc.Add(WebUtility.HtmlDecode(r["description"].ToString()));
                    id_lang.Add(Convert.ToInt32(r["id_language"]));
                    language_name.Add(r["language_name"].ToString());
                    co++;
                }
                publication.ToArray()[i].Title = title.ToArray();
                publication.ToArray()[i].Description = desc.ToArray();
                publication.ToArray()[i].Id_language = id_lang.ToArray();
                publication.ToArray()[i].Language_name = language_name.ToArray();
                r.Close();
            }
            con.Close();

        }
        catch (Exception ex) { }

        return publication.ToArray();
    }




    /// <summary>
    /// this method return only one row 
    /// </summary>
    /// <param name="id_tag"></param>
    /// <param name="id_dependence"></param>
    /// <param name="limit"></param>
    /// <returns>Array Object</returns>
    public publications[] getPublication(int id_dependence, int id_pub)
    {
        String SQL = "select  pub.*, pr.name +'  '+pr.last_name as posted_by_name from publications pub inner join  profile pr on pr.id = pub.posted_by where  pub.id_dependence = " + id_dependence + "  and pub.id = " + id_pub + " and pub.state = 1";
        List<publications> publication = new List<publications>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            int co = 0;
            while (reader.Read())
            {
                publications pub = new publications();
                pub.Id = Convert.ToInt32(reader["id"]);
                pub.Posted_by = Convert.ToInt32(reader["posted_by"]);
                pub.Id_tag = Convert.ToInt32(reader["id_tag"]);
                pub.Date_publication = Convert.ToDateTime(reader["date_publication"]);
                pub.Multilanguage = Convert.ToInt32(reader["multilanguage"]);
                pub.Image = reader["image"].ToString();
                pub.Posted_by_name = reader["posted_by_name"].ToString();
                publication.Add(pub);
            }
            reader.Close();
            for (int i = 0; i < publication.ToArray().Length; i++)
            {
                String SQL2 = "select pl.*, l.name as language_name from pub_lang pl inner join language l on l.id = pl.id_language  where pl.id_publication =" + publication.ToArray()[i].Id;
                Console.WriteLine(SQL2);
                SqlCommand cmd = new SqlCommand(SQL2, con);
                SqlDataReader r = cmd.ExecuteReader();
                co = 0;
                List<String> title = new List<String>();
                List<String> desc = new List<String>();
                List<int> id_lang = new List<int>();
                List<string> language_name = new List<string>();
                while (r.Read())
                {
                    title.Add((String)r["title"]);
                    desc.Add(WebUtility.HtmlDecode((String)r["description"]));
                    id_lang.Add(Convert.ToInt32(r["id_language"]));
                    language_name.Add((String)r["language_name"]);
                    co++;
                }
                publication.ToArray()[i].Title = title.ToArray();
                publication.ToArray()[i].Description = desc.ToArray();
                publication.ToArray()[i].Id_language = id_lang.ToArray();
                publication.ToArray()[i].Language_name = language_name.ToArray();
            }
            con.Close();
        }
        catch { }
        return publication.ToArray();
    }


    public String publicationformatLarge(int id_tag, int id_dependence, int limit, String pathImage, String pathPage)
    {
        publications[] pub = getPublication(id_tag, id_dependence, limit);
        string publication = "";
        for (int i = 0; i < pub.Length; i++)
        {
            if (i == 0)
            {
                publication += "<div class=\"row\"> " +
                            "<ul class=\"portfolio group\"  >";
            }

            if (i == 4)
            {
                publication += "<div class=\"row\"> " +
                              "<ul class=\"portfolio group\"  >";
            }
            publication += "<li class=\"span3 in\"  data-id=\"id-1\" data-type=\"advertising\">" +
                     "<div class=\"view\">" +
                      "<div class=\"h_port_image_p\">" +
                       "<a href=\"" + pathImage + "" + pub[i].Image + "\" title=\"\" data-rel=\"prettyPhoto[portfolio]\" class=\"view_image\">" +
                          "<img src=\"" + pathImage + "" + pub[i].Image + "\" alt=\"\">" +
                          "<div class=\"link_overlay icon-search\"></div>" +
                       "</a>" +
                      "</div>" +
                       "<span class=\"clear\"></span>" +
                    "</div>" +
                     "<div class=\"view_title_port_p\">" +
                          "<a href=\"" + pathPage + "?idp=" + pub[i].Id + "\"><h4>" + pub[i].Title[0] + "</h4></a>" +
                          "<span class=\"port_cat\"><p>" + pub[i].Description[0].Substring(0, 15) + "...</p> </span>" +
                      "<span class=\"clear\"></span>" +
                    "</div>" +
                    "<div class=\"port_read_more_p\"><a href=\"" + pathPage + "?idp=" + pub[i].Id + "\">Mas Información <i class=\"icon_port_more_p\"></i></a> </div>" +
                 "</li>";

            if (i == 3)
            {
                publication += "</ul>" +
                                "<div class=\"clear\"></div>	" +
                            "</div>  ";
            }

            if (i == (pub.Length - 1))
            {
                publication += "</ul>" +
                                "<div class=\"clear\"></div>	" +
                            "</div>  ";
            }

        }
        return publication;
    }




    /// <summary>
    /// This method return all publications  for  diferents dependences and tags
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="id_dependence"></param>
    /// <returns>publications</returns>
    public publications[] getPublication(int id_dependence)
    {
        String SQL = "select  pub.*, pr.name +'  '+ pr.last_name as posted_by_name from publications pub inner join  profile pr on pr.id = pub.posted_by where  id_dependence = " + id_dependence ;
        List<publications> publication = new List<publications>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            int co = 0;
            while (reader.Read())
            {
                publications pub = new publications();
                pub.Id = Convert.ToInt32(reader["id"]);
                pub.Posted_by = Convert.ToInt32(reader["posted_by"]);
                pub.Id_tag = Convert.ToInt32(reader["id_tag"]);
                pub.Date_publication = Convert.ToDateTime(reader["date_publication"]);
                pub.Multilanguage = Convert.ToInt32(reader["multilanguage"]);
                pub.Image = reader["image"].ToString();
                pub.Posted_by_name = reader["posted_by_name"].ToString();
                pub.State = Convert.ToInt32(reader["state"]);
                publication.Add(pub);
            }
            reader.Close();
            for (int i = 0; i < publication.ToArray().Length; i++)
            {
                String SQL2 = "select pl.*, l.name as language_name from pub_lang pl inner join language l on l.id = pl.id_language  where pl.id_publication =" + publication.ToArray()[i].Id;
                Console.WriteLine(SQL2);
                SqlCommand cmd = new SqlCommand(SQL2, con);
                SqlDataReader r = cmd.ExecuteReader();
                co = 0;
                List<String> title = new List<String>();
                List<String> desc = new List<String>();
                List<int> id_lang = new List<int>();
                List<string> language_name = new List<string>();
                List<int> id_pubLang = new List<int>();
                while (r.Read())
                {
                    title.Add(r["title"].ToString());
                    desc.Add(r["description"].ToString());
                    id_lang.Add(Convert.ToInt32(r["id_language"]));
                    language_name.Add(r["language_name"].ToString());
                    id_pubLang.Add(Convert.ToInt32(r["id"]));
                    co++;
                }
                publication.ToArray()[i].Title = title.ToArray();
                publication.ToArray()[i].Description = desc.ToArray();
                publication.ToArray()[i].Id_language = id_lang.ToArray();
                publication.ToArray()[i].Language_name = language_name.ToArray();
                publication.ToArray()[i].Id_publang = id_pubLang.ToArray();
                r.Close();
            }
            con.Close();

        }
        catch (Exception ex) { }

        return publication.ToArray();
    }
    public pubLang getItemPub(int id_pub)
    {
         pubLang pl =  new pubLang();
         String SQL2 = "select pl.*, pb.state as estado from pub_lang pl  inner join  publications pb  on pl.id_publication = pb.id where pl.id =" +id_pub;
         try{
         SqlConnection con = db.conexion();
         con.Open();
                Console.WriteLine(SQL2);
                SqlCommand cmd = new SqlCommand(SQL2, con);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    pl.Title = r["title"].ToString();
                    pl.Description = r["description"].ToString();
                    pl.Id_language = Convert.ToInt32(r["id_language"]);
                    pl.Id = Convert.ToInt32(r["id"]);
                    pl.State = Convert.ToInt32(r["estado"]);
                }            
            con.Close();
        }
        catch (Exception ex) { }
        return pl;
    }

    public publications getPub(int id_pub)
    {
        publications pub = new publications();
        String SQL2 = "select pub.* from publications pub inner join pub_lang pl on pl.id_publication = pub.id where pl.id_publication = " + id_pub;
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            Console.WriteLine(SQL2);
            SqlCommand cmd = new SqlCommand(SQL2, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                pub.Id = Convert.ToInt32(r["id"]);
                pub.Id_tag = Convert.ToInt32(r["id_tag"]);
               
            }
            con.Close();
        }
        catch (Exception ex) { }
        return pub;
    }





    public Boolean SavePublication(publications pub, int id_user)
    {
        String SQL = "INSERT INTO  publications (posted_by,id_tag, id_dependence, date_publication, multilanguage, image, [state])" +
                     "VALUES(" + pub.Posted_by + ", " + pub.Id_tag + ", " + pub.Id_dependence + ", GetDate()  ," + pub.Multilanguage + ", '" + pub.Image + "' , "+pub.State+" )";
        if (db.ejecutar(SQL))
        {
            for (int i = 0; i < pub.Title.Length; i++)
            {
                String SQl2 = "INSERT INTO  pub_lang ( id_language, id_publication, title, description)" +
                              " VALUES (" + pub.Id_language[i] + ", (select max(id) from publications where posted_by = " + pub.Posted_by + ")  ,'" + pub.Title[i] + "', '" + pub.Description[i] + "')";
                db.ejecutar(SQl2);
            }

            return true;
        }
        else { return false; }
    }
    /// <summary>
    /// /
    /// </summary>
    /// <param name="id_publication"></param>
    /// <returns></returns>
    public Boolean deletePublication(int id_publication)
    {
        String SQL = "delete from publications where id  = " + id_publication;
        return db.ejecutar(SQL);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id_pub_lang"></param>
    /// <returns></returns>
    public Boolean deletePubLang(int id_pub_lang) {
        String SQL = "delete from pub_lang where id = "+id_pub_lang;
        return db.ejecutar(SQL);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pub"></param>
    /// <returns></returns>
    public Boolean updatePublication(publications pub) {
        if (pub.Image != "")
        {
            String SQL = "UPDATE  publications " +
                        "   SET  [id_tag] =" + pub.Id_tag + " , [multilanguage] = 1, [image] = '" + pub.Image + "'" +", [state] = "+pub.State+
                       " WHERE id= (select  id_publication from pub_lang where id="+ pub.Id+")" ;
            return db.ejecutar(SQL);
        }
        else {
            String SQL = "UPDATE  publications " +
                            "   SET  [id_tag] =" + pub.Id_tag + " ,  [multilanguage] = 1"  +" , [state] = "+pub.State+
                            " WHERE id= (select  id_publication from pub_lang where id=" + pub.Id + ")";
            return db.ejecutar(SQL);
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pub"></param>
    /// <returns></returns>
    public Boolean updatePubLang(pubLang pub) {
        String SQL = "UPDATE pub_lang"+
                     "  SET [id_language] ="+pub.Id_language+",[title] ='"+pub.Title+"',[description] = '"+pub.Description+
                     "' WHERE id = "+pub.Id;
        return db.ejecutar(SQL);
    }

    public Boolean saveNewVersion(pubLang pub) {
        String SQL = "INSERT INTO pub_lang ([id_language],[id_publication],[title],[description])"+
                    " VALUES (" + pub.Id_language + ",(select id_publication from pub_lang where id =" + pub.Id_publication + "),'" + pub.Title + "','" + pub.Description + "')";
        return db.ejecutar(SQL);
    }

    public String TableDataOptions(int id_dependence, Users usr, profile pf, String page)
    {
        publications[] publ = getPublication(id_dependence);
        String ListData = "";
        for (int i = 0; i < publ.Length; i++)
        {
            for (int j = 0; j < publ[i].Title.Length; j++)
            {
                ListData += "<tr>" +
                                "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page, publ[i].Id_publang[j]) + "<a href=\"" + page + "?action=4&idItem=" + publ[i].Id + "\" class=\"btn btn-primary btn-label-left\">Eliminar Publicacion</a></td>" +
                                "<td>" + publ[i].Title[j] + "</td>" +
                                 "<td>" + publ[i].Description[j].Substring(0, Convert.ToInt32(publ[i].Description[j].Length*0.5)) + "</td>" +
                                "<td>" + publ[i].Language_name[j] + "</td>" +
                            "</tr>";
            }
        }
        return ListData;
    }


}