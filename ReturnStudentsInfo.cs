using System;
using System.Collections.Generic;
namespace EvaluationSystem
{
	public class ReturnStudentsInfo
	{


		private List<Student> _studentslist;
		private List<Teacher> _teacherslist;
		private List<Activity> _activitieslist;
		private string _input;
		public ReturnStudentsInfo(List<Student> Studentslist, List<Teacher> Teacherslist, List<Activity> Activitieslist, string input)
		{
			this._studentslist = Studentslist;
			this._teacherslist = Teacherslist;
			this._activitieslist = Activitieslist;
			this._input = input;
		}

		public override string ToString()
		{
			string displaystudent = "";

		
				foreach (Student student in this._studentslist)
				{
					//Test if already have given evaluations to the student in the list
					if (student.is_evaluated == false)
					{
						if (student.Matricule.ToString() == this._input)
						{

							string line;
							System.IO.StreamReader evaluations = new System.IO.StreamReader("Evaluations.txt");
							while ((line = evaluations.ReadLine()) != null)
							{
								string[] evaluation = line.Split(new Char[] { ';' });
								if (evaluation[2] == student.Matricule.ToString())
								{

									if (this._activitieslist.Count == 0)
									{
										ReturnActivities result = new ReturnActivities(this._teacherslist);
										this._activitieslist = result.List();
									}


									foreach (Activity eachactivity in this._activitieslist)
									{
										if (eachactivity.Code == evaluation[0])
										{
											int value;
											if (int.TryParse(evaluation[1], out value))
											{
												Cote cotestudent = new Cote(eachactivity,
																			Convert.ToInt32(evaluation[1]));
												student.Add(cotestudent);
											}
											else
											{
												Appreciation studentappreciation = new Appreciation(eachactivity,
																									evaluation[1]);
												student.Add(studentappreciation);
											}
										}
									}
								}
							}
							displaystudent = student.Bulletin();
						}
					}
					else
					{
							if (student.Matricule.ToString() == this._input)
							{
								displaystudent += student.Bulletin();
							}
					}
				}


			return displaystudent;

		}
	}
}
