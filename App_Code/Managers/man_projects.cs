using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_projects
/// </summary>
public class man_projects
{
    clsDb db = new clsDb();
	public man_projects(){}

    public int getIdLastProject(int id_dependence) {
        String SQL = "Select max(id) as ultimate from project where id_dependence = "+id_dependence;
        int amount = 0;
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                amount = Convert.ToInt32(reader["ultimate"]);
            }
            con.Close();
            return amount;
        }
        catch (Exception e) {
            return  0;
        }
    }
    public projects getdataProject( int id)
    {
        String SQL = "Select  p.*, t.name as name_tag, pr.name+'  '+pr.last_name as posted  from project p inner join tag t on t.id = p.id_tag inner join profile pr on pr.id = p.posted_by where  p.id = " + id;
        projects p = new projects();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {                
                p.Id = Convert.ToInt32(reader["id"]);
                p.Name = reader["name"].ToString();
                p.Description = reader["description"].ToString();
                p.Autor_project = reader["autor_project"].ToString();
                p.Made_date = Convert.ToDateTime(reader["made_date"]);
                p.Posted_by = reader["posted"].ToString();
                p.Posted_by_id = Convert.ToInt32(reader["posted_by"]);
                p.Id_tag = Convert.ToInt32(reader["id_tag"]);
                p.Tag_name = reader["name_tag"].ToString();
                p.Pic = reader["pic"].ToString();
                p.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                p.Featured = Convert.ToInt32(reader["featured"]);
                p.Lat = Convert.ToDouble(reader["lat"]);
                p.Lat = Convert.ToDouble(reader["lon"]);
                p.Id_city = Convert.ToInt32(reader["id_city"]);
                p.Id_client = Convert.ToInt32(reader["id_client"]);
                p.State = Convert.ToInt32(reader["state"]);
                 
            }
            con.Close();
        }
        catch { }
        return p;
    }

    private projects[] getInfoProjects(int id_dependence)
    {
        String SQL = "Select p.*, t.name as name_tag, pr.name+'  '+pr.last_name as posted  from project p inner join tag t on t.id = p.id_tag inner join profile pr on pr.id = p.posted_by where  id_dependence = " + id_dependence;
        List<projects> project = new List<projects>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                projects p = new projects();
                p.Id = Convert.ToInt32(reader["id"]);
                p.Name = reader["name"].ToString();
                p.Description = reader["description"].ToString();
                p.Autor_project = reader["autor_project"].ToString();
                p.Made_date = Convert.ToDateTime(reader["made_date"]);
                p.Posted_by = reader["posted"].ToString();
                p.Posted_by_id = Convert.ToInt32(reader["posted_by"]);
                p.Id_tag = Convert.ToInt32(reader["id_tag"]);
                p.Tag_name = reader["name_tag"].ToString();
                p.Pic = reader["pic"].ToString();
                p.Id_dependence = Convert.ToInt32(reader["id_dependence"]);
                p.Featured = Convert.ToInt32(reader["featured"]);
                p.Lat = Convert.ToDouble(reader["lat"]);
                p.Lat = Convert.ToDouble(reader["lon"]);
                p.Id_city = Convert.ToInt32(reader["id_city"]);
                p.Id_client = Convert.ToInt32(reader["id_client"]);
                p.State = Convert.ToInt32(reader["state"]);
                project.Add(p);
            }
            con.Close();
        }
        catch { }

        return project.ToArray();
    }

    public void  saveImagesSlider(String[] namesFiles,int id_lastProject)
    {
        for (int i = 0; i < namesFiles.Length; i++) {
            
            String SQL = "INSERT INTO sliderproject ([img],[id_project]) VALUES('"+namesFiles[i]+"',"+id_lastProject+")";
            db.ejecutar(SQL);
        }
        
    }

    public SliderProject[] getImagesSlider(int id_project) {
        String SQL = "SELECT * FROM  sliderproject where id_project = "+id_project;
        List<SliderProject> slp = new List<SliderProject>();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                SliderProject sl = new SliderProject();
                sl.Id = Convert.ToInt32(reader["id"]);
                sl.Img = reader["img"].ToString();
                sl.Id_project = Convert.ToInt32(reader["id_project"]);
                slp.Add(sl);
            }
            con.Close();
            return slp.ToArray();
        }
        catch (Exception e) {
            return slp.ToArray();
        
        }
    }

    public Boolean saveProject(projects pro) {
        String SQL = "INSERT INTO project (name ,description ,autor_project ,made_date ,posted_by ,id_tag ,pic ,id_dependence ,featured ,lat ,lon ,id_city ,id_client, [state])"+
        " VALUES ('"+pro.Name+"' , '"+pro.Description+"', '"+pro.Autor_project+"', "+pro.Made_date.ToString("dd/MM/yyyy")+", "+pro.Posted_by_id+", "+pro.Id_tag+", '"+pro.Pic+"', "+pro.Id_dependence+", "+pro.Featured+", "+pro.Lat+", "+pro.Lon+", "+pro.Id_city+", "+pro.Id_client+","+pro.State+")";
        return db.ejecutar(SQL);
    }

    public Boolean deleteProject(int id_project) {
        String SQL = "DELETE FROM project where id = "+id_project;
        return db.ejecutar(SQL);
    }

    public Boolean updateProject(projects project,int ver) {        
        if (ver == 1)
        {
            String SQL = "UPDATE project" +
                    "  SET [name] ='" + project.Name + "' ,[description] = '" + project.Description + "' ,[autor_project] = '" + project.Autor_project + "' ,[made_date] = '" + project.Made_date.ToString("yyyy/MM/dd") + "' ,[posted_by] = " + project.Posted_by_id + " ,[id_tag] = " + project.Id_tag + " ,[pic] = '" + project.Pic + "' ,[id_dependence] = '" + project.Id_dependence + "' ,[featured] = " + project.Featured + " ,[lat] = " + project.Lat + " ,[lon] = " + project.Lon + " ,[id_city] = " + project.Id_city + " ,[id_client] =  " + project.Id_client + ", [state] = "+project.State+
                    " WHERE id =  " + project.Id;
            return db.ejecutar(SQL);
        }
        else {
            String SQL = "UPDATE project" +
                     "  SET [name] ='" + project.Name + "' ,[description] = '" + project.Description + "' ,[autor_project] = '" + project.Autor_project + "' ,[made_date] = '" + project.Made_date.ToString("yyyy/MM/dd") + "' ,[posted_by] = " + project.Posted_by_id + " ,[id_tag] = " + project.Id_tag + "  ,[id_dependence] = '" + project.Id_dependence + "' ,[featured] = " + project.Featured + " ,[lat] = " + project.Lat + " ,[lon] = " + project.Lon + " ,[id_city] = " + project.Id_city + " ,[id_client] =  " + project.Id_client + ", [state] = " + project.State +
                     " WHERE id =  " + project.Id;
            return db.ejecutar(SQL);
        }        
    }

    public String TableDataOptions(int id_dependence, Users usr, profile pf, String page)
    {
        projects[] pro = getInfoProjects(id_dependence);
        String ListData = "";
        for (int i = 0; i < pro.Length; i++)
        {
            ListData += "<tr>" +
                            "<td>" + genericFunctions.OptionsRoleBasicActions(usr, pf, page, pro[i].Id) + "</td>" +
                            "<td>" + pro[i].Name + "</td>" +
                             "<td>" + pro[i].Autor_project + "</td>" +
                            "<td>" + pro[i].Description + "</td>" +
                        "</tr>";
        }

        return ListData;
    }

    #region update and delete imageSlider

    public Boolean deletePhoto(int id_image) {
        String SQL = "DELETE FROM sliderproject where id = "+id_image;
        return db.ejecutar(SQL);
    }

    public Boolean deleteAndUpdatePhoto(int id_image, String name, int id_project) {
        String SQL = "select img from sliderproject where id = "+id_image;
        SliderProject sl = new SliderProject();
        Boolean res = false;
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                sl.Img = reader["img"].ToString();                
            }

            if (!name.Equals(sl.Img))
            {
                deletePhoto(id_image);
            }
            else {
               if(deletePhoto(id_image)){
                  res = updatePhotoSlider(id_project);
               }
            }
            con.Close();
            return res;
        }
        catch (Exception e) {
            return res;
        }
    }

    private Boolean updatePhotoSlider(int id_project){
        String SQL = "select top 1 img from sliderproject where id_project = "+id_project;
         SliderProject sl = new SliderProject();
        try
        {
            SqlConnection con = db.conexion();
            con.Open();
            SqlCommand com = new SqlCommand(SQL, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                sl.Img = reader["img"].ToString();                
            }
            con.Close();
            String SQLUpdate = "UPDATE project  SET [pic] = '" + sl.Img + "'  WHERE id =  " + id_project;
            return db.ejecutar(SQLUpdate);
        }catch(Exception e){
            return false;
        }    
        
    }
    #endregion

    public String getPhotosSliderFormat(int id_project,String path) {
        SliderProject[] sl = getImagesSlider(id_project);
        String table = "<table>";
        String listData = "<tr>";
        String listOption = "<tr>";
        for (int i = 0; i < sl.Length; i++) {
            listData += "<td><img src=\""+path+sl[i].Img+"\" width=\"100\"></td>";
            listOption += "<td><a href=\"#"+sl[i].Id+"|"+sl[i].Img+"|"+sl[i].Id_project+"\"  class=\"delPhoto\">Eliminar</a></td>";
        }
        listOption += "</tr>";
        listData += "</tr>";

        table += listOption + listData;
        table += "</table>";
        

        return table;
    }

    
}