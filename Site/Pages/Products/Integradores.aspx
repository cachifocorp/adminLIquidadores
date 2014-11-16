<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="Integradores.aspx.cs" Inherits="Pages_Products_Integradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
			.depends{
				margin-top: 55px;				
				float: left;
			}
			.logos{
				width: 20px;
				height: 10px;
			}
		</style>
        <script type="text/javascript">
			jQuery(document).ready(function($) {
				// Define any icon actions before calling the toolbar
				$('.toolbar-icons a').on('click', function( event ) {
					event.preventDefault();
				});				
				$('#normal-button-bottom').toolbar({content: '#user-options', position: 'bottom'});			

			});
		</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
    	<!-- Start Main title wrapper  -->	   
	<div class="main_title_wrapper">
		    
		<div class="page_title_wrapper">
	    <div class="container">
		 <div class="row">
		  <div class="span12">
          <div class="page_title_inner">	      			       	
				<span class="main_t_1">  INTEGRADORES </span>
				<span class="main_t_2"> AMV | Energia Y Comunicaciones </span>
				<span class="breadcrumb"> <a href="../Default.aspx">inicio </a> / INTEGRADORES </span>
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
		 		
		    <div class="row" >
		         <div class="blog_h_inner" >	        						   
			 <ul class="blog_homepage" id="pub_integrators" runat="server">				
			</ul>
                      <!-- Pagination -->		                    
		            <div class="pagi">
		                <ul id="nextPage" runat="server">		                                       
		                </ul>
		                <div class="clear"></div>
		            </div>
					
				 <div class="clear"></div>	
		    <div class="clear"></div>	
		  </div>  <!-- End Blog homepage wrapper --> 	
		  </div> <!-- End row -->
		</div>  <!-- End content wrapper section -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

