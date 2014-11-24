<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="Detalle.aspx.cs" Inherits="mods_normatividad_Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <form id="Form1" runat="server">
        <div class="row">
            <div id="breadcrumb" class="col-md-12">
                <ol class="breadcrumb">
                    <li><a href="../Default.aspx">Dashboard</a></li>
                    <li><a href="#">Normatividad</a></li>
                </ol>
            </div>
        </div>
        <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Detalle de la Información</span>
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
				    <h4 class="page-header"><%=getTitulo()%> </h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">


                            <asp:HiddenField ID="HfId" runat="server" />
                            <asp:HiddenField ID="HfArchivo" runat="server" />
                            <asp:HiddenField ID="HfCodigo" runat="server" />
                              <label  class="col-sm-2 control-label">Numero
                              </label>
						    <div class="col-sm-4">
							    <input type="text" id="txtNumero" runat="server" class="form-control" 
                                    placeholder="Numero" data-toggle="tooltip" data-placement="bottom" title="Numero" required>
						    </div>
                           
						    <label  class="col-sm-2 control-label">Fecha</label>
						    <div class="col-sm-4">
							    <input type="date" id="txtFecha" runat="server" class="form-control" 
                                    placeholder="Fecha" data-toggle="tooltip" data-placement="bottom" 
                                    title="Fecha" required >
						    </div>
                            
                            <% try
                               {
                                   if (!getTitulo().Contains("Decreto"))
                                   { %>

                            <label  class="col-sm-2 control-label">Autoridad Expide</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtAutoridadExpide" runat="server" class="form-control" 
                                    placeholder="Autoridad que la Expide" data-toggle="tooltip" data-placement="bottom" 
                                    title="Autoridad que la Expide">
						    </div>
                            
                            <%}
                               }
                               catch { } %>
                            <label  class="col-sm-2 control-label">Fecha de Publicación</label>
						    <div class="col-sm-4">
							    <input type="date" id="txtFechaPublicacion" runat="server" class="form-control" 
                                    placeholder="Fecha de Publicación" data-toggle="tooltip" data-placement="bottom" 
                                    title="Fecha de Publicación" required>
						    </div>
                            <label  class="col-sm-2 control-label">Asunto</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtAsunto" runat="server" class="form-control" 
                                    placeholder="Asunto" data-toggle="tooltip" data-placement="bottom" 
                                    title="Asunto" required>
						    </div>
                            
                            <label class="col-sm-2 control-label" for="form-styles">Archivo</label>
						    <div class="col-sm-4">
                                <asp:FileUpload ID="flIcon" runat="server"  />
                                
						    </div>
                            <div id="Divguardado" runat="server" visible="false">
                                
						    <div class="col-sm-4">
                                <asp:HyperLink ID="hfLink" runat="server" Target="_blank" >Ver Archivo Guardado</asp:HyperLink>
                                </div>

                            </div>
                            
					    </div>
					    
                         
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="UpdateData" runat="server" Text="Actualizar"  class="btn btn-primary btn-label-left btn-info" Enabled="True" OnClick="UpdateData_Click" />
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="DeleteData" runat="server" Text="Eliminar" class="btn btn-primary btn-label-left btn-danger" Enabled="True" OnClick="DeleteData_Click" />
						</div>
                        <div class="col-sm-2">
                            <% Response.Write("<a href='Detalle.aspx?tipo=" + Request.Params["tipo"] + "&Codigo=" + Request.Params["Codigo"] + "' class='btn btn-primary btn-label-left btn-warning'>Cancelar</a>"); %>
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
					        <span>Datos Agregados</span>
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
                                    <th>Acción</th>
                                    <th>Numero</th>
                                    <th>Fecha</th>
                                    <th>Autoridad Expide</th>
                                    <th>Asunto</th>
						        </tr>
					        </thead>
					        <tbody id="List_menus" runat="server">
					        <%=GetGuardados()%>
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

