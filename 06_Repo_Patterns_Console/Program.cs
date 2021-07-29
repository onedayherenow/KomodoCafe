using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Repo_Patterns_Console
{
	class Program
	{
		static void Main(string[] args)  //main is first thing to fire off, single responsibility to run UI
		{
			ProgramUI program = new ProgramUI();
			program.Run();
		}		
	}
}
