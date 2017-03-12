using System;
using UIKit;

namespace RecipeManager
{
	public class IngredientsTableViewSource : UITableViewSource
	{
		protected string cellIdentifier = "IngredientCell";
		Ingredient[] ingredientTableItems;

		public IngredientsTableViewSource(Ingredient[] ingredientItems)
		{
			ingredientTableItems = ingredientItems;
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return ingredientTableItems.Length;
		}
		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if(cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

			cell.TextLabel.Text = ingredientTableItems[indexPath.Row].IngredientTitle;

			return cell;
		}
	}
}
