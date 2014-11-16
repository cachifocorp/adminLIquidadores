using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for item_module_profile
/// </summary>
public class item_module_profile
{
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    private int id_item;

    public int Id_item
    {
        get { return id_item; }
        set { id_item = value; }
    }
    private DateTime date_register;

    public DateTime Date_register
    {
        get { return date_register; }
        set { date_register = value; }
    }
    private int options;

    public int Options
    {
        get { return options; }
        set { options = value; }
    }
	public item_module_profile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}