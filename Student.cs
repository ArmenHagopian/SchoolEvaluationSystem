﻿using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	public class Student : Person
	{
		private List<Evaluation> Cours = new List<Evaluation>();
		private string _firstname;
		private string _lastname;
		private int _matricule;
		public bool is_evaluated = false;
		public Student(string Firstname, string Lastname, int Matricule) : base(Firstname, Lastname)
		{
			this._firstname = Firstname;
			this._lastname = Lastname;
			this._matricule = Matricule;
			this.is_evaluated = false;
		}

		public void Add(Evaluation evaluation)
		{
			Cours.Add(evaluation);
			//Allows to know if we have given Evaluations to the student, if Cours is not empty
			is_evaluated = true;
		}
		public int Matricule
		{
			get { return this._matricule; }
		}
		public double Average()
		{
			double average = 0;
			foreach (Evaluation e in Cours)
			{
				average += e.Note();
			}

			return average / Cours.Count;
		}

		//Student's report is returned based on his info and given Evaluations
		public string Bulletin()
		{
			string bulletin = "Nom du cours" + "\tCode du cours" + "\tNbre ECTS" + "\tCote obtenue\n";
			foreach (Evaluation eval in Cours)
			{
				//More or less tab depending on the length of the name of the activity to align the displayed report
				if (eval.Activity.Name.Length < 10)
				{
					bulletin += eval.Activity.Name + "\t\t" + eval.Activity.Code + "\t\t" + eval.Activity.ECTS + "\t\t" + eval.Note() + "\n";
				}
				else
				{
					bulletin += eval.Activity.Name + "\t" + eval.Activity.Code + "\t\t" + eval.Activity.ECTS + "\t\t" + eval.Note() + "\n";
				}
			}
			bulletin = string.Format("Bulletin de {0} {1} : \n\n{2}\nLa moyenne obtenue est de {3}\n",
									  this._firstname, this._lastname, bulletin, Average());

			return bulletin;
		}

	}
}