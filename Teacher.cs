﻿using System;
using System.Collections.Generic;

namespace Relations_classes_objets
{
	public class Teacher : Person
	{
		private int _salary;
		private List<Student> Students = new List<Student>();
		public Teacher(string Firstname, string Lastname, int Salary) : base(Firstname, Lastname)
		{
			this._salary = Salary;
		}

		public void AddStudent(Student student)
		{
			Students.Add(student);
		}

		public string Salary
		{
			get { return Convert.ToString(this._salary); }
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