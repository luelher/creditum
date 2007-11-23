using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;
using Creditum.Usuarios;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripci�n breve de NuevaCasaComercial.
	/// </summary>
	public class NuevaCasaComercial : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtRif;
		protected System.Web.UI.WebControls.Label lblRif;
		protected System.Web.UI.WebControls.TextBox txtNit;
		protected System.Web.UI.WebControls.Label lblNit;
		protected System.Web.UI.WebControls.TextBox txtUbicacion;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorNombre;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryCC;
		protected System.Web.UI.WebControls.Label lblUbicacion;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
				{
				}
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			string scriptConfirmar = @"return confirm('Desea agregar la casa comercial ' + txtNombre.value + '?');";
			btnAceptar.Attributes.Add("OnClick", scriptConfirmar);
		}

		#region C�digo generado por el Dise�ador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Dise�ador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				DataSet ds = new DataSet();
				try
				{
					#region CargarConfig
					ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					#region SqlInsert
					string strInsert = 
						@"INSERT INTO casas_comerciales(NOMBRE,RIF,NIT,UBICACION) "
						+ @"VALUES("
						+ "'" + txtNombre.Text + "',"
						+ "'" + txtRif.Text + "',"
						+ "'" + txtNit.Text + "',"
						+ "'" + txtUbicacion.Text + @"');";
					#endregion
					if (clsBD.EjecutarNonQuery(conn, strInsert) == -1)
						//lblError.Text = "No se pudo agregar el nuevo usuario, verifique si �ste ya existe";
						MensajeWeb.Info("No se pudo agregar la nueva Casa Comercial, el sistema no est� disponible", Page, "InfoError1");
					else
					{
						txtNombre.Text = "";
						txtRif.Text = "";
						txtNit.Text = "";
						txtUbicacion.Text = "";
						MensajeWeb.Info("La casa Comercial ha sido registrada satisfactoriamente, gracias por utilizar CREDITUM", Page, "InfoOK1");
						Page.RegisterStartupScript("cerrar","<script language='javascript'>window.close();</script>");
					}
				}
				catch
				{
					MensajeWeb.Info("No se pudo agregar la nueva Casa Comercial, el sistema no est� disponible en estos momentos", Page, "InfoError5");
					//lblError.Text = "No se pudo agregar el nuevo usuario, el sistema no esta disponible en estos momentos";
					//lblInfo.Text = "";
				}
			}
		}
	}
}
