using System;
using System.Collections.Generic;

namespace EvaluationSystem
{
	public class Book
	{
		private string _bookname;
		private int _bookprice;
		public Book(string Bookname, int Bookprice)
		{
			this._bookname = Bookname;
			this._bookprice = Bookprice;
		}

		public string Name
		{
			get { return this._bookname; }
		}

		public int Price
		{
			get { return this._bookprice; }
		}
	}
}