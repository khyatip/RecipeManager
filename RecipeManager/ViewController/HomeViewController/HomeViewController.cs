using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreGraphics;
using SQLite;
using UIKit;

namespace RecipeManager
{
	public partial class HomeViewController : UIViewController
	{
		IEnumerable<Recipe> recipeTableItems;
		protected HomeViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			AddRecipeButton.TouchUpInside += (sender,ea) =>
			{
				AddRecipeButtonSelected();
			};
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationController.NavigationBarHidden = true;
			RecipeTableView.ContentInset = new UIEdgeInsets(-40, 0, 0, 0);
			recipeTableItems = AppDelegate.RecipesDB.GetRecipesList();
			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems);
			RecipeTableView.ReloadData();
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			NavigationController.NavigationBarHidden = false;
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
				var navctlr = segue.DestinationViewController as RecipeDetailsViewController;
				if (navctlr != null)
				{
					var source = RecipeTableView.Source as RecipeTableViewSource;
					var rowPath = RecipeTableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetRecipe(this, item);
				}
		}

		public void AddRecipeButtonSelected()
		{
			var detail = Storyboard.InstantiateViewController("RecipeDetails") as RecipeDetailsViewController;
			detail.Delegate = this;
			NavigationController.PushViewController(detail, true);
		}

		public void SaveRecipe(Recipe recipe)
		{
			AppDelegate.RecipesDB.SaveRecipe(recipe);
			NavigationController.PopViewController(true);
		}
		public int GetNextRecipeID()
		{
			if (recipeTableItems.ToList().Count == 0)
				return 1;
			else
				return recipeTableItems.ToList().Count + 1;
		}

	}
}
