﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mods_chat_chatespera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        setDatos();
    }

    man_chat objChat = new man_chat();
 
    public void setDatos()
    {
        List_menus.InnerHtml=objChat.GetEnEsperaAdmin(1);
        
    }
}