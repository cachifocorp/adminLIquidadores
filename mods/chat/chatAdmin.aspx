<%@ Page Title="" Language="C#" MasterPageFile="~/mods/masterPageContent/ContentMasterPage.master" AutoEventWireup="true" CodeFile="chatAdmin.aspx.cs" Inherits="mods_chat_chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
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
				    <h4 class="page-header">Chat Cliente </h4>
                    <div id="Messages" runat="server"></div>
				    <div class="form-horizontal" role="form">
                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer runat="server" id="Timer1" Interval="1000" OnTick="Timer1_Tick"  ></asp:Timer>
                
               

                <br />
                <div style="height:300px; overflow: scroll;" id="ContentChat" runat="server">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
                        <center>
                        <asp:TextBox ID="txtMensaje" runat="server" style="width:70%"></asp:TextBox>
                        <asp:Button ID="btnEnviar" runat="server" Text="Button" class="btn btn-primary btn-label-left btn-default" OnClick="btnEnviar_Click" />
                        </center>
                       <div class="clearfix"></div>
					<div class="form-group">
						<div class="col-sm-2">
                            <asp:Button ID="SaveData" runat="server" Text="Salir Solicitud" class="btn btn-primary btn-label-left btn-danger" OnClick="SaveData_Click1" />
						</div>
                       
					</div>
                       
                    </div>
                </div>
            </div>
         </div>
    </div>
     </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="customScripts" Runat="Server">
</asp:Content>

