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
	[Register ("WeeklyShoppingListViewController")]
	partial class WeeklyShoppingListViewController
	{
		[Outlet]
		UIKit.UITableView ShoppingListTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ShoppingListTableView != null) {
				ShoppingListTableView.Dispose ();
				ShoppingListTableView = null;
			}
		}
	}
}
