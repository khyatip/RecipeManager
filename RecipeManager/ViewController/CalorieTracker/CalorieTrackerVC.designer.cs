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
	[Register ("CalorieTrackerVC")]
	partial class CalorieTrackerVC
	{
		[Outlet]
		UIKit.UITextField CalorieGoalField { get; set; }

		[Outlet]
		UIKit.UITableView CalorieTrackerTableView { get; set; }

		[Outlet]
		UIKit.UILabel DailyCalorieGoalLabel { get; set; }

		[Action ("TrackButtonSelected:")]
		partial void TrackButtonSelected (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (DailyCalorieGoalLabel != null) {
				DailyCalorieGoalLabel.Dispose ();
				DailyCalorieGoalLabel = null;
			}

			if (CalorieGoalField != null) {
				CalorieGoalField.Dispose ();
				CalorieGoalField = null;
			}

			if (CalorieTrackerTableView != null) {
				CalorieTrackerTableView.Dispose ();
				CalorieTrackerTableView = null;
			}
		}
	}
}
