using System;
using System.Collections.Generic;
using System.Linq;
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
			AddRecipeButton.TouchUpInside += (sender, ea) =>
			{
				AddRecipeButtonSelected();
			};
			SearchBar.SearchButtonClicked += (sender, e) =>
			{
				//TODO: error checking for if one of the buttons is not selected
				Search();
			};
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			//NavigationController.NavigationBarHidden = true;
			RecipeTableView.ContentInset = new UIEdgeInsets(-35, 0, 0, 0);
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

		partial void RecipeTitleFilterButtonSelected(Foundation.NSObject sender)
		{
			RecipeTitleFilterButton.Highlighted = true;
			RecipeTitleFilterButton.BackgroundColor = UIColor.LightGray;
			CalorieCountFilterButton.BackgroundColor = UIColor.White;
			CookTimeFilterButton.BackgroundColor = UIColor.White;
		}
		partial void CalorieCountFilterButtonSelected(Foundation.NSObject sender)
		{
			CalorieCountFilterButton.Highlighted = true;
			CalorieCountFilterButton.BackgroundColor = UIColor.LightGray;
			RecipeTitleFilterButton.BackgroundColor = UIColor.White;
			CookTimeFilterButton.BackgroundColor = UIColor.White;
		}
		partial void CookTimeFilterButtonSelected(Foundation.NSObject sender)
		{
			CookTimeFilterButton.Highlighted = true;
			CookTimeFilterButton.BackgroundColor = UIColor.LightGray;
			CalorieCountFilterButton.BackgroundColor = UIColor.White;
			RecipeTitleFilterButton.BackgroundColor = UIColor.White;
		}
		public void Search()
		{
			if (!string.IsNullOrEmpty(SearchBar.Text))
			{
				if (RecipeTitleFilterButton.BackgroundColor == UIColor.LightGray)
					recipeTableItems = AppDelegate.RecipesDB.SearchByRecipeTitle(SearchBar.Text);
				else if (CalorieCountFilterButton.BackgroundColor == UIColor.LightGray) // error handling
					recipeTableItems = AppDelegate.RecipesDB.SearchByCalories(Convert.ToInt32(SearchBar.Text));
				else if (CookTimeFilterButton.BackgroundColor == UIColor.LightGray) // error handling
					recipeTableItems = AppDelegate.RecipesDB.SearchByCookTime(Convert.ToInt32(SearchBar.Text));
			}

			SearchBar.Text = "";
			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems);
			RecipeTableView.ReloadData();
		}
	}
}
