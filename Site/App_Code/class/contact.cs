using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for contact
/// </summary>
public class contact
{
    private int id;
    private String name;
    private String address;
    private String phone;
    private int id_city;
    private String email;
    private String file_name;
    private String comment;
    private int type;
    private int id_dependence;
    
	public contact(){}

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

    public int Id_city
    {
        get { return id_city; }
        set { id_city = value; }
    }

    public String Email
    {
        get { return email; }
        set { email = value; }
    }

    public String File_name
    {
        get { return file_name; }
        set { file_name = value; }
    }

    public String Comment
    {
        get { return comment; }
        set { comment = value; }
    }

    public int Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
    }
}