using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	public class Teacher : Person
	{
		private int _salary;
		private string _trigram;
		private List<Student> Students = new List<Student>();
		public bool has_students = false;
		public Teacher(string Firstname, string Lastname, int Salary, string Trigram) : base(Firstname, Lastname)
		{
			this._salary = Salary;
			this._trigram = Trigram;
			this.has_students = false;
		}

		public void AddStudent(Student student)
		{
			Students.Add(student);
			this.has_students = true;
		}
		public List<Student> Studentslist
		{
			get { return Students;}
		}
		public string DisplayStudents()
		{
			string display = string.Format("Ci-desssous sont repris tous les eleves de {0} {1} :\n", Firstname, Lastname);
			foreach (Student student in Students)
			{
				display += student + ", Matricule : " + student.Matricule + "\n";
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