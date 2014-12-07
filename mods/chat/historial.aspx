<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="historial.aspx.cs" Inherits="mods_chat_historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <form id="Form1" runat="server">
        <div class="row">
            <div class="box-header">
				        <div class="box-name">
					        <i class="fa fa-usd"></i>
					        <span>Historial de Chat</span>
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
                       <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Acción</th>
                                    <th>Cliente</th>
                                    <th>Correo</th>
                                    <th>Fecha</th>
                                    
						        </tr>
					        </thead>
					        <tbody id="List_menus" runat="server">
					        <%=getHistorial()%>
                            </tbody>
                        </table>
                         <div id="actions" runat="server"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" runat="Server">
</asp:Content>

