using System;

using UIKit;

namespace RecipeManager
{
	public partial class RecipeDetailsViewController : UIViewController
	{
		Recipe currentRecipe;
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
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			if (currentRecipe.RecipeTitle != null && currentRecipe.CalorieCount != 0 && currentRecipe.CookTime != 0.0)
			{
				RecipeTitleField.Text = currentRecipe.RecipeTitle;
				CalorieCountField.Text = Convert.ToString(currentRecipe.CalorieCount);
				CookTimeField.Text = Convert.ToString(currentRecipe.CookTime);
			}
		}

		partial void AddIngredientButtonSelected(Foundation.NSObject sender)
		{
			//currentRecipe.ingredients.Add(IngredientField.Text)
		}

		partial void RecipeSaveButtonSelected(Foundation.NSObject sender)
		{
			// TODO: Error Handling 
			currentRecipe.RecipeTitle = RecipeTitleField.Text;
			currentRecipe.CalorieCount = Convert.ToInt32(CalorieCountField.Text);
			currentRecipe.CookTime = Convert.ToDouble(CookTimeField.Text);

			Delegate.SaveRecipe(currentRecipe);
			this.DismissViewController(true,null);
		}
	}
}

