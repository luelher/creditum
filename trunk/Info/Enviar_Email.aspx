<%@ Page CodeBehind="Enviar_Email.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Creditum.Enviar_Email" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Creditum - Enviar Email</title>
		<script language="Javascript">
			var RCMensaje = "CREDITUM, su plataforma de información crediticia";
			function DeshabilitarClickDerecho(btnClick)
			{
				if (navigator.appName == "Netscape" && btnClick.which == 3)
				{ 
					alert(RCMensaje);
					return false;
				}
				else if (navigator.appName == "Microsoft Internet Explorer" && event.button == 2)
				{
					alert(RCMensaje);
					return false;
				}
			}
			document.onmousedown = DeshabilitarClickDerecho;
		</script>
		<!-- Information generated and read by Xara Webstyle. Do not edit this line. [Integrate (Theme);CreditumStyle;Theme Color 1;2201395;themecolour1;Theme Color 2;8255934;themecolour2;Background Color;16053492;themecolour3]
-->
		<!-- Template design (c) Xara Ltd 2003 -->
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css">BODY { FONT-SIZE: 9px; COLOR: #000000; FONT-FAMILY: "Trebuchet MS", Arial, Sans-serif; BACKGROUND-COLOR: #f4f4f4 }
	TABLE { FONT: 9pt "trebuchet ms", arial, sans-serif }
	P { MARGIN: 0px 30px 0px 0px }
	BLOCKQUOTE { MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #000000; MARGIN-RIGHT: 0px }
	OL { MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #000000 }
	UL { MARGIN-TOP: 0px; LIST-STYLE-IMAGE: url(Home_files/Home_bullet.gif); MARGIN-BOTTOM: 0px; MARGIN-LEFT: 20px; COLOR: #000000 }
	A:link { COLOR: #277619 }
	A:visited { COLOR: #000000 }
	A:hover { COLOR: #33305b }
	H1 { MARGIN-TOP: 0px; FONT-WEIGHT: bold; FONT-SIZE: 16px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 2px; MARGIN-LEFT: 20px; COLOR: #000000 }
	H2 { MARGIN-TOP: 0px; FONT-WEIGHT: bold; FONT-SIZE: 15px; MARGIN-BOTTOM: 0px; COLOR: #339721 }
	.hnavbg { BACKGROUND-IMAGE: url(Home_files/Home_hnavbar_bg.gif); BACKGROUND-REPEAT: repeat-x }
	.leftcolumn { BACKGROUND-IMAGE: url(Home_files/Home_border_left.gif); BACKGROUND-REPEAT: repeat-y }
	.rightcolumn { PADDING-LEFT: 15px; BACKGROUND: url(Home_files/Home_border_right.gif) repeat-y right 50% }
	.footer { BACKGROUND-IMAGE: url(Home_files/Home_footer_bg.gif); BACKGROUND-REPEAT: repeat-x }
	</style>
	</HEAD>
	<body leftMargin="0" topMargin="5">
		<form id="Home" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="98%" align="center">
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="46" height="43"><IMG src="Home_files/Home_top_left.gif" border="0" moduleid="CreditumStyle (Project)\Home_top_left.xws"
													editor="Webstyle4"></td>
											<td vAlign="top" width="64"><IMG src="Home_files/Home_spacer.gif" border="0" moduleid="CreditumStyle (Project)\Home_spacer.xws"
													editor="Webstyle4"></td>
											<td class="hnavbg" vAlign="top">
												<script Webstyle4>document.write('<scr'+'ipt src="Home_files/xaramenu.js">'+'</scr'+'ipt>');document.write('<scr'+'ipt src="Home_files/home_hnavbar.js">'+'</scr'+'ipt>');/*img src="Home_files/Home_hnavbar.gif" moduleid="CreditumStyle (Project)\Home_hnavbar_off.xws"*/</script>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_top_right.gif" border="0" moduleid="CreditumStyle (Project)\Home_top_right.xws"
													editor="Webstyle4"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" width="160">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="leftcolumn" vAlign="top" align="center" height="75">
															<div align="center"><IMG src="Home_files/Home_logo2.gif" border="0" moduleid="CreditumStyle (Project)\Home_logo2.xws"
																	editor="Webstyle4"></div>
														</td>
													</tr>
													<tr>
														<td>
															<script Webstyle4>document.write('<scr'+'ipt src="Home_files/xaramenu.js">'+'</scr'+'ipt>');document.write('<scr'+'ipt src="Home_files/home_vnavbar.js">'+'</scr'+'ipt>');/*img src="Home_files/Home_vnavbar.gif" moduleid="CreditumStyle (Project)\Home_vnavbar_off.xws"*/</script>
														</td>
													</tr>
												</table>
												<P>&nbsp;</P>
												<P align="justify">Web Site desarrollado con el poder de MYSQL y ASP.NET</P>
												<P><asp:hyperlink id="lnkMySql" runat="server" NavigateUrl="http://www.mysql.com" ImageUrl="Home_files/mysql.png">MySql</asp:hyperlink></P>
												<P><asp:hyperlink id="lnkASP" runat="server" NavigateUrl="http://www.asp.net" ImageUrl="Home_files/ASPNET.gif">ASP.NET</asp:hyperlink></P>
												<P>&nbsp;</P>
											</td>
											<td class="rightcolumn" vAlign="top">
												<P align="right">
													<asp:Label id="lblTime" runat="server">Hoy</asp:Label></P>
												<H1>
													Enviar E-mail</H1>
												<P>
													<asp:validationsummary id="ValidationSummaryMail" runat="server" Width="294px" HeaderText="Errores Encontrados"></asp:validationsummary></P>
												<P>&nbsp;</P>
												<P>Ingresa tus datos para poder responder a tu mensaje:</P>
												<P>&nbsp;</P>
												<P>
													<asp:label id="lblNombre" runat="server" Font-Size="XX-Small">NOMBRE</asp:label></P>
												<P>
													<asp:textbox id="txtNombre" runat="server" Width="102px" Font-Size="XX-Small"></asp:textbox>
													<asp:RequiredFieldValidator id="RequiredFieldValidatorNombre" runat="server" ErrorMessage="El campo Nombre no puede estar vacío"
														ControlToValidate="txtNombre">*</asp:RequiredFieldValidator></P>
												<P>&nbsp;</P>
												<P>
													<asp:label id="Label1" runat="server" Font-Size="XX-Small">APELLIDO</asp:label></P>
												<P></P>
												<P>
													<asp:textbox id="txtApellido" runat="server" Width="134px" Font-Size="XX-Small"></asp:textbox>
													<asp:RequiredFieldValidator id="RequiredFieldValidatorApellido" runat="server" ErrorMessage="El campo Apellido no puede estar vacío"
														ControlToValidate="txtApellido">*</asp:RequiredFieldValidator>
												<P>
												&nbsp;
												<P>
													<asp:label id="Label2" runat="server" Font-Size="XX-Small">E-MAIL</asp:label>
												<P></P>
												<P>
													<asp:textbox id="txtEmail" runat="server" Width="174px" Font-Size="XX-Small"></asp:textbox>
													<asp:RegularExpressionValidator id="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Dirección de Email Inválida"
														ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>&nbsp;
													<asp:RequiredFieldValidator id="RequiredFieldValidatorMail" runat="server" ErrorMessage="El campo Email no puede estar vacío"
														ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
												<P>
												&nbsp;
												<P>
												<P>
													<asp:label id="lblDestino" runat="server" Font-Size="XX-Small">SELECCIONA EL DESTINO DE TU MENSAJE</asp:label>
												<P>
													<asp:DropDownList id="ddlDestino" runat="server" Width="144px" Font-Size="XX-Small">
														<asp:ListItem Value="consulcreline@cantv.net" Selected="True">Atenci&#243;n al cliente</asp:ListItem>
														<asp:ListItem Value="grupoemporium@cantv.net">Soporte t&#233;cnico</asp:ListItem>
													</asp:DropDownList>
												<P>
												&nbsp;
												<P>
												<P>
													<asp:label id="Label3" runat="server" Font-Size="XX-Small">MENSAJE</asp:label>
													<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="El campo Mensaje no puede estar vacío"
														ControlToValidate="txtMensaje">*</asp:RequiredFieldValidator>
												<P>
													<asp:textbox id="txtMensaje" runat="server" Width="336px" Height="136px" Font-Size="X-Small"
														TextMode="MultiLine">  ------Escribe aqu&#237; tu mensaje------</asp:textbox>
												<P>
												<P>&nbsp;</P>
												<P>
													<asp:Button id="btnEnviar" runat="server" Text="Enviar"></asp:Button></P>
												<P>&nbsp;</P>
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> </BLOCKQUOTE>
												<P>&nbsp;</P>
												<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
												<P align="left"><asp:adrotator id="RotadorBanner" runat="server" Height="66px" Width="512px" AdvertisementFile="XMLBanner.xml"></asp:adrotator></P>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_left.gif" border="0" moduleid="CreditumStyle (Project)\Home_bottom_left.xws"
													editor="Webstyle4"></td>
											<td class="footer">
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
														<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																	<P align="left">&nbsp;
																		<asp:hyperlink id="lnkHome" runat="server" ForeColor="White" NavigateUrl="..\Home.aspx">HOME</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkWho" runat="server" ForeColor="White" NavigateUrl="Quienes_somos.aspx">¿QUIENES SOMOS?</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkServ" runat="server" ForeColor="White" NavigateUrl="http://www.google.com">SERVICIOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkContactanos" runat="server" ForeColor="White" NavigateUrl="Contactanos.aspx">CONTACTANOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkLinks" runat="server" ForeColor="White" NavigateUrl="Links.aspx">LINKS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkHelp" runat="server" ForeColor="White" NavigateUrl="Ayuda.aspx">AYUDA</asp:hyperlink></P>
																</BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_right.gif" border="0" moduleid="CreditumStyle (Project)\Home_bottom_right.xws"
													editor="Webstyle4"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
