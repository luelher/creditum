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

namespace Creditum
{
	/// <summary>
	/// Descripción breve de Via_Email.
	/// </summary>
	public class Via_Email : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Image HSeparador1;
		protected System.Web.UI.WebControls.HyperLink lnkRegistro;
		protected System.Web.UI.WebControls.Label lblLogin;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorCI;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorCI;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorPass;
		protected System.Web.UI.WebControls.Button btnIngresar;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.AdRotator RotadorBanner;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.HyperLink lnkMail;
		protected System.Web.UI.WebControls.HyperLink lnkMail2;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (User.Identity.IsAuthenticated)
				lblTime.Text = User.Identity.Name.ToString();	
			else
				lblTime.Text = System.DateTime.Now.ToLongDateString();

			// Introducir aquí el código de usuario para inicializar la página
		}

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
