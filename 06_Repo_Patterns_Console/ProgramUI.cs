using KomodoCafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo
{
	class ProgramUI
	{
		private Menu_List_Repo _menuRepo = new Menu_List_Repo();   //persister, always existing for whole instance of this UI object


		//method that runs/starts the UI part of application
		public void Run() //public so it can be called through class to method
		{
			SeedContentMenu();
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
						//create new items
						CreateNewMenuItem();
						break;
					case "2":
						//view menu of all items
						DisplayMenu();
						break;
					case "3":
						//Delete existing item
						DeleteExistingItem();
						break;
					case "":
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

		//create new menu item
		private void CreateNewMenuItem()
		{
			MenuItem newItem = new MenuItem(); //we declare it first so that we can then use the user's input for properties

			//title
			Console.WriteLine("Enter the number for this item");
			newItem.Number = Console.ReadLine();

			//name
			Console.WriteLine("Enter the name for this item");
			newItem.Name = Console.ReadLine();

			//description
			Console.WriteLine("Enter the description for this item");
			newItem.Description = Console.ReadLine();

			//ingredients
			Console.WriteLine("Enter the ingredients for this item.");
			newItem.Ingredients = Console.ReadLine();

			//price
			Console.WriteLine("What is the price for this item?");
			string inputPrice = Console.ReadLine();  //recieves the price input as a string and saves it into inputPrice
			newItem.Price = double.Parse(inputPrice);  //we parse inputPrice into a double, and assign that value to price

			_menuRepo.AddItemToMenu(newItem);  //adds the new item with it's user-input-defined properties to the menu repo

		}

		//view current menu items that are saved to the whole menu
		private void DisplayMenu()
		{
			Console.Clear(); //clears menu before we see all content

			// we set menuLitOfItems (a list of menuitem objects) equal to the persistant repository _menuRepo,
			// which is equal to out list inside our repository, which has access to crud methods
			List<MenuItem> MenuListofItems = _menuRepo.GetMenuItems();

			foreach (MenuItem item in MenuListofItems)
			{
				Console.WriteLine($"Number: {item.Number}\n" +
					$"Name: { item.Name}\n" +
					$"Description: {item.Description}\n" +
					$"Ingredients: {item.Ingredients}\n" +
					$"Price: {item.Price}\n");
			}
		}

		//delete existing content
		private void DeleteExistingItem()
		{
			DisplayMenu();

			//get the title we want to delete
			Console.WriteLine("\nEnter the number of the item you would like to remove.");

			string inputNumber = Console.ReadLine();

			//call the delete method
			//calls repository method of menu repo and deletes, if it was deleted it returns true, if not then false, so we make it a boolean
			bool wasDeleted = _menuRepo.RemoveItemFromMenu(inputNumber);

			//if the content was deleted, say so
			if (wasDeleted)
			{
				Console.WriteLine("The menu item was successfully deleted");
			}
			else
			{
				Console.WriteLine("Menu item could not be deleted");
			}	//otherwise state it could not be deleted
		}


		//Seed Method  --> will seed the content list so that we can have menu items already on the menu
		private void SeedContentMenu()
		{
			MenuItem avocadoSalad = new MenuItem("1", "Avocado Salad", "Mixed greens, peppers, and avocado", 
				"lettuce, red peppers, yellow peppers, avocado, lemon dressing", 8.50 );
			MenuItem misoSoup = new MenuItem("2", "Miso Soup", "Oriental-style miso soup", "miso, tofu, seaweed, green onions", 6.00);
			MenuItem veggieBurger = new MenuItem("3", "Veggie Burger", "Vegetarian-patty burger", "bread, lettuce, onions, veggie-patty, sauce", 10.50);

			_menuRepo.AddItemToMenu(avocadoSalad);  //we created new menu items and added them to the repo with our repo add methods
			_menuRepo.AddItemToMenu(misoSoup);
			_menuRepo.AddItemToMenu(veggieBurger);
		}
	} //class
} //namespace