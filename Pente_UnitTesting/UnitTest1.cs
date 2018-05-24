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
		/// TRIA CHECKS : VERTICAL
		/// </summary>

		[TestMethod] public void CheckTria_Vertical_TopBottom_Empty()
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

			bool actual = ValidityTests.CheckForTriaVertical(current, 3, 1);

			Assert.IsTrue(actual);
        }

        [TestMethod] public void CheckTria_Vertical_Bottom_Empty()
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

            bool actual = ValidityTests.CheckForTriaVertical(current, 6, 1);

            Assert.IsFalse(actual);
        }

        [TestMethod] public void CheckTria_Vertical_Top_Empty()
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

            bool actual = ValidityTests.CheckForTriaVertical(current, 3, 7);

            Assert.IsFalse(actual);
        }

        [TestMethod] public void CheckTria_Vertical_None_Empty()
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

			bool actual = ValidityTests.CheckForTriaVertical(current, 0, 1);

			Assert.IsFalse(actual);
        }

        [TestMethod] public void CheckTria_Vertical_Edgecase_Bottom()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0, 5] = -1;
            current[0, 6] = 1;
            current[0, 7] = 1;
            current[0, 8] = 1;

            bool actual = ValidityTests.CheckForTriaVertical(current, 0, 6);

            Assert.IsFalse(actual);
        }
        
        [TestMethod] public void CheckTria_Vertical_Edgecase_Top()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0, 0] = 1;
            current[0, 1] = 1;
            current[0, 2] = 1;
            current[0, 3] = -1;

            bool actual = ValidityTests.CheckForTriaVertical(current, 0, 0);

            Assert.IsFalse(actual);
        }
        
        /// <summary>
        /// TRIA CHECKS : HORIZONTAL
        /// </summary>

        [TestMethod] public void CheckTria_Horizontal_Left_Empty()
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

			bool actual = ValidityTests.CheckForTriaHorizontal(current, 4, 5);

			Assert.IsFalse(actual);
		}

		[TestMethod] public void CheckTria_Horizontal_Both_Empty()
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

			bool actual = ValidityTests.CheckForTriaHorizontal(current, 4, 4);

			Assert.IsTrue(actual);
		}

		[TestMethod] public void CheckTria_Horizontal_None_Empty()
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

			bool actual = ValidityTests.CheckForTriaHorizontal(current, 4, 5);

			Assert.IsFalse(actual);
		}

		[TestMethod] public void CheckTria_Horizontal_Right_Empty()
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

			bool actual = ValidityTests.CheckForTriaHorizontal(current, 4, 7);

			Assert.IsFalse(actual);
		}

		[TestMethod] public void CheckTria_Horizontal_Edgecase_Left()
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
			current[3, 0] = -1;

			bool actual = ValidityTests.CheckForTriaHorizontal(current, 1, 0);

			Assert.IsFalse(actual);
		}

		[TestMethod] public void CheckTria_Horizontal_Edgecase_Right()
		{
			int[,] current = new int[9, 9];

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					current[i, j] = -1;
				}
			}

			current[5, 3] = 1;
			current[6, 3] = 0;
			current[7, 3] = 0;
			current[8, 3] = 0;

			bool actual = ValidityTests.CheckForTriaHorizontal(current, 7, 3);

			Assert.IsFalse(actual);
		}

        /// <summary>
        /// TRIA CHECKS : DIAGONAL (TOP LEFT)
        /// </summary>

        [TestMethod] public void CheckTria_LeftDiagonal_Left_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[3,3] = -1;
            current[4,4] = 0;
            current[5,5] = 0;
            current[6,6] = 0;
            current[7,7] = 1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 6, 6));
        }

        [TestMethod] public void CheckTria_LeftDiagonal_Right_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[3, 3] = 1;
            current[4, 4] = 0;
            current[5, 5] = 0;
            current[6, 6] = 0;
            current[7, 7] = -1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 6, 6));
        }

        [TestMethod] public void CheckTria_LeftDiagonal_Both_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[3, 3] = -1;
            current[4, 4] = 0;
            current[5, 5] = 0;
            current[6, 6] = 0;
            current[7, 7] = -1;

            Assert.IsTrue(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 6, 6));
        }

        [TestMethod] public void CheckTria_LeftDiagonal_None_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[3, 3] = 1;
            current[4, 4] = 0;
            current[5, 5] = 0;
            current[6, 6] = 0;
            current[7, 7] = 1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 6, 6));
        }

        [TestMethod] public void CheckTria_LeftDiagonal_Edgecase_Top_NotEmpty()
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
            current[3, 3] = 1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 2, 2));
        }

        [TestMethod] public void CheckTria_LeftDiagonal_Edgecase_Top_Empty()
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
            current[3, 3] = -1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 2, 2));
        }

        [TestMethod] public void CheckTria_RightDiagonal_Edgecase_Bottom_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0, 8] = 0;
            current[1, 7] = 0;
            current[2, 6] = 0;
            current[3, 5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 0, 8));
        }

        [TestMethod] public void CheckTria_RightDiagonal_Edgecase_Bottom_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0, 8] = 0;
            current[1, 7] = 0;
            current[2, 6] = 0;
            current[3, 5] = -1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 0, 8));
        }

        /// <summary>
        /// TRIA CHECKS : DIAGONAL (TOP RIGHT)
        /// </summary>

        [TestMethod] public void CheckTria_RightDiagonal_Left_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8, 0] = 1;
            current[7, 1] = 0;
            current[6, 2] = 0;
            current[5, 3] = 0;
            current[4, 4] = -1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 5, 3));
        }

        [TestMethod] public void CheckTria_RightDiagonal_Right_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8, 0] = -1;
            current[7, 1] = 0;
            current[6, 2] = 0;
            current[5, 3] = 0;
            current[4, 4] = 1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 5, 3));
        }

        [TestMethod] public void CheckTria_RightDiagonal_Both_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0, 0] = -1;
            current[1, 1] = 0;
            current[2, 2] = 0;
            current[3, 3] = 0;
            current[4, 4] = -1;

            Assert.IsTrue(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 1, 1));
        }

        [TestMethod] public void CheckTria_RightDiagonal_None_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8, 0] = 1;
            current[7, 1] = 0;
            current[6, 2] = 0;
            current[5, 3] = 0;
            current[4, 4] = 1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 5, 3));
        }

        [TestMethod] public void CheckTria_RightDiagonal_Edgecase_Top_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8, 0] = 0;
            current[7, 1] = 0;
            current[6, 2] = 0;
            current[5, 3] = 1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 8, 0));
        }

        [TestMethod] public void CheckTria_RightDiagonal_Edgecase_Top_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8, 0] = 0;
            current[7, 1] = 0;
            current[6, 2] = 0;
            current[5, 3] = -1;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 8, 0));
        }

        [TestMethod] public void CheckTria_LeftDiagonal_Edgecase_Bottom_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[5, 5] = 1;
            current[6, 6] = 0;
            current[7, 7] = 0;
            current[8, 8] = 0;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 8, 8));
        }

        [TestMethod] public void CheckTria_LeftDiagonal_Edgecase_Bottom_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[6, 6] = -1;
            current[7, 7] = 0;
            current[8, 8] = 0;
            current[8, 8] = 0;

            Assert.IsFalse(ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 8, 8));
        }

        /// <summary>
        /// TESSERA CHECKS : LEFT DIAGONAL
        /// </summary>

        [TestMethod] public void CheckTessera_LeftDiagonal_Edgecase_Top_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,0] = 0;
            current[1,1] = 0;
            current[2,2] = 0;
            current[3,3] = 0;
            current[4,4] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 0, 0));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_LeftDiagonal_Edgecase_Top_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,0] = 0;
            current[1,1] = 0;
            current[2,2] = 0;
            current[3,3] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 0, 0));
        }

        [TestMethod] public void CheckTessera_LeftDiagonal_Edgecase_Bottom_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,8] = 0;
            current[7,7] = 0;
            current[6,6] = 0;
            current[5,5] = 0;
            current[4,4] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 8, 8));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_LeftDiagonal_Edgecase_Bottom_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,8] = 0;
            current[7,7] = 0;
            current[6,6] = 0;
            current[5,5] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 8, 8));
        }

        [TestMethod] public void CheckTessera_LeftDiagonal_Both_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }
            
            current[1,1] = 0;
            current[2,2] = 0;
            current[3,3] = 0;
            current[4,4] = 0;

            Assert.IsTrue(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 1, 1));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_LeftDiagonal_Left_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }
            
            current[1,1] = 0;
            current[2,2] = 0;
            current[3,3] = 0;
            current[4,4] = 0;
            current[5,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 1, 1));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_LeftDiagonal_Right_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,0] = 1;
            current[1,1] = 0;
            current[2,2] = 0;
            current[3,3] = 0;
            current[4,4] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 1, 1));
        }

        [TestMethod] public void CheckTessera_LeftDiagonal_Both_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,0] = 1;
            current[1,1] = 0;
            current[2,2] = 0;
            current[3,3] = 0;
            current[4,4] = 0;
            current[5,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(current, 1, 1));
        }


        /// <summary>
        /// TESSERA CHECKS : RIGHT DIAGONAL
        /// </summary>

        [TestMethod] public void CheckTessera_RightDiagonal_Edgecase_Top_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,0] = 0;
            current[7,1] = 0;
            current[6,2] = 0;
            current[5,3] = 0;
            current[4,4] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 8, 0));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_RightDiagonal_Edgecase_Top_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,0] = 0;
            current[7,1] = 0;
            current[6,2] = 0;
            current[5,3] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 8, 0));
        }

        [TestMethod] public void CheckTessera_RightDiagonal_Edgecase_Bottom_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,8] = 0;
            current[1,7] = 0;
            current[2,6] = 0;
            current[3,5] = 0;
            current[4,4] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 0, 8));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_RightDiagonal_Edgecase_Bottom_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,8] = 0;
            current[1,7] = 0;
            current[2,6] = 0;
            current[3,5] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 0, 8));
        }

        [TestMethod] public void CheckTessera_RightDiagonal_Both_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }
            
            current[8,1] = 0;
            current[7,2] = 0;
            current[6,3] = 0;
            current[5,4] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 8, 1));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_RightDiagonal_Left_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,0] = 1;
            current[7,1] = 0;
            current[6,2] = 0;
            current[5,3] = 0;
            current[4,4] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 7, 1));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_RightDiagonal_Right_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,1] = 0;
            current[7,2] = 0;
            current[6,3] = 0;
            current[5,4] = 0;
            current[4,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 8, 1));
        }

        [TestMethod] public void CheckTessera_RightDiagonal_Both_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,0] = 1;
            current[7,1] = 0;
            current[6,2] = 0;
            current[5,3] = 0;
            current[4,4] = 0;
            current[3,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(current, 8, 1));
        }

        /// <summary>
        /// TESSERA CHECKS : HORIZONTAL
        /// </summary>

        [TestMethod] public void CheckTessera_Horizontal_Edgecase_Left_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,5] = 0;
            current[1,5] = 0;
            current[2,5] = 0;
            current[3,5] = 0;
            current[4,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraHorizontal(current, 0, 5));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Horizontal_Edgecase_Left_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,5] = 0;
            current[1,5] = 0;
            current[2,5] = 0;
            current[3,5] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraHorizontal(current, 3, 5));
        }

        [TestMethod] public void CheckTessera_Horizontal_Edgecase_Right_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,5] = 0;
            current[7,5] = 0;
            current[6,5] = 0;
            current[5,5] = 0;
            current[4,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraHorizontal(current, 8, 5));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Horizontal_Edgecase_Right_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[8,5] = 0;
            current[7,5] = 0;
            current[6,5] = 0;
            current[5,5] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraHorizontal(current, 8, 5));
        }

        [TestMethod] public void CheckTessera_Horizontal_Both_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[1,5] = 0;
            current[2,5] = 0;
            current[3,5] = 0;
            current[4,5] = 0;

            Assert.IsTrue(ValidityTests.CheckForTesseraHorizontal(current, 1, 5));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Horizontal_Left_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[1,5] = 0;
            current[2,5] = 0;
            current[3,5] = 0;
            current[4,5] = 0;
            current[5,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraHorizontal(current, 1, 5));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Horizontal_Right_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,5] = 1;
            current[1,5] = 0;
            current[2,5] = 0;
            current[3,5] = 0;
            current[4,5] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraHorizontal(current, 1, 5));
        }

        [TestMethod] public void CheckTessera_Horizontal_Both_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[0,5] = 1;
            current[1,5] = 0;
            current[2,5] = 0;
            current[3,5] = 0;
            current[4,5] = 0;
            current[5,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraHorizontal(current, 1, 5));
        }

        /// <summary>
        /// TESSERA CHECKS : VERTICAL
        /// </summary>

        [TestMethod] public void CheckTessera_Vertical_TopEdgecase_Bottom_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[5,0] = 0;
            current[5,1] = 0;
            current[5,2] = 0;
            current[5,3] = 0;
            current[5,4] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraVertical(current, 5, 0));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Vertical_TopEdgecase_Bottom_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[5,0] = 0;
            current[5,1] = 0;
            current[5,2] = 0;
            current[5,3] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraVertical(current, 5, 0));
        }

        [TestMethod] public void CheckTessera_Vertical_BottomEdgecase_Top_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }
            
            current[5,4] = 1;
            current[5,5] = 0;
            current[5,6] = 0;
            current[5,7] = 0;
            current[5,8] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraVertical(current, 5, 6));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Vertical_BottomEdgecase_Top_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }
            
            current[5,5] = 0;
            current[5,6] = 0;
            current[5,7] = 0;
            current[5,8] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraVertical(current, 5, 6));
        }

        [TestMethod] public void CheckTessera_Vertical_Both_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }
            
            current[5,1] = 0;
            current[5,2] = 0;
            current[5,3] = 0;
            current[5,4] = 0;

            Assert.IsTrue(ValidityTests.CheckForTesseraVertical(current, 5, 1));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Vertical_Top_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[5,1] = 0;
            current[5,2] = 0;
            current[5,3] = 0;
            current[5,4] = 0;
            current[5,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraVertical(current, 5, 1));
        }

        //Check if this passes with Professor Krebs, or if it is a failing condition
        [TestMethod] public void CheckTessera_Vertical_Bottom_Empty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[5,0] = 1;
            current[5,1] = 0;
            current[5,2] = 0;
            current[5,3] = 0;
            current[5,4] = 0;

            Assert.IsFalse(ValidityTests.CheckForTesseraVertical(current, 5, 1));
        }

        [TestMethod] public void CheckTessera_Vertical_Both_NotEmpty()
        {
            int[,] current = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    current[i, j] = -1;
                }
            }

            current[5,0] = 1;
            current[5,1] = 0;
            current[5,2] = 0;
            current[5,3] = 0;
            current[5,4] = 0;
            current[5,5] = 1;

            Assert.IsFalse(ValidityTests.CheckForTesseraVertical(current, 5, 1));
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

			bool actual = ValidityTests.CheckForTriaTopRightToBottomLeftDiagonal(current, 3, 1);

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

			bool actual = ValidityTests.CheckForTriaTopRightToBottomLeftDiagonal(current, 3, 1);

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

			bool actual = ValidityTests.CheckForTriaTopRightToBottomLeftDiagonal(current, 3, 1);

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

			bool actual = ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 5, 1);

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

			bool actual = ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 5, 5);

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

			bool actual = ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 5, 1);

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

			bool actual = ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 6, 3);

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

			bool actual = ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 7, 5);

			Assert.IsTrue(actual);
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

			bool actual = ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(current, 6, 3);

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

			bool actual = ValidityTests.CheckForTriaTopRightToBottomLeftDiagonal(current, 3, 4);

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

			bool actual = ValidityTests.CheckForTriaTopRightToBottomLeftDiagonal(current, 5, 4);

			Assert.IsTrue(actual);
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

			bool actual = ValidityTests.CheckForTriaTopRightToBottomLeftDiagonal(current, 2, 6);

			Assert.IsFalse(actual);
		}



	}
}
