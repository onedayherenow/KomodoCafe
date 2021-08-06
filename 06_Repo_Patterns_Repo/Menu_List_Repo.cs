using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoCafe_Repo;

namespace KomodoCafe_Repo
{
	public class Menu_List_Repo
	{
		private readonly List<MenuItem> _menuList = new List<MenuItem>();   //field made up of the streamingcontent class, not repos
		//field usables in all crud methods, they can all use the same list in all methods, persisting object
		//the methods need to be used outside, public

		//create
		public void AddItemToMenu(MenuItem item) //add streaming content to list, building entryways into our class
		{
			_menuList.Add(item);  //anything with an underscore and camelcase is a field
		}

		//read
		public List<MenuItem> GetMenuItems()   //returns whole list of menu items, return type is list of MenuItem objects
		{
			return _menuList;   
		}

		//delete
		public bool RemoveItemFromMenu(string number)
		{
			MenuItem item = GetItemByNumber(number);   
			if (item == null)   //check this first, if item does't exist
			{
				return false;
			}
			int initialCount = _menuList.Count;  //count is a property of the list that will get us the number of elements in a list
			_menuList.Remove(item); //remove it
			
			//check if it was removed
			if (initialCount > _menuList.Count)  //if the initial count is greater than the current count, then we did remove is
			{
				return true;
			}
			else
			{
				return false;  //if item was not removed
			}
		}


		//helper method 
		public MenuItem GetItemByNumber(string number)   //returns an object MenuItem of the list, .GetItemByNumber()
		{
			foreach (MenuItem item in _menuList)  //iterates through each item in the menu
			{
				if (item.Number == number)   //if the number is found, we return the item
				{
					return item; 
				}
			}
			return null; //if we find it we return, if not return null
		}
	}
}
