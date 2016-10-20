using System;
using System.Collections.Generic;

namespace Relations_classes_objets
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			//Teacher teacher = new Teacher("Armen", "Hagopian", 10);
			//Console.WriteLine("Salaire : " + teacher.Salary + ", " + teacher);

			//Teacher LUR = new Teacher("Quentin", "Lurkin", 2500);
			//Teacher LRG = new Teacher("Andre", "Lorge", 1000);
			//Activity informatique = new Activity(5, "Informatique", "IN20", LUR);
			//Activity math = new Activity(7, "Base de donnees", "DB20", LRG);
			//Student A14040 = new Student("Armen", "Hagopian");
			//A14040.Add(new Cote(informatique, 12));
			//A14040.Add(new Appreciation(math, "N"));
			//A14040.Add(new Evaluation(informatique));
			//A14040.Add(new Appreciation(math, "X"));
			//Console.WriteLine("Moyenne de {0} {1} : {2} ", A14040.Firstname, A14040.Lastname, A14040.Average());
			//Console.WriteLine("Bulletin de {0} {1} : \n{2}", A14040.Firstname, A14040.Lastname, A14040.Bulletin());




//----------------------------------------------------------------------------------------------------------------------
			int counter = 0;
			string line;
			List<Student> studentslist = new List<Student>();

			// Read the file line by line.
			System.IO.StreamReader allStudents = new System.IO.StreamReader("Students.txt");
			while ((line = allStudents.ReadLine()) != null)
			{
				string[] splitstudents = line.Split(new Char[] { ';' });
				Student student = new Student(splitstudents[0], splitstudents[1]);
				studentslist.Add(student);
				counter++;
			}


//----------------------------------------------------------------------------------------------------------------------
			List<Teacher> teacherslist = new List<Teacher>();
			System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
			while ((line = allTeachers.ReadLine()) != null)
			{
				string[] splitteachers = line.Split(new Char[] { ';' });
				Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]));
				teacherslist.Add(teacher);
			}



//----------------------------------------------------------------------------------------------------------------------
			List<Activity> activitieslist = new List<Activity>();
			System.IO.StreamReader allactivities = new System.IO.StreamReader("Activities.txt");
			while ((line = allactivities.ReadLine()) != null)
			{
				string[] splitactivities = line.Split(new Char[] { ';' });
				foreach (Teacher element in teacherslist)
				{
					if (element.Firstname == splitactivities[3] & element.Lastname == splitactivities[4])
					{
						Teacher teacherobject = new Teacher(element.Firstname, element.Lastname, 
						                                    Convert.ToInt32(element.Salary));
						Activity activity = new Activity(Convert.ToInt32(splitactivities[0]), splitactivities[1], 
						                                 splitactivities[2], teacherobject);
						activitieslist.Add(activity);
					}
				}
			}



//----------------------------------------------------------------------------------------------------------------------
			int countline = 0;
			//permet d'enregistrer les lignes qui contiennent le nom et le prenom des eleves
			List<int> nameslines = new List<int>();
			List<Student> studentnames = new List<Student>();
			System.IO.StreamReader evaluations = new System.IO.StreamReader("Evaluations.txt");
			while ((line = evaluations.ReadLine()) != null)
			{
				string[] splitstudents = line.Split(new Char[] { ';' });
				Student student = new Student(splitstudents[0], splitstudents[1]);
				for (int studentnumber = 0; studentnumber < studentslist.Count; studentnumber++)
				{
					if (student.Firstname == studentslist[studentnumber].Firstname & 
					    student.Lastname == studentslist[studentnumber].Lastname)
					{
						nameslines.Add(countline);
						studentnames.Add(studentslist[studentnumber]);
					}
				}
				countline++;
			}


//----------------------------------------------------------------------------------------------------------------------
			System.IO.StreamReader evaluations2 = new System.IO.StreamReader("Evaluations.txt");
			List<Student> newstudentslist = new AddEvaluations().Return(evaluations2, nameslines, activitieslist, 
			                                                            studentslist, studentnames);



//----------------------------------------------------------------------------------------------------------------------
			//Writes reports (Bulletins) of all students in same txt file
			string text = "";
			foreach (Student eachstudent in newstudentslist)
			{
				Console.WriteLine(eachstudent.Bulletin());
				text += string.Format(eachstudent.Bulletin());
			}

			// WriteAllText creates a file, writes the specified string to the file and then closes the file.
			System.IO.File.WriteAllText(@"Bulletins.txt", text);

			//Writes report of each student in a differnet txt file
			string text2 = "";
			foreach (Student eachstudent in newstudentslist)
			{
				string filename = string.Format("Bulletin_de_{0}_{1}.txt", eachstudent.Firstname, eachstudent.Lastname);
				text2 = string.Format(eachstudent.Bulletin());
				System.IO.File.WriteAllText(filename, text2);
			}
		}
	}
}