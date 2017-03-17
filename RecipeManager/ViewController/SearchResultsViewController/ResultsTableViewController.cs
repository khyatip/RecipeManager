using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace RecipeManager
{
	public class ResultsTableViewController : UITableViewController
	{
		IList<Recipe> recipeTableItems;
		protected string cellIdentifier = "SearchResultCell";

		public ResultsTableViewController(IEnumerable<Recipe> recipeItems)
		{
			recipeTableItems = recipeItems.ToList();
		}
		public override nint RowsInSection(UITableView tableView, nint section)
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
	}
}
