using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SliderProject
/// </summary>
public class SliderProject
{
    private int id;
    private String img;
    private String src;
    private int id_project;
	public SliderProject()
	{
	}

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public String Img
    {
        get { return img; }
        set { img = value; }
    }

    public int Id_project
    {
        get { return id_project; }
        set { id_project = value; }
    }

    public String Src
    {
        get { return src; }
        set { src = value; }

    }
}