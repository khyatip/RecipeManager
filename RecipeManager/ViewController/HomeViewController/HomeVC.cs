using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace RecipeManager
{
	public partial class HomeVC : UIViewController
	{

		IEnumerable<Recipe> recipeTableItems;
		RecipesViewModel recipesVM;
		RecipeDetailsVC recipeDetailsVC;
		CreateEventEditViewDelegate eventControllerDelegate;

		public HomeVC(IEnumerable<Recipe> recipeTableItems, RecipesViewModel recipesVM) : base("HomeVC", null)
		{
			this.recipeTableItems = recipeTableItems;
			this.recipesVM = recipesVM;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Recipes";

			SearchBar.TextChanged += (sender, e) =>
			{
				SearchBar.ShowsCancelButton = true;
			};
			SearchBar.SearchButtonClicked += (sender, e) =>
			{
				if (SearchFilterSeclectionCheck() == true)
				{
					SearchBar.ResignFirstResponder();
	                Search();
				}
			};
			SearchBar.CancelButtonClicked += (sender, e) =>
			{
				SearchBar.Text = "";
				SearchBar.ShowsCancelButton = false;
				UpdateRecipesTableView(recipesVM.GetRecipesTableItems());
				SearchBar.ResignFirstResponder();
			};
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			RecipeTableView.ContentInset = new UIEdgeInsets(-35, 0, 0, 0);
			UpdateRecipesTableView(recipesVM.GetRecipesTableItems());

		}
		public void UpdateRecipesTableView(IEnumerable<Recipe> recipeTableItems)
		{
			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems, this);
			RecipeTableView.ReloadData();
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			NavigationController.NavigationBarHidden = false;
		}

		partial void AddRecipeButtonSelected(Foundation.NSObject sender)
		{
			var recipe = new Recipe();
			ViewRecipe(recipe);

		}
		public void ViewRecipe(Recipe recipe)
		{
			var ingredientsVM = new IngredientsViewModel(/*recipesVM.GetIngredientsTableItems(recipe.Id)*/);
			var stepsVM = new StepsViewModel(/*recipesVM.GetStepsTableItems(recipe.Id)*/);
			recipeDetailsVC = new RecipeDetailsVC(recipe,ingredientsVM, stepsVM);
			recipeDetailsVC.EdgesForExtendedLayout = UIRectEdge.None;
			recipeDetailsVC.Delegate = this;
			NavigationController.PushViewController(recipeDetailsVC, true);
		}

		partial void CalorieTrackerButtonSelected(NSObject sender)
		{
			var calorieTrackerVC = new CalorieTrackerVC();
			calorieTrackerVC.EdgesForExtendedLayout = UIRectEdge.None;
			NavigationController.PushViewController(calorieTrackerVC, true);
		}

		public void SaveRecipe(Recipe recipe)
		{
			recipesVM.SaveRecipe(recipe);
			NavigationController.PopViewController(true);
		}
		public void SaveIngredient(int recipeID, string ingredient)
		{
			recipesVM.SaveIngredient(recipeID, ingredient);
		}
		public int GetNextRecipeID()
		{
			if (recipeTableItems.ToList().Count == 0)
				return 1;

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
					recipeTableItems = recipesVM.SearchByRecipeTitle(SearchBar.Text);
				else if (CalorieCountFilterButton.BackgroundColor == UIColor.LightGray) // error handling
					recipeTableItems = recipesVM.SearchByCalories(SearchBar.Text);
				else if (CookTimeFilterButton.BackgroundColor == UIColor.LightGray) // error handling
					recipeTableItems = recipesVM.SearchByCookTime(SearchBar.Text);
			}

			SearchBar.Text = "";
			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems, this);
			RecipeTableView.ReloadData();
		}

		partial void ShoppingListButtonSelected(NSObject sender)
		{
			var shoppingListVC = new WeeklyShoppingListVC(recipesVM.GetWeeklyShoppingList());
			shoppingListVC.EdgesForExtendedLayout = UIRectEdge.None;
			shoppingListVC.Delegate = this;
			NavigationController.PushViewController(shoppingListVC, true);
		}

		public bool SearchFilterSeclectionCheck()
		{
			if (RecipeTitleFilterButton.Highlighted == false && CalorieCountFilterButton.Highlighted == false && CookTimeFilterButton.Highlighted == false)
			{
				var okAlertController = UIAlertController.Create("Error", "Select Recipe Title, Calorie Count, or Cook Time filter before searching.", UIAlertControllerStyle.Alert);
				okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
				PresentViewController(okAlertController, true, null);
				return false;
			}
			return true;
		}
		public void LaunchCreateNewEvent(Foundation.NSIndexPath indexPath)
		{
			EventKitUI.EKEventEditViewController eventController = new EventKitUI.EKEventEditViewController();
			eventController.EventStore = App.Current.EventStore;
			eventControllerDelegate = new CreateEventEditViewDelegate(eventController, recipeTableItems.ToList()[indexPath.Row]);
			eventController.EditViewDelegate = eventControllerDelegate;
			eventController.Title = recipeTableItems.ToList()[indexPath.Row].RecipeTitle;
			NavigationController.PresentViewController(eventController, true, null);
		}
	}
}

