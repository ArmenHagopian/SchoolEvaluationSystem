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
			string input = "";
			string a = "";

			input = Console.ReadLine();
			if (input != "quit" & a!="quit")
			{
				DisplayCase display = new DisplayCase(input, studentslist, teacherslist, activitieslist);
				Console.WriteLine(display);
				//input = Console.ReadLine();

				while (display.ToString() == "Veuillez entrer l'un des numeros de liste existants" & input != "quit")
				{
					input = Console.ReadLine();

					if (input != "quit" & a != "quit")
					{
						display = new DisplayCase(input, studentslist, teacherslist, activitieslist);
						Console.WriteLine(display);

					}
				}
				if (input != "quit")
				{
					a = Console.ReadLine();
				}
				while (a == "B" & (a != "quit" & input !="quit"))
				{
					Console.WriteLine("=== Bienvenue dans le meilleur logiciel de gestion d'Evaluations ===");
					Console.WriteLine("1/ Liste des étudiants.");
					Console.WriteLine("2/ Liste des enseignants.");
					Console.WriteLine("3/ Liste des activités.");
					Console.WriteLine("Veuillez entrer le numéro de la liste que vous souhaitez consulter");
					input = Console.ReadLine();
					if (input != "quit" & a != "quit")
					{
						display = new DisplayCase(input, studentslist, teacherslist, activitieslist);
						Console.WriteLine(display);
						while (display.ToString() == "Veuillez entrer l'un des numeros de liste existants" & input != "quit")
						{
							input = Console.ReadLine();
							if (input != "quit" & a != "quit")
							{

								display = new DisplayCase(input, studentslist, teacherslist, activitieslist);
								Console.WriteLine(display);
							}			
						}
						if (input != "quit")
						{
							a = Console.ReadLine();
						}
					}
				}
			}
			Console.WriteLine("\nBye");
		}
	}
}