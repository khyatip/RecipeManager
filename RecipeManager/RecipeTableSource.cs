using System;
using System.Collections.Generic;
using UIKit;

namespace RecipeManager
{
	public class RecipeTableSource : UITableViewSource
	{
		protected List<string> recipeTableItems;
		protected string cellIdentifier = "TableCell";

		public RecipeTableSource(List<string> recipeTableItems)
		{
			this.recipeTableItems = recipeTableItems;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;//base.NumberOfSections(tableView);
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return recipeTableItems.Count;
		}

		//public void AddRecipeToTable(UITableView tableView,string recipeTitle)
		//{
		//	UITableViewCell newCell;
		//	newCell.TextLabel.Text = recipeTitle;
		//	tableView.InsertRows(Foundation.NSIndexPath atIndexPaths, UITableViewRowAnimation withoutRowAnimation
		//}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			string item = recipeTableItems[indexPath.Row];

			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier); }

			cell.TextLabel.Text = item;

			return cell;
		}
	}
}
