<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Site_Pages_consultas_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
          <!-- Start Main title wrapper  -->	 
	<div class="main_title_wrapper">
		<div class="page_title_wrapper">
	    <div class="container">
		 <div class="row">
		  <div class="span12">
          <div class="page_title_inner">	      			       	
				<span class="main_t_1">INGRESO </span>
				<span class="main_t_2"> INICIO  DE SESION EPS </span>				
		  </div>
		  </div>
		 </div>
        </div>			
      </div> <!-- End page title wrapper -->
	  <div class="clear"></div>
    </div> 	
<!-- End Main title wrapper --> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content_page" Runat="Server">
   <form runat ="server">
     <div class="row">
              <div class="span4"></div>
              <div class="span4" style="text-align:center;">
                  <p>Este espacio  es de uso exclusivo  para las EPS que hacen parte del proceso de adignacion de afiliados</p>	  	 
						    <input type="text" placeholder="NIT" id="txtnit" runat="server" style="width:100%;"/>
						    <input type="password" placeholder="Contraseña" id="txtPass" runat="server" style="width:100%;"/>
                            <asp:Button ID="btnLogin" runat="server" Text="Ingresar"  OnClick="btnLogin_Click"/>
                  <asp:Label ID="mess" runat="server" ></asp:Label>
                  <hr />
                  <p>Si suted es afiliado y desea consultar la EPS a donde fue asignado  de click <a href="EPSasignada.aspx">Aquí</a></p>
              </div>
              <div class="span4"></div>
              </div>
   </form>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

