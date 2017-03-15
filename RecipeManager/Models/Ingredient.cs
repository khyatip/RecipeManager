using System;
using SQLite;

namespace RecipeManager
{
	public class Ingredient
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public int RecipeId { get; set; }
		public string IngredientTitle { get; set; }

	}
}
