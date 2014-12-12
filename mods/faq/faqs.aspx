<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="faqs.aspx.cs" Inherits="mods_faq_faqs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <form id="Form1" runat="server">
        <div class="row">
            <div id="breadcrumb" class="col-md-12">
                <ol class="breadcrumb">
                    <li><a href="#">Dashboard</a></li>
                    <li><a href="#">Preguntas frecuentes</a></li>
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
				    <h4 class="page-header">Faqs </h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">


                            <asp:HiddenField ID="HfId" runat="server" />
                            <asp:HiddenField ID="HfArchivo" runat="server" />
                            <asp:HiddenField ID="HfCodigo" runat="server" />
                              <label  class="col-sm-2 control-label">Tipo
                              </label>
						    <div class="col-sm-4">
                                <asp:DropDownList ID="ddlTipo" runat="server">
                                    <asp:ListItem Value="1">Preguntas Frecuentes</asp:ListItem>
                                    <asp:ListItem Value="2">Liquidacion de Acreencias</asp:ListItem>
                                    <asp:ListItem Value="3">Acreencias extratemporales</asp:ListItem>
                                </asp:DropDownList>
						    </div>
                           
						    <label  class="col-sm-2 control-label">Titulo</label>
						    <div class="col-sm-4">
							    <input type="text" id="TxtTitulo" runat="server" class="form-control" 
                                    placeholder="Titulo" data-toggle="tooltip" data-placement="bottom" 
                                    title="TxtTitulo" required >
						    </div>
                           
                            <label  class="col-sm-2 control-label">Descripción</label>
						    <div class="col-sm-4">
							    <textarea  id="txtDescripcion" runat="server" class="form-control" 
                                    placeholder="Descripción" rows="4" cols="50" data-toggle="tooltip" data-placement="bottom" 
                                    title="Descripción" required />
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
                            <% Response.Write("<a href='faqs.aspx' class='btn btn-primary btn-label-left btn-warning'>Cancelar</a>"); %>
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
                                    <th>Titulo</th>
                                    <th>descripcion</th>
                                    <th>tipo</th>
                                    
						        </tr>
					        </thead>
					        <tbody id="List_menus" runat="server">
					        
                            </tbody>
                        </table>
                         <div id="actions" runat="server"></div>
                    </div>
                    </div>
                </div>
            </div>

    </form>
















</form>
















</form>
















</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

