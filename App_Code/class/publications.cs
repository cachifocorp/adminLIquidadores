using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// this class is a data template for publications 
/// </summary>
public class publications
{
    private int id;
    private String[] title;
    private String[] description;
    private int posted_by;
    private String posted_by_name;    
    private int id_tag;
    private DateTime date_publication;
    private int id_dependence;   
    private int[] id_language;
    private String[] language_name;    
    private int multilanguage;
    private String image;
    private int[] id_publang;
    private int state;

    

    
       
	public publications()
	{
        this.id = 0;
        this.title = null;
        this.description = null;
        this.posted_by = 0;
        this.id_tag = 0;
        this.date_publication = new DateTime();
        this.id_language = null;
        this.image = "";
        this.posted_by_name ="";
        this.language_name = null;
	}

    public publications(int pId, string[] pTitle, string[] pDescription, int pPosted_by,String pPosted_by_name, int pId_tag,
        DateTime pDate_publication, int[] pId_language, String[] pLanguage_name, String pImage) {
            this.id = pId;
            this.title = pTitle;
            this.description = pDescription;
            this.posted_by = pPosted_by;
            this.posted_by_name = pPosted_by_name;
            this.id_tag = pId_tag;
            this.date_publication = pDate_publication;
            this.id_language = pId_language;
            this.image = pImage;
            this.language_name = pLanguage_name;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }


    public String[] Title
    {
        get { return title; }
        set { title = value; }
    }

    
    public int Posted_by
    {
        get { return posted_by; }
        set { posted_by = value; }
    }

    public String Posted_by_name
    {
        get { return posted_by_name; }
        set { posted_by_name = value; }
    }

    public int Id_tag
    {
        get { return id_tag; }
        set { id_tag = value; }
    }

    public DateTime Date_publication
    {
        get { return date_publication; }
        set { date_publication = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
    }

    public int[] Id_language
    {
        get { return id_language; }
        set { id_language = value; }
    }

    public String[] Language_name
    {
        get { return language_name; }
        set { language_name = value; }
    }

    public int Multilanguage
    {
        get { return multilanguage; }
        set { multilanguage = value; }
    }

    public String[] Description
    {
        get { return description; }
        set { description = value; }
    }
    public String Image
    {
        get { return image; }
        set { image = value; }
    }

    public int[] Id_publang
    {
        get { return id_publang; }
        set { id_publang = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }
}