<%@ Page CodeBehind="Precios.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Creditum.PCOA.Precios" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Creditum - Ajuste de Precios</title>
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
													Ajuste del Costo de las Consultas</H1>
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<P>
														<asp:validationsummary id="ValidationSummaryHome" runat="server" Width="270px" HeaderText="Errores Encontrados"></asp:validationsummary></P>
													<P align="justify">
														<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label></P>
													<P align="justify">&nbsp;</P>
													<P>
														<asp:label id="lblP1" runat="server" Font-Size="XX-Small">CONSULTA VÁLIDA. COSTO 1 (Bs.)</asp:label></P>
													<P></P>
													<P>
														<asp:textbox id="txtP1" runat="server" Width="112px" Font-Size="XX-Small"></asp:textbox>
														<asp:requiredfieldvalidator id="RequiredfieldvalidatorP1" runat="server" Width="23px" Font-Size="X-Small" ControlToValidate="txtP1"
															ErrorMessage="Costo 1 Requerido" EnableClientScript="False">*</asp:requiredfieldvalidator>
														<asp:RangeValidator id="RangeValidator1" runat="server" Width="32px" Font-Size="X-Small" ErrorMessage="Valor Fuera de Rango del Costo 1"
															ControlToValidate="txtP1" MinimumValue="0" Type="Integer" MaximumValue="1000000" EnableClientScript="False">*</asp:RangeValidator></P>
													<P>&nbsp;</P>
													<P align="justify">
														<asp:label id="lblP2" runat="server" Font-Size="XX-Small">CONSULTA VÁLIDA. COSTO 2 (Bs.)</asp:label></P>
													<P></P>
													<P align="justify">
														<asp:textbox id="txtP2" runat="server" Width="112px" Font-Size="XX-Small"></asp:textbox>
														<asp:requiredfieldvalidator id="RequiredfieldvalidatorP2" runat="server" Width="23px" Font-Size="X-Small" ControlToValidate="txtP2"
															ErrorMessage="Costo 2 Requerido" EnableClientScript="False">*</asp:requiredfieldvalidator>
														<asp:RangeValidator id="RangeValidator2" runat="server" Width="32px" Font-Size="X-Small" ErrorMessage="Valor Fuera de Rango del Costo 2"
															ControlToValidate="txtP2" MinimumValue="0" Type="Integer" MaximumValue="1000000" EnableClientScript="False">*</asp:RangeValidator></P>
													<P align="justify">&nbsp;</P>
													<P align="justify">
														<asp:label id="lblP3" runat="server" Font-Size="XX-Small">CONSULTA VÁLIDA. COSTO 3 (Bs.)</asp:label></P>
													<P></P>
													<P align="justify">
														<asp:textbox id="txtP3" runat="server" Width="112px" Font-Size="XX-Small"></asp:textbox>
														<asp:requiredfieldvalidator id="RequiredfieldvalidatorP3" runat="server" Width="23px" Font-Size="X-Small" ControlToValidate="txtP3"
															ErrorMessage="Costo 3 Requerido" EnableClientScript="False">*</asp:requiredfieldvalidator>
														<asp:RangeValidator id="RangeValidator3" runat="server" Width="32px" Font-Size="X-Small" ErrorMessage="Valor Fuera de Rango del Costo 3"
															ControlToValidate="txtP3" MinimumValue="0" Type="Integer" MaximumValue="1000000" EnableClientScript="False">*</asp:RangeValidator></P>
													<STRONG></STRONG></BLOCKQUOTE><BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<P>&nbsp;</P>
													<P align="justify">
														<asp:label id="lblP4" runat="server" Font-Size="XX-Small">CONSULTA VÁLIDA. COSTO 4 (Bs.)</asp:label></P>
													<P></P>
													<P align="justify">
														<asp:textbox id="txtP4" runat="server" Width="112px" Font-Size="XX-Small"></asp:textbox>
														<asp:requiredfieldvalidator id="RequiredfieldvalidatorP4" runat="server" Width="23px" Font-Size="X-Small" ErrorMessage="Costo 4 Requerido"
															ControlToValidate="txtP4" EnableClientScript="False">*</asp:requiredfieldvalidator>
														<asp:RangeValidator id="RangeValidator4" runat="server" Width="32px" Font-Size="X-Small" ErrorMessage="Valor Fuera de Rango del Costo 4"
															ControlToValidate="txtP4" MinimumValue="0" Type="Integer" MaximumValue="1000000" EnableClientScript="False">*</asp:RangeValidator></P>
													<P align="justify">&nbsp;</P>
													<P align="justify">
														<asp:label id="lblF" runat="server" Font-Size="XX-Small">COSTO CONSULTA FALLIDA (Bs.)</asp:label></P>
													<P></P>
													<P align="justify">
														<asp:textbox id="txtF" runat="server" Width="112px" Font-Size="XX-Small"></asp:textbox>
														<asp:requiredfieldvalidator id="RequiredfieldvalidatorF" runat="server" Width="23px" Font-Size="X-Small" ErrorMessage="Costo de la Consulta Fallida Requerido"
															ControlToValidate="txtF" EnableClientScript="False">*</asp:requiredfieldvalidator>
														<asp:RangeValidator id="RangeValidator5" runat="server" Width="32px" Font-Size="X-Small" ErrorMessage="Valor Fuera de Rango del costo de la consulta fallida"
															ControlToValidate="txtF" MinimumValue="0" Type="Integer" MaximumValue="1000000" EnableClientScript="False">*</asp:RangeValidator></P>
													<P align="justify">&nbsp;</P>
												</BLOCKQUOTE><BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<P>
														<asp:button id="btnAceptar" runat="server" Font-Size="XX-Small" Text="Modificar"></asp:button></P>
													<P dir="ltr">&nbsp;</P>
													<P dir="ltr">
														<asp:Label id="lblInfo" runat="server" ForeColor="Green"></asp:Label></P>
													<P dir="ltr">&nbsp;</P>
													<P></P>
													<P dir="ltr">&nbsp;</P>
												</BLOCKQUOTE>
												<H1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</H1>
												<P align="left">&nbsp;</P>
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
																		<asp:hyperlink id="lnkHome" runat="server" ForeColor="White" NavigateUrl="Home.aspx">HOME</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkWho" runat="server" ForeColor="White" NavigateUrl="Info\Quienes_somos.aspx">¿QUIENES SOMOS?</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkServ" runat="server" ForeColor="White" NavigateUrl="http://www.google.com">SERVICIOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkContactanos" runat="server" ForeColor="White" NavigateUrl="Info\Contactanos.aspx">CONTACTANOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkLinks" runat="server" ForeColor="White" NavigateUrl="Info\Links.aspx">LINKS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkHelp" runat="server" ForeColor="White" NavigateUrl="Info\Ayuda.aspx">AYUDA</asp:hyperlink></P>
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
