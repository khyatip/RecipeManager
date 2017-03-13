using System;
using UIKit;

namespace RecipeManager
{
	public class StepsTableViewSource: UITableViewSource
	{
		protected string cellIdentifier = "IngredientCell";
		Step[] stepsTableItems;

		public StepsTableViewSource(Step[] recipeSteps)
		{
			stepsTableItems = recipeSteps;
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return stepsTableItems.Length;
		}
		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

			cell.TextLabel.Text = stepsTableItems[indexPath.Row].StepDetial;

			return cell;
		}
	}
}
