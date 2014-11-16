<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="mods_general_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">

    <form id="Form1" runat="server">

     <div class="row">
	        <div class="col-xs-12">
		        <div class="box">
			        <div class="box-header">
				        <div class="box-name">
					        <i class="fa fa-usd"></i>
					        <span>Lista de Clientes</span>
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
			        <div class="box-content no-padding">
                        <div class="btn-group"  >
                            <asp:Button ID="btnContact" runat="server" Text="Contacto" OnClick="btnContact_Click" />
                            <asp:Button ID="btnprov" runat="server" Text="Proveedor" OnClick="btnprov_Click" />
                            <asp:Button ID="btnjob" runat="server" Text="trabajo" OnClick="btnjob_Click" />
			            </div>
                      <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Opciones</th>
							        <th>Nombre</th>
							        <th>Comentario</th>
							        <th>Ciudad</th>
                                    <th>Archivo</th>
						        </tr>
					        </thead>
					        <tbody id="list_Contact" runat="server">
					        <!-- Start: list_row -->
                            </tbody>
                        </table>
                         <div id="actions" runat="server"></div>
                    </div>
                    </div>
                </div>
            </div>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

