using System;
using System.Collections.Generic;
using UIKit;

namespace RecipeManager
{
	public partial class RecipeDetailsViewController : UIViewController
	{
		Recipe currentRecipe;
		List<Ingredient> ingredientsTableView = new List<Ingredient>();
		public HomeViewController Delegate { get; set; }

		protected RecipeDetailsViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void SetRecipe(HomeViewController mainViewController, Recipe recipe)
		{
			Delegate = mainViewController;
			currentRecipe = recipe;    
			
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//IngredientsTableView.ContentInset = new UIEdgeInsets(-40, 0, 0, 0);
			//IngredientsTableView.Source = new RecipeTableViewSource(ingredientsTableView.ToArray());
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			if (currentRecipe.RecipeTitle != "" && currentRecipe.CalorieCount != 0 && currentRecipe.CookTimeInMinutes != 0)
			{
				RecipeTitleField.Text = currentRecipe.RecipeTitle;
				CalorieCountField.Text = Convert.ToString(currentRecipe.CalorieCount);
				CookTimeField.Text = Convert.ToString(currentRecipe.CookTimeInMinutes);
				if (currentRecipe.ingredients != null)
				{
					IngredientsTableView.Source = new IngredientsTableViewSource(currentRecipe.ingredients.ToArray());

					foreach (Ingredient i in currentRecipe.ingredients)
						Console.WriteLine(i.ToString());
				}
			}
		}

		partial void AddIngredientButtonSelected(Foundation.NSObject sender)
		{
			int newIngredientId;
			if (ingredientsTableView.Count == 0)
				newIngredientId = 0;
			else
				newIngredientId = ingredientsTableView[ingredientsTableView.Count - 1].Id + 1;

			if (IngredientField.Text != "")
			{
				ingredientsTableView.Add(new Ingredient(newIngredientId, IngredientField.Text));
				IngredientField.Text = "";
				IngredientsTableView.Source = new IngredientsTableViewSource(ingredientsTableView.ToArray());
				IngredientsTableView.ReloadData();
			}

			foreach (Ingredient i in ingredientsTableView)
				Console.WriteLine(i.ToString());			

		}

		partial void RecipeSaveButtonSelected(Foundation.NSObject sender)
		{
			// TODO: Error Handling 
			currentRecipe.RecipeTitle = RecipeTitleField.Text;
			currentRecipe.CalorieCount = Convert.ToInt32(CalorieCountField.Text);
			currentRecipe.CookTimeInMinutes = Convert.ToInt32(CookTimeField.Text);
			if (ingredientsTableView.Count != 0)
				currentRecipe.ingredients = ingredientsTableView;

			int saveType = Delegate.SaveRecipe(currentRecipe);
			if (saveType == 1)
				this.DismissViewController(true, null);
			else
				NavigationController.PopViewController(true);
		}
	}
}

