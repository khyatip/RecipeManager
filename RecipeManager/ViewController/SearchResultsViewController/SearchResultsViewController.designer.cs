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
	[Register ("SearchResultsViewController")]
	partial class SearchResultsViewController
	{
		[Outlet]
		UIKit.UIButton CalorieCountFilterButton { get; set; }

		[Outlet]
		UIKit.UIButton CookTimeFilterButton { get; set; }

		[Outlet]
		UIKit.UIButton RecipeTitleFilterButton { get; set; }

		[Outlet]
		UIKit.UITableView SearchResultsTableView { get; set; }

		[Action ("CalorieCountFilterButtonSelected:")]
		partial void CalorieCountFilterButtonSelected (Foundation.NSObject sender);

		[Action ("CookTimeFilterButtonSelected:")]
		partial void CookTimeFilterButtonSelected (Foundation.NSObject sender);

		[Action ("RecipeTitleFilterButtonSelected:")]
		partial void RecipeTitleFilterButtonSelected (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (RecipeTitleFilterButton != null) {
				RecipeTitleFilterButton.Dispose ();
				RecipeTitleFilterButton = null;
			}

			if (CalorieCountFilterButton != null) {
				CalorieCountFilterButton.Dispose ();
				CalorieCountFilterButton = null;
			}

			if (CookTimeFilterButton != null) {
				CookTimeFilterButton.Dispose ();
				CookTimeFilterButton = null;
			}

			if (SearchResultsTableView != null) {
				SearchResultsTableView.Dispose ();
				SearchResultsTableView = null;
			}
		}
	}
}
