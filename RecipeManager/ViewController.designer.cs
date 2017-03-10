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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton AddRecipeButton { get; set; }

		[Outlet]
		UIKit.UITableView RecipeTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddRecipeButton != null) {
				AddRecipeButton.Dispose ();
				AddRecipeButton = null;
			}

			if (RecipeTableView != null) {
				RecipeTableView.Dispose ();
				RecipeTableView = null;
			}
		}
	}
}
