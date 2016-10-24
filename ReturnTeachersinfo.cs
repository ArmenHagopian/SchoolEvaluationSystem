using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	public class ReturnTeachersinfo
	{
		private List<Teacher> _teacherslist;
		private List<Student> _studentslist;
		private string _input;
		public ReturnTeachersinfo(List<Teacher> Teacherslist, List<Student> Studentslist, string input)
		{
			this._teacherslist = Teacherslist;
			this._studentslist = Studentslist;
			this._input = input;
		}
		public override string ToString()

		{
			string display = "";

			string line;


			if (this._studentslist.Count == 0)
			{
				System.IO.StreamReader allStudents = new System.IO.StreamReader("Students.txt");
				while ((line = allStudents.ReadLine()) != null)
				{
					string[] splitstudents = line.Split(new Char[] { ';' });
					Student student = new Student(splitstudents[0], splitstudents[1], Convert.ToInt32(splitstudents[2]));
					this._studentslist.Add(student);
				}
			}


			//if (this._teacherslist.Count == 0)
			//{
				System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
				while ((line = allTeachers.ReadLine()) != null)
				{
					string[] splitteachers = line.Split(new Char[] { ';' });
					Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]), splitteachers[3]);
					for (int i = 4; i < splitteachers.Length; i++)
					{
						foreach (Student student in this._studentslist)
						{
							if (student.Matricule.ToString() == splitteachers[i])
							{
								teacher.AddStudent(student);
							}
						}
					}
					this._teacherslist.Add(teacher);
				}
			//}


			//else 
			//{ 
			//	System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
			//	while ((line = allTeachers.ReadLine()) != null)
			//	{
			//		string[] splitteachers = line.Split(new Char[] { ';' });
			//		Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]), splitteachers[3]);
			//		for (int i = 4; i < splitteachers.Length; i++)
			//		{
			//			foreach (Student student in this._studentslist)
			//			{
			//				if (student.Matricule.ToString() == splitteachers[i])
			//				{
			//					teacher.AddStudent(student);
			//				}
			//			}
			//		}
			//		this._teacherslist.Add(teacher);
			//	}
			//}

			string salary = "";
			foreach (Teacher teacher in this._teacherslist)
			{
				if (teacher.Trigram == this._input)
				{
					display = teacher.DisplayStudents();
					salary = teacher.Salary;
					
				}
			}
			display += "\n\nEt son salaire : " + salary +  " euros";

			return display;

		}
	}
}
