using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace RecipeManager
{
	public class IngredientsTableViewSource : UITableViewSource
	{		
		IList<Ingredient> ingredientTableItems;
		protected string cellIdentifier = "IngredientCell";

		public IngredientsTableViewSource(IEnumerable<Ingredient> ingredientItems)
		{
			ingredientTableItems = ingredientItems.ToList();
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return ingredientTableItems.Count;
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
