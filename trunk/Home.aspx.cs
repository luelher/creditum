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
using System.Web.Security;
using Creditum.Usuarios;

namespace Creditum
{
	/// <summary>
	/// Descripci�n breve de Home.
	/// </summary>
	public class Home : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkEmail;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Image HSeparador1;
		protected System.Web.UI.WebControls.Label lblLogin;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnIngresar;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.AdRotator RotadorBanner;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorCI;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorPass;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorCI;
		protected System.Web.UI.WebControls.Label lblStatus;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			lblTime.Text = System.DateTime.Now.ToLongDateString();
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
			this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnIngresar_Click(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			try
			{
				MetodosComunes mc = new MetodosComunes();
				bool res = mc.AutenticarRedireccionar(txtCedula.Text, txtPassword.Text, Page);
				if (!res)
					lblStatus.Text = "Login o Password Inv�lido";
			}
			catch(Exception ex)
			{
				lblStatus.Text = "Login o Password Inv�lido" + ex.Message;
			}
		}
	}
}
