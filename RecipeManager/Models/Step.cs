using System;
using SQLite;

namespace RecipeManager
{
	public class Step
	{
		[PrimaryKey, AutoIncrement]
		public int RecipeId { get; set; }
		public int Id { get; set; }
		//public int StepNum { get; set; }
		public string StepDetial { get; set; }

		public Step()
		{
			RecipeId = 0;
			Id = 0;
			StepDetial = "";
		}
		public Step(int recipeId,int id, string step)
		{
			RecipeId = recipeId;
			Id = id;
			StepDetial = step;
		}
		public override string ToString()
		{
			return string.Format("[Step: RecipeId={0}, Id={1}, StepDetial={2}]", RecipeId, Id, StepDetial);
		}
	}
}
