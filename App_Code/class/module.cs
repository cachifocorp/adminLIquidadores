using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for module
/// </summary>
public class module
{
    private int id;   
    private String name;   
   // private DateTime date_register;
    private String url;
    private String icon;

    

    public module() { }

    public module(int pId, String pName, String pUrl) {
        this.id = pId;
        this.name = pName;
       // this.date_register = pDate_register;
        this.url = pUrl;
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

    
    public String Url
    {
        get { return url; }
        set { url = value; }
    }

    public String Icon
    {
        get { return icon; }
        set { icon = value; }
    }
}