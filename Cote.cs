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

		public override int Note()          //methode
		{
			return this._note;
		}
		public void setNote(int note)       //pour modifier une note existante
		{
			this._note = note;
		}
	}
}
