
using System;
using NUnit.Framework;
using RecipeManager;

namespace RecipeManagerUnitTests
{
	[TestFixture]
	public class RecipeTest
	{
		[Test]
		public void Pass()
		{
			Assert.True(true);
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
		[Test]
		public void CreateRecipe()
		{
			Recipe recipe = new Recipe { RecipeTitle = "New Recipe", CalorieCount = 100, CookTimeInMinutes = 10};
			Assert.IsTrue(recipe.RecipeTitle == "New Recipe","Recipe title not set");
		}
		public void HomeViewControllerTest()
		{

		}
	}
}
