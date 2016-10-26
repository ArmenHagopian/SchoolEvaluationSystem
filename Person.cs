using System;
namespace EvaluationSystem
{
	public class Person
	{
		private string _firstname;
		private string _lastname;
		public Person(string Firstname, string Lastname)
		{
			this._firstname = Firstname;
			this._lastname = Lastname;
		}

		public string Firstname
		{
			get { return this._firstname; }
		}
		public string Lastname
		{
			get { return this._lastname; }
		}

		public string DisplayName()
		{
			return "Firstname : " + Firstname + ", Lastname : " + Lastname;
		}

		public override string ToString()
		{
			return this.DisplayName();
		}
	}
}