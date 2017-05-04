﻿
using System;
using System.Collections.Generic;
using NUnit.Framework;
using RecipeManager;
using UIKit;

namespace RecipeManagerUnitTests
{
	[TestFixture]
	public class RecipeTest
	{
		HomeVC testVC;
		public static RecipesDatabase RecipesTestDB;
		IEnumerable<Recipe> recipeTableItems;

		[SetUp]
		public void SetUpViewController()
		{
			//UIStoryboard storyBoard = UIStoryboard.FromName("Main", null);
			//testVC = storyBoard.InstantiateViewController("HomeViewController") as HomeViewController;
			RecipesTestDB = new RecipesDatabase(RecipesDatabase.DatabaseFilePath);
			recipeTableItems = RecipesTestDB.GetRecipesList();
			var recipeListModel = new RecipeListViewModel(recipeTableItems);
			var homeVC = new HomeVC(RecipesTestDB.GetRecipesList(), recipeListModel);
		}
		[Test]
		public void CreateRecipe()
		{
			Recipe recipe = new Recipe { RecipeTitle = "New Recipe", CalorieCount = 100, CookTimeInMinutes = 10};
			Assert.IsTrue(recipe.RecipeTitle == "New Recipe","Recipe title not set");
		}
		[Test]
		public void NoRecipeTableItemTest()
		{
			//Assert.IsTrue(testVC.r)

		}
	}
}
