
using System;
using NUnit.Framework;
using RecipeManager;

namespace RecipeManagerUnitTests
{
	[TestFixture]
	public class MyTest
	{
		public static RecipesDatabase RecipesTestDB;

		[SetUp]
		public void SetUpViewController()
		{
			//UIStoryboard storyBoard = UIStoryboard.FromName("Main", null);
			//testVC = storyBoard.InstantiateViewController("HomeViewController") as HomeViewController;
			RecipesTestDB = new RecipesDatabase(RecipesDatabase.DatabaseFilePath);
		}

		[Test]
		public void SaveRecipeTest()
		{
			Recipe recipe = new Recipe { RecipeTitle = "New Recipe", CalorieCount = 100, CookTimeInMinutes = 10};
			RecipesTestDB.SaveRecipe(recipe);
			Assert.AreEqual(recipe.RecipeTitle, "New Recipe");
		}

		[Test]
		public void Fail()
		{
			Assert.False(true);
		}

		[Test]
		[Ignore("another time")]
		public void Ignore()
		{
			Assert.True(false);
		}
	}
}
