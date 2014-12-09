<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Site_Pages_consultas_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content_page" Runat="Server">
   <form runat ="server">
    <div class="content">	
     <div class="page_wrapper">	
	     <div class="page_wrapper_inner_c">	 
	    <div class="container content_wrapper_section">  	  	  		
          <div class="row">
              <div class="span4"></div>
              <div class="span4">
						    <input  type="text" placeholder="NIT"/>
						    <input type="password" placeholder="Contraseña"/>
                            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" />
              </div>
              <div class="span4"></div>
              </div>
            </div>
             </div>
         </div>
      </div>
   </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

