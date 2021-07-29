using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_Types
{
	[TestClass]
	public class TypeExamples
	{
		[TestMethod]
		public void ValueTypes()
		{
			//-- whole numbers
			byte oneBytesWorth;
			oneBytesWorth = 255;

			short smallWholeNumber = 16;
			int wholeNumber = 32;
			long largeWholeNumber = 64;

			//-- decimals
			float floatExample = 1.234567f;
			double doubleExample = 1.237909d;
			decimal decimalExample = 1.7000m;

			char letter = 'j';


		}
	}
}
