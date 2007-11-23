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
using Creditum.Usuarios;
using GrupoEmporium.Mensajes;

namespace Creditum
{
	/// <summary>
	/// Descripci�n breve de CambioPwd.
	/// </summary>
	public class CambioPwd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorPass;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorPwd1;
		protected System.Web.UI.WebControls.TextBox txtPwdNuevo;
		protected System.Web.UI.WebControls.Label lblpwdnuevo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorPwd2;
		protected System.Web.UI.WebControls.TextBox txtPwdConfirm;
		protected System.Web.UI.WebControls.Label lblPwdConfirm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			string scriptConfirmar = @"return confirm('Esta seguro que desea cambiar su contrase�a?');";
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
				lblError.Text = "";
				lblInfo.Text = "";
				if (txtPwdNuevo.Text != txtPwdConfirm.Text)
					lblError.Text = "Error, las contrase�as no coinciden";
				else
				{
					if (txtPassword.Text == txtPwdConfirm.Text)
						lblError.Text = "Error, la contrase�a anterior y nueva son iguales";
					else
					{
						MetodosComunes mc = new MetodosComunes();
						Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
						DataSet ds = new DataSet();
						try
						{
							#region VerificarContrase�a
							ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
							usr = usr.Buscar(ds.Tables["Config"].Rows[0].ItemArray[0].ToString(),
								ds.Tables["Config"].Rows[0].ItemArray[1].ToString(),
								ds.Tables["Config"].Rows[0].ItemArray[2].ToString(),
								ds.Tables["Config"].Rows[0].ItemArray[3].ToString(),
								Convert.ToInt32(usr.Cedula),
								txtPassword.Text);
							#endregion
							if (usr != null)
							{
								#region CargarConfig
								clsBDConexion conn = MetodosComunes.Conectar(out ds);
								#endregion
								#region Consulta
								string strSQLUPDATE =
									@"UPDATE usuarios SET PWD=PASSWORD('" + txtPwdNuevo.Text + @"')" + " "
									+ @"WHERE cedula=" + usr.Cedula + ";";
								#endregion
								if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) > 0)
								{
									txtPassword.Text = "";
									txtPwdConfirm.Text = "";
									txtPwdNuevo.Text = "";
									lblInfo.Text = "Contrase�a actualizada satisfactoriamente";
									//MensajeWeb.Info("Datos del usuario actualizados satisfactoriamente", Page, "Update1");
								}
								else
									lblError.Text = @"Error actualizando los datos. El sistema puede que no est� disponible";
							}
							else
								lblError.Text = "Error, Contrase�a inv�lida";
						}
						catch
						{
							lblError.Text = @"Error actualizando los datos. El sistema puede que no est� disponible";
						}
					}
				}
			}
		}
	
	}
}
