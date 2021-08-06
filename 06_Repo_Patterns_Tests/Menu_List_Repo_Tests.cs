using KomodoCafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafe_Repo
{
	[TestClass]
	public class Menu_List_Repo_Tests
	{
		private Menu_List_Repo _menu;  //intitalizing
		private MenuItem _item; //initiallizing

		[TestInitialize] //this will run before each test
		public void Arrange()
		{
			_menu = new Menu_List_Repo();  //new instance of field with access to all methods
			_item = new MenuItem("4", "Arepa", "Cooked venezuelan homemade dish", "cooked corn flour, salt, butter", 9.50);  //new object of streaming content

			_menu.AddItemToMenu(_item);  //added item to menu, now accessable 
		}

		//add method
		[TestMethod]
		public void AddToMenu_ShouldGetNotNull()
		{	//AAA paradigm 
			//Arrange --> setting up playing field
			MenuItem item = new MenuItem();   //new object to stream
			item.Number = "5";  //made the number 5
			Menu_List_Repo repository = new Menu_List_Repo();   //new repo object, blank constructor already exists.

			//Act  --> run code we want to test
			repository.AddItemToMenu(item);   //we added the menu item to our repo 
			MenuItem contentFromDirectory = repository.GetItemByNumber("5");  //get the item we just added 
			 
			//Assert -->  Use the assert to verify expected outcome
			Assert.IsNotNull(contentFromDirectory);  //if title does not exist in directory and has not been added, test will fail
		}

		//read
		[TestMethod]
		public void GetMenuItems_ShouldGetNotNull()
		{	//arrange, test initialier
			//returns the item we added to the menu at the "Test Initializer"
		
			//both act and assert nested within another
			Assert.IsNotNull(_menu.GetMenuItems());
		}

		[TestMethod]
		public void RemoveItemFromMenu_ShouldReturnTrue()
		{	//arrange is in the test initializer

			//act
			bool deleteResult = _menu.RemoveItemFromMenu(_item.Number); 

			//assert
			Assert.IsTrue(deleteResult);
		}
	}
}