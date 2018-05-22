using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void CheckWinRow()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 0] = 0;
			current[1, 0] = 0;
			current[2, 0] = 0;
			current[3, 0] = 0;
			current[4, 0] = 0;

			bool actual = ValidityTests.CheckForWin(current, 0, 0);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckWinRowTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 4] = 1;
			current[4, 4] = 1;
			current[5, 4] = 1;
			current[6, 4] = 1;
			current[7, 4] = 1;

			bool actual = ValidityTests.CheckForWin(current, 3, 4);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckWinRowFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 0] = 0;
			current[1, 0] = 0;
			current[2, 0] = 0;
			current[3, 0] = 0;
			current[4, 0] = 1;

			bool actual = ValidityTests.CheckForWin(current, 0, 0);

			Assert.IsFalse(actual);

		}

		[TestMethod]
		public void CheckWinCol()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 0] = 0;
			current[0, 1] = 0;
			current[0, 2] = 0;
			current[0, 3] = 0;
			current[0, 4] = 0;

			bool actual = ValidityTests.CheckForWin(current, 0, 0);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckWinColTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 2] = 2;
			current[6, 3] = 2;
			current[6, 4] = 2;
			current[6, 5] = 2;
			current[6, 6] = 2;

			bool actual = ValidityTests.CheckForWin(current, 6, 4);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckWinColFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 0] = 0;
			current[0, 1] = 0;
			current[0, 2] = 0;
			current[0, 3] = 0;
			current[0, 4] = 1;

			bool actual = ValidityTests.CheckForWin(current, 0, 0);

			Assert.IsFalse(actual);

		}

		[TestMethod]
		public void CheckTopRightDiagonalWin()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 0] = 0;
			current[1, 1] = 0;
			current[2, 2] = 0;
			current[3, 3] = 0;
			current[4, 4] = 0;

			bool actual = ValidityTests.CheckForWin(current, 0, 0);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckTopRightDiagonalWinTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 2] = 1;
			current[4, 3] = 1;
			current[5, 4] = 1;
			current[6, 5] = 1;
			current[7, 6] = 1;

			bool actual = ValidityTests.CheckForWin(current, 6, 5);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckTopRightDiagonalFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 0] = 0;
			current[1, 1] = 0;
			current[2, 2] = 0;
			current[3, 3] = 0;
			current[4, 4] = 1;

			bool actual = ValidityTests.CheckForWin(current, 0, 0);

			Assert.IsFalse(actual);

		}

		[TestMethod]
		public void CheckTopLeftDiagonalWin()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 4] = 0;
			current[1, 3] = 0;
			current[2, 2] = 0;
			current[3, 1] = 0;
			current[4, 0] = 0;

			bool actual = ValidityTests.CheckForWin(current, 0, 4);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckTopLeftDiagonalWinTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[8, 3] = 0;
			current[7, 4] = 0;
			current[6, 5] = 0;
			current[5, 6] = 0;
			current[4, 7] = 0;

			bool actual = ValidityTests.CheckForWin(current, 7, 4);

			Assert.IsTrue(actual);

		}

		[TestMethod]
		public void CheckTopLeftDiagonalFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 4] = 0;
			current[1, 3] = 0;
			current[2, 2] = 0;
			current[3, 1] = 0;
			current[4, 0] = 1;

			bool actual = ValidityTests.CheckForWin(current, 0, 4);

			Assert.IsFalse(actual);

		}

		[TestMethod]
		public void CheckCaptureTop()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 4] = 0;
			current[6, 3] = 1;
			current[6, 2] = 1;
			current[6, 1] = 0;

			bool actual = ValidityTests.CheckForCaptureTop(current, 6, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureTopFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 4] = 0;
			current[6, 3] = 1;
			current[6, 2] = 1;
			current[6, 1] = 1;

			bool actual = ValidityTests.CheckForCaptureTop(current, 6, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureBottom()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 8] = 0;
			current[3, 7] = 1;
			current[3, 6] = 1;
			current[3, 5] = 0;

			bool actual = ValidityTests.CheckForCaptureBottom(current, 3, 8);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureBottomFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 8] = 1;
			current[3, 7] = 1;
			current[3, 6] = 1;
			current[3, 5] = 0;

			bool actual = ValidityTests.CheckForCaptureBottom(current, 3, 8);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureLeft()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[2, 2] = 0;
			current[4, 2] = 1;
			current[5, 2] = 1;
			current[6, 2] = 0;

			bool actual = ValidityTests.CheckForCaptureLeft(current, 2, 2);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureLeftFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[1, 4] = 0;
			current[2, 4] = 1;
			current[3, 4] = 1;
			current[4, 4] = 1;

			bool actual = ValidityTests.CheckForCaptureLeft(current, 1, 4);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureRight()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[1, 4] = 0;
			current[2, 4] = 1;
			current[3, 4] = 1;
			current[4, 4] = 0;

			bool actual = ValidityTests.CheckForCaptureRight(current, 4, 4);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureRightFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[1, 0] = 1;
			current[2, 0] = 1;
			current[3, 0] = 1;
			current[4, 0] = 0;

			bool actual = ValidityTests.CheckForCaptureRight(current, 4, 0);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureTopLeft()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 4] = 0;
			current[5, 3] = 1;
			current[4, 2] = 1;
			current[3, 1] = 0;

			bool actual = ValidityTests.CheckForCaptureTopLeft(current, 3, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureTopLeftFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[5, 4] = 1;
			current[4, 3] = 1;
			current[3, 2] = 1;
			current[2, 1] = 0;

			bool actual = ValidityTests.CheckForCaptureTopLeft(current, 2, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureTopRight()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 3] = 0;
			current[4, 2] = 2;
			current[5, 1] = 2;
			current[6, 0] = 0;

			bool actual = ValidityTests.CheckForCaptureTopRight(current, 6, 0);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureTopRightFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 6] = 0;
			current[1, 5] = 1;
			current[2, 4] = 1;
			current[3, 3] = 1;

			bool actual = ValidityTests.CheckForCaptureTopRight(current, 3, 3);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureBottomRight()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 0] = 0;
			current[4, 1] = 2;
			current[5, 2] = 2;
			current[6, 3] = 0;

			bool actual = ValidityTests.CheckForCaptureBottomRight(current, 6, 3);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureBottomRightFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[0, 0] = 0;
			current[1, 1] = 2;
			current[2, 2] = 2;
			current[3, 3] = 2;

			bool actual = ValidityTests.CheckForCaptureBottomRight(current, 3, 3);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureBottomLeft()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 1] = 0;
			current[5, 2] = 1;
			current[4, 3] = 1;
			current[3, 4] = 0;

			bool actual = ValidityTests.CheckForCaptureBottomLeft(current, 3, 4);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckCaptureBottomLeftFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 1] = 0;
			current[5, 2] = 1;
			current[4, 3] = 1;
			current[3, 4] = 1;

			bool actual = ValidityTests.CheckForCaptureBottomLeft(current, 3, 4);

			Assert.IsFalse(actual);
		}
	}
}
