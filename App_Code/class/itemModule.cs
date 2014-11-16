using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for itemModule
/// </summary>
public class itemModule
{
    private int id;
    private String name;
    private int id_module;
    private String module_name;  
    private DateTime date_register;
    private String url;

    
	public itemModule()
	{}

    public itemModule(int pId, String pName, int pId_module, DateTime pDate_register, String pUrl) {
        this.id = pId;
        this.name = pName;
        this.id_module = pId_module;
        this.date_register = pDate_register;
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

    public int Id_module
    {
        get { return id_module; }
        set { id_module = value; }
    }

    public DateTime Date_register
    {
        get { return date_register; }
        set { date_register = value; }
    }

    public String Url
    {
        get { return url; }
        set { url = value; }
    }

    public String Module_name
    {
        get { return module_name; }
        set { module_name = value; }
    }
    
}