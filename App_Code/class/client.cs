using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// this class is a template for  manage data of client
/// </summary>
public class client
{
    private int id;
    private String name;   
    private String description;   
    private String logo_client;    
    private String comment;    
    private int id_dependence;
    private String team_photo;
    private String team_name;
    private String position_company;
    private int state;

    

 

	public client()
	{
	}

    public client(int pId,String pName, String pDescription, String pLogo_client, String pComment, int pId_Dependence, String pTeam_photo, String pTeam_name, String pPosition_Company) {
        this.id = pId;
        this.name = pName;
        this.description = pDescription;
        this.logo_client = pLogo_client;
        this.comment = pComment;
        this.id_dependence = pId_Dependence;
        this.team_photo = pTeam_photo;
        this.team_name = pTeam_name;
        this.position_company = pPosition_Company;

    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public String Description
    {
        get { return description; }
        set { description = value; }
    }

    public String Logo_client
    {
        get { return logo_client; }
        set { logo_client = value; }
    }

    public String Comment
    {
        get { return comment; }
        set { comment = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
    }

    public String Team_photo
    {
        get { return team_photo; }
        set { team_photo = value; }
    }

    public String Team_name
    {
        get { return team_name; }
        set { team_name = value; }
    }

    public String Position_company
    {
        get { return position_company; }
        set { position_company = value; }
    }

    public String Name
    {
        get { return name; }
        set { name = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }
}