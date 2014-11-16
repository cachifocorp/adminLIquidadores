<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="clients.aspx.cs" Inherits="mods_general_clients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<form id="Form1" runat="server">
   <div class="row">
	    <div id="breadcrumb" class="col-md-12">
		    <ol class="breadcrumb">
			    <li><a href="../Default.aspx">Dashboard</a></li>
			    <li><a href="#">Clientes</a></li>
		    </ol>
	    </div>
    </div>
    <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Registro</span>
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
			    <div class="box-content">
				    <h4 class="page-header">Registro de Clientes</h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
						    <label  class="col-sm-2 control-label">Nombre</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtName" runat="server" class="form-control" placeholder="Nombre del Cliente" data-toggle="tooltip" data-placement="bottom" title="Nombre del Cliente">
						    </div>
					    </div>
					    <div class="form-group">
						    <label class="col-sm-2 control-label" for="form-styles">Descripción</label>
						    <div class="col-sm-10">
								<textarea  class="form-control" rows="5" id="taDescription" runat="server"></textarea>
						    </div>
					    </div>
                         <div class="form-group has-feedback">
                             <label class="col-sm-2 control-label" for="form-styles">¿Activo?</label>
                             <div class="col-sm-1">
						        <div class="toggle-switch toggle-switch-success">
							        <label>
								        <input id="chkstate" runat="server"  type="checkbox" checked>
								        <div class="toggle-switch-inner"></div>
								        <div class="toggle-switch-switch"><i class="fa fa-check"></i></div>
							        </label>
						        </div>
					        </div> 
                          </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="form-styles">Logo Cliente</label>
						    <div class="col-sm-10">
                                <asp:FileUpload ID="flPicClient" runat="server" />
						    </div>
                        </div>
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click"/>
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="updateData" runat="server" Text="Actualizar" class="btn btn-primary btn-label-left" OnClick="UpdateData_Click" Enabled="False" />
						</div>
					</div>
                    </div>
                </div>
            </div>
         </div>
    </div>

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
                      <table class="table table-bordered table-striped table-hover table-heading table-datatable" id="datatable-1">
					        <thead>
						        <tr>
                                    <th>Opciones</th>
							        <th>Nombre</th>
							        <th>Descripcion</th>
							        <th>comentario</th>
						        </tr>
					        </thead>
					        <tbody id="list_offices" runat="server">
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

