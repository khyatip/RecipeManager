using System;
using System.Collections.Generic;
using System.Linq;
using EventKit;
using Foundation;
using UIKit;

namespace RecipeManager
{
	public class CalorieTrackerTableViewSource : UITableViewSource
	{
		IList<EKCalendarItem> eventsTableItems;
		IEnumerable<Recipe> recipesList;
		string cellIdentifier = "EventCell";
		NSDateFormatter dateFormat;
		IList<NSDate> datesWithEvents;
		int CalorieLimit;

		public CalorieTrackerTableViewSource(IEnumerable<NSDate> datesWithEvents, IEnumerable<EKCalendarItem> eventsTableItems, IEnumerable <Recipe> recipesList, int CalorieLimit)
		{
			this.eventsTableItems = eventsTableItems.ToList();
			this.recipesList = recipesList;
			this.datesWithEvents = datesWithEvents.ToList();
			this.CalorieLimit = CalorieLimit;
			dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "MMM d yyyy"; 
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
						if (cell == null)
							cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

			if(indexPath.Row < datesWithEvents.Count())
				cell.TextLabel.Text = dateFormat.ToString(datesWithEvents[indexPath.Row]) + " | "
					+ CalorieSumOfRecipesPerDay(eventsTableItems, datesWithEvents[indexPath.Row]) + " | "
					+ CalorieLimitExceeded(CalorieSumOfRecipesPerDay(eventsTableItems, datesWithEvents[indexPath.Row]));

			return cell;
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return eventsTableItems.Count;
		}

		public string CalorieLimitExceeded(int calories)
		{
			if (calories > CalorieLimit)
				return "\U0000274E";
			else
				return "\U00002705";
					
		}
		public int CalorieSumOfRecipesPerDay(IList<EKCalendarItem> eventsList, NSDate date)
		{
			int sum = 0;
			foreach (EKCalendarItem item in eventsList)
				if (DoesRecipeExist(item.Title) && dateFormat.ToString(item.CreationDate) == dateFormat.ToString(date))
					sum = sum + GetCalories(item.Title);

			return sum;
		}

		public int GetCalories(string recipeTitle)
		{
			return recipesList.First(recipe => recipe.RecipeTitle == recipeTitle).CalorieCount;
		}
		public bool DoesRecipeExist(string eventTitle)
		{
			return recipesList.Any(recipe => recipe.RecipeTitle == eventTitle);
		}
	}
}
