using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace RecipeManager
{
	public class StepsTableViewSource: UITableViewSource
	{		
		IList<Step> stepsTableItems;
		protected string cellIdentifier = "StepsCell";

		public StepsTableViewSource(IEnumerable<Step> recipeSteps)
		{
			stepsTableItems = recipeSteps.ToList();
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return stepsTableItems.Count;
		}
		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

			cell.TextLabel.Text = stepsTableItems[indexPath.Row].StepDetail;

			return cell;
		}
	}
}
