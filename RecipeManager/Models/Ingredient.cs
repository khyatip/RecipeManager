using System;
using SQLite;

namespace RecipeManager
{
	public class Ingredient
	{
		[PrimaryKey, AutoIncrement]
		public int RecipeId { get; set; }
		public int Id { get; set; }
		public string IngredientTitle { get; set; }

		public Ingredient()
		{
			RecipeId = 0;
			Id = 0;
			IngredientTitle = "";
		}
		public Ingredient(int recipeId, int id, string ingredient)
		{
			RecipeId = recipeId;
			Id = id;
			IngredientTitle = ingredient;
		}
		public override string ToString()
		{
			return string.Format("[Ingredient: RecipeId={0}, Id={1}, IngredientTitle={2}]", RecipeId, Id, IngredientTitle);
		}
	}
}
