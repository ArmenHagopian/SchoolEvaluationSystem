using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	class MainClass
	{

		public static void Main(string[] args)
		{

			Console.WriteLine("=== Bienvenue dans le meilleur logiciel de gestion d'Evaluations ===");
			Console.WriteLine("1/ Liste des étudiants.");
			Console.WriteLine("2/ Liste des enseignants.");
			Console.WriteLine("3/ Liste des activités.");
			Console.WriteLine("Veuillez entrer le numéro de la liste que vous souhaitez consulter");

			List<Student> studentslist = new List<Student>();
			List<Teacher> teacherslist = new List<Teacher>();
			List<Activity> activitieslist = new List<Activity>();

			string a = Console.ReadLine();
			if (a == "1")
			{
				Console.WriteLine("\nVoici la liste des etudiants\n");
				int counter = 0;
				string line;
				// Read the file line by line.
				System.IO.StreamReader allStudents = new System.IO.StreamReader("Students.txt");
				while ((line = allStudents.ReadLine()) != null)
				{
					string[] splitstudents = line.Split(new Char[] { ';' });
					Student student = new Student(splitstudents[0], splitstudents[1], Convert.ToInt32(splitstudents[2]));
					studentslist.Add(student);
					counter++;
				}
				foreach (Student eachstudent in studentslist)
				{
					Console.WriteLine(string.Format("{0}, Matricule : {1}", eachstudent.DisplayName(), eachstudent.Matricule));
				}
			}
			else if (a == "2")
			{
				Console.WriteLine("\nVoici la liste des enseignants\n");
				string line;
				System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
				while ((line = allTeachers.ReadLine()) != null)
				{
					string[] splitteachers = line.Split(new Char[] { ';' });
					Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]), splitteachers[3]);
					teacherslist.Add(teacher);
				}
				foreach (Teacher eachteacher in teacherslist)
				{
					Console.WriteLine(string.Format("{0}, Trigramme : {1}", eachteacher.DisplayName(), eachteacher.Trigram));
				}
			}
			else if (a == "3")
			{
				Console.WriteLine("\nVoici la liste des activites\n");
				string line;
				System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
				while ((line = allTeachers.ReadLine()) != null)
				{
					string[] splitteachers = line.Split(new Char[] { ';' });
					Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]), splitteachers[3]);
					teacherslist.Add(teacher);
				}

				System.IO.StreamReader allactivities = new System.IO.StreamReader("Activities.txt");

				while ((line = allactivities.ReadLine()) != null)
				{
					string[] splitactivities = line.Split(new Char[] { ';' });
					foreach (Teacher element in teacherslist)
					{
						if (element.Trigram == splitactivities[3])
						{
							Teacher teacherobject = new Teacher(element.Firstname, element.Lastname,
							                                    Convert.ToInt32(element.Salary), element.Trigram);
							Activity activity = new Activity(Convert.ToInt32(splitactivities[0]), splitactivities[1],
															 splitactivities[2], teacherobject);
							activitieslist.Add(activity);
						}
					}
				}
				string activitydisplay = "Nom du cours" + "\tCode du cours" + "\tNbre ECTS" + "\tEnseignant\n";
				foreach (Activity eachactivity in activitieslist)
				{
					//more or less tab depending on the length of the name of the activity 
					if (eachactivity.Name.Length < 10)
					{
						activitydisplay += eachactivity.Name + "\t\t" + eachactivity.Code + "\t\t" + eachactivity.ECTS + "\t\t" + eachactivity.Teacher.Trigram + "\n";
					}
					else
					{
						activitydisplay += eachactivity.Name + "\t" + eachactivity.Code + "\t\t" + eachactivity.ECTS + "\t\t" + eachactivity.Teacher.Trigram + "\n";
					}
				}
				Console.WriteLine(activitydisplay);
			}
			else
			{
				Console.WriteLine("Veuillez entrer l'un des numeros de liste existant");
			}
		}
	}
}