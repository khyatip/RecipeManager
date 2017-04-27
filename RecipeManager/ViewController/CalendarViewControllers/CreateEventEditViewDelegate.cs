using System;
using System.Collections.Generic;
using EventKit;
using Foundation;

namespace RecipeManager
{
	public class CreateEventEditViewDelegate : EventKitUI.EKEventEditViewDelegate
	{
		protected EventKitUI.EKEventEditViewController eventController;
		Recipe recipeEvent;

		public CreateEventEditViewDelegate(EventKitUI.EKEventEditViewController eventController, Recipe recipe)
		{
			this.eventController = eventController;
			recipeEvent = recipe;
			SetEventValues(recipe);
		}

		public void SetEventValues(Recipe recipe)
		{
			eventController.Event.Title = recipe.RecipeTitle;
			eventController.Event.Notes = "Calorie Count: " + recipe.CalorieCount + "\n" +
										 "Cook Time In Minutes: " + recipe.CookTimeInMinutes + "\n";
			eventController.Event.Notes = eventController.Event.Notes + GetIngredients(recipe);
			eventController.Event.Notes = eventController.Event.Notes + GetSteps(recipe);

		}
		public string GetIngredients(Recipe recipe)
		{
			IEnumerable<Ingredient> ingredientsTableItems;
			ingredientsTableItems = AppDelegate.RecipesDB.GetIngredientsList(recipe.Id);
			var ingredients = "Ingredients: \n";
			foreach (Ingredient ingredient in ingredientsTableItems)
			{
				ingredients = ingredients + ingredient.IngredientTitle + ", ";
			}
			return ingredients;
		}
		public string GetSteps(Recipe recipe)
		{
			IEnumerable<Step> stepsTableItems;
			stepsTableItems = AppDelegate.RecipesDB.GetStepsList(recipe.Id);
			
			var steps = "Steps: \n";
			foreach (Step step in stepsTableItems)
			{
				steps = steps + step.StepDetail + "\n";
			}
			return steps;
		}
		public override void Completed(EventKitUI.EKEventEditViewController controller, EventKitUI.EKEventEditViewAction action)
		{
			eventController.DismissViewController(true, null);

			switch (action)
			{
				case EventKitUI.EKEventEditViewAction.Canceled:
					break;
				case EventKitUI.EKEventEditViewAction.Deleted:
					break;
				case EventKitUI.EKEventEditViewAction.Saved:
					break;
			}
		}
	}
}
