<%@ Page CodeBehind="Quienes_somos.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Creditum.Quienes_somos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Creditum - Quienes Somos</title>
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
													¿Quiénes Somos?</H1>
												<P>&nbsp;</P>
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<P align="justify"><STRONG><EM>Informadora de Crédito en Línea</EM></STRONG>, es 
														una empresa que nace de la necesidad que tiene el sector Comercial - 
														Empresarial de proteger sus intereses al momento de realizar una transacción 
														crediticia cualquierea que sea.</P>
													<P align="justify">&nbsp;</P>
												</BLOCKQUOTE>
												<P dir="ltr" align="justify">
													<asp:image id="HSeparador2" runat="server" ImageUrl="Home_files/H_Separador.gif" Width="480px"
														Height="8px"></asp:image></P>
												<H1>&nbsp;</H1>
												<H1>Personal</H1>
												<P>&nbsp;</P>
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<P align="justify">Nuestro personal está conformado por:</P>
													<P align="justify">&nbsp;</P>
													<UL>
														<UL>
															<LI>
																<EM><STRONG>Técnicos Especializados.</STRONG></EM>
															<LI>
																<EM><STRONG>Profesionales en el manejo de Información Crediticia e Informática.</STRONG></EM></LI></UL>
													</UL>
													<P align="justify">&nbsp;</P>
													<P align="justify">Ellos, son&nbsp;quienes gustosamente tendrán el placer de 
														orientarle y guiarle en el manejo de nuestro sistema de información.</P>
													<P align="justify">&nbsp;</P>
													<P align="justify">Nuestros técnicos e ingenieros, han diseñado un sistema, muy 
														sencillo, y fácil de operar. Para comunicarte con nosotros pulsa
														<asp:hyperlink id="lnkComunicar" runat="server" NavigateUrl="Contactanos.aspx" Font-Size="X-Small"
															ForeColor="Green">aquí</asp:hyperlink>.</P>
													<P align="justify">&nbsp;</P>
												</BLOCKQUOTE>
												<P dir="ltr" align="justify">
													<asp:image id="HSeparador3" runat="server" ImageUrl="Home_files/H_Separador.gif" Width="480px"
														Height="8px"></asp:image></P>
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<P align="justify">&nbsp;</P>
												</BLOCKQUOTE>
												<H1 dir="ltr" align="justify">Servicios</H1>
												<P dir="ltr" align="justify">&nbsp;</P>
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<P dir="ltr" align="justify">A través de nuestra página web: <A href="http://www.consulcreline.com">
															www.consulcreline.com</A>, nuestros clientes podrán:</P>
													<P dir="ltr" align="justify">&nbsp;</P>
													<UL dir="ltr" style="MARGIN-RIGHT: 0px">
														<UL>
															<LI dir="ltr">
																<STRONG><EM>Realizar consultas las 24 horas del día</EM></STRONG>
															<LI dir="ltr">
																<STRONG><EM>Ver e imprimir reportes del estado de cuenta</EM></STRONG>
															<LI dir="ltr">
																<STRONG><EM>Actualizar datos.</EM></STRONG></LI></UL>
													</UL>
													<P dir="ltr"><STRONG><EM></EM></STRONG>&nbsp;</P>
													<P dir="ltr">También tendrán la&nbsp;opción de comunicarse telefónicamente con 
														nuestros operadores, quienes estarán en disposición de suministrarle la 
														información de la consulta solicitada por Ud.</P>
													<P dir="ltr"><STRONG><EM></EM></STRONG>&nbsp;</P>
													<P dir="ltr"><EM>La actualización de nuestra información</EM>, será enviada por 
														nuestros clientes, quienes gozarán de&nbsp;<STRONG>créditos</STRONG> que serán 
														descontados de sus facturas, dichos créditos serán por cliente enviado.
													</P>
													<P dir="ltr">&nbsp;</P>
													<P dir="ltr">Para actualizar los datos, estamos en disposición de brindarle el <EM>software 
															especializado</EM>&nbsp;con la capacidad de:</P>
													<P dir="ltr">&nbsp;</P>
													<UL>
														<UL>
															<UL>
																<LI dir="ltr">
																	<STRONG><EM>Recopilar la información</EM></STRONG>
																<LI dir="ltr">
																	<STRONG><EM>Codificar dicha información</EM></STRONG>
																<LI dir="ltr">
																	<STRONG><EM>Conectarse a internet y enviar los datos a nuestro sistema, sin que usted 
																			tenga que dirigirse a nuestras oficinas</EM></STRONG>
																<LI dir="ltr">
																	<STRONG><EM>Almacenar en un Diskette la información codificada</EM></STRONG></LI></UL>
														</UL>
													</UL>
													<P dir="ltr">&nbsp;</P>
													<P dir="ltr">Nuestras tarifas son inmejorables, contamos con una gran base de datos 
														con numerosos registros e información de experiencias crediticias, que 
														pondremos a su disposición gratuitamente durante nuestro período de prueba, vía 
														Internet.</P>
													<P dir="ltr">&nbsp;</P>
												</BLOCKQUOTE>
												<P>&nbsp;</P>
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
													<H2>ESTAMOS EN LÍNEA LAS 24 HORAS DEL DÍA.</H2>
												</BLOCKQUOTE>
												<P>&nbsp;</P>
												<P><asp:image id="HSeparador1" runat="server" ImageUrl="Home_files/H_Separador.gif" Height="8px"
														Width="480px"></asp:image></P>
												<P>&nbsp;</P>
												<H1>Ingresa a Nuestro Sistema</H1>
												<P>&nbsp;</P>
												<P>Ingresa a nuestro sistema y disfruta de consultas gratuitas&nbsp;durante 
													el&nbsp;período de prueba. Si no estás registrado&nbsp;pulsa
													<asp:hyperlink id="lnkRegistro" runat="server" ForeColor="Green" NavigateUrl="http://www.cantv.net"
														Font-Size="X-Small">aquí</asp:hyperlink>.</P>
												<P>&nbsp;</P>
												<P><asp:label id="lblLogin" runat="server" Font-Size="XX-Small">CEDULA</asp:label></P>
												<P><asp:textbox id="txtCedula" runat="server" Font-Size="XX-Small" Width="88px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidatorLogin" runat="server" Font-Size="X-Small" Width="23px"
														ControlToValidate="txtCedula" ErrorMessage="Especifique una Cédula">*</asp:requiredfieldvalidator>
													<asp:RangeValidator id="RangeValidatorCI" runat="server" Font-Size="X-Small" ErrorMessage="Cédula Inválida"
														ControlToValidate="txtCedula" MaximumValue="100000000" MinimumValue="1000000" Type="Integer">*</asp:RangeValidator></P>
												<P><asp:label id="lblPassword" runat="server" Font-Size="XX-Small">PASSWORD</asp:label></P>
												<P><asp:textbox id="txtPassword" runat="server" Font-Size="XX-Small" Width="112px" TextMode="Password"></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredfieldvalidatorPass" runat="server" Width="23px" Font-Size="X-Small"
														ErrorMessage="Especifique una contraseña" ControlToValidate="txtPassword">*</asp:requiredfieldvalidator></P>
												<P>&nbsp;</P>
												<P><asp:button id="btnIngresar" runat="server" Font-Size="XX-Small" Text="Ingresar"></asp:button></P>
												<P>&nbsp;</P>
												<P><asp:validationsummary id="ValidationSummaryHome" runat="server" HeaderText="Errores Encontrados"></asp:validationsummary></P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</P>
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
