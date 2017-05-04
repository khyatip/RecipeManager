using System;
using System.Collections.Generic;

namespace RecipeManager
{
	public class StepsViewModel
	{
		//IEnumerable<Step> stepsTableItems;

		public StepsViewModel(/*IEnumerable<Step> stepsTableItems*/)
		{
			//this.stepsTableItems = stepsTableItems;
		}
		public IEnumerable<Step> GetStepsTableItems(int recipeID)
		{
			return AppDelegate.RecipesDB.GetStepsList(recipeID);
		}
		public void SaveStep(int recipeID, string stepDetail)
		{
			var newStep = new Step();
			newStep.RecipeId = recipeID;
			newStep.StepDetail = stepDetail;
			AppDelegate.RecipesDB.SaveStep(newStep);
		}
		public void SaveStepsList(int recipeID, IList<string> addedStepsList)
		{
			foreach (string step in addedStepsList)
				SaveStep(recipeID, step);
		}
	}
}
