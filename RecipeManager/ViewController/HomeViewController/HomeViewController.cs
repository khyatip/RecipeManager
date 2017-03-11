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

			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems.ToArray());
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			if (segue.Identifier == "RecipeDetailsSegue")
			{
				var destinationController = segue.DestinationViewController as RecipeDetailsViewController;
				if (destinationController != null)
				{
					destinationController.Delegate = this;
					destinationController.CurrentRecipe = CreateNewRecipe();
				}
			}
		}

		partial void AddRecipeButtonSelected(Foundation.NSObject sender)
		{
			
		}

		public Recipe CreateNewRecipe()
		{
			int newId;

			if (recipeTableItems.Count == 0)
				newId = 0;
			else 
				newId = recipeTableItems[recipeTableItems.Count - 1].Id + 1;

			var newRecipe = new Recipe { Id = newId};

			return newRecipe;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}
