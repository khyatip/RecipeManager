// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RecipeManager
{
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        UIKit.UIButton AddRecipeButton { get; set; }


        [Outlet]
        UIKit.UITableView RecipeTableView { get; set; }


        [Action ("AddRecipeButtonSelected:")]
        partial void AddRecipeButtonSelected (Foundation.NSObject sender);

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