using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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