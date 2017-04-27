using System;
using System.Linq;
using System.Collections.Generic;
using EventKit;
using Foundation;
using MonoTouch.Dialog;
using UIKit;

namespace RecipeManager
{
	public class CalendarListViewController : DialogViewController
	{
		// our roote element for MonoTouch.Dialog
		protected RootElement calendarListRoot = new RootElement("Calendars");

		// list of calendars
		protected EKCalendar[] calendars;
		// the type of calendar: Event or Reminder
		protected EKEntityType entityType;
		Recipe currentRecipe { get; set; }


		public CalendarListViewController(EKEntityType storeType) : base (UITableViewStyle.Plain, null, true)
		{
			entityType = storeType;
			App.Current.EventStore.RequestAccess(entityType, (bool granted, NSError e) =>
			{
				PopulateCalendarList(granted, e);
			});
		}

		public void SetRecipe(Recipe recipe)
		{
			//Delegate = homeViewController;
			currentRecipe = recipe;
		}

		/// <summary>
		/// called as the completion handler to requesting access to the calendar
		/// </summary>
		protected void PopulateCalendarList(bool grantedAccess, NSError e)
		{
			// if it err'd show it to the user
			if (e != null)
			{
				Console.WriteLine("Err: " + e.ToString());
				new UIAlertView("Error", e.ToString(), null, "ok", null).Show();
				return;
			}
			if (grantedAccess)
			{
				calendars = App.Current.EventStore.GetCalendars(entityType);
				var section = new Section();
				section.AddAll(
					from elements in calendars
					select new StringElement(elements.Title, elements.Source.Title)
				);
				calendarListRoot.Add(section);

				this.InvokeOnMainThread(() =>
				{
					this.Root = calendarListRoot;
				});
			}
			else
			{
				Console.WriteLine("Access denied by user. ");
				InvokeOnMainThread(() =>
				{
					new UIAlertView("No Access", "Access to calendar not granted", null, "ok", null).Show();
				});
			}
		}

	}
}
