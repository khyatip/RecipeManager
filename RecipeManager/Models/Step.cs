using System;
namespace RecipeManager
{
	public class Step
	{
		public int Id { get; set; }
		//public int StepNum { get; set; }
		public string StepDetial { get; set; }

		public Step()
		{
			Id = 0;
			//StepNum = 0;
			StepDetial = "";
		}
		public Step(int id, string step)
		{
			Id = id;
			//StepNum = stepNum;
			StepDetial = step;
		}
		public override string ToString()
		{
			return string.Format("[Step: Id={0}, StepDetial={1}]", Id, StepDetial);
		}
	}
}
