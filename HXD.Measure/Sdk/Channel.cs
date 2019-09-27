using Sdk.NewsSystem.Modules;
using System;
using System.Web.UI;
namespace Sdk
{
	public class Channel : Page
	{
		protected NewsList NewsList1;
		protected string title;
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				this.title = value;
			}
		}
		private void Page_Load(object sender, EventArgs e)
		{
			if (!base.get_IsPostBack())
			{
				string typeName = base.get_Request().get_Item("t");
				if (typeName == null || typeName == "")
				{
					base.get_Response().Write("参数错误");
					base.get_Response().End();
				}
				else
				{
					this.NewsList1.TypeName = typeName;
					this.Title = typeName;
				}
			}
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
