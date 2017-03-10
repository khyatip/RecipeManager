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
		UIKit.UITableView RecipeDetailsTableView { get; set; }

		[Action ("RecipeDoneButton:")]
		partial void RecipeDoneButton (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (RecipeDetailsTableView != null) {
				RecipeDetailsTableView.Dispose ();
				RecipeDetailsTableView = null;
			}
		}
	}
}
