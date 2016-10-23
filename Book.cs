using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	public class Book
	{
		private List<string> Livre = new List<string>();
		private string _nomLivre;
		public Book(string nomLivre)
		{
			this._nomLivre = nomLivre;
		}
		public void add() 
		{
			Livre.Add(this._nomLivre);
		}

	}
}
