using System;
using System.Collections.Generic;
using UIKit;

namespace RecipeManager
{
	public class RecipesViewModel
	{
		//IEnumerable<Recipe> recipeTableItems;
		static int lastRecipeID;

		public RecipesViewModel(/*IEnumerable<Recipe> recipeTableItems*/)
		{
			//this.recipeTableItems = recipeTableItems;
		}
		public IEnumerable<Recipe> GetRecipesTableItems()
		{
			return AppDelegate.RecipesDB.GetRecipesList();
			//return new RecipeTableViewSource(recipeTableItems, homeVC, recipeDetailsVC);
		}
		public IEnumerable<Ingredient> GetIngredientsTableItems(int recipeID/*, UITableView ingredientsTableView, RecipeDetailsVC recipeDetailsVC*/)
		{
			//ingredientsTableItems =
			return AppDelegate.RecipesDB.GetIngredientsList(recipeID);
			//return new IngredientsTableViewSource(ingredientsTableItems);
		}
		public IEnumerable<Step> GetStepsTableItems(int recipeID/*, UITableView ingredientsTableView, RecipeDetailsVC recipeDetailsVC*/)
		{
			//stepsTableItems = 
			return AppDelegate.RecipesDB.GetStepsList(recipeID);
			//return new StepsTableViewSource(stepsTableItems);
		}
		public int GetNextRecipeID()
		{
			return lastRecipeID++;
		}
		public void SaveRecipe(Recipe recipe)
		{
			AppDelegate.RecipesDB.SaveRecipe(recipe);
		}

		public void SaveIngredient(int recipeID, string ingredientTitle)
		{
			var newIngredient = new Ingredient();
			newIngredient.RecipeId = recipeID;
			newIngredient.IngredientTitle = ingredientTitle;
			AppDelegate.RecipesDB.SaveIngredient(newIngredient);
		}
		public void SaveStep(int recipeID, string stepDetail)
		{
			var newStep = new Step();
			newStep.RecipeId = recipeID;
			newStep.StepDetail = stepDetail;
			AppDelegate.RecipesDB.SaveStep(newStep);
		}
		public IEnumerable<Recipe> SearchByRecipeTitle(string searchString)
		{
			return AppDelegate.RecipesDB.SearchByRecipeTitle(searchString);
		}

		public IEnumerable<Recipe> SearchByCalories(string searchString)
		{
			return AppDelegate.RecipesDB.SearchByCalories(Convert.ToInt32(searchString));
		}
		public IEnumerable<Recipe> SearchByCookTime(string searchString)
		{
			return AppDelegate.RecipesDB.SearchByCookTime(Convert.ToInt32(searchString));
		}
		public IEnumerable<Ingredient> GetWeeklyShoppingList()
		{
			return AppDelegate.RecipesDB.GetWeeklyShoppingList();
		}

	}
}
