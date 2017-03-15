using System;
using System.Collections.Generic;
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
	}
}
