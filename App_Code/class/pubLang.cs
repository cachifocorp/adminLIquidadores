using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for pubLang
/// </summary>
public class pubLang
{
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    private int id_language;

    public int Id_language
    {
        get { return id_language; }
        set { id_language = value; }
    }
    private int id_publication;

    public int Id_publication
    {
        get { return id_publication; }
        set { id_publication = value; }
    }
    private String title;

    public String Title
    {
        get { return title; }
        set { title = value; }
    }
    private String description;

    public String Description
    {
        get { return description; }
        set { description = value; }
    }

    private int state;


    public int State
    {
        get { return state; }
        set { state = value; }
    }

	public pubLang()
	{
	}
}