<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inscription.aspx.vb" Inherits="ProjetWebUI.inscription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<meta  content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>تسجيل</title>
<link href="styles/MyStyle.css" rel="stylesheet" type="text/css" />
<link href="styles/MainStyle.css" rel="stylesheet" type="text/css" />
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
				<asp:TextBox CssClass="floatRight" id="nomAssTB" runat="server" Width="237px"></asp:TextBox>
				</td>
				<td>اسم الجمعية </td>
			</tr>

			<tr>
				<td>
				<asp:TextBox CssClass="floatRight"  id="emailTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>ايميل الجمعية </td>
			</tr>

			<tr>
				<td>
				<asp:TextBox CssClass="floatRight" id="confEmailTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>تأكيد ايميل الجمعية </td>
			</tr>

			<tr>
				<td>
				<asp:DropDownList CssClass="floatRight" id="regCB" runat="server" AutoPostBack="True" OnTextChanged="itemSelected" ></asp:DropDownList>
				</td>
				<td>الجهة </td>
			</tr>

			<tr>
				<td>
				<asp:DropDownList CssClass="floatRight" id="vilCB" runat="server" AutoPostBack="True" ></asp:DropDownList>
				</td>
				<td>المدينة </td>
			</tr>
			<tr>
				<td>
				<asp:TextBox CssClass="floatRight" id="adrAssTB" runat="server" Width="237px"></asp:TextBox>
				</td>
				<td>العنوان </td>
			</tr>

			<tr>
				<td>
				<asp:TextBox CssClass="floatRight" id="telAssTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>هاتف الجمعية </td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:Button id="confirmerBT" runat="server" style="width 49px; height: 21px" Text="تأكيد المعلومات"></asp:Button>
				</td>
				<td></td>
			</tr>
		</tbody>
		</table>
</div>
</body>
</form>

</html>
