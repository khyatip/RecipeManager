// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RecipeManager
{
	[Register("RecipeDetailsVC")]
	partial class RecipeDetailsVC
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


		[Outlet]
		UIKit.UIView ViewContainingIngredients { get; set; }


		[Action("AddIngredientButtonSelected:")]
		partial void AddIngredientButtonSelected(Foundation.NSObject sender);


		[Action("AddRecipeStepButtonSelected:")]
		partial void AddRecipeStepButtonSelected(Foundation.NSObject sender);


		[Action("RecipeDoneButton:")]
		partial void RecipeDoneButton(Foundation.NSObject sender);


		[Action("RecipeSaveButtonSelected:")]
		partial void RecipeSaveButtonSelected(Foundation.NSObject sender);

		void ReleaseDesignerOutlets()
		{
			if (AddIngredientButton != null)
			{
				AddIngredientButton.Dispose();
				AddIngredientButton = null;
			}

			if (AddRecipeStepButton != null)
			{
				AddRecipeStepButton.Dispose();
				AddRecipeStepButton = null;
			}

			if (CalorieCountField != null)
			{
				CalorieCountField.Dispose();
				CalorieCountField = null;
			}

			if (CookTimeField != null)
			{
				CookTimeField.Dispose();
				CookTimeField = null;
			}

			if (IngredientField != null)
			{
				IngredientField.Dispose();
				IngredientField = null;
			}

			if (IngredientsTableView != null)
			{
				IngredientsTableView.Dispose();
				IngredientsTableView = null;
			}

			if (RecipeSaveButton != null)
			{
				RecipeSaveButton.Dispose();
				RecipeSaveButton = null;
			}

			if (RecipeStepField != null)
			{
				RecipeStepField.Dispose();
				RecipeStepField = null;
			}

			if (RecipeStepsTableView != null)
			{
				RecipeStepsTableView.Dispose();
				RecipeStepsTableView = null;
			}

			if (RecipeTitleField != null)
			{
				RecipeTitleField.Dispose();
				RecipeTitleField = null;
			}

			if (ViewContainingIngredients != null)
			{
				ViewContainingIngredients.Dispose();
				ViewContainingIngredients = null;
			}
		}
		//void ReleaseDesignerOutlets()
		//{	//}
	}

}
