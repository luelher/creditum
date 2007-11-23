<%@ Page CodeBehind="NuevoUsuarioC.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Creditum.PCOA.NuevoUsuarioC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Creditum - Nuevo Usuario</title>
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
											<td vAlign="top" width="46" height="43"><IMG src="Home_files/Home_top_left.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_top_left.xws"></td>
											<td vAlign="top" width="64"><IMG src="Home_files/Home_spacer.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_spacer.xws"></td>
											<td class="hnavbg" vAlign="top">
												<script Webstyle4>document.write('<scr'+'ipt src="Home_files/xaramenu.js">'+'</scr'+'ipt>');document.write('<scr'+'ipt src="Home_files/home_hnavbar.js">'+'</scr'+'ipt>');/*img src="Home_files/Home_hnavbar.gif" moduleid="CreditumStyle (Project)\Home_hnavbar_off.xws"*/</script>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_top_right.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_top_right.xws"></td>
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
															<div align="center"><IMG src="Home_files/Home_logo2.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_logo2.xws"></div>
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
												<P><asp:hyperlink id="lnkMySql" runat="server" ImageUrl="Home_files/mysql.png" NavigateUrl="http://www.mysql.com">MySql</asp:hyperlink></P>
												<P><asp:hyperlink id="lnkASP" runat="server" ImageUrl="Home_files/ASPNET.gif" NavigateUrl="http://www.asp.net">ASP.NET</asp:hyperlink></P>
												<P>&nbsp;</P>
											</td>
											<td class="rightcolumn" vAlign="top">
												<P align="right"><asp:label id="lblTime" runat="server">Hoy</asp:label></P>
												<H1>
													Agregar Nuevo Usuario</H1>
												<P>&nbsp;</P>
												<P><asp:label id="lblUser" runat="server"></asp:label></P>
												<P>
													<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label>
													<asp:label id="lblInfo" runat="server"></asp:label></P>
												<P>&nbsp;</P>
												<P><STRONG><EM>Paso1:</EM></STRONG> Seleccione&nbsp;el cliente&nbsp;al que 
													pertenecerá el nuevo usuario</P>
												<P>&nbsp;</P>
												<P>
													Cliente</P>
												<P align="justify">
													<asp:DropDownList id="DropDownListCasa" runat="server" Width="328px"></asp:DropDownList></P>
												<P align="justify">&nbsp;</P>
												<P>&nbsp;</P>
												<P>
													<asp:image id="Image1" runat="server" ImageUrl="Home_files/H_Separador.gif" Height="8px" Width="480px"></asp:image></P>
												<P>&nbsp;</P>
												<P><STRONG><EM>Paso2:</EM></STRONG> Ingrese los datos personales del nuevo usuario</P>
												<P>&nbsp;</P>
												<P>
													<asp:validationsummary id="ValidationSummaryHome" runat="server" HeaderText="Errores Encontrados" EnableClientScript="False"></asp:validationsummary></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="lblCedula" runat="server" Font-Size="XX-Small">CÉDULA</asp:Label></P>
												<P>
													<asp:textbox id="txtCedula" runat="server" Width="88px" Font-Size="XX-Small"></asp:textbox>
													<asp:RangeValidator id="RangeValidatorCI" runat="server" Type="Integer" MinimumValue="1000000" MaximumValue="100000000"
														ControlToValidate="txtCedula" ErrorMessage="Cédula Inválida" Font-Size="X-Small" EnableClientScript="False">*</asp:RangeValidator>
													<asp:requiredfieldvalidator id="RequiredFieldValidatorCI" runat="server" Width="23px" ControlToValidate="txtCedula"
														ErrorMessage="Especifique una Cédula" Font-Size="X-Small" EnableClientScript="False">*</asp:requiredfieldvalidator></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="lblNac" runat="server" Font-Size="XX-Small">NACIONALIDAD</asp:Label></P>
												<P>
													<asp:DropDownList id="DropDownNacionalidad" runat="server" Width="136px">
														<asp:ListItem Value="VENEZOLANO">VENEZOLANO</asp:ListItem>
														<asp:ListItem Value="EXTRANGERO">EXTRANGERO</asp:ListItem>
													</asp:DropDownList></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="lblNombre" runat="server" Font-Size="XX-Small">NOMBRE</asp:Label></P>
												<P>
													<asp:TextBox id="txtNombre" runat="server"></asp:TextBox>
													<asp:requiredfieldvalidator id="RequiredfieldvalidatorNombre" runat="server" Width="23px" ControlToValidate="txtNombre"
														ErrorMessage="Especifique una Nombre" Font-Size="X-Small" EnableClientScript="False">*</asp:requiredfieldvalidator></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="lblApellido" runat="server" Font-Size="XX-Small">APELLIDO</asp:Label></P>
												<P>
													<asp:TextBox id="txtApellido" runat="server"></asp:TextBox>
													<asp:requiredfieldvalidator id="RequiredfieldvalidatorApellido" runat="server" Width="23px" ControlToValidate="txtApellido"
														ErrorMessage="Especifique un Apellido" Font-Size="X-Small" EnableClientScript="False">*</asp:requiredfieldvalidator></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="lblTelf" runat="server" Font-Size="XX-Small">TELÉFONO HABITACIÓN</asp:Label></P>
												<P>
													<asp:textbox id="txtTelef" runat="server" Width="88px" Font-Size="XX-Small"></asp:textbox>
													<asp:RegularExpressionValidator id="RegularExpressionValidatorTelf" runat="server" ErrorMessage="Número de teléfono inválido. Ej: nnnn-nnnnnnn"
														ControlToValidate="txtTelef" ValidationExpression="\d{4}-\d{7}" EnableClientScript="False">*</asp:RegularExpressionValidator></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="Label1" runat="server" Font-Size="XX-Small">TELÉFONO CELULAR</asp:Label></P>
												<P>
													<asp:textbox id="txtCelular" runat="server" Width="88px" Font-Size="XX-Small"></asp:textbox>
													<asp:RegularExpressionValidator id="RegularExpressionValidatorCel" runat="server" ErrorMessage="Número de teléfono celular inválido. Ej: 041n-nnnnnnn"
														ControlToValidate="txtCelular" ValidationExpression="041\d{1}-\d{7}" EnableClientScript="False">*</asp:RegularExpressionValidator></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="Label2" runat="server" Font-Size="XX-Small">NIVEL DE ACCESIBILIDAD</asp:Label></P>
												<P>
													<asp:DropDownList id="DropDownListNivel" runat="server" Width="232px">
														<asp:ListItem Value="4">CONSULTOR ADMINISTRADOR</asp:ListItem>
														<asp:ListItem Value="3">CONSULTOR</asp:ListItem>
													</asp:DropDownList></P>
												<P>&nbsp;</P>
												<P>
													<asp:Label id="Label3" runat="server" Font-Size="XX-Small">CONTRASEÑA PREDETERMINADA</asp:Label></P>
												<P>
													<asp:textbox id="txtPWD" runat="server" Width="88px" Font-Size="XX-Small" ReadOnly="True" Enabled="False">creditum123</asp:textbox></P>
												<P>&nbsp;</P>
												<P>
													<asp:Button id="btnInsertar" runat="server" Text="Insertar" Font-Size="XX-Small"></asp:Button></P>
												<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
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
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_left.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_bottom_left.xws"></td>
											<td class="footer">
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
														<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																	<P align="left">&nbsp;
																		<asp:hyperlink id="lnkHome" runat="server" NavigateUrl="Home.aspx" ForeColor="White">HOME</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkWho" runat="server" NavigateUrl="Info\Quienes_somos.aspx" ForeColor="White">¿QUIENES SOMOS?</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkServ" runat="server" NavigateUrl="http://www.google.com" ForeColor="White">SERVICIOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkContactanos" runat="server" NavigateUrl="Info\Contactanos.aspx" ForeColor="White">CONTACTANOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkLinks" runat="server" NavigateUrl="Info\Links.aspx" ForeColor="White">LINKS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkHelp" runat="server" NavigateUrl="Info\Ayuda.aspx" ForeColor="White">AYUDA</asp:hyperlink></P>
																</BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_right.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_bottom_right.xws"></td>
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
