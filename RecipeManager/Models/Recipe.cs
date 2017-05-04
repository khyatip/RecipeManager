using SQLite;

namespace RecipeManager
{
	public class Recipe
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string RecipeTitle { get; set; }
		public int CalorieCount { get; set; }
		public int CookTimeInMinutes { get; set; }

		public Recipe()
		{
			this.Id = 0;
			this.RecipeTitle = null;
			this.CalorieCount = 0;
			this.CookTimeInMinutes = 0;
		}
		public Recipe(int recipeID)
		{
			this.Id = recipeID;
			this.RecipeTitle = null;
			this.CalorieCount = 0;
			this.CookTimeInMinutes = 0;
		}
		public Recipe(string recipeTitle, int calorieCount, int cookTimeInMinutes)
		{
			this.RecipeTitle = recipeTitle;
			this.CalorieCount = calorieCount;
			this.CookTimeInMinutes = cookTimeInMinutes;
		}
		public override string ToString()
		{
			return ("Recipe ID: " + this.Id + " | Recipe Title: " + this.RecipeTitle + " | Calorie Count: " + this.CalorieCount + " | Cook Time: " + this.CookTimeInMinutes);
		}


	}
}
