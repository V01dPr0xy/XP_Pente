using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{

		/// <summary>
		/// WIN CHECKS
		/// </summary>

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

		/// <summary>
		/// TRIA CHECKS
		/// </summary>

		[TestMethod]
		public void CheckTriaTop()
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
			current[6, 0] = -1;

			bool actual = ValidityTests.CheckTriaTop(current, 6, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 4] = -1;
			current[3, 3] = 1;
			current[3, 2] = 1;
			current[3, 1] = 1;
			current[3, 0] = -1;

			bool actual = ValidityTests.CheckTriaTop(current, 3, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopFail()
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
			current[0, 3] = 1;
			current[0, 2] = 1;
			current[0, 1] = 1;
			current[0, 0] = 0;

			bool actual = ValidityTests.CheckTriaTop(current, 0, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottom()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 8] = -1;
			current[3, 7] = 1;
			current[3, 6] = 1;
			current[3, 5] = 1;
			current[3, 4] = 2;

			bool actual = ValidityTests.CheckTriaBottom(current, 3, 7);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[1, 8] = -1;
			current[1, 7] = 1;
			current[1, 6] = 1;
			current[1, 5] = 1;
			current[1, 4] = -1;

			bool actual = ValidityTests.CheckTriaBottom(current, 1, 7);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 8] = 2;
			current[3, 7] = 1;
			current[3, 6] = 1;
			current[3, 5] = 1;
			current[3, 4] = 2;

			bool actual = ValidityTests.CheckTriaBottom(current, 3, 7);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaLeft()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 5] = -1;
			current[4, 5] = 1;
			current[5, 5] = 1;
			current[6, 5] = 1;
			current[7, 5] = 0;

			bool actual = ValidityTests.CheckTriaLeft(current, 4, 5);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaLeftTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 4] = -1;
			current[4, 4] = 1;
			current[5, 4] = 1;
			current[6, 4] = 1;
			current[7, 4] = -1;

			bool actual = ValidityTests.CheckTriaLeft(current, 4, 4);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaLeftFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[3, 5] = 0;
			current[4, 5] = 1;
			current[5, 5] = 1;
			current[6, 5] = 1;
			current[7, 5] = 0;

			bool actual = ValidityTests.CheckTriaLeft(current, 4, 5);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaRight()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[1, 7] = 1;
			current[2, 7] = 0;
			current[3, 7] = 0;
			current[4, 7] = 0;
			current[5, 7] = -1;

			bool actual = ValidityTests.CheckTriaRight(current, 4, 7);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaRightTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[1, 0] = -1;
			current[2, 0] = 0;
			current[3, 0] = 0;
			current[4, 0] = 0;
			current[5, 0] = -1;

			bool actual = ValidityTests.CheckTriaRight(current, 4, 0);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaRightFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[4, 3] = 1;
			current[5, 3] = 0;
			current[6, 3] = 0;
			current[7, 3] = 0;
			current[8, 3] = 1;

			bool actual = ValidityTests.CheckTriaRight(current, 7, 3);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopLeft()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 4] = 1;
			current[5, 3] = 0;
			current[4, 2] = 0;
			current[3, 1] = 0;
			current[2, 0] = -1;

			bool actual = ValidityTests.CheckTriaTopLeft(current, 3, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopLeftTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[5, 4] = -1;
			current[4, 3] = 0;
			current[3, 2] = 0;
			current[2, 1] = 0;
			current[1, 0] = -1;

			bool actual = ValidityTests.CheckTriaTopLeft(current, 3, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopLeftFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[6, 4] = 1;
			current[5, 3] = 0;
			current[4, 2] = 0;
			current[3, 1] = 0;
			current[2, 0] = 1;

			bool actual = ValidityTests.CheckTriaTopLeft(current, 3, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopRight()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[2, 4] = 0;
			current[3, 3] = 2;
			current[4, 2] = 2;
			current[5, 1] = 2;
			current[6, 0] = -1;

			bool actual = ValidityTests.CheckTriaTopRight(current, 5, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopRightTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[2, 8] = -1;
			current[3, 7] = 2;
			current[4, 6] = 2;
			current[5, 5] = 2;
			current[6, 4] = -1;

			bool actual = ValidityTests.CheckTriaTopRight(current, 5, 5);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaTopRightFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[2, 4] = 0;
			current[3, 3] = 2;
			current[4, 2] = 2;
			current[5, 1] = 2;
			current[6, 0] = 0;

			bool actual = ValidityTests.CheckTriaTopRight(current, 5, 1);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomRight()
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
			current[4, 1] = 1;
			current[5, 2] = 1;
			current[6, 3] = 1;
			current[7, 4] = -1;

			bool actual = ValidityTests.CheckTriaBottomRight(current, 6, 3);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomRightTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[4, 2] = -1;
			current[5, 3] = 1;
			current[6, 4] = 1;
			current[7, 5] = 1;
			current[8, 6] = -1;

			bool actual = ValidityTests.CheckTriaBottomRight(current, 7, 5);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomRightFail()
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
			current[4, 1] = 1;
			current[5, 2] = 1;
			current[6, 3] = 1;
			current[7, 4] = 0;

			bool actual = ValidityTests.CheckTriaBottomRight(current, 6, 3);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomLeft()
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
			current[2, 5] = -1;

			bool actual = ValidityTests.CheckTriaBottomLeft(current, 3, 4);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomLeftTwo()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[8, 1] = -1;
			current[7, 2] = 1;
			current[6, 3] = 1;
			current[5, 4] = 1;
			current[4, 5] = -1;

			bool actual = ValidityTests.CheckTriaBottomLeft(current, 5, 4);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void CheckTriaBottomLeftFail()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[5, 3] = 0;
			current[4, 4] = 1;
			current[3, 5] = 1;
			current[2, 6] = 1;
			current[1, 7] = 0;

			bool actual = ValidityTests.CheckTriaBottomLeft(current, 2, 6);

			Assert.IsFalse(actual);
		}
	}
}
