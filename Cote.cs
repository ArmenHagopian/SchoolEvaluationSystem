using System;
namespace EvaluationSystem
{
	public class Cote : Evaluation
	{
		private int _note;
		public Cote(Activity activity, int note) : base(activity)
		{
			this._note = note;
		}

		public override int Note()
		{
			return this._note;
		}

		public void setNote(int note)
		{
			this._note = note;
		}
	}
}