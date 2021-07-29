using _06_Repo_Patterns_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _06_Repo_Patterns_Tests
{
	[TestClass]
	public class StreamingContentRepositoryTests
	{

		private StreamingContentRepository _repo;  //intitalizing
		private StreamingContent _content; //initiallizing

		[TestInitialize] //this will run before each test
		public void Arrange()
		{
			_repo = new StreamingContentRepository();  //new instance of field with access to all methods
			_content = new StreamingContent("Rubber", "A car tire comes to life", "R", 5.8, false, GenreType.Drama);  //new object of streaming content

			_repo.AddContentToList(_content);  //added content to repo, now accessable 

		}

		//add method
		[TestMethod]
		public void AddToList_ShouldGetNotNull()
		{

			//AAA paradigm 
			//Arrange --> setting up playing field
			StreamingContent content = new StreamingContent();   //new object to stream
			content.Title = "Toy Story";  //made the title toy story
			StreamingContentRepository repository = new StreamingContentRepository();   //new repo object, blank constructor already exists.
			//^^^ now we have access to the repo methods

			//Act  --> run code we want to test
			repository.AddContentToList(content);   //we added the streaming object to our repo 
			StreamingContent contentFromDirectory = repository.GetContentByTitle("Toy Story");  
			 
			//Assert -->  Use the assert to verify expected outcome
			Assert.IsNotNull(contentFromDirectory);  //if title does not exist in directory and has not been added, test will fail
		}

		//update
		//we dont have to do every single thing to setup every single time
		[TestMethod]
		public void UpdateExistingContent_ShouldReturnTrue()
		{
			// Arrange
			//Test initialize 
			StreamingContent newContent = new StreamingContent("Rubber", "A car tire comes to life", "R", 4.3, false, GenreType.RomCom);

			//act
			bool updateResult = _repo.UpdateExistingContent("Rubber", newContent);

			//Assert
			Assert.IsTrue(updateResult);
		}


		[DataTestMethod]   //tests your data
		[DataRow("Rubber", true)]
		[DataRow("Toy Story", false)]
		public void UpdateExistingContent_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate) //will change title
		{
			// Arrange
			//Test initialize 
			StreamingContent newContent = new StreamingContent("Rubber", "A car tire comes to life", "R", 4.3, false, GenreType.RomCom);

			//act
			bool updateResult = _repo.UpdateExistingContent(originalTitle, newContent);

			//Assert
			Assert.AreEqual(shouldUpdate, updateResult);

		}

		[TestMethod]
		public void DeleteContent_ShouldReturnTrue()
		{
			//arrange
			//test initializer

			//act
			bool deleteResult = _repo.RemoveContentByList(_content.Title); 

			//assert
			Assert.IsTrue(deleteResult);
	}

	}
}
