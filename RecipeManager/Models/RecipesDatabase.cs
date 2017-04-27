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
			CreateTable<Ingredient>();
			CreateTable<Step>();
		}
		public static string DatabaseFilePath
		{
			get
			{
				var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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
				//TODO: add cleanup for corresponding ingredients and steps
			}
		}
		public IEnumerable<Recipe> SearchByRecipeTitle(string searchString)
		{
			lock (lockObject)
			{
				return (from i in Table<Recipe>() where i.RecipeTitle == searchString select i).ToList();
			}
		}
		public IEnumerable<Recipe> SearchByCalories(int searchCalories)
		{
			lock (lockObject)
			{
				return (from i in Table<Recipe>() where i.CalorieCount == searchCalories select i).ToList();
			}
		}
		public IEnumerable<Recipe> SearchByCookTime(int searchCookTime)
		{
			lock (lockObject)
			{
				return (from i in Table<Recipe>() where i.CookTimeInMinutes == searchCookTime select i).ToList();
			}
		}
		public IEnumerable<Ingredient> GetIngredientsList(int recipeItemID)
		{
			lock (lockObject)
			{
				return (from i in Table<Ingredient>() where i.RecipeId == recipeItemID select i).ToList();
			}
		}
		public Ingredient GetIngredient(int id)
		{
			lock (lockObject)
			{
				return Table<Ingredient>().FirstOrDefault(x => x.Id == id);
			}
		}
		public IEnumerable<Ingredient> GetWeeklyShoppingList()
		{
			lock (lockObject)
			{
				//return from i in Table<Recipe>() where i.CalorieCount == searchCalories select i).ToList()

				return (from i in Table<Ingredient>() where i.RecipeId == 1 select i).ToList();
			}
		}
		public int SaveIngredient(Ingredient ingredientItem)
		{
			lock (lockObject)
			{
				if (ingredientItem.Id != 0)
				{
					Update(ingredientItem);
					return ingredientItem.Id;
				}
				else
					return Insert(ingredientItem);
			}
		}
		public int DeleteIngredient(Ingredient ingredientItem)
		{
			lock (lockObject)
			{
				return Delete(ingredientItem.Id);
			}
		}
		public IEnumerable<Step> GetStepsList(int recipeItemID)
		{
			lock (lockObject)
			{
				return (from i in Table<Step>() where i.RecipeId == recipeItemID select i).ToList();
			}
		}
		public Step GetStep(int id)
		{
			lock (lockObject)
			{
				return Table<Step>().FirstOrDefault(x => x.Id == id);
			}
		}
		public int SaveStep(Step stepItem)
		{
			lock (lockObject)
			{
				if (stepItem.Id != 0)
				{
					Update(stepItem);
					return stepItem.Id;
				}
				else
					return Insert(stepItem);
			}
		}
		public int DeleteStep(Step stepItem)
		{
			lock (lockObject)
			{
				return Delete(stepItem.Id);
			}
		}
	}
}
