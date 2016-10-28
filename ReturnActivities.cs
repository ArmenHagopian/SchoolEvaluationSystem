using System;
using System.Collections.Generic;
namespace EvaluationSystem
{
	public class ReturnActivities
	{
		private List<Teacher> _teacherslist;
		private List<Activity> activitieslist = new List<Activity>();
		public ReturnActivities(List<Teacher> Teacherslist)
		{
			this._teacherslist = Teacherslist;
		}
		public List<Activity> List()
		{
			string line;
			//If the teacherlist is empty, we read the file with the teacher data until there isn't any line left.
			//Then the object teacher is added to a Teacher list.
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
			System.IO.StreamReader allactivities = new System.IO.StreamReader("Activities.txt");
			System.IO.StreamReader allbooks = new System.IO.StreamReader("Books.txt");
			//For every Teacher, the corresponding activity is added in a list.
			if (activitieslist.Count == 0)
			{
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
							activitieslist.Add(activity);
						}
					}
				}
				//The object book corresponding to an Activity is added in a list.
				while ((line = allbooks.ReadLine()) != null)
				{
					foreach (Activity eachactivity in activitieslist)
					{
						string[] splitbooks = line.Split(new Char[] { ';' });
						if (splitbooks[2] == eachactivity.Code)
						{
							Book book = new Book(splitbooks[0], Convert.ToInt32(splitbooks[1]));
							eachactivity.AddBook(book);
						}
					}
				}
			}
			return activitieslist;
		}
	}
}
