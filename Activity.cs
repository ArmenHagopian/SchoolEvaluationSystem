﻿using System;
using System.Collections.Generic;
namespace EvaluationSystem

{
	public class Activity
	{
		private int _ECTS;
		private string _name;
		private string _code;
		private Teacher _teacher;
		private List<Book> Books = new List<Book>();

		public Activity(int ECTS, string name, string code, Teacher teacher)
		{
			this._ECTS = ECTS;
			this._name = name;
			this._code = code;
			this._teacher = teacher;
		}
		public int ECTS
		{
			get { return this._ECTS; }
		}
		public string Name
		{
			get { return this._name; }
		}

		public string Code
		{
			get { return this._code; }
		}
		public Teacher Teacher
		{
			get { return this._teacher; }
		}

		public void AddBook(Book book)
		{
			Books.Add(book);
		}

		public string DisplayBook()
		{
			string display = string.Format("Le(s) livre(s) de {0} est/sont :\n", this._name);
			foreach (Book book in Books)
			{
				display += book + "\n";
			}
			if (Books.Count == 0)
			{
				display = "Pas de livre encodé";
			}
			return display;
		}
	}
}
