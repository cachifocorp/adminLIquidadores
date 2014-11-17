<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="project.aspx.cs" Inherits="Pages_Projects_project_All" %>

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
				<span class="main_t_1"> PROYECTOS</span>
				<span class="main_t_2"> LO MEJOR SE HACE AQUI EN AMV </span>
				<span class="breadcrumb"> <a href="../Default.aspx">INICIO </a> / <a href="projects.aspx">PROYECTOS </a> </span>
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
    <div class="container content_wrapper_section">	 		
        <div class="row">
            <div class="port_inner_post">	
                <div class="portfolio group" id="pj_post" runat="server">
                </div>

            </div>
        </div>
    </div>
    <div class="container content_wrapper_section">
         <div class="port_wrapper_home_p">
		      <div class="block_tile_wrapper">	 
	           <span class="block_tile_1"> PROYECTOS</span>
	           <span class="block_tile_2"> AMV </span>
		      </div>
            <div class="clear"></div>		
         </div>  
        <div class="container">
	      <div class="row">		
	        <ul class="portfolio group" id="post_smalpro" runat="server"> 		
	        </ul>
	    </div>  <!-- End port wrapper -->
        </div>	
   </div> <!-- End content wrapper section --> 
 </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

