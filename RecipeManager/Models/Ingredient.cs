using System;
namespace RecipeManager
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string IngredientTitle { get; set; }

		public Ingredient()
		{
			Id = 0;
			IngredientTitle = "";
		}
		public Ingredient(int id, string ingredient)
		{
			Id = id;
			IngredientTitle = ingredient;
		}
		public override string ToString()
		{
			return string.Format("[Ingredient: Id={0}, IngredientTitle={1}]", Id, IngredientTitle);
		}
	}
}
