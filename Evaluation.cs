using System;

namespace Relations_classes_objets
{
	public abstract class Evaluation
	{
		private Activity _activity;
		//private int _note;
		public Evaluation(Activity activity)
		{
			this._activity = activity;
			//this._note = note;
		}
		public Activity Activity
		{
			get { return this._activity; }
		}

		//permet d'utiliser Activity.Note() mais la note vient de Cote.Note() ou 
		//Appreciation.Note() en fonction de si la note a ete donnee avec la classe Cote ou Appreciation
		public abstract int Note();

		//return this._note;
		//Cote(this._activity, 3);

		//if (Appreciation.Note)
		//{
		//	return "n";
		//}

	}
}
