namespace Creditum
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.UI;

	/// <summary>
	/// Cancel the move of the scrollbar
	/// </summary>
	public class GetPositionPostBack: System.Web.UI.HtmlControls.HtmlInputHidden, IPostBackDataHandler
	{
		public int VPos
		{
			get 
			{
				if(ViewState["VPos"]==null)
				{
					ViewState["VPos"] = 0;
				}
				return (int)ViewState["VPos"];
			}
			set { ViewState["VPos"] = value; }
		}

		public int HPos
		{
			get
			{
				if(ViewState["HPos"]==null)
				{
					ViewState["HPos"] = 0;
				}
				return (int)ViewState["HPos"];
			}
			set { ViewState["HPos"] = value; }
		}


		public bool LoadPostData(String postDataKey, System.Collections.Specialized.NameValueCollection values) 
		{
			bool _returnV;
			bool _returnH;
				
			string Val = values[this.UniqueID].Trim();
			char Eperluette = Char.Parse("&");
			string[] _Val = Val.Split(Eperluette);
			if(_Val.Length>1)
			{
				if(!HPos.ToString().Equals(_Val[0])  && _Val[0].Trim()!=null )
				{
					HPos= Int32.Parse(_Val[0]);
					_returnH=true;	
				}
				else _returnH=false;

				if(!VPos.ToString().Equals(_Val[1])  && _Val[1].Trim()!=null )
				{
					VPos= Int32.Parse(_Val[1]);
					_returnV=true;	
				}
				else _returnV=false;	
			}
			else
			{
				HPos = 0;
				VPos=0;
				return false; //return true to execute RaisePostDataChangedEvent();
			}

			//_______return_________

			if(_returnV || _returnH) return false; //return true to execute RaisePostDataChangedEvent();
			else return false;		
		}

		public void RaisePostDataChangedEvent() 
		{
			// Part of the IPostBackDataHandler contract.  Invoked if we ever returned true from the
			// LoadPostData method (indicates that we want a change notification raised).  Since we
			// always return false, this method is just a no-op.		
			
		}		

		protected override void OnPreRender(EventArgs e) 
		{				
			string _start = "<script language='Javascript'>onscroll = function(){";
			_start += "document.getElementById('"+this.UniqueID+"').value = document.body.scrollLeft+'&'+document.body.scrollTop;";
			_start += "}</script>";
			if(!Page.IsClientScriptBlockRegistered("start"))
			{
				Page.RegisterClientScriptBlock("start",_start);
			}
			//_______________Move the scrollbar____________________________________
			string _goScroll = "<script language='javascript'>scrollTo("+this.HPos+","+this.VPos+");</script>";
			if(!Page.IsStartupScriptRegistered("goScroll"))
			{
				Page.RegisterStartupScript("goScroll",_goScroll);
			}
		}		
	}
}
