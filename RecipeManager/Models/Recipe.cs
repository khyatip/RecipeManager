using System;
using System.Collections.Generic;

namespace RecipeManager
{
	public class Recipe
	{
		public int Id { get; set; }
		public string RecipeTitle { get; set; }
		public int CalorieCount { get; set; }
		public double CookTime { get; set; }
		public List<string> ingredients;
		public List<string> recipeSteps;

		public Recipe()
		{
			Id = 0;
			RecipeTitle = "";
			CalorieCount = 0;
			CookTime = 0.0;
			ingredients = new List<string>();
			recipeSteps = new List<string>();
		}

		public Recipe(int ID,string recipeTitle, int calorieCount, double cookTime, List<string> ingred, List<string> steps)
		{
			Id = ID;
			RecipeTitle = recipeTitle;
			CalorieCount = calorieCount;
			CookTime = cookTime;
			ingredients = ingred;
			recipeSteps = steps;
		}
			

		public override string ToString()
		{
			return string.Format("[Recipe: Id={0}, RecipeTitle={1}, CalorieCount={2}, CookTime={3}]", Id, RecipeTitle, CalorieCount, CookTime);
		}
	}
}
