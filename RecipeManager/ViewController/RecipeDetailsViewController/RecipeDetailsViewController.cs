using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace RecipeManager
{
	public partial class RecipeDetailsViewController : UIViewController
	{
		Recipe currentRecipe { get; set; }
		IEnumerable<Ingredient> ingredientsTableItems;
		IEnumerable<Step>stepsTableItems;
		public HomeViewController Delegate { get; set; }
		//public HomeViewController DelegateHome { get; set; }
		//public SearchResultsViewController DelegateSearch  {get; set; }

		protected RecipeDetailsViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Details";
		}
		public void SetRecipe(HomeViewController homeViewController, Recipe recipe)
		{
			Delegate = homeViewController;
			currentRecipe = recipe;    	
		}
		public int GetNextStepNumber()
		{
			if (stepsTableItems.ToList().Count == 0)
				return 1;
			else
				return stepsTableItems.ToList().Count + 1;
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			if (currentRecipe == null)
				currentRecipe = new Recipe();
			RecipeTitleField.Text = currentRecipe.RecipeTitle;
			CalorieCountField.Text = Convert.ToString(currentRecipe.CalorieCount);
			CookTimeField.Text = Convert.ToString(currentRecipe.CookTimeInMinutes);

			ingredientsTableItems = AppDelegate.RecipesDB.GetIngredientsList(currentRecipe.Id);
			IngredientsTableView.Source = new IngredientsTableViewSource(ingredientsTableItems);
			IngredientsTableView.ReloadData();

			stepsTableItems = AppDelegate.RecipesDB.GetStepsList(currentRecipe.Id);
			RecipeStepsTableView.Source = new StepsTableViewSource(stepsTableItems);
			RecipeStepsTableView.ReloadData();

		}
		partial void AddIngredientButtonSelected(Foundation.NSObject sender)
		{
			var newIngredient = new Ingredient();
			if (IngredientField.Text != null && IngredientField.Text != "")
			{
				int recipeId;
				if (currentRecipe.Id == 0) // this is a new recipe; not yet saved
					recipeId = Delegate.GetNextRecipeID();
				else
					recipeId = currentRecipe.Id;
				
				newIngredient.RecipeId = recipeId;
				newIngredient.IngredientTitle = IngredientField.Text;
				AppDelegate.RecipesDB.SaveIngredient(newIngredient);
				IngredientField.Text = "";
				ingredientsTableItems = AppDelegate.RecipesDB.GetIngredientsList(recipeId);
				IngredientsTableView.Source = new IngredientsTableViewSource(ingredientsTableItems);
				IngredientsTableView.ReloadData();
			}
		}
		partial void AddRecipeStepButtonSelected(Foundation.NSObject sender)
		{
			var newStep = new Step();
			if (RecipeStepField.Text != null && RecipeStepField.Text != "")
			{
				int recipeId;
				int stepCount = GetNextStepNumber();
				if (currentRecipe.Id == 0) // this is a new recipe; not yet saved
					recipeId = Delegate.GetNextRecipeID();
				else
					recipeId = currentRecipe.Id;

				newStep.RecipeId = recipeId;
				newStep.StepDetail = stepCount + ". " + RecipeStepField.Text;
				AppDelegate.RecipesDB.SaveStep(newStep);
				RecipeStepField.Text = "";
				stepsTableItems = AppDelegate.RecipesDB.GetStepsList(recipeId);
				RecipeStepsTableView.Source = new StepsTableViewSource(stepsTableItems);
				RecipeStepsTableView.ReloadData();
			}
		}
		partial void RecipeSaveButtonSelected(Foundation.NSObject sender)
		{
			// TODO: Error Handling 
			if (RecipeTitleField.Text != null && RecipeTitleField.Text != "")
				currentRecipe.RecipeTitle = RecipeTitleField.Text;
			if (CalorieCountField.Text != null && CalorieCountField.Text != "")//character to int handling
				currentRecipe.CalorieCount = Convert.ToInt32(CalorieCountField.Text);
			if (CookTimeField.Text != null && CookTimeField.Text != "")
				currentRecipe.CookTimeInMinutes = Convert.ToInt32(CookTimeField.Text);
			
				Delegate.SaveRecipe(currentRecipe);
				NavigationController.PopViewController(true);


		}
	}
}

