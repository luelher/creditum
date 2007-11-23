using System;
using Creditum.Usuarios;
using System.Data;
using GrupoEmporium.Datos;
using System.Web.Security;
using System.Web.UI;

namespace Creditum
{
	/// <summary>
	/// Clase para ejecutar los metodos comunes a todos los web forms
	/// </summary>
	public class MetodosComunes
	{
		public MetodosComunes()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		/// <summary>
		/// Lee el valor del name de la cookie encriptado, y lo deserializa y retorna el objeto Usuario
		/// </summary>
		/// <param name="XmlConfigPath">Ruta al archivo Config.xml</param>
		/// <param name="strCookEncr">String del valor de la cookie</param>
		/// <returns>Objeto Usuario, null si ocurre un error</returns>
		public Usuario LeerCookie(string XmlConfigPath, string strCookEncr)
		{
			try
			{
				DataSet ds = new DataSet();
				ds.ReadXml(XmlConfigPath, XmlReadMode.ReadSchema);
				Usuario usr = new Usuario();
				return usr.DecryptDeser(strCookEncr, ds.Tables["Config"].Rows[0].ItemArray[4].ToString());
			}
			catch
			{
				return null;
			}			
		}

		public static clsBDConexion Conectar(out DataSet ds)
		{
			ds = new DataSet();
			try
			{
				#region CargarConfig
				ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
				clsBDConexion conn = new clsBDConexion(ds.Tables["Config"].Rows[0].ItemArray[0].ToString(),
					ds.Tables["Config"].Rows[0].ItemArray[1].ToString(),
					ds.Tables["Config"].Rows[0].ItemArray[2].ToString(),
					ds.Tables["Config"].Rows[0].ItemArray[3].ToString());
				#endregion
				return conn;
			}
			catch
			{
				return null;
			}
		}

		public bool AutenticarRedireccionar(string uid, string strPwd, Page pg)
		{
			DataSet ds = new DataSet();
			try
			{
				ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
				Usuario usr = new Usuario();
//
/*				
				string sql = "SELECT usuarios.*,clientes.nombre as nombrecliente,casas_comerciales.nombre as nombrecasacomercial FROM usuarios " +
							" inner join " +
							" (clientes inner join casas_comerciales on clientes.id_casa_comercial=casas_comerciales.id_casa_comercial) " +
							" on " +
							" usuarios.id_cliente = clientes.id_cliente " +
							" where cedula=" + uid.ToString() + " and pwd='" + strPwd.Replace(" ","_") + "'";

				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion

				DataTable dt = new DataTable();

				bool resp = clsBD.EjecutarQuery(conn,sql,out dt);

				if (dt.Rows.Count>0 && resp)
				{
					usr.IDCliente = Convert.ToInt32(dt.Rows[0]["id_cliente"].ToString());
					usr.Cedula = dt.Rows[0]["cedula"].ToString();
					usr.Nombre = dt.Rows[0]["nombre"].ToString();
					usr.Apellido = dt.Rows[0]["apellido"].ToString();
					usr.IDNivel = Convert.ToByte(dt.Rows[0]["id_nivel"].ToString());
					usr.NombreCliente = dt.Rows[0]["nombrecliente"].ToString();
					usr.NombreCasa = dt.Rows[0]["nombrecasacomercial"].ToString();

				}
				else{usr=null;}
*/
				usr = usr.Buscar(ds.Tables["Config"].Rows[0].ItemArray[0].ToString(),
					ds.Tables["Config"].Rows[0].ItemArray[1].ToString(),
					ds.Tables["Config"].Rows[0].ItemArray[2].ToString(),
					ds.Tables["Config"].Rows[0].ItemArray[3].ToString(),
					Convert.ToInt32(uid),
					strPwd);
					
				if (usr != null)
				{
					string usrEnc = usr.SerEncriptar(ds.Tables["Config"].Rows[0].ItemArray[4].ToString());
					FormsAuthentication.SetAuthCookie(usrEnc, false);
					RedireccionarUsuario(usr, pg);
					return true;
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				string exec = ex.Message;
				return false;
			}
		}

		private void RedireccionarUsuario(Usuario webusr, Page pg)
		{
			if (webusr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
				pg.Response.Redirect("pcoa/panelcontroloa.aspx");
			else if (webusr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR)))
				pg.Response.Redirect("pco/panelcontrolo.aspx");
			else if (webusr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR)))
				pg.Response.Redirect("pcc/panelcontrolc.aspx");
			else if (webusr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR_ADMINISTRADOR)))
				pg.Response.Redirect("pcca/panelcontrolca.aspx");
		}
	}
}
