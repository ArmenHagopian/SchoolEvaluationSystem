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
		private bool _studentchosen = false;
		private bool _teacherchosen = false;
		private bool _activitychosen = false;
		public DisplayCase(string input, List<Student> studentslist, List<Teacher> teacherslist, List<Activity> activitieslist)
		{
			this._input = input;
			this._studentslist = studentslist;
			this._teacherslist = teacherslist;
			this._activitieslist = activitieslist;
		}
		//Displays the second menu for all the possibilities 
		public override string ToString()
		{
			switch (this._input)
			{
				//case "qui":
				//	return "stop";
				//Displays the student list
				case "1":
					_studentchosen = true;
					_teacherchosen = false;
					_activitychosen = false;

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
					//Displays a number in front of the 3 possible choices, starting at 1
					int counter = 1;
					foreach (Student eachstudent in this._studentslist)
					{
						studentdisplay += string.Format("{0}/ {1}, Matricule : {2}\n", counter, eachstudent.DisplayName(), eachstudent.Matricule);
						counter++;
					}
					
					return studentdisplay + "\nChoisir un etudiant pour afficher son bulletin en donnant le numero de son matricule ou taper B pour revenir au menu principal.";
				
					//Displays the list of teachers
				case "2":
					_studentchosen = false;
					_teacherchosen = true;
					_activitychosen = false;
					string teacherdisplay = "\nVoici la liste des enseignants\n";
					this._teacherslist = new List<Teacher>();
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
					
					return teacherdisplay + "\nChoisir un enseignant en donnant son trigramme pour afficher son salaire " +
					"et tous ces eleves ou taper B pour revenir au menu principal.";
				//Displays the activities
				case "3":
					
					_studentchosen = false;
					_teacherchosen = false;
					_activitychosen = true;

					string activitydisplay = "\nVoici la liste des activites\n";

					if (this._activitieslist.Count == 0)
					{
						ReturnActivities result = new ReturnActivities(this._teacherslist);
						this._activitieslist = result.List();
					}

					activitydisplay += "Nom du cours" + "\tCode du cours" + "\tNbre ECTS" + "\tEnseignant\n";

					foreach (Activity eachactivity in this._activitieslist)
					{
						//More or less tab depending on the length of the name of the activity 
						if (eachactivity.Name.Length < 10)
						{
							activitydisplay += eachactivity.Name + "\t\t" + eachactivity.Code + "\t\t" + eachactivity.ECTS + "\t\t" + eachactivity.Teacher.Trigram + "\n";
						}
						else
						{
							activitydisplay += eachactivity.Name + "\t" + eachactivity.Code + "\t\t" + eachactivity.ECTS + "\t\t" + eachactivity.Teacher.Trigram + "\n";
						}
					}

					return activitydisplay + "\nChoisir une activite en donnant son code pour afficher le(s) livre(s) " +
					"associe(s) et les eleves qui y sont inscrits ou taper B pour revenir au menu principal.";

				default:

					return "Veuillez entrer l'un des numeros de liste existants";
				
			}
		}

		//Return info about the list chosen by the user
		public string ChosenList(string input)
		{   
			//Error message displayed when the user doesn't give an existing 'matricule'
			if (_studentchosen == true)
			{
				//Default value to display if user doesn't give an existing 'matricule'
				string displaystudent = "";
				ReturnStudentsInfo studentsinfo = new ReturnStudentsInfo(this._studentslist, this._teacherslist, this._activitieslist, input);
				displaystudent = studentsinfo.ToString();
				if (displaystudent != "")
				{
					return displaystudent;
				}
				return "Veuillez entrer l'un des matricules existants\n";
			}
			//Error message displayed when the user doesn't give an existing trigram
			else if (_teacherchosen == true)
			{
				string displayteacher = "";
				List<Teacher> newteacherslist = new List<Teacher>();
				displayteacher = new ReturnTeachersinfo(newteacherslist, this._studentslist, input).ToString();
				if (displayteacher != "")
				{
					return displayteacher;
				}
				return "Veuillez entrer un trigramme existant\n";
			}
			//Error message displayed when the user doesn't give an existing codes
			else if (_activitychosen == true)
			{
				string displayactivities = "";
		
				ReturnActivities activities = new ReturnActivities(this._teacherslist);
				//This loop analyses the list of activities for a match between the input and one of the activity
				foreach (Activity eachactivity in activities.List())
				{
					if (eachactivity.Code == input)
					{
						displayactivities += eachactivity.DisplayBook();
					}
				}
				if (displayactivities != "")
				{
					return displayactivities;
				}
				return "Veuillez entrer l'un des codes d'activites existants\n";
			}
			return "Error";
		}
	}
}
