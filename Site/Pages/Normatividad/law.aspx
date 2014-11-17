<%@ Page Title="" Language="C#" MasterPageFile="~/site/Pages/masterPages/baseLine.master" AutoEventWireup="true" CodeFile="law.aspx.cs" Inherits="Pages_About_policies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content_page" Runat="Server"> 
    <div class="page-header text-center">
      <h1>Resoluciones  <small>Supersalud</small></h1>
    </div>
    <div class="content">		
				
 <div class="page_wrapper">	
	 <div class="page_wrapper_inner">
	 
	<div class="container content_wrapper_section">  
		 		
      <div class="row">
         <div class="span12">
    <form runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlNormarividad" AllowPaging="True" style="border:1px solid black; color: black;" CssClass="table">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="N&#176;" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
                <asp:BoundField DataField="date" HeaderText="FECHA" SortExpression="date"></asp:BoundField>
                <asp:BoundField DataField="subject" HeaderText="ASUNTO" SortExpression="suject"></asp:BoundField>
                <asp:BoundField DataField="Issuingauthority" HeaderText="AUTORIDAD QUE LA EXPIDE" SortExpression="Issuingauthority"></asp:BoundField>
                <asp:BoundField DataField="postDate" HeaderText="FECHA PUBLICACION WEB" SortExpression="postDate"></asp:BoundField>
                <asp:TemplateField HeaderText="DESCARGAR" SortExpression="file">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("file") %>' ID="TextBox1"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("file") %>' ID="Label1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sqlNormarividad" ConnectionString='<%$ ConnectionStrings:AMVConnectionString %>' SelectCommand="SELECT [id], [date], [Issuingauthority], [postDate], '<a href">' as [file], [subject] FROM [regulations]"></asp:SqlDataSource>
    </form>
             </div>
          </div>
        </div>
         </div>
     </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts_down" Runat="Server">
    <script>
        $(function () {
            $(".in").attr("class", "span4");
        });
    </script>
</asp:Content>

