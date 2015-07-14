using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace WebApplication2
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//var content = File.ReadAllText(@"C:/103578186.html");
			//var result = content.Substring(content.IndexOf(""));

			//IList<Record> myList = GetContent(content).Select(r => new Record() { Value = r }).ToList();
			//Response.Write(GetContent(content));

			//int count = 1;
			//using (var ctx = new DemoContext())
			//{
			//	MyGridView.DataSource = ctx.Data.ToList();
			//	MyGridView.DataBind();
			//myList.ToList().ForEach(c => ctx.Data.Add(new Data()
			//{
			//	DataId = count++,
			//	Content = c.Value
			//}));

			//ctx.SaveChanges();
		}

		private IEnumerable<string> GetContent(string content)
		{
			var doc = new HtmlDocument();
			doc.LoadHtml(content);

			return doc.DocumentNode.SelectNodes("//text()").Select(node => node.InnerText).ToList();
		}

		protected void btnSaveData_Click(object sender, EventArgs e)
		{
			var content = File.ReadAllText(@"C:/103578186.html");
			//var content = File.ReadAllText(@"C:/CM Team/102935761.html");
			var myList = GetContent(content);
			var count = 100;
			using (var ctx = new DemoContext())
			{

				myList.ToList().ForEach(c => ctx.Data.Add(new Data()
				{
					DataId = count++,
					Content = c
				}));

				ctx.SaveChanges();
			}
		}

		protected void btnShowData_Click(object sender, EventArgs e)
		{
			using (var ctx = new DemoContext())
			{
				XDocument doc =
  new XDocument(
    new XElement("file",
      new XElement("name", new XAttribute("filename", "sample")),
      new XElement("date", new XAttribute("modified", DateTime.Now)),
      new XElement("info",
        ctx.Data.ToList().Select(x => new XElement("data", new XAttribute("value", x.Content)))
      )
    )
  );

				//var doc = new XmlDocument();
				//var root = doc.CreateElement("Root");
				
				//ctx.Data.ToList().ForEach(line =>
				//{
				//	var node = doc.CreateElement("Data");
				//	node.Value = line.Content.Replace(Environment.NewLine, "").Replace("\r\n", "");
				//	root.AppendChild(node);
				//});
				//doc.AppendChild(root);
				
				doc.Save(@"c:\temp.xml");

				MyGridView.DataSource = ctx.Data.ToList();
				MyGridView.DataBind();
			}
		}

		public class Record
		{
			public string Value { get; set; }
		}
	}
}