using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for slider
/// </summary>
public class slider
{
    private int id;
    private String slide;
    private int id_dependence;
    private DateTime date_register;
    private String name;

    public slider()
    {

    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public String Slide
    {
        get { return slide; }
        set { slide = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
    }

    public DateTime Date_register
    {
        get { return date_register; }
        set { date_register = value; }
    }

    public String Name
    {
        get { return name; }
        set { name = value; }
    }
}