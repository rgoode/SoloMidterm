using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello fellow book enthusiast!");
			Console.WriteLine("Enter a book title or author to search for your next read!");
			var userInput = Console.ReadLine();
        }
    }
    public class BookInfo
    {
        public string name;
        public string author;
        
    }
    public class BookClass : BookInfo
    {
        public BookClass(string name, string author)
        {
            this.name = name;
            this.author = author;
        }
        public bool IOnShelf { get; set; } = true;

        public string DueDate { get; set; } = " ";
        public bool IsCheckedIn { get; internal set; }
    }


	public class PullingFromtxt
	{
		public object bookInfo;
		public string authorName;

		public string searchBookNames;

		public string bookTitle;

		public PullingFromtxt()
		{
			string[] BookTxtPull = File.ReadAllLines("../../../BookNames.txt");

			var bookTxtGrouping = BookTxtPull.GroupBy(b => b.Split('|')[1], b => b.Split('|')[0]);



			// lists and splits book title from author
			var bookTxtClasses = new List<BookTxtPull>();
			foreach (var bookinfo in BookTxtPull)
			{
				var splitBookInfo = bookinfo.Split('|');
				var title = splitBookInfo[0];
				var authorName = splitBookInfo[1];
				//DateTime checkOut = DateTime.Parse(splitBookInfo[2]);


			}

			//dictionary to pull from key word?
			Dictionary<string, string> bookInfo = new Dictionary<string, string>();
			var bookInfoDictionary = BookTxtPull.GroupBy(b => b.Split('|')[1], b => b.Split('|')[0]);
			//.ToDictionary(b => b.Key, b => b.Select(a => a));
			var allBookNames = bookInfoDictionary.SelectMany(i => i);
			var keyWordSearch = allBookNames.Where(i => i.Contains(searchBookNames, StringComparison.OrdinalIgnoreCase)).ToList();


			//searching by author
			Console.WriteLine("Enter an Author to search their literature.");
			var author = Console.ReadLine();
			foreach (var authorBook in bookTxtClasses.Where(b => b.Equals(author == authorName)).Select(b => b.bookTitle))
			{
				Console.WriteLine(authorBook);
			}


			//searching title
			Console.WriteLine("Enter a Book title To search options");
			var bTitle = Console.ReadLine();
			foreach (var titleBook in bookTxtClasses.Where(b => b.Equals(bTitle = bookTitle)).Select(b => b.bookTitle))
			{
				Console.WriteLine(titleBook);
			}

		}
	}
		public class SaveBookList
		{
			public SaveBookList()
			{
			}
		}

		internal class BookCheck
		{

			public static string CheckOut(BookClass book)
			{
				string duedate = book.DueDate;
				string checkedOutMessage;
				DateTime today = new DateTime();
				if (book.IsCheckedIn)
				{
					DateTime.Now.ToString();
					book.DueDate = today.AddDays(14).ToString();
					/*using (StreamWriter sw = File.AppendText("../../../BookNames.txt"))
					{
						sw.WriteLine(book.IsCheckedIn);
					}*/
					duedate = book.DueDate.ToString();
					book.IsCheckedIn = false;
					/*using (StreamWriter sw = File.AppendText("../../../BookNames.txt"))
					{
						sw.WriteLine(book.IsCheckedIn);
					}*/
					return duedate;
				}
				else
				{
					checkedOutMessage = $"This Book is checked out. It should be back {book.DueDate.ToString()}.";
					return checkedOutMessage;
				}

			}

			public static string CheckIn(BookClass book)
			{
				string duedate = book.DueDate;
				DateTime today = new DateTime();
				if (book.IsCheckedIn)
				{

					return "This book is already checked in.";
				}
				else if (!book.IsCheckedIn)
				{

					book.IsCheckedIn = true;
				}

				return "Book Checked in.";
			}
		}
		public class BookReturn
		{
        private bool userTurnIn;

        public BookReturn()
			{
				if (userTurnIn == true)
				{
					Console.WriteLine("Thank you! Feel free to browse for your next read!");
				}
				else
				{
					Console.WriteLine("Dont miss your due date!");

				}

			}			
		}












		public class AuthorTxtPull
		{
			public AuthorTxtPull(string authorName)
			{
				Author = authorName;
			}
			public string Author { get; } = string.Empty;

		}

		public class BookTxtPull
		{
			internal object bookTitle;
			internal object authorName;

			public BookTxtPull(string bookTitle)
			{
				Title = bookTitle;
			}
			public string Title { get; set; } = string.Empty;

			public IEnumerable<string> BookTitles { get; set; } = new List<string>();
		}

}
