using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for profile
/// </summary>
public class profile 
{

    private int id;
    private String name;
    private String last_name;
    private String identification;
    private int user_id;
    private DateTime born_date;
    private int city_id;
    private String address;
    private String phone;    
	public profile()
	{}

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

    public String Last_name
    {
        get { return last_name; }
        set { last_name = value; }
    }

    public String Identification
    {
        get { return identification; }
        set { identification = value; }
    }

    public int User_id
    {
        get { return user_id; }
        set { user_id = value; }
    }

    public DateTime Born_date
    {
        get { return born_date; }
        set { born_date = value; }
    }

    public int City_id
    {
        get { return city_id; }
        set { city_id = value; }
    }

    public String Address
    {
        get { return address; }
        set { address = value; }
    }

    public String Phone
    {
        get { return phone; }
        set { phone = value; }
    }
}