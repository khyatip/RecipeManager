using System;
using System.Collections.Generic;
using UIKit;

namespace RecipeManager
{
	public partial class RecipeDetailsViewController : UIViewController
	{
		Recipe currentRecipe { get; set; }
		IEnumerable<Ingredient> ingredientsTableItems;
		public HomeViewController Delegate { get; set; }

		protected RecipeDetailsViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		public void SetRecipe(HomeViewController homeViewController, Recipe recipe)
		{
			Delegate = homeViewController;
			currentRecipe = recipe;    	
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
				ingredientsTableItems = AppDelegate.RecipesDB.GetIngredientsList(currentRecipe.Id);
				IngredientsTableView.Source = new IngredientsTableViewSource(ingredientsTableItems);
				IngredientsTableView.ReloadData();
			}
		}
		//partial void AddRecipeStepButtonSelected(Foundation.NSObject sender)
		//{
		//	int newStepId;
		//	if (stepsTableView.Count == 0)
		//		newStepId = 0;
		//	else
		//		newStepId = stepsTableView[stepsTableView.Count - 1].Id + 1;

		//	if (RecipeStepField.Text != "")
		//	{
		//		stepsTableView.Add(new Step(newStepId, (stepsTableView.Count+1 + ". " + RecipeStepField.Text)));
		//		RecipeStepField.Text = "";
		//		RecipeStepsTableView.Source = new StepsTableViewSource(stepsTableView.ToArray());
		//		RecipeStepsTableView.ReloadData();
		//	}
		//}
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

