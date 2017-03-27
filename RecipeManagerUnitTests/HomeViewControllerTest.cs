
using System;
using NUnit.Framework;
using RecipeManager;

namespace RecipeManagerUnitTests
{
	[TestFixture]
	public class HomeViewControllerTest
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
		public void TestHomeViewController()
		{
			var hvc = HomeViewController();
		}
	}
}
