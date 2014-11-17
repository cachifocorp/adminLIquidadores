using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for man_Project
/// </summary>
public class man_Project
{
    clsDb db = new clsDb();
	public man_Project(){}


    /// <summary>
    /// this method will consult  information in database  and create an Object list to be processed later
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="limit"></param>
    /// <returns>Object list</returns>
    private projects[] getInfoProjects(int id_dependence, int limit, int featured) {
        String SQL = "Select TOP " + limit + " p.*, t.name as name_tag, pr.name+'  '+pr.last_name as posted  from project p inner join tag t on t.id = p.id_tag inner join profile pr on pr.id = p.posted_by where featured = " + featured + " and id_dependence = " + id_dependence+" and [state] = 1";
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
                project.Add(p);
            }
            con.Close();
        }
        catch{ }
        
        return project.ToArray();
    }


    /// <summary>
    /// this method will consult  information in database  and create an Object list to be processed later
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="featured"></param>
    /// <param name="id"></param>
    /// <returns>Object List</returns>
    private projects[] getOneProject(int id_dependence,  int id)
    {
        String SQL = "Select  p.*, t.name as name_tag, pr.name+'  '+pr.last_name as posted  from project p inner join pro_category t on t.id = p.id_tag inner join profile pr on pr.id = p.posted_by where p.id_dependence = " + id_dependence + " and p.id = " + id + " and [state] = 1 ";
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
                project.Add(p);
            }
            con.Close();
        }
        catch { }
        return project.ToArray();
    }

    /// <summary>
    /// this method get information about project in a small formal definited 
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="limit"></param>
    /// <returns> data in the format String  ready for print</returns>
    public String getProjectFormatSmall(int id_dependence, int limit, int featured, String pathImage) {
        projects[] project = getInfoProjects( id_dependence,  limit, featured);
        String pub = "";
        for (int i = 0; i < project.Length; i++) {
            pub += "<li class=\"span6\">"+		
			           "<div class=\"view_title_port\">"+
                            "<a href=\"project.aspx?pj=" + project[i].Id + "\"><h4>" + project[i].Name + "</h4></a>" +
						    "<span class=\"port_cat\"><p>"+project[i].Description+"</p> </span>"+
                            "<span class=\"clear\"></span>"+
                        "<a href=\"project.aspx?pj=" + project[i].Id + "\">"+
                        "<div class=\"port_read_more\">Más Información <i class=\"icon_port_more\"></i></div></a>" +
				     " </div>"+		   
			           "<div class=\"view\">"+
				        "<div class=\"h_port_image\">"+
                        " <a href=\"images/projects/"+project[i].Pic+"\"  data-rel=\"prettyPhoto[portfolio]\" class=\"view_image\">"+
                            "<img src=\"" + pathImage + "" + project[i].Pic + "\" alt=\"\">" +				
						    "<div class=\"link_overlay icon-search\"></div>"+
					     "</a>"+
					    "</div>"+
                      "</div>"+
                    "</li> ";        
        }
        return pub;
    }

    /// <summary>
    /// this method gets information abut project  in a format big definited  
    /// </summary>
    /// <param name="id_dependence"></param>
    /// <param name="limit"></param>
    /// <returns>will return a formated list String ready for print</returns>
    public String getprojectFormatbig(int id_dependence, int limit, int featured, String pathImage){
        projects[] project = getInfoProjects( id_dependence,  limit, featured);
        String pub = "";
        for (int i = 0; i < project.Length; i++) {
            pub += "<li class=\"span4\" data-id=\"id-" + project[i].Id + "\" data-type=\"annoucement\">" +
                       "<div class=\"view\">" +
                        "<div class=\"h_port_image_p\">" +
                         "<a href=\"" + pathImage + "" + project[i].Pic + "\" title=\"\" data-rel=\"prettyPhoto[portfolio]\" class=\"view_image\">" +
                            "<img src=\"" + pathImage + "" + project[i].Pic + "\" height=\"504\" width=\"593\" alt=\"\">" +
                            "<div class=\"link_overlay icon-search\"></div>" +
                         "</a>" +
                        "</div>" +
                         "<span class=\"clear\"></span>" +
                      "</div>" +
                       "<div class=\"view_title_port_p\">" +
                            "<a href=\"project.aspx?pj=" + project[i].Id + "\"><h4>" + project[i].Name + "</h4></a>" +
                            "<span class=\"port_cat\"><p> " + project[i].Description.Substring(0, Convert.ToInt32(project[i].Description.Length * 0.5)) + " </p> </span>" +
                        "<span class=\"clear\"></span>" +
                      "</div>" +
                      "<div class=\"port_read_more_p\"><a href=\"project.aspx?pj=" + project[i].Id + "\">Leer Más  <i class=\"icon_port_more_p\"></i></a></div>" +
                   "</li>";
        }
        return pub;
    }


    public String getPostProject(int id_dependence,  int id ,String pathImage) {
        projects[] project = getOneProject( id_dependence,id);
        String pub = "";
        for (int i = 0; i < project.Length; i++) {

            pub = "<div class=\"span12\" >" +
                "<div class=\"slider_wrapper\">"	+		    
		           "<div class=\"fullwidthbanner-container\">"+
						"<div class=\"fullwidthbanner\">"+
                             "<ul id=\"Slider_Sliders\">" +
                                this.ProjectSliderbyID(id, pathImage)+
                             "</ul>"+
                        "</div>"+
                    "</div>"+
                "</div>"+
            "</div> " +
            "<div class=\"span12\">" +
             " <div class=\"view_title_ps\"> " +
                    "<div class=\"one_third\">	" +
                             "<div class=\"project_details\">" +
                                "<h3>Información del proyecto</h3>" +
                               " <p><span>Autor:</span> <a href=\"#\">" + project[i].Autor_project + "</a></p>" +
                                "<p><span>Fecha:</span> " + project[i].Made_date.ToString("MMMM dd, yyyy") + "</p>" +
                                "<p><span>Categoria:</span> <a href=\"#\">" + project[i].Tag_name + "</a></p>" +
                                "<span class=\"bg_split\"></span>" +
                            "</div>	" +
                    "</div> " +
                    "<div class=\"two_thirds\">" +
                               "<div class=\"view_title_port_p_2\">" +
                                    "<a href=\"#\"><h4>" + project[i].Name + "</h4></a>" +
                                    "<span class=\"port_cat\"><p>" + project[i].Description.Substring(0, Convert.ToInt32(project[i].Description.Length * 0.5)) + "</p>" +
                                    "</span>" +
                                "<span class=\"clear\"></span>	" +
                              "</div>	" +
                    "</div> " +
                "<div class=\"clearfix\"></div>" +
             " </div> " +
            "</div>" +
            "<div class=\"clearfix\"></div>";	
		
        }

        return pub;
    }




    /*=======================================
     *          Slider Pagina
     * ======================================
     */


    public SliderProject[] getImagesSliderByproject(int id) {
        String SQL = "select * from sliderproject where id_project = " + id;
        List<SliderProject> slider = new List<SliderProject>();
         try
         {
             SqlConnection con = db.conexion();
             con.Open();
             SqlCommand com = new SqlCommand(SQL, con);
             SqlDataReader reader = com.ExecuteReader();
             while (reader.Read())
             {
                 SliderProject sp = new SliderProject();
                 sp.Id= Convert.ToInt32(reader["id"]);
                 sp.Src = reader["img"].ToString();
                 sp.Id_project = Convert.ToInt32(reader["id_project"]);
                 slider.Add(sp);
             }
             con.Close();
             return slider.ToArray();
         }
         catch (Exception e) {

             return slider.ToArray();
         }
    }

    public String ProjectSliderbyID(int id, String ruteImage) {

        SliderProject[] imgP = this.getImagesSliderByproject(id);
        String Sl = "";
        for (int i = 0; i < imgP.Length; i++) {
            Sl += "<li data-transition=\"fade\">";
            Sl+="<img src=\""+ruteImage+imgP[i].Src+"\"  >";
            Sl += "</li>";
        }
        return Sl;
    }
    
}