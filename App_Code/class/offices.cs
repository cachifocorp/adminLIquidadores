using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for offices
/// </summary>
public class offices
{

    private int id;
    private String lat;
    private String lon;
    private int id_dependence;
    private String address;
    private String phone;
    private String fax;   
    private String email;
    private int id_city;
    private String city_name;  
    private String icon;

   

	public offices(){}
    public offices(int pId, String pLat, String pLon, int pId_dependence, String pAddress,
        String pPhone, String pEmail, int pId_city, String pIcon) {
            this.id = pId;
            this.lat = pLat;
            this.lon = pLon;
            this.id_dependence = pId_dependence;
            this.address = pAddress;
            this.phone = pPhone;
            this.email = pEmail;
            this.id_city = pId_city;
            this.icon = pIcon;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public String Lat
    {
        get { return lat; }
        set { lat = value; }
    }

    public String Lon
    {
        get { return lon; }
        set { lon = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
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

    public String Fax
    {
        get { return fax; }
        set { fax = value; }
    }

    public String Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Id_city
    {
        get { return id_city; }
        set { id_city = value; }
    }

    public String Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public String City_name
    {
        get { return city_name; }
        set { city_name = value; }
    }

}