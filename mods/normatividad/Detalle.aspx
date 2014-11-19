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
                              <label  class="col-sm-2 control-label">Numero
                              </label>
						    <div class="col-sm-4">
							    <input type="text" id="txtNumero" runat="server" class="form-control" 
                                    placeholder="Numero" data-toggle="tooltip" data-placement="bottom" title="Numero" required>
						    </div>
                           
						    <label  class="col-sm-2 control-label">Fecha</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtFecha" runat="server" class="form-control" 
                                    placeholder="Fecha" data-toggle="tooltip" data-placement="bottom" 
                                    title="Fecha" required >
						    </div>
                            
                            <% if (!getTitulo().Contains("Decreto") )
                               { %>

                            <label  class="col-sm-2 control-label">Autoridad que la Expide</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtAutoridadExpide" runat="server" class="form-control" 
                                    placeholder="Autoridad que la Expide" data-toggle="tooltip" data-placement="bottom" 
                                    title="Autoridad que la Expide">
						    </div>
                            
                            <%} %>
                            <label  class="col-sm-2 control-label">Fecha de Publicación</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtFechaPublicacion" runat="server" class="form-control" 
                                    placeholder="Fecha de Publicación" data-toggle="tooltip" data-placement="bottom" 
                                    title="Fecha de Publicación" required>
						    </div>
                            <label  class="col-sm-2 control-label">Asunto</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtAsunto" runat="server" class="form-control" 
                                    placeholder="Fecha de Publicación" data-toggle="tooltip" data-placement="bottom" 
                                    title="Asunto" required>
						    </div>
                            
                            <label class="col-sm-2 control-label" for="form-styles">Archivo</label>
						    <div class="col-sm-2">
                                <asp:FileUpload ID="flIcon" runat="server"  />
						    </div>
                            
					    </div>
					    <div class="form-group">
						    
                             
					    </div>
                         
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Guardar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
						</div>
                        <div class="col-sm-2">
                            <asp:Button ID="UpdateData" runat="server" Text="Cancelar" class="btn btn-primary btn-label-left btn-danger" Enabled="True" />
						</div>
					</div>
                       
                    </div>
                </div>
            </div>
         </div>
    </div>


    </form>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" runat="Server">
</asp:Content>

