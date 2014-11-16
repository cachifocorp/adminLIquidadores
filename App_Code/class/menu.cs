using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for menu
/// </summary>
public class menu
{
    private int id;    
    private String name;   
    private int id_parent;
    private String parent_name;    
    private String url;   
    private int activated;
    private int id_dependence;    
	public menu( int pId , String pName, int pId_parent, String pUrl, int pActivated, int pId_dependence)
	{
        this.id = pId;
        this.name = pName;
        this.id_parent = pId_parent;
        this.url = pUrl;
        this.activated = pActivated;
        this.id_dependence = pId_dependence;
    }

    public menu() { }

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

    public int Id_parent
    {
        get { return id_parent; }
        set { id_parent = value; }
    }

    public String Url
    {
        get { return url; }
        set { url = value; }
    }

    public int Activated
    {
        get { return activated; }
        set { activated = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
    }

    public String Parent_name
    {
        get { return parent_name; }
        set { parent_name = value; }
    }

}