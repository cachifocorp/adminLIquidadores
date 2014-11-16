using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// this class is used for manage data about Slider project
/// </summary>
public class SliderProject
{

    private int id;
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

    public String Src
    {
        get { return src; }
        set { src = value; }
    }

    public int Id_project
    {
        get { return id_project; }
        set { id_project = value; }
    }
}