using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace RecipeManager
{
	public class RecipeTableViewSource : UITableViewSource
	{
		IList<Recipe> recipeTableItems;
		protected string cellIdentifier = "RecipeCell";

		public RecipeTableViewSource(IEnumerable<Recipe> recipeItems)
		{
			recipeTableItems = recipeItems.ToList();
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

		public Recipe GetItem(int id)
		{
			return recipeTableItems[id];
		}

		/// <summary>
		/// Called by the table view to determine whether or not the row is editable
		/// </summary>
		public override bool CanEditRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return true;
		}

		/// <summary>
		/// Called by the table view to determine whether or not the row is moveable
		/// </summary>
		public override bool CanMoveRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return true;
		}

		/// <summary>
		/// Called by the table view to determine whether the editing control should be an insert
		/// or a delete.
		/// </summary>
		public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
				return UITableViewCellEditingStyle.Delete;
		}

		/// <summary>
		/// Custom text for delete button
		/// </summary>
		public override string TitleForDeleteConfirmation(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return "Delete";
		}

		/// <summary>
		/// Should be called CommitEditingAction or something, is called when a user initiates a specific editing event
		/// </summary>
		/// 
		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
		{
			switch (editingStyle)
			{
				case UITableViewCellEditingStyle.Delete:
					//---- remove recipe from database
					AppDelegate.RecipesDB.DeleteRecipe(recipeTableItems[indexPath.Row]);
					//---- remove recipe from the underlying data source
					recipeTableItems.RemoveAt(indexPath.Row);
					//---- delete the row from the table
					tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
					break;

				case UITableViewCellEditingStyle.None:
					Console.WriteLine("CommitEditingStyle:None called");
					break;
			}
		}
	
	}
}
