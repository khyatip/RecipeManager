// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RecipeManager
{
	[Register ("RecipeDetailsViewController")]
	partial class RecipeDetailsViewController
	{
		[Outlet]
		UIKit.UIButton AddIngredientButton { get; set; }

		[Outlet]
		UIKit.UIButton AddRecipeStepButton { get; set; }

		[Outlet]
		UIKit.UITextField CalorieCountField { get; set; }

		[Outlet]
		UIKit.UITextField CookTimeField { get; set; }

		[Outlet]
		UIKit.UITextField IngredientField { get; set; }

		[Outlet]
		UIKit.UITableView IngredientsTableView { get; set; }

		[Outlet]
		UIKit.UIButton RecipeSaveButton { get; set; }

		[Outlet]
		UIKit.UITextField RecipeStepField { get; set; }

		[Outlet]
		UIKit.UITableView RecipeStepsTableView { get; set; }

		[Outlet]
		UIKit.UITextField RecipeTitleField { get; set; }

		[Action ("AddIngredientButtonSelected:")]
		partial void AddIngredientButtonSelected (Foundation.NSObject sender);

		[Action ("AddRecipeStepButtonSelected:")]
		partial void AddRecipeStepButtonSelected (Foundation.NSObject sender);

		[Action ("AddStepButtonSelected:")]
		partial void AddStepButtonSelected (Foundation.NSObject sender);

		[Action ("RecipeDoneButton:")]
		partial void RecipeDoneButton (Foundation.NSObject sender);

		[Action ("RecipeSaveButtonSelected:")]
		partial void RecipeSaveButtonSelected (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (RecipeTitleField != null) {
				RecipeTitleField.Dispose ();
				RecipeTitleField = null;
			}

			if (CalorieCountField != null) {
				CalorieCountField.Dispose ();
				CalorieCountField = null;
			}

			if (CookTimeField != null) {
				CookTimeField.Dispose ();
				CookTimeField = null;
			}

			if (IngredientField != null) {
				IngredientField.Dispose ();
				IngredientField = null;
			}

			if (AddIngredientButton != null) {
				AddIngredientButton.Dispose ();
				AddIngredientButton = null;
			}

			if (IngredientsTableView != null) {
				IngredientsTableView.Dispose ();
				IngredientsTableView = null;
			}

			if (RecipeStepField != null) {
				RecipeStepField.Dispose ();
				RecipeStepField = null;
			}

			if (AddRecipeStepButton != null) {
				AddRecipeStepButton.Dispose ();
				AddRecipeStepButton = null;
			}

			if (RecipeStepsTableView != null) {
				RecipeStepsTableView.Dispose ();
				RecipeStepsTableView = null;
			}

			if (RecipeSaveButton != null) {
				RecipeSaveButton.Dispose ();
				RecipeSaveButton = null;
			}
		}
	}
}
