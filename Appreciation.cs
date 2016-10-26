using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	public class Appreciation : Evaluation
	{
		private string _appreciation;
		public Appreciation(Activity activity, string appreciation) : base(activity)
		{
			this._appreciation = appreciation;
		}
		public void setAppreciation(string appreciation)
		{
			this._appreciation = appreciation;
		}
		public override int Note()
		{
			switch (this._appreciation)
			{
				case "X":
					return 20;
				case "TB":
					return 16;
				case "B":
					return 12;
				case "C":
					return 8;
				case "N":
					return 4;
				default:
					return 0;
			}
		}

	}
}