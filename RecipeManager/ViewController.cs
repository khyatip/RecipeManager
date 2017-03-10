using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace RecipeManager
{
	public partial class ViewController : UIViewController
	{

		//UITableView recipeTable;
		List<string> tableItems = new List<string>();

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var width = View.Bounds.Width;
			var height = View.Bounds.Height;

			CreateTableItems();
			Add(RecipeTableView);

		}
		private static void Print(string s)
		{
			Console.WriteLine(s);
		}

		protected void CreateTableItems()
		{
			
			tableItems.Add("Apple");
			tableItems.Add("Banana");
			tableItems.Add("Carrots");
			tableItems.Add("Something that starts with a D");
			RecipeTableView.Source = new RecipeTableSource(tableItems);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}
