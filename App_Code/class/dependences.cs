using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dependences
/// </summary>
public class dependences
{
    private int id;    
    private String name;   
    private String dependence_logo;    
    private String address;    
    private int id_city;   
    private int id_company;    
    private String company_name;    
    private double lat;    
    private double lon;
    private String url;
    private String phone;    
    private String email;   

   
	public dependences()
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

    public String Dependence_logo
    {
        get { return dependence_logo; }
        set { dependence_logo = value; }
    }

    public String Address
    {
        get { return address; }
        set { address = value; }
    }

    public int Id_city
    {
        get { return id_city; }
        set { id_city = value; }
    }

    public int Id_company
    {
        get { return id_company; }
        set { id_company = value; }
    }

    public String Company_name
    {
        get { return company_name; }
        set { company_name = value; }
    }

    public double Lat
    {
        get { return lat; }
        set { lat = value; }
    }

    public double Lon
    {
        get { return lon; }
        set { lon = value; }
    }

    public String Url
    {
        get { return url; }
        set { url = value; }
    }

    public String Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public String Email
    {
        get { return email; }
        set { email = value; }
    }
}