using System;

namespace EvaluationSystem
{
	public abstract class Evaluation
	{
		private Activity _activity;
		public Evaluation(Activity activity)
		{
			this._activity = activity;
		}
		public Activity Activity
		{
			get { return this._activity; }
		}

		public abstract int Note();
	}
}