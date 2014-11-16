using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for projects
/// </summary>
public class projects
{
    private int id;
    private String name;
    private String description;
    private String autor_project;
    private DateTime made_date;
    private int posted_by_id;
    private String posted_by;
    private int id_tag;
    private String tag_name;
    private String pic;
    private int id_dependence;
    private int featured;
    private double lat;   
    private double lon;    
    private int id_city;   
    private int id_client;
    private int state;    

	public projects()
	{
	}

     public projects(int pId, String pName, String pDescription, String pAutor_project, DateTime pMade_date, int pPosted_by_id,
         String pPosted_by, int pId_tag, String pTag_name, String pPic, int pFeatured, double pLat, double pLon, int pId_city, int pId_client) {
             this.id = pId;
             this.name = pName;
             this.description = pDescription;
             this.autor_project = pAutor_project;
             this.made_date = pMade_date;
             this.posted_by_id = pPosted_by_id;
             this.posted_by = pPosted_by;
             this.id_tag = pId_tag;
             this.tag_name = pTag_name;
             this.pic = pPic;
             this.featured = pFeatured;
             this.lat = pLat;
             this.lon = pLon;
             this.id_city = pId_city;
             this.id_client = pId_client;

    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public String Name
    {
        get { return name; }
        set { name = value; }
    }

    public String Description
    {
        get { return description; }
        set { description = value; }
    }

    public String Autor_project
    {
        get { return autor_project; }
        set { autor_project = value; }
    }

    public DateTime Made_date
    {
        get { return made_date; }
        set { made_date = value; }
    }

    public int Posted_by_id
    {
        get { return posted_by_id; }
        set { posted_by_id = value; }
    }

    public String Posted_by
    {
        get { return posted_by; }
        set { posted_by = value; }
    }

    public int Id_tag
    {
        get { return id_tag; }
        set { id_tag = value; }
    }

    public String Tag_name
    {
        get { return tag_name; }
        set { tag_name = value; }
    }

    public String Pic
    {
        get { return pic; }
        set { pic = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
    }

    public int Featured
    {
        get { return featured; }
        set { featured = value; }
    }

    public double Lat
    {
        get { return lat; }
        set { lat = value; }
    }

    public double Lon
    {
        get { return lon; }
        set { lon = value; }
    }

    public int Id_city
    {
        get { return id_city; }
        set { id_city = value; }
    }

    public int Id_client
    {
        get { return id_client; }
        set { id_client = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }
}