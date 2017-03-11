using System;

using UIKit;

namespace RecipeManager
{
	public partial class RecipeDetailsViewController : UIViewController
	{
		Recipe currentRecipe = new Recipe();
		public ViewController Delegate { get; set;}

		protected RecipeDetailsViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

		}

		public void SetRecipe(ViewController mainViewController, Recipe recipe)
		{
			Delegate = mainViewController;
			currentRecipe = recipe;
		}

		partial void RecipeSaveButtonSelected(Foundation.NSObject sender)
		{
			//int highestRecipeId = 
			currentRecipe.RecipeTitle = RecipeTitleField.Text;
			currentRecipe.CalorieCount = Convert.ToInt32(CalorieCountField.Text);
			currentRecipe.CookTime = Convert.ToDouble(CookTimeField.Text);
			//Console.WriteLine(currentRecipe.ToString());
			//var recipeTitle = RecipeTitleField.Text;
			//var calorieCount = Convert.ToInt32(CalorieCountField.Text);
			//var cookTime = Convert.ToDouble(CookTimeField.Text);
			Delegate.SaveRecipe(currentRecipe);
			this.DismissViewController(true,null);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

