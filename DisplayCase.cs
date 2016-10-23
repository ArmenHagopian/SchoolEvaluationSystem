using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	public class DisplayCase
	{
		private string _input;
		List<Student> _studentslist;
		List<Teacher> _teacherslist;
		List<Activity> _activitieslist;
		public DisplayCase(string input, List<Student> studentslist, List<Teacher> teacherslist, List<Activity> activitieslist)
		{
			this._input = input;
			this._studentslist = studentslist;
			this._teacherslist = teacherslist;
			this._activitieslist = activitieslist;
		}

		public override string ToString()
		{
			switch (this._input)
			{
				//case "qui":
				//	return "stop";
				case "1":

					string studentdisplay = "\nVoici la liste des etudiants\n";
					string line;
					if (this._studentslist.Count == 0)
					{
						// Read the file line by line.
						System.IO.StreamReader allStudents = new System.IO.StreamReader("Students.txt");
						while ((line = allStudents.ReadLine()) != null)
						{
							string[] splitstudents = line.Split(new Char[] { ';' });
							Student student = new Student(splitstudents[0], splitstudents[1], Convert.ToInt32(splitstudents[2]));
							this._studentslist.Add(student);
						}
					}
					int counter = 1;
					foreach (Student eachstudent in this._studentslist)
					{
						studentdisplay += string.Format("{0}/ {1}, Matricule : {2}\n", counter, eachstudent.DisplayName(), eachstudent.Matricule);
						counter++;
					}
					
					return studentdisplay + "\nChoisir un etudiant en donnant le numero de son matricule ou taper B pour revenir au menu principal.";

				case "2":

					string teacherdisplay = "\nVoici la liste des enseignants\n";
					if (this._teacherslist.Count == 0)
					{
						System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
						while ((line = allTeachers.ReadLine()) != null)
						{
							string[] splitteachers = line.Split(new Char[] { ';' });
							Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]), splitteachers[3]);
							this._teacherslist.Add(teacher);
						}
					}
						counter = 1;
						foreach (Teacher eachteacher in this._teacherslist)
						{
							teacherdisplay += string.Format("{0}/ {1}, Trigramme : {2}\n", counter, eachteacher.DisplayName(), eachteacher.Trigram);
							counter++;
						}
					
					return teacherdisplay + "\nChoisir un enseignant en donnant son trigramme ou taper B pour revenir au menu principal.";
					
				case "3":

					Console.WriteLine("\nVoici la liste des activites\n");
					if (this._teacherslist.Count == 0)
					{
						System.IO.StreamReader allTeachers = new System.IO.StreamReader("Teachers.txt");
						while ((line = allTeachers.ReadLine()) != null)
						{
							string[] splitteachers = line.Split(new Char[] { ';' });
							Teacher teacher = new Teacher(splitteachers[0], splitteachers[1], Convert.ToInt32(splitteachers[2]), splitteachers[3]);
							this._teacherslist.Add(teacher);
						}
					}

					if (this._activitieslist.Count == 0)
					{
						System.IO.StreamReader allactivities = new System.IO.StreamReader("Activities.txt");

						while ((line = allactivities.ReadLine()) != null)
						{
							string[] splitactivities = line.Split(new Char[] { ';' });
							foreach (Teacher element in this._teacherslist)
							{
								if (element.Trigram == splitactivities[3])
								{
									Teacher teacherobject = new Teacher(element.Firstname, element.Lastname,
																		Convert.ToInt32(element.Salary), element.Trigram);
									Activity activity = new Activity(Convert.ToInt32(splitactivities[0]), splitactivities[1],
																	 splitactivities[2], teacherobject);
									this._activitieslist.Add(activity);
								}
							}
						}
					}
					string activitydisplay = "Nom du cours" + "\tCode du cours" + "\tNbre ECTS" + "\tEnseignant\n";
					foreach (Activity eachactivity in this._activitieslist)
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

					return activitydisplay + "\nChoisir une activite en donnant son code ou taper B pour revenir au menu principal.";

				default:

					return "Veuillez entrer l'un des numeros de liste existant";
				
			}
		}
	}
}
