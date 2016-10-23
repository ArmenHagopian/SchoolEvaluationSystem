using System;
namespace EvaluationSystem
{
	public class Activity
	{
		private int _ECTS;
		private string _name;
		private string _code;
		private Teacher _teacher;
		private Book _book;
		public Activity(int ECTS, string name, string code, Teacher teacher, Book book)
		{
			this._ECTS = ECTS;
			this._name = name;
			this._code = code;
			this._teacher = teacher;
			this._book = book;
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
		//Attention cette fonction retourne une liste de livre avec différent nom de cours
		public Book Book
		{ 
			get { return this._book; }
		}
	}
}
