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
		{

			//AAA paradigm 
			//Arrange --> setting up playing field
			MenuItem item = new MenuItem();   //new object to stream
			item.Number = "5";  //made the number 5
			Menu_List_Repo repository = new Menu_List_Repo();   //new repo object, blank constructor already exists.
			//^^^ now we have access to the repo methods

			//Act  --> run code we want to test
			repository.AddItemToMenu(item);   //we added the streaming object to our repo 
			MenuItem contentFromDirectory = repository.GetItemByNumber("5");  
			 
			//Assert -->  Use the assert to verify expected outcome
			Assert.IsNotNull(contentFromDirectory);  //if title does not exist in directory and has not been added, test will fail
		}

		//update
		//we dont have to do every single thing to setup every single time
		//[testmethod]
		//public void updateexistingcontent_shouldreturntrue()
		//{
		//	arrange
		//   test initialize
		//   streamingcontent newcontent = new streamingcontent("rubber", "a car tire comes to life", "r", 4.3, false, genretype.romcom);

		//	act
		//	bool updateresult = _repo.updateexistingcontent("rubber", newcontent);

		//	assert
		//	assert.istrue(updateresult);
		//}


		//[DataTestMethod]   //tests your data
		//[DataRow("Rubber", true)]
		//[DataRow("Toy Story", false)]
		//public void UpdateExistingContent_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate) //will change title
		//{
		//	// Arrange
		//	//Test initialize 
		//	StreamingContent newContent = new StreamingContent("Rubber", "A car tire comes to life", "R", 4.3, false, GenreType.RomCom);

		//	//act
		//	bool updateResult = _repo.UpdateExistingContent(originalTitle, newContent);

		//	//Assert
		//	Assert.AreEqual(shouldUpdate, updateResult);

		//}
		[TestMethod]
		public void 


		[TestMethod]
		public void RemoveItemFromMenu_ShouldReturnTrue()
		{
			//arrange
			//test initializer

			//act
			bool deleteResult = _menu.RemoveItemFromMenu(_item.Number); 

			//assert
			Assert.IsTrue(deleteResult);
	}

	}
}
