using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventKit;
using Foundation;
using UIKit;

namespace RecipeManager
{
	public partial class CalorieTrackerVC : UIViewController
	{
		RecipesViewModel recipeVM;
		NSDateFormatter dateFormat;
		int CalorieLimit;
		public CalorieTrackerVC(RecipesViewModel recipeVM) : base("CalorieTrackerVC", null)
		{
			this.recipeVM = recipeVM;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "MMM d yyyy"; 
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		partial void TrackButtonSelected(Foundation.NSObject sender)
		{
			if (!string.IsNullOrEmpty(CalorieGoalField.Text))
				CalorieLimit = Convert.ToInt32(CalorieGoalField.Text);
			GetEventsViaQuery();
		}
		protected void GetEventsViaQuery()
		{
			var startDate = (NSDate)DateTime.Now.AddDays(-7);
			var endDate = (NSDate)DateTime.Today.AddDays(1);
			NSPredicate query = App.Current.EventStore.PredicateForEvents(startDate, endDate, null);

			EKCalendarItem[] events = App.Current.EventStore.EventsMatching(query);

			IEnumerable<EKCalendarItem> eventsList = events;
			foreach (EKCalendarItem item in eventsList)
				Console.WriteLine("CalendarItem: " + item.Title);

			UpdateEventsTableView(eventsList);
		}

		public void UpdateEventsTableView(IEnumerable<EKCalendarItem> eventsTableItems)
		{
			CalorieTrackerTableView.Source = new CalorieTrackerTableViewSource(GetDatesWithRecipeEvents(eventsTableItems), eventsTableItems, recipeVM.GetRecipesTableItems(), CalorieLimit);
			CalorieTrackerTableView.ReloadData();
		}
		public IEnumerable<NSDate> GetDatesWithRecipeEvents(IEnumerable<EKCalendarItem> eventsList)
		{
			IList<NSDate> datesList = new List<NSDate>();
			string dateWithoutTime;
			foreach (EKCalendarItem item in eventsList)
			{
				dateWithoutTime = dateFormat.ToString(item.CreationDate);
				if (datesList.Contains(dateFormat.Parse(dateWithoutTime)) == false)
					datesList.Add(dateFormat.Parse(dateWithoutTime));
			}
			IEnumerable<NSDate> dates = datesList;

			return datesList;
		}
	}
}