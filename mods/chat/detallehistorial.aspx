<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="detallehistorial.aspx.cs" Inherits="mods_chat_detallehistorial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <form id="Form1" runat="server">
        <div class="row">
            <div class="box-header">
				        <div class="box-name">
					        <i class="fa fa-usd"></i>
					        <span>Chat </span>
				        </div>
				        <div class="box-icons">
					        <a class="collapse-link">
						        <i class="fa fa-chevron-up"></i>
					        </a>
					        <a class="expand-link">
						        <i class="fa fa-expand"></i>
					        </a>
					        <a class="close-link">
						        <i class="fa fa-times"></i>
					        </a>
				        </div>
				        <div class="no-move"></div>
			        </div>
            <div class="col-xs-12 col-sm-12">
                <div class="box">
                    <div class="box-content no-padding">
                       <div style="width: 100%; height: 500px; overflow-y: scroll;">
                           <%=getConversacion() %>

                           
                       </div>
                         <div id="actions" runat="server"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

