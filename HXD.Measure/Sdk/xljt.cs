using System;
using System.Web.UI;
namespace Sdk
{
	public class xljt : Page
	{
		private void Page_Load(object sender, EventArgs e)
		{
		}
		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}
		private void InitializeComponent()
		{
			base.add_Load(new EventHandler(this.Page_Load));
		}
	}
}
