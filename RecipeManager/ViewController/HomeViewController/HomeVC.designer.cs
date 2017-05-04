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
	[Register ("HomeVC")]
	partial class HomeVC
	{
		[Outlet]
		UIKit.UIButton AddRecipeButton { get; set; }

		[Outlet]
		UIKit.UIButton AddToScheduleButton { get; set; }

		[Outlet]
		UIKit.UIButton CalorieCountFilterButton { get; set; }

		[Outlet]
		UIKit.UIButton CookTimeFilterButton { get; set; }

		[Outlet]
		UIKit.UITableView RecipeTableView { get; set; }

		[Outlet]
		UIKit.UIButton RecipeTitleFilterButton { get; set; }

		[Outlet]
		UIKit.UISearchBar SearchBar { get; set; }

		[Outlet]
		UIKit.UISearchBar SearchTextField { get; set; }

		[Outlet]
		UIKit.UIButton ShoppingListButton { get; set; }

		[Action ("AddRecipeButtonSelected:")]
		partial void AddRecipeButtonSelected (Foundation.NSObject sender);

		[Action ("AddToScheduleButtonSelected:")]
		partial void AddToScheduleButtonSelected (Foundation.NSObject sender);

		[Action ("CalorieCountFilterButtonSelected:")]
		partial void CalorieCountFilterButtonSelected (Foundation.NSObject sender);

		[Action ("CalorieTrackerButtonSelected:")]
		partial void CalorieTrackerButtonSelected (Foundation.NSObject sender);

		[Action ("CookTimeFilterButtonSelected:")]
		partial void CookTimeFilterButtonSelected (Foundation.NSObject sender);

		[Action ("RecipeTitleFilterButtonSelected:")]
		partial void RecipeTitleFilterButtonSelected (Foundation.NSObject sender);

		[Action ("ShoppingListButtonSelected:")]
		partial void ShoppingListButtonSelected (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AddRecipeButton != null) {
				AddRecipeButton.Dispose ();
				AddRecipeButton = null;
			}

			if (AddToScheduleButton != null) {
				AddToScheduleButton.Dispose ();
				AddToScheduleButton = null;
			}

			if (CalorieCountFilterButton != null) {
				CalorieCountFilterButton.Dispose ();
				CalorieCountFilterButton = null;
			}

			if (CookTimeFilterButton != null) {
				CookTimeFilterButton.Dispose ();
				CookTimeFilterButton = null;
			}

			if (RecipeTableView != null) {
				RecipeTableView.Dispose ();
				RecipeTableView = null;
			}

			if (RecipeTitleFilterButton != null) {
				RecipeTitleFilterButton.Dispose ();
				RecipeTitleFilterButton = null;
			}

			if (SearchBar != null) {
				SearchBar.Dispose ();
				SearchBar = null;
			}

			if (SearchTextField != null) {
				SearchTextField.Dispose ();
				SearchTextField = null;
			}

			if (ShoppingListButton != null) {
				ShoppingListButton.Dispose ();
				ShoppingListButton = null;
			}
		}
	}
}
