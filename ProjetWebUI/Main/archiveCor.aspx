<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="archiveCor.aspx.vb" Inherits="ProjetWebUI.archiveCor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>ارشيف المراسلات</title>
<link href="../styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>

<body id="b">

	<div id="header">
		<img id="logo" alt="" src="../Img/logo.png" />
		<img id="titre" alt="" class="imgHeader" src="../Img/titre.png" />
	</div>
	
	<div id="menuBar">
		<a class="LabelMenu" href="envoyerCor.aspx">ارسال مراسلة</a>&nbsp;&nbsp;|&nbsp;&nbsp;
		<span class="LabelMenuInactif">تتبع مراسلاتكم</span>&nbsp;&nbsp;|&nbsp;&nbsp;
		<a class="LabelMenu" href="updateCompte.aspx">تعديل بياناتكم</a>&nbsp;&nbsp;|&nbsp;&nbsp;
		<a class="LabelMenu" href="logout.aspx">تسجيل الخروج</a>
	</div>
	
	<div id="center">
        
<form id="form1" runat="server">
			<table align="center" class="tables">
			<tbody>
			
			<tr>
			<td class="contentFont">لائحة المراسلات</td>
			</tr>
			<tr>
			<td>
			 <asp:GridView id="corGV" runat="server" AutoGenerateColumns="false">
             <Columns>
                <asp:BoundField DataField="objet" HeaderText="العنوان" ReadOnly="true"/>
                <asp:BoundField DataField="datEnv" dataformatstring="{0:MM/dd/yyyy}" HeaderText="تاريخ الارسال" ReadOnly="true"/>
                <asp:BoundField DataField="datRec" dataformatstring="{0:MM/dd/yyyy}" HeaderText="تاريخ التوصل" ReadOnly="true"/>
                <asp:BoundField DataField="etat" HeaderText="الحالة" ReadOnly="true"/>
                <asp:TemplateField HeaderText="القرار">
                <ItemTemplate>
                    <asp:Label ID="typLB" runat="server" Text='<%# Eval("dec.type.libTyp") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="estPos" HeaderText="بريدية" ReadOnly="true" />
             </Columns>
             </asp:GridView>
			</td>
			</tr>
						
			</tbody>
			</table>
    </form>
	</div>
</body>

</html>
