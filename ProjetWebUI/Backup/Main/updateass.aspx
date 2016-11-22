<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="updateass.aspx.vb" Inherits="ProjetWebUI.updateass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="../styles/MainStyle.css" rel="stylesheet" type="text/css" />
    <title>تحديث بيانات الجمعية</title>
</head>

<form id="form1" runat="server">
<body id="b">
	<div id="header">
		<img id="logo" alt="" src="../Img/logo.png" />
		<img id="titre" alt="" class="imgHeader" src="../Img/titre.png" />
	</div>
	
	<div id="menuBar">
	<a class="LabelMenu" href="envoyerCor.aspx">ارسال مراسلة</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="archiveCor.aspx">تتبع مراسلاتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="updateCompte.aspx">تعديل بياناتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="../default.aspx">تسجيل الخروج</a> </div>	
	
	<div id="center">
		
			<table class="tables" align="center">
			
			<tbody>
			<tr>
				<td>
				<asp:DropDownList CssClass="floatRight" id="vilCB" runat="server"></asp:DropDownList>
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
				<td>
				<asp:TextBox CssClass="floatRight" id="siteTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>الموقع الالكتروني </td>
			</tr>

			<tr>
				<td>
				<asp:TextBox MaxLength="4" CssClass="floatRight" id="datCreaTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
                <br/>
                <asp:RegularExpressionValidator CssClass="errors" ID="RegularExpressionValidator1" ControlToValidate="datCreaTB" runat="server" ErrorMessage="المرجوا ادخال سنة" ValidationExpression="\d+"></asp:RegularExpressionValidator>                
                </td>
				<td>تاريخ التأسيس </td>
			</tr>

			<tr>
				<td colspan="2">
				<asp:Button id="confirmerBT" runat="server" style="width 49px; height: 21px" Text="تأكيد المعلومات"></asp:Button>
                </td>
				<td></td>
			</tr>

            <tr>
				<td class="errors" colspan="3">
				<asp:Label ID="errLB" runat="server"></asp:Label>
				</td>
			</tr>
		</tbody>
		</table>

	</div>
</body>
</form>

</html>
