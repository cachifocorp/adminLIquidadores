<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="RegistroUsuario.aspx.cs" Inherits="mods_chat_RegistroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
    <script type="text/javascript" language="javascript">
        function onBackClick() {
            window.close();
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
    <form id="Form1" runat="server">
        <div class="row">
	    <div class="col-xs-12 col-sm-12">
		    <div class="box">
			    <div class="box-header">
				    <div class="box-name">
					    <i class="fa fa-search"></i>
					    <span>Solicitar Chat</span>
				    </div>
				    
			    </div>
			    <div class="box-content">
				    <h4 class="page-header">Registrar Chat </h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        <div class="form-group">
                              <label  class="col-sm-2 control-label">Nombre Usuario
                              </label>
						    <div class="col-sm-4">
							    <input type="text" id="txtNombre" runat="server" class="form-control" 
                                    placeholder="Nombre Completo" data-toggle="tooltip" data-placement="bottom" required="required" title="Nombre Completo">
						    </div>
						    <label  class="col-sm-2 control-label">Correo</label>
						    <div class="col-sm-4">
							    <input type="text" id="txtCorreo" runat="server" class="form-control" 
                                    placeholder="Email" data-toggle="tooltip" data-placement="bottom" 
                                    title="Email" required="required">
						    </div>
                            
					    </div>
					    
                         
                      <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Ingresar" class="btn btn-primary btn-label-left" OnClick="SaveData_Click" />
						</div>
                        <div class="col-sm-2">
                            <a href="javascript:onBackClick()" class="btn btn-primary btn-label-left btn-danger">Cancelar</a>
                            
						</div>
					</div>
                       
                    </div>
                </div>
            </div>
         </div>
    </div>
     </form>
</asp:Content>

