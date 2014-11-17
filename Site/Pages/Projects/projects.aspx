<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="projects.aspx.cs" Inherits="Pages_Projects_projects" %>

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
				<span class="main_t_2"> PROYECTOS RELIZADOS Y EN CURSO</span>				
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
		<div class="port_wrapper_home">
	        
			  <div class="block_tile_wrapper">	 
		       <span class="block_tile_1"> Proyectos Destacados</span>
		       <span class="block_tile_2"> | AMV </span>
			  </div>
			
	        <div class="clear"></div>		
     	</div>
      <div class="row">        							    
		<ul id="Content_page_post_policies" class="portfolio group">
            <div class="row"> 
	            <ul class="portfolio group" id="pub_featured" runat="server"> 
	            </ul>
            </div>
            </ul>
        </div>

	
		<div class="clearfix"></div>

		<div id="span12">
			<div class="port_wrapper_home">
	      
			  <div class="block_tile_wrapper">	 
		       <span class="block_tile_1"> Proyectos </span>
		       <span class="block_tile_2"> | AMV </span>
			  </div>
			
	        <div class="clear"></div>		
     	</div>
            <div class="row"> 
            <ul class="portfolio group" id ="prjs_p" runat="server">         			
	        </ul>
            </div>
		</div>
		
	
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

