
using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			List<Student> studentslist = new List<Student>();
			List<Teacher> teacherslist = new List<Teacher>();
			List<Activity> activitieslist = new List<Activity>();
			string input = "";

			input = "B";

			//We check several times if the user types the word 'quit' to end the program or B to come back to homepage
			while (input == "B" & input != "quit")
			{
				Console.WriteLine("=== Bienvenue dans le meilleur logiciel de gestion d'Evaluations ===");
				Console.WriteLine("1/ Liste des étudiants.");
				Console.WriteLine("2/ Liste des enseignants.");
				Console.WriteLine("3/ Liste des activités.");
				Console.WriteLine("Veuillez entrer le numéro de la liste que vous souhaitez consulter");
				Console.WriteLine("\nP.S. : Vous pouvez taper quit a n'importe quel moment pour quitter le logiciel\n");

				input = Console.ReadLine();
				if (input != "quit")
				{   //Uses a DisplayCase object to generate a proper response to display after the input
					DisplayCase display = new DisplayCase(input, studentslist, teacherslist, activitieslist);
					Console.WriteLine(display);
					while (display.ToString() == "Veuillez entrer l'un des numeros de liste existants" & input != "quit")
					{
						input = Console.ReadLine();
						if (input != "quit")
						{
							display = new DisplayCase(input, studentslist, teacherslist, activitieslist);
							Console.WriteLine(display);
						}
					}
					if (input != "quit")
					{
						input = Console.ReadLine();
					}
					//if the input is B then the program goes back to the first menu
					if (input != "B" & input != "quit")
					{
						Console.WriteLine(display.ChosenList(input));
						while ((display.ChosenList(input) == "Veuillez entrer l'un des matricules existants\n" ||
							display.ChosenList(input) == "Veuillez entrer un trigramme existant\n" ||
							display.ChosenList(input) == "Veuillez entrer l'un des codes d'activites existants\n") &
							   input != "quit")
						{
							input = Console.ReadLine();
							if (input != "quit")
							{
								Console.WriteLine(display.ChosenList(input));
							}
						}

						if (input != "quit")
						{
							Console.WriteLine("Tapez B pour revenir au menu principal ou tapez quit ou n'importe " +
											  "quoi d'autre pour quitter le programme");
							input = Console.ReadLine();
						}
					}
				}
			}
			Console.WriteLine("\nBye");
		}
	}
}