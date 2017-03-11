using System;
using System.Collections.Generic;
using UIKit;

namespace RecipeManager
{
	public class RecipeTableViewSource : UITableViewSource
	{
		protected string cellIdentifier = "RecipeCell";

		Recipe[] recipeTableItems;

		public RecipeTableViewSource(Recipe[] recipeTableItems)
		{
			this.recipeTableItems = recipeTableItems;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return recipeTableItems.Length;
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
			if (cell == null)
			{ 
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier); 
			}

			cell.TextLabel.Text = recipeTableItems[indexPath.Row].RecipeTitle;

			return cell;
		}

		public Recipe GetItem(int id)
		{
			return recipeTableItems[id];
		}
	}
}
