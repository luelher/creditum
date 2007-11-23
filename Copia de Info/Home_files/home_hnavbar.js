//©Xara Ltd
if(typeof(loc)=="undefined"||loc==""){var loc="";if(document.body&&document.body.innerHTML){var tt=document.body.innerHTML;var ml=tt.match(/["']([^'"]*)home_hnavbar.js["']/i);if(ml && ml.length > 1) loc=ml[1];}}

var bd=0
document.write("<style type=\"text/css\">");
document.write("\n<!--\n");
document.write(".home_hnavbar_menu {z-index:999;border-color:#000000;border-style:solid;border-width:"+bd+"px 0px "+bd+"px 0px;background-color:#339721;position:absolute;left:0px;top:0px;visibility:hidden;}");
document.write(".home_hnavbar_plain, a.home_hnavbar_plain:link, a.home_hnavbar_plain:visited{text-align:left;background-color:#339721;color:#ffffff;text-decoration:none;border-color:#000000;border-style:solid;border-width:0px "+bd+"px 0px "+bd+"px;padding:2px 0px 2px 0px;cursor:hand;display:block;font-size:8pt;font-family:Arial, Helvetica, sans-serif;font-weight:bold;}");
document.write("a.home_hnavbar_plain:hover, a.home_hnavbar_plain:active{background-color:#bef97d;color:#000000;text-decoration:none;border-color:#000000;border-style:solid;border-width:0px "+bd+"px 0px "+bd+"px;padding:2px 0px 2px 0px;cursor:hand;display:block;font-size:8pt;font-family:Arial, Helvetica, sans-serif;font-weight:bold;}");
document.write("a.home_hnavbar_l:link, a.home_hnavbar_l:visited{text-align:left;background:#339721 url("+loc+"home_hnavbar_l.gif) no-repeat right;color:#ffffff;text-decoration:none;border-color:#000000;border-style:solid;border-width:0px "+bd+"px 0px "+bd+"px;padding:2px 0px 2px 0px;cursor:hand;display:block;font-size:8pt;font-family:Arial, Helvetica, sans-serif;font-weight:bold;}");
document.write("a.home_hnavbar_l:hover, a.home_hnavbar_l:active{background:#bef97d url("+loc+"home_hnavbar_l2.gif) no-repeat right;color: #000000;text-decoration:none;border-color:#000000;border-style:solid;border-width:0px "+bd+"px 0px "+bd+"px;padding:2px 0px 2px 0px;cursor:hand;display:block;font-size:8pt;font-family:Arial, Helvetica, sans-serif;font-weight:bold;}");
document.write("\n-->\n");
document.write("</style>");

var fc=0x000000;
var bc=0xbef97d;
if(typeof(frames)=="undefined"){var frames=0;}

startMainMenu("",0,0,2,0,0)
mainMenuItem("home_hnavbar_b1",".gif",43,117,"../home.aspx","","HOME",2,2,"home_hnavbar_plain");
mainMenuItem("home_hnavbar_b2",".gif",43,117,"quienes_somos.aspx","","¿QUIENES SOMOS?",2,2,"home_hnavbar_plain");
mainMenuItem("home_hnavbar_b3",".gif",43,117,"javascript:;","","SERVICIOS",2,2,"home_hnavbar_plain");
mainMenuItem("home_hnavbar_b4",".gif",43,117,"javascript:;","","CONTACTANOS",2,2,"home_hnavbar_plain");
mainMenuItem("home_hnavbar_b5",".gif",43,117,"javascript:;","","LINKS",2,2,"home_hnavbar_plain");
mainMenuItem("home_hnavbar_b6",".gif",43,117,"javascript:;","","AYUDA",2,2,"home_hnavbar_plain");
endMainMenu("",0,0);

startSubmenu("home_hnavbar_b6","home_hnavbar_menu",158);
submenuItem("INFORMACION GENERAL","javascript:;","","home_hnavbar_plain");
submenuItem("PREGUNTAS Y RESPUESTAS","javascript:;","","home_hnavbar_plain");
submenuItem("SOPORTE TECNICO","javascript:;","","home_hnavbar_plain");
endSubmenu("home_hnavbar_b6");

startSubmenu("home_hnavbar_b4","home_hnavbar_menu",117);
submenuItem("VIA TELEFONICA","via_telefonica.aspx","","home_hnavbar_plain");
submenuItem("VIA EMAIL","via_email.aspx","","home_hnavbar_plain");
endSubmenu("home_hnavbar_b4");

startSubmenu("home_hnavbar_b3_3","home_hnavbar_menu",146);
submenuItem("CONSULTAS MENSUALES","javascript:;","","home_hnavbar_plain");
submenuItem("MI PERFIL","javascript:;","","home_hnavbar_plain");
endSubmenu("home_hnavbar_b3_3");

startSubmenu("home_hnavbar_b3_2","home_hnavbar_menu",150);
submenuItem("INFORMACION CREDITICIA","javascript:;","","home_hnavbar_plain");
submenuItem("ESTADO DE CUENTA","javascript:;","","home_hnavbar_plain");
endSubmenu("home_hnavbar_b3_2");

startSubmenu("home_hnavbar_b3","home_hnavbar_menu",212);
submenuItem("REGISTRO","javascript:;","","home_hnavbar_plain");
mainMenuItem("home_hnavbar_b3_2","CONSULTAS",0,0,"javascript:;","","",1,1,"home_hnavbar_l");
mainMenuItem("home_hnavbar_b3_3","REPORTES",0,0,"javascript:;","","",1,1,"home_hnavbar_l");
submenuItem("ENVIAR INFORMACION DE CLIENTE","javascript:;","","home_hnavbar_plain");
endSubmenu("home_hnavbar_b3");

loc="";
