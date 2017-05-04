using System;
using System.Collections.Generic;
using System.Linq;
using EventKit;
using Foundation;
using UIKit;

namespace RecipeManager
{
	public class RecipeTableViewSource : UITableViewSource
	{
		IList<Recipe> recipeTableItems;
		string cellIdentifier = "RecipeCell";
		HomeVC owner;

		public RecipeTableViewSource(IEnumerable<Recipe> recipeItems, HomeVC HomeVC)
		{
			recipeTableItems = recipeItems.ToList();
			this.owner = HomeVC;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return recipeTableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

			cell.TextLabel.Text = recipeTableItems[indexPath.Row].RecipeTitle;

			return cell;
		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			owner.ViewRecipe(recipeTableItems[indexPath.Row]);
		}
		public Recipe GetItem(int id)
		{
			return recipeTableItems[id];
		}
		public override bool CanEditRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return true;
		}
		public override bool CanMoveRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return true;
		}

		public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewRowAction DeleteRecipeOption = UITableViewRowAction.Create(
				UITableViewRowActionStyle.Destructive,
				"Delete",
				delegate
				{
					DeleteRecipe(tableView, indexPath);
				});
			UITableViewRowAction ScheduleRecipeButton = UITableViewRowAction.Create(
				UITableViewRowActionStyle.Normal,
				"Schedule",
				delegate
				{
					RequestAccess(EKEntityType.Event, () => { owner.LaunchCreateNewEvent(indexPath); });
				});

			return new UITableViewRowAction[] { DeleteRecipeOption, ScheduleRecipeButton };

		}

		public void DeleteRecipe(UITableView tableView, /*UITableViewRowAction rowAction,*/ Foundation.NSIndexPath indexPath)
		{
			AppDelegate.RecipesDB.DeleteRecipe(recipeTableItems[indexPath.Row]);
			recipeTableItems.RemoveAt(indexPath.Row);
			tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
		}

		protected void RequestAccess(EKEntityType type, Action completion)
		{
			App.Current.EventStore.RequestAccess(type,
				(bool granted, NSError e) =>
				{
					InvokeOnMainThread(() =>
					{
						if (granted)
							completion.Invoke();
						else
							PresentError();
					});
				});
		}
		public void PresentError()
		{
			var okAlertController = UIAlertController.Create("Access Denied", "User denied access to Calenders", UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
			owner.PresentViewController(okAlertController, true, null);
		}
	}
}
