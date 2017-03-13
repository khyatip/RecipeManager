using System;
using System.Collections.Generic;

namespace RecipeManager
{
	public class Recipe
	{
		public int Id { get; set; }
		public string RecipeTitle { get; set; }
		public int CalorieCount { get; set; }
		public int CookTimeInMinutes { get; set; }
		public List<Ingredient> ingredients;
		public List<Step> recipeSteps;

		public Recipe()
		{
			Id = 0;
			RecipeTitle = "";
			CalorieCount = 0;
			CookTimeInMinutes = 0;
			ingredients = new List<Ingredient>();
			recipeSteps = new List<Step>();
		}

		public Recipe(int ID,string recipeTitle, int calorieCount, int cookTime, List<Ingredient> ingred, List<Step> steps)
		{
			Id = ID;
			RecipeTitle = recipeTitle;
			CalorieCount = calorieCount;
			CookTimeInMinutes = cookTime;
			ingredients = ingred;
			recipeSteps = steps;
		}
			
		public override string ToString()
		{
			return string.Format("[Recipe: Id={0}, RecipeTitle={1}, CalorieCount={2}, CookTime={3}]", Id, RecipeTitle, CalorieCount, CookTimeInMinutes);
		}
	}
}
