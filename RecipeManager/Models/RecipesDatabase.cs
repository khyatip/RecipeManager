using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;

namespace RecipeManager
{
	public class RecipesDatabase : SQLiteConnection
	{
		static object lockObject = new object();
		public RecipesDatabase (string path) : base(path)
		{
			CreateTable<Recipe>();
		}
		public static string DatabaseFilePath
		{
			get
			{
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				var path = Path.Combine(documentsPath, "Recipes.db");

				return path;
			}
		}

		public IEnumerable<Recipe> GetRecipesList()
		{
			lock(lockObject)
			{
				return (from i in Table<Recipe>() select i).ToList();
			}
		}
		public Recipe GetRecipe(int id)
		{
			lock(lockObject)
			{
				return Table<Recipe>().FirstOrDefault(x => x.Id == id);
			}
		}
		public int SaveRecipe(Recipe recipeItem)
		{
			lock(lockObject)
			{
				if (recipeItem.Id != 0)
				{
					Update(recipeItem);
					return recipeItem.Id;
				}
				else
					return Insert(recipeItem);
			}
		}
		public int DeleteRecipe(Recipe recipeItem)
		{
			lock(lockObject)
			{
				return Delete<Recipe>(recipeItem.Id);
			}
		}
	}
}
