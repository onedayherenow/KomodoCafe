using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoCafe_Repo;

namespace KomodoCafe_Repo
{
	
	//POCO -- Plaing old Csharp object
	//Simple object that holds data
	public class MenuItem
	{
		//properties
		public string Number { get; set }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Ingredients { get; set; }
		public double Price { get; set; }


		//constructors

		public MenuItem() {}
		
		//cant go out using title, can only go in,, scope
		public MenuItem(string number, string name, string description, string ingredients, double price)
		{
			Number = number;
			Name = description;
			Description = description;
			Ingredients = ingredients;
			Price = price; 
		}

	
	}
}
