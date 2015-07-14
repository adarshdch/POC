<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:Button runat="server" ID="btnSaveData" Text ="Save Data" OnClick="btnSaveData_Click"/>
		<asp:Button runat="server" ID="btnShowData" Text ="Show Data" OnClick="btnShowData_Click"/>
		<div>
			<asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="false">
				<Columns>
					<asp:BoundField DataField="Content" />
				</Columns>
			</asp:GridView>
		</div>
	</form>
</body>
</html>