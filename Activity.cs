using System;
namespace Relations_classes_objets
{
	public class Activity
	{
		private int _ECTS;
		private string _name;
		private string _code;
		private Teacher _teacher;
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
	}
}
