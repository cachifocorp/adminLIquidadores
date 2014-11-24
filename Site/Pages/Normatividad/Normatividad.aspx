<%@ Page Title="" Language="C#" MasterPageFile="~/site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="Normatividad.aspx.cs" Inherits="Pages_About_policies" %>

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
				<span class="main_t_1"> NORMATIVIDAD </span>
				<span class="main_t_2"> Resoluciones Supersalud </span>
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
    <form id="Form1" runat="server">
    <div class="content">	
        
         <div class="row" style="margin-left:10%">
               
             <div class="contact_form contact_form_h" >
             <div class="span8">  	
				<div class="input_holder">
                    <h5><b>Filtro</b></h5>
						<input class="field-name" type="text" placeholder="ej Decreto 24" id="txtTexto" runat="server" />
					</div>
					<div class="input_holder">
                    <h5>&nbsp;</h5>
						<asp:Button ID="saveData" runat="server" Text="Buscar" class="search-button" OnClick="saveData_Click" /> 
					</div>
					
                       
					

	        </div> 
                 </div>
                 </div>
     	
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlNormarividad" AllowPaging="True" style="border:1px solid black; color: black;" CssClass="table">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="N&#176;" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
                <asp:BoundField DataField="date" HeaderText="FECHA" SortExpression="date"></asp:BoundField>
                <asp:BoundField DataField="subject" HeaderText="ASUNTO" SortExpression="suject"></asp:BoundField>
                <asp:BoundField DataField="Issuingauthority" HeaderText="AUTORIDAD QUE LA EXPIDE" SortExpression="Issuingauthority"></asp:BoundField>
                <asp:BoundField DataField="postDate" HeaderText="FECHA PUBLICACION WEB" SortExpression="postDate"></asp:BoundField>
                <asp:TemplateField HeaderText="DESCARGAR" SortExpression="file">
                     <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# Bind("file") %>'>Descargar</asp:HyperLink>
                    </ItemTemplate>
                         <EditItemTemplate>
                        <asp:TextBox runat="server" Text='' ID="TextBox1"></asp:TextBox>
                    </EditItemTemplate>
                   
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sqlNormarividad" ConnectionString='<%$ ConnectionStrings:AMVConnectionString %>' SelectCommand="SELECT [id], [date], [Issuingauthority], [postDate], '&lt;a href=''../uploads/normatividad/'+[file]+''''+'target=''_blank'''+' class=''button'''+'&gt;DESCARGAR&lt;/a&gt;' as [file], [subject] FROM [regulations] ">
            
             </asp:SqlDataSource>
    </form> 
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts_down" Runat="Server">
    <script>
        $(function () {
            $(".in").attr("class", "span4");
        });
    </script>
</asp:Content>

