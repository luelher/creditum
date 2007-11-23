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
using System.Web.Mail;

namespace Creditum
{
	/// <summary>
	/// Descripci�n breve de Enviar_Email.
	/// </summary>
	public class Enviar_Email : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.AdRotator RotadorBanner;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.Button btnEnviar;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtApellido;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlDestino;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Label lblDestino;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtMensaje;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryMail;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorApellido;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorMail;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
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
			this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnEnviar_Click(object sender, System.EventArgs e)
		{
			string Remitente = "Remitente: " + txtNombre.Text + " " + txtApellido.Text + "\n\r\n\r";
			MailMessage MyMail = new MailMessage();
			MyMail.From = txtEmail.Text;
			MyMail.To = ddlDestino.SelectedValue;
			MyMail.Subject = "Creditum: " + ddlDestino.Items[ddlDestino.SelectedIndex].Text;
			MyMail.Body = Remitente + txtMensaje.Text;
			MyMail.Cc = "";
			MyMail.Bcc = "";
			SmtpMail.SmtpServer = "mail.cantv.net";
			SmtpMail.Send(MyMail);
		}
	}
}
