using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace RecipeManager
{
	public partial class RecipeDetailsVC : UIViewController
	{
		//DataViewModel dataModel;
		public Recipe currentRecipe { get; set;}
		IEnumerable<Ingredient> ingredientsTableItems;
		IEnumerable<Step> stepsTableItems;
		public HomeVC Delegate { get; set; }
		IngredientsViewModel ingredientsVM;
		StepsViewModel stepsVM;
		IList<string> newIngredientsList;
		IList<string> newStepsList;

		public RecipeDetailsVC(Recipe currentRecipe, IngredientsViewModel ingredientsVM, StepsViewModel stepsVM) : base("RecipeDetailsVC", null)
		{
			this.currentRecipe = currentRecipe;
			this.ingredientsVM = ingredientsVM;
			this.stepsVM = stepsVM;
		}
		public int GetNextStepNumber()
		{
			if (stepsTableItems.ToList().Count == 0)
				return 1;
			else
				return stepsTableItems.ToList().Count + 1;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Details";
			ingredientsTableItems = ingredientsVM.GetIngredientsTableItems(currentRecipe.Id);
			stepsTableItems = stepsVM.GetStepsTableItems(currentRecipe.Id);
			newIngredientsList = new List<string>();
			newStepsList = new List<string>();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			if (currentRecipe == null)
				currentRecipe = new Recipe();
			RecipeTitleField.Text = currentRecipe.RecipeTitle;
			CalorieCountField.Text = Convert.ToString(currentRecipe.CalorieCount);
			CookTimeField.Text = Convert.ToString(currentRecipe.CookTimeInMinutes);

			UpdateIngredientsTableView(currentRecipe.Id, ingredientsTableItems);
			UpdateStepsTableView(currentRecipe.Id, stepsTableItems);

		}
		partial void AddIngredientButtonSelected(Foundation.NSObject sender)
		{
			if (!string.IsNullOrEmpty(IngredientField.Text))
			{
				var newIngredient = new Ingredient();
				newIngredient.RecipeId = currentRecipe.Id;
				newIngredient.IngredientTitle = IngredientField.Text;

				newIngredientsList.Add(newIngredient.IngredientTitle);
				IngredientField.Text = "";

                UpdateIngredientsTableView(currentRecipe.Id, AddIngredientToList(ingredientsTableItems, newIngredient));
			}
		}
		public IEnumerable<Ingredient> AddIngredientToList(IEnumerable<Ingredient> ingredientsTableItems, Ingredient newIngredient)
		{
			if (ingredientsTableItems != null)
				return ingredientsTableItems.Concat(new[] { newIngredient });
			else
				return new Ingredient[] { newIngredient };
		}
		public void UpdateIngredientsTableView(int recipeId, IEnumerable<Ingredient> ingredientsTableItems)
		{
			IngredientsTableView.Source = new IngredientsTableViewSource(ingredientsTableItems);
			IngredientsTableView.ReloadData();
		}
		partial void AddRecipeStepButtonSelected(Foundation.NSObject sender)
		{
			
			if (!string.IsNullOrEmpty(RecipeStepField.Text))
			{
				var newStep = new Step();
				int stepCount = GetNextStepNumber();
				newStep.RecipeId = currentRecipe.Id;
				newStep.StepDetail = stepCount + ". " + RecipeStepField.Text;

				newStepsList.Add(newStep.StepDetail);
				RecipeStepField.Text = "";

				UpdateStepsTableView(currentRecipe.Id, AddStepToList(stepsTableItems, newStep));
			}
		}

		public IEnumerable<Step> AddStepToList(IEnumerable<Step> stepsTableItems, Step newStep)
		{
			if (stepsTableItems != null)
				return stepsTableItems.Concat(new[] { newStep });
			else
				return new Step[] { newStep };
		}

		public void UpdateStepsTableView(int recipeId, IEnumerable<Step> stepsTableItems)
		{
			RecipeStepsTableView.Source = new StepsTableViewSource(stepsTableItems);
			RecipeStepsTableView.ReloadData();
		}

		partial void RecipeSaveButtonSelected(Foundation.NSObject sender)
		{
			AssignRecipeValues();

			Delegate.SaveRecipe(currentRecipe);
			ingredientsVM.SaveIngredentsList(currentRecipe.Id, newIngredientsList);
			stepsVM.SaveStepsList(currentRecipe.Id, newStepsList);
			Console.WriteLine("RECIPE SAVED");
			NavigationController.PopViewController(true);
		}
		public void AssignRecipeValues()
		{
			if (!string.IsNullOrEmpty(RecipeTitleField.Text))
				currentRecipe.RecipeTitle = RecipeTitleField.Text;
			if (!string.IsNullOrEmpty(CalorieCountField.Text))//character to int handling
				currentRecipe.CalorieCount = Convert.ToInt32(CalorieCountField.Text);
			if (!string.IsNullOrEmpty(CookTimeField.Text))
				currentRecipe.CookTimeInMinutes = Convert.ToInt32(CookTimeField.Text);
		}
	}
}

