using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnityTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public IEnumerator WinRow()
		{
			// Use the Assert class to test conditions.
			// yield to skip a frame
			int[,] current = new int[9, 9];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}
			current[0, 0] = 1;
			current[1, 0] = 1;
			current[2, 0] = 1;
			current[3, 0] = 1;
			current[4, 0] = 1;
			bool actual = ValidityTests.CheckForWin(current, 0, 0);
			Assert.IsTrue(actual);
			//Assert.Fail();
			//return null;

		}
	}
}
