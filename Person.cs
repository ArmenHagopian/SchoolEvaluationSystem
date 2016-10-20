using System;
namespace Relations_classes_objets
{
	public class Person		//est prive si met pas public class
	{
		private string _firstname;
		private string _lastname;
		public Person(string Firstname, string Lastname)
		{
			this._firstname = Firstname;
			this._lastname = Lastname;

		}

		public string Firstname		//public donc on peut y acceder en faisant student.Firstname
		{
			get { return this._firstname;}
		}
		public string Lastname
		{
			get { return this._lastname;}
		}

		public string DisplayName()
		{
			return "Firstname : " + Firstname + ", Lastname : " + Lastname;
		}

		public override string ToString()		//permet d'appeler directement DisplayName quand cree nouvel objet student par exemple : Person student = new Person("Armen", "Hagopian"); Console.WriteLine(student);
		{
			return this.DisplayName();
		}
	}
}
