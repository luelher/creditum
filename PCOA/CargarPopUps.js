function popup_windowCC()
{
    window.open('http://localhost/creditum/pcoa/NuevaCasaComercial.aspx', '_blank', 'width=285, height=390, menubar=no, scrollbars=yes, toolbar=no, location=no, resizable=no, top=200, left=400');
}
function popup_window() 
{
    window.open('http://localhost/creditum', 'Creditum', 'width=' + (screen.width-10) + ', height=' + (screen.height-70) + ', menubar=no, scrollbars=yes, toolbar=no, location=no, resizable=yes, top=o, left=0');
}
function popup_windowSuc()
{
    window.open('http://localhost/creditum/pcoa/NuevaSucursal.aspx', '_blank', 'width=350, height=500, menubar=no, scrollbars=yes, toolbar=no, location=no, resizable=no, top=150, left=400');
}
function popup_windowMCC(index)
{
    window.open('http://localhost/creditum/pcoa/MCasaComercial.aspx?Index='+index, '_blank', 'width=285, height=390, menubar=no, scrollbars=yes, toolbar=no, location=no, resizable=no, top=200, left=400');
}
function popup_windowMSuc(index)
{
    window.open('http://localhost/creditum/pcoa/MSucursal.aspx?Index='+index, '_blank', 'width=350, height=500, menubar=no, scrollbars=yes, toolbar=no, location=no, resizable=no, top=150, left=400');
}