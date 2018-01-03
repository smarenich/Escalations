<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" 
ValidateRequest="false" CodeFile="NewEscalationItem.aspx.cs" Inherits="Page_NewEscalationItem" 
Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="PX.Objects.CR.IPEscalationItem" PrimaryView="Item" >
		<CallbackCommands>
			<px:PXDSCallbackCommand Name="EscalateCase" CommitChanges="True" Visible="True" PopupVisible="True" ClosePopup="True"/>  
			<px:PXDSCallbackCommand Name="Close" Visible="True" PopupVisible="True" ClosePopup="True"/>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataMember="Item"  FilesIndicator="False" NoteIndicator="False" >
		<Template>
			<px:PXRichTextEdit ID="edDescription" runat="server" DataField="Description" TextMode="MultiLine" Style="margin-bottom: 8px; border: 1px solid #BBBBBB;"  
                AllowAttached="true">
				<AutoSize Enabled="True" Container="Parent" />
			</px:PXRichTextEdit>                
        </Template>
        <AutoSize Enabled="True" Container="Window"/>
	</px:PXFormView>
</asp:Content>
