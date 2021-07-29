using _06_Repo_Patterns_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Repo_Patterns_Console
{
	class ProgramUI
	{
		private Menu_List_Repo _contentRepo = new Menu_List_Repo();   //persister, always existing for whole instance of this UI object


		//method that runs/starts the UI part of application
		public void Run() //public so it can be called through class to method
		{
			Menu();
		}

		//menu  ---we want these private
		private void Menu()
		{
			bool keepRunning = true;
			while (keepRunning)
			{
				//1. display options to the user
				//building a UI menu that matches each of our add/view-all/delete prompts
				Console.WriteLine("What Would You Like To Do?\n" +
					"1. Create a new menu item \n" +
					"2. View All Menu Items \n" +
					"3. Delete Existing Content \n" +
					"4. Exit");

				//2. get the user's input
				string mainMenuInput = Console.ReadLine();

				//3. evaluate user's input and act accordingly
				switch (mainMenuInput)
				{
					case "1":
						//create new content
						CreateNewContent();
						break;
					case "2":
						//view all content
						DisplayAllContent();
						break;
					case "3":
						//view content by title
						DisplayContentByTitle();
						break;
					case "4":
						//Update existing content
						UpdateExistingContent();
						break;
					case "5":
						//Delete existing content
						DeleteExistingContent();
						break;
					case "6":
						// exit
						Console.WriteLine("Goodbye");
						keepRunning = false; //breaks the while loop and exits the application
						break;
					default:
						Console.WriteLine("Please enter a valid number");
						break;
				}
				Console.WriteLine("Please press any key to continue...");
				Console.ReadLine();
				Console.Clear();
			}
		}



		//methods that we want to do something but not return anything from this method to menu (void)
		//private so that they can be used inside this class by another method but not from outside this class
		//create new streaming content
		private void CreateNewContent()
		{
			StreamingContent newContent = new StreamingContent(); //we declare it first so that we can then use the property of object for user input
			
			//title
			Console.WriteLine("Enter the title for the content");
			newContent.Title = Console.ReadLine();

			//description
			Console.WriteLine("Enter the description for the content");
			newContent.Description = Console.ReadLine();

			//maturity rating
			Console.WriteLine("Enter the maturity rating for the content: (G, PG, PG-13, etc");
			newContent.MaturityRating = Console.ReadLine();

			//star rating
			Console.WriteLine("Enter the star rating for the content: (5.8, 10, 1.5, etc)");
			string starsAsString = Console.ReadLine();
			newContent.StarRating = double.Parse(starsAsString); 

			//is familly friendly\
			Console.WriteLine("Is this content family friendly?  (y/n)");
			string familyFriendlyString = Console.ReadLine().ToLower();

			if (familyFriendlyString == "y")
			{
				newContent.IsFamilyFriendly = true;
			}
			else
			{
				newContent.IsFamilyFriendly = false;
			}

			//genretype
			Console.WriteLine("Enter the genre number: \n +" +
				"1. Horror\n +" +
				"2. RomCom\n +" +
				"3. SciFi\n +" +
				"4. Documentary\n +" +
				"5. Drama\n +" +
				"6. Action");

			string genreAsString = Console.ReadLine();
			int genreAsInt = int.Parse(genreAsString);
			newContent.TypeOfGenre = (GenreType)genreAsInt;    //casting integer into enum by the enum's numerical value

			_contentRepo.AddContentToList(newContent);
		
		}

		//view current StreamingContent that is saved
		private void DisplayAllContent()
		{ 
		}

		//view existing content by title
		private void DisplayContentByTitle()
		{ 
		}

		//update existing content

		private void UpdateExistingContent()
		{ 
		}

		//delete existing content
		private void DeleteExistingContent()
		{ 
		}

	} //class
} //namespace