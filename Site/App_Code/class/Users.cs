using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    private int id;
    private String username;
    private String password;
    private int id_role;
    private DateTime date_register;
    private int id_dependence;
    private int state;

    
	public Users()
	{	}

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public String Username
    {
        get { return username; }
        set { username = value; }
    }

    public String Password
    {
        get { return password; }
        set { password = value; }
    }

    public int Id_role
    {
        get { return id_role; }
        set { id_role = value; }
    }
    public DateTime Date_register
    {
        get { return date_register; }
        set { date_register = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }
}