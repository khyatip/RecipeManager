using System;
using System.Collections.Generic;

namespace RecipeManager
{
	public class IngredientsViewModel
	{
		//IEnumerable<Ingredient> ingredientsTableItems;

		public IngredientsViewModel(/*IEnumerable<Ingredient> ingredientsTableItem*/)
		{
			//this.ingredientsTableItems = ingredientsTableItem;
		}
		public IEnumerable<Ingredient> GetIngredientsTableItems(int recipeID/*, UITableView ingredientsTableView, RecipeDetailsVC recipeDetailsVC*/)
		{
			//ingredientsTableItems =
			return AppDelegate.RecipesDB.GetIngredientsList(recipeID);
			//return new IngredientsTableViewSource(ingredientsTableItems
		}
		public Ingredient GetIngredient(int recipeId, int ingredientId)
		{
			return AppDelegate.RecipesDB.GetIngredient(recipeId, ingredientId);
		}
		public void SaveIngredient(int recipeID, string ingredientTitle)
		{
			var newIngredient = new Ingredient();
			newIngredient.RecipeId = recipeID;
			newIngredient.IngredientTitle = ingredientTitle;
			AppDelegate.RecipesDB.SaveIngredient(newIngredient);
		}
		public void SaveIngredentsList(int recipeID, IList<string> addedIngredentsList)
		{
			foreach (string ingredient in addedIngredentsList)
				SaveIngredient(recipeID, ingredient);	
		}
	}
}
