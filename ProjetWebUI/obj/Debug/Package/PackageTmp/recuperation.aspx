<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="recuperation.aspx.vb" Inherits="ProjetWebUI.recuperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="stylesheet" href="styles/MyStyle.css" type="text/css"/>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<link href="styles/MainStyle.css" rel="stylesheet" type="text/css" />
<title>تذكير بكلمة المرور</title>
</head>
	<form id="form1" runat="server">
<body>
<div id="up">
	<img id="logo" alt="" src="Img/logo.png" />
	<img id="titre" alt="" class="imgHeader" src="Img/titre.png" /> </div>
<div id="right">
	<a id="externLink" href="other">مراسلتنا</a> </div>
<div id="below">

		<table align="center" class="tables">
			<tbody>
				<tr>
					<td>
						<asp:Button id="demandeBT" runat="server" style="width 49px; height: 21px" Text="طلب"></asp:Button>
					</td>
					<td>
						<asp:TextBox id="emailTB" CssClass="floatRight" runat="server" style="width: 200px; height: 18px;"></asp:TextBox>
 					</td>
					<td>ايميل الجمعية</td>
				</tr>
				<tr>
					<td>
						<a id="inscrLink" href="inscription.aspx"><asp:Label id="linkLB" CssClass="floatRight" runat="server" Text=""></asp:Label> </a>
					</td>
					<td class="errors" colspan="2">
						<asp:Label id="emailNotFoundLB" CssClass="floatRight" runat="server" Text=""></asp:Label>
					</td>
				</tr>
			</tbody>
        </table>

</div>

</body>
</form>
</html>
