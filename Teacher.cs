using System;
using System.Collections.Generic;

namespace Relations_classes_objets
{
	public class Teacher : Person
	{
		private int _salary;
		private string _trigram;
		private List<Student> Students = new List<Student>();
		public Teacher(string Firstname, string Lastname, int Salary, string Trigram) : base(Firstname, Lastname)
		{
			this._salary = Salary;
			this._trigram = Trigram;
		}

		public void AddStudent(Student student)
		{
			Students.Add(student);
		}
		public string DisplayStudents()
		{
			string display = string.Format("Ci-desssous sont repris tous les eleves de {0} {1} :\n", Firstname, Lastname);
			foreach (Student student in Students)
			{
				display += student + "\n";
			}
			return display;
		}
		public string Salary
		{
			get { return Convert.ToString(this._salary); }
		}
		public string Trigram
		{
			get { return this._trigram;}
		}
	}
}

//using System;

//namespace Relations_classes_objets
//{
//	class MainClass
//	{
//		public static void Main(string[] args)
//		{
//			Teacher teacher = new Teacher("Armen", "Hagopian", 10);
//			Console.WriteLine("Salaire : " + teacher.Salary + ", " + teacher);
//		}
//	}
//}