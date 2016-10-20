using System;
using System.Collections.Generic;

namespace Relations_classes_objets
{
	public class AddEvaluations
	{
		public AddEvaluations()
		{
		}

		public List<Student> Return(System.IO.StreamReader evaluations2, List<int> nameslines, List<Activity> activitieslist,
							  List<Student> studentslist, List<Student> studentnames)
		{
			string line;
			int countline = 0;
			while ((line = evaluations2.ReadLine()) != null)
			{
				//students.Add(line);
				if (countline > nameslines[0])
				{
					for (int i = 0; i < nameslines.Count; i++)
					{
						if (i < (nameslines.Count - 1))
						{
							//on n'ajoute que les cours et pas les noms des eleves
							if (countline > nameslines[i] & countline < nameslines[i + 1])
							{
								string[] evaluation = line.Split(new Char[] { ';' });
								for (int k = 0; k < activitieslist.Count; k++)
								{
									if (activitieslist[k].Code == evaluation[0])
									{
										int value;
										if (int.TryParse(evaluation[1], out value))
										{
											Cote cotestudent = new Cote(activitieslist[k],
																		Convert.ToInt32(evaluation[1]));
											for (int n = 0; n < studentslist.Count; n++)
											{
												if (studentslist[n].Firstname == studentnames[i].Firstname &
													studentslist[n].Lastname == studentnames[i].Lastname)
												{
													studentslist[n].Add(cotestudent);
												}
											}
										}
										else
										{
											Appreciation studentappreciation = new Appreciation(activitieslist[k],
																								evaluation[1]);
											for (int n = 0; n < studentslist.Count; n++)
											{
												if (studentslist[n].Firstname == studentnames[i].Firstname &
													studentslist[n].Lastname == studentnames[i].Lastname)
												{
													studentslist[n].Add(studentappreciation);
												}
											}
										}
									}
								}
							}
						}
						//we just check if we're below a name 'cause it's the last student in the file
						else
						{
							if (countline > nameslines[i])
							{
								string[] evaluation = line.Split(new Char[] { ';' });
								for (int k = 0; k < activitieslist.Count; k++)
								{
									if (activitieslist[k].Code == evaluation[0])
									{
										//check if the Evaluation is an integer to use as a 'Cote'
										int value;
										if (int.TryParse(evaluation[1], out value))
										{
											Cote cotestudent = new Cote(activitieslist[k], Convert.ToInt32(evaluation[1]));

											for (int n = 0; n < studentslist.Count; n++)
											{
												if (studentslist[n].Firstname == studentnames[i].Firstname &
													studentslist[n].Lastname == studentnames[i].Lastname)
												{
													studentslist[n].Add(cotestudent);
												}
											}
										}
										else
										{
											Appreciation studentappreciation = new Appreciation(activitieslist[k],
																								evaluation[1]);

											for (int n = 0; n < studentslist.Count; n++)
											{
												if (studentslist[n].Firstname == studentnames[i].Firstname &
													studentslist[n].Lastname == studentnames[i].Lastname)
												{
													studentslist[n].Add(studentappreciation);
												}
											}

										}
									}
								}
							}
						}
					}
				}
				countline++;
			}

			return studentslist;
		}
		

	}
}
