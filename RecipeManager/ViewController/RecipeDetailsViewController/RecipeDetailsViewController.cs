using System;
using System.Collections.Generic;
using UIKit;

namespace RecipeManager
{
	public partial class RecipeDetailsViewController : UIViewController
	{
		Recipe currentRecipe { get; set; }
		//List<Ingredient> ingredientsTableView = new List<Ingredient>();
		//List<Step> stepsTableView = new List<Step>();
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
			//if (currentRecipe.RecipeTitle != "" && currentRecipe.CalorieCount != 0 && currentRecipe.CookTimeInMinutes != 0)
			//{
			//	RecipeTitleField.Text = currentRecipe.RecipeTitle;
			//	CalorieCountField.Text = Convert.ToString(currentRecipe.CalorieCount);
			//	CookTimeField.Text = Convert.ToString(currentRecipe.CookTimeInMinutes);
			//	if (currentRecipe.ingredients != null)
			//	{
			//		ingredientsTableView = currentRecipe.ingredients;
			//		IngredientsTableView.Source = new IngredientsTableViewSource(ingredientsTableView.ToArray());
			//	}
			//	if (currentRecipe.recipeSteps != null)
			//	{
			//		stepsTableView = currentRecipe.recipeSteps;
			//		RecipeStepsTableView.Source = new StepsTableViewSource(stepsTableView.ToArray());
			//	}
			//}
		}
		//partial void AddIngredientButtonSelected(Foundation.NSObject sender)
		//{
		//	int newIngredientId;
		//	if (ingredientsTableView.Count == 0)
		//		newIngredientId = 0;
		//	else
		//		newIngredientId = ingredientsTableView[ingredientsTableView.Count - 1].Id + 1;

		//	if (IngredientField.Text != "")
		//	{
		//		ingredientsTableView.Add(new Ingredient(newIngredientId, IngredientField.Text));
		//		IngredientField.Text = "";
		//		IngredientsTableView.Source = new IngredientsTableViewSource(ingredientsTableView.ToArray());
		//		IngredientsTableView.ReloadData();
		//	}	
		//}
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

