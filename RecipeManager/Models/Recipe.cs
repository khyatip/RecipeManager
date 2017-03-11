using System;
namespace RecipeManager
{
	public class Recipe
	{
		public int Id { get; set; }
		public string RecipeTitle { get; set; }
		public int CalorieCount { get; set; }
		public double CookTime { get; set; }

		public Recipe()
		{
			Id = 0;
			RecipeTitle = "";
			CalorieCount = 0;
			CookTime = 0.0;
		}

		public Recipe(int ID,string recipeTitle, int calorieCount, double cookTime)
		{
			Id = ID;
			RecipeTitle = recipeTitle;
			CalorieCount = calorieCount;
			CookTime = cookTime;
		}
			

		public override string ToString()
		{
			return string.Format("[Recipe: Id={0}, RecipeTitle={1}, CalorieCount={2}, CookTime={3}]", Id, RecipeTitle, CalorieCount, CookTime);
		}
	}
}
