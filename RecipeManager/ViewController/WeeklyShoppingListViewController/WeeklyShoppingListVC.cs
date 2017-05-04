using System;
using System.Collections.Generic;
using UIKit;

namespace RecipeManager
{
	public partial class WeeklyShoppingListVC : UIViewController
	{
		IEnumerable<Ingredient> shoppingListTableItems;
		public HomeVC Delegate { get; set; }

		public WeeklyShoppingListVC(IEnumerable<Ingredient> shoppingListTableItems) : base("WeeklyShoppingListVC", null)
		{
			this.shoppingListTableItems = shoppingListTableItems;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Weekly Shopping List";
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			ShoppingListTableView.Source = new IngredientsTableViewSource(shoppingListTableItems);
			ShoppingListTableView.ReloadData();
		}
	}
}

