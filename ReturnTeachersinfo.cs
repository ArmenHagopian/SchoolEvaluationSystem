﻿using System;
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

			//If the Student list is empty, the program reads the file and creates a Student object with the data contained on each line of the file. Then it adds those object in a list.
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

			//If the Teacher list is empty or if the Teacher doesn't have the student in his class
			if (this._teacherslist.Count == 0 || this._teacherslist[0].has_students == false)
			{
				System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
				while ((line = allTeachers.ReadLine()) != null)
				{
					string[] splitteachers = line.Split(new Char[] { ';' });
					Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]), splitteachers[3]);
					if (teacher.has_students == false)
					{   //The loop starts at 4 because the relevant data starts at position 4 on the line
						for (int i = 4; i < splitteachers.Length; i++)
						{   //For every student object in the list, if the registration number of the student is equal to the number in the teachers file then the teacher object adds the student object
							foreach (Student student in this._studentslist)
							{
								if (student.Matricule.ToString() == splitteachers[i])
								{
									teacher.AddStudent(student);
								}
							}
						}
					}
					this._teacherslist.Add(teacher);
				}
			}

			System.IO.StreamReader allactivities = new System.IO.StreamReader("Activities.txt");

			//Display every student that the teacher has in each activity
			while ((line = allactivities.ReadLine()) != null)
			{
				string[] splitactivities = line.Split(new Char[] { ';' });
				foreach (Teacher element in this._teacherslist)
				{
					if (element.Trigram == splitactivities[3] & element.Trigram == this._input)
					{
						display += string.Format("\nLes eleves de {0} {1} de l'activite {2} sont\n", element.Firstname,
												 element.Lastname, splitactivities[1]);
						foreach (Student eachstudent in this._studentslist)
						{
							for (int i = 4; i < splitactivities.Length; i++)
							{
								if (eachstudent.Matricule.ToString() == splitactivities[i])
								{
									display += eachstudent.DisplayName() + "\n";
								}
							}
						}

					}
				}
			}

			string salary = "";
			//Retrieves the salary of a teacher
			foreach (Teacher teacher in this._teacherslist)
			{
				if (teacher.Trigram == this._input)
				{
					salary = teacher.Salary;

				}
			}
			display += "\nEt son salaire : " + salary + " euros\n";
			if (display == "\nEt son salaire : " + salary + " euros\n")
			{
				return "";
			}
			return display;

		}
	}
}