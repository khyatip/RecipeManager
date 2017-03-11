using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace RecipeManager
{
	public partial class HomeViewController : UIViewController
	{

		List<Recipe> recipeTableItems = new List<Recipe>();

		protected HomeViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var width = View.Bounds.Width;
			var height = View.Bounds.Height;

			CreateTableItems();

		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			if (segue.Identifier == "RecipeDetailsSegue")
			{
				var destinationController = segue.DestinationViewController as RecipeDetailsViewController;
				if (destinationController != null)
				{
					//var source = RecipeTableView.Source as RecipeTableSource;
					//var rowPath = RecipeTableView.IndexPathForSelectedRow;
					//var recipeItem = source.GetItem(rowPath.Row);
					//destinationController.SetRecipe(this, recipeItem);
					destinationController.Delegate = this;
				}
			}
		}


		protected void CreateTableItems()
		{
			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems.ToArray());
		}

		partial void AddRecipeButtonSelected(Foundation.NSObject sender)
		{
			CreateRecipe();
		}

		public void CreateRecipe()
		{
			int newId;
			if (recipeTableItems.Count == 0)
				newId = 0;
			else newId = recipeTableItems[recipeTableItems.Count - 1].Id + 1;
			var newRecipe = new Recipe { Id = newId};
			recipeTableItems.Add(newRecipe);
			Console.WriteLine(newRecipe.ToString());
			Console.WriteLine(recipeTableItems[newId].Id);
			var detailsView = Storyboard.InstantiateViewController("recipeDetailsViewController") as RecipeDetailsViewController;
			detailsView.SetRecipe(this, newRecipe);
		}

		public void SaveRecipe(Recipe recipe)
		{

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}
