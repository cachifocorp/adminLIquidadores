<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="faqs.aspx.cs" Inherits="Site_Pages_faqs_faqs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Slider" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content_page" Runat="Server">
       <div class="content">						
	 <div class="content_wrapper">	
	  <div class="content_wrapper_inner">	  
	 <!-- Services Block --> 	 
	  <div class="container content_wrapper_section">  
		 <div class="service_wrapper_holder">	
           <div class="container">
		     <div class="row">					 
                   <div class="span4">
				        <div class="service_wrapper">									 
							     
								<a href="#"><img src="../src/images/stuff/support.png" alt=""/></a>
								<div class="clear"></div>	
				                <div class="service_wrapper_inner"> 	      
									   <h3><a href="faqs.aspx?tipo=1">PREGUNTAS FRECUENTES</a> </h3>
									
					            </div> <!-- End service wrapper inner --> 							
					    </div>					
			   	   </div> <!-- End service wrapper -->

                   <div class="span4">
				        <div class="service_wrapper">									 
							     
								<a href="#"><img src="../src/images/stuff/support.png" alt=""/></a>
								<div class="clear"></div>	
				                <div class="service_wrapper_inner"> 	      
									   <h3><a href="faqs.aspx?tipo=2">PROCESO DE LIQUIDACIÓN DE ACREENCIAS</a> </h3>			   
					            </div> <!-- End service wrapper inner --> 							
					    </div>					
			   	   </div> <!-- End service wrapper -->
                 
                   <div class="span4">
				        <div class="service_wrapper">									 
							     
								<a href="#"><img src="../src/images/stuff/support.png" alt=""/></a>
								<div class="clear"></div>	
				                <div class="service_wrapper_inner"> 	      
									   <h3><a href="faqs.aspx?tipo=3">ACREENCIAS EXTRATEMPORANEAS</a> </h3>
					            </div> <!-- End service wrapper inner --> 							
					    </div>					
			   	   </div> <!-- End service wrapper -->			   
                   <div class="clear"></div>
		        </div><!-- End service wrapper holder -->
				</div>
             </div>				 
		 </div>  <!-- End content wrapper section -->
	    <div class="clear"></div>   
          
	 <div class="content_wrapper_section">
		 <div class="port_wrapper_home">
			<i class="icon_faq"></i>
			  <div class="block_tile_wrapper">	 
			   <span class="block_tile_2"> &nbsp; | &nbsp;  Lo que usted debe Saber</span>
			  </div>
			<div class="readmore_holder"><a href="#"><i class="icon_plus"></i></a></div>
			<div class="clear"></div>		
		 </div>  
		 <div class="row"> 	 
		  <div class="span12">    					
			<div class="faq_holder"> 
			  <div class="accordion-items" id="itemsFaqs" runat="server">
			  </div>
				<div class="clear"></div>
			 </div>			
		  </div>
		 </div>  <!-- End row -->	  
		<div class="clear"></div>	
	   </div> <!-- End content wrapper section --> 
          </div>
         </div>
           </div>
       
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content_down" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts_down" Runat="Server">
</asp:Content>

