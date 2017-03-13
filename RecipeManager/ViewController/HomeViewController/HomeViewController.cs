using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CoreGraphics;
using SQLite;
using UIKit;

namespace RecipeManager
{
	public partial class HomeViewController : UIViewController
	{
		private string _pathToDatabase;
		List<Recipe> recipeTableItems = new List<Recipe>();

		protected HomeViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			RecipeTableView.ContentInset = new UIEdgeInsets(-40, 0, 0, 0);
			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems.ToArray());

			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			_pathToDatabase = Path.Combine(documents, "Recipes.db");
			Console.WriteLine(_pathToDatabase);
			using (var conn = new SQLite.SQLiteConnection(_pathToDatabase))
			{
				conn.CreateTable<Recipe>();
			}
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationController.NavigationBarHidden = true;
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			NavigationController.NavigationBarHidden = false;
		}
		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			var destinationController = segue.DestinationViewController as RecipeDetailsViewController;
			if (segue.Identifier == "RecipeDetailsSegue")
			{				
				if (destinationController != null)
					destinationController.SetRecipe(this, CreateNewRecipe());
			}
			else if (segue.Identifier == "RecipeCellSelected")
			{
				if (destinationController != null)
				{
					Console.WriteLine(recipeTableItems[RecipeTableView.IndexPathForSelectedRow.Row].ToString());
					destinationController.SetRecipe(this, recipeTableItems[RecipeTableView.IndexPathForSelectedRow.Row]);
				}
			}
		}
		public Recipe CreateNewRecipe()
		{
			int newId;

			if (recipeTableItems.Count == 0)
				newId = 0;
			else 
				newId = recipeTableItems[recipeTableItems.Count - 1].Id + 1;

			return new Recipe { Id = newId};
		}
		public int SaveRecipe(Recipe recipe)
		{
			int saveType = 0;
			if (recipeTableItems.Exists(x => x.Id == recipe.Id))
			{
				recipeTableItems[recipe.Id] = recipe;
			}
			else
			{
				recipeTableItems.Add(recipe);
				saveType = 1;
				using (var db = new SQLite.SQLiteConnection(_pathToDatabase))
				{
					db.Insert(recipe);
				}
			}
			RecipeTableView.Source = new RecipeTableViewSource(recipeTableItems.ToArray());
			return saveType;
		}

	}
}
