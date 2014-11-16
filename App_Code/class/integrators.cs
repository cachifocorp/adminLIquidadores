using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// this class is a template for manage data of integrators
/// </summary>
public class integrators
{
    private int id;
    private String name;
    private String description;    
    private DateTime dateRegister;   
    private String photo;
    private int id_dependence;
    private int state;

 

   
    
	public integrators()
	{	}

    public integrators( int pId, String pDescription, DateTime pDateRegister, String pPhoto, int pId_dependence)
    {
        this.id = pId;
        this.description = pDescription;
        this.dateRegister = pDateRegister;
        this.photo = pPhoto;
        this.id_dependence = pId_dependence;
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

    public DateTime DateRegister
    {
        get { return dateRegister; }
        set { dateRegister = value; }
    }

    public String Photo
    {
        get { return photo; }
        set { photo = value; }
    }

    public int Id_dependence
    {
        get { return id_dependence; }
        set { id_dependence = value; }
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