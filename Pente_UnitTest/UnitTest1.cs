using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pente_UnitTest
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WinColumn_True()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            bool expected = true;
            int[,] board_actual = new int[9, 9];
            for (int i = 0; i < 9; i++) for (int j = 0; j < 9; j++) board_actual[i, j] = -1;

            board_actual[5, 3] = 1;
            board_actual[5, 4] = 1;
            board_actual[5, 5] = 1;
            board_actual[5, 6] = 1;
            board_actual[5, 7] = 1;

            bool actual = ValidityTests.CheckForWin(board_actual, 5, 7);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WinRow_True()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            bool expected = true;
            int[,] board_actual = new int[9, 9];
            for (int i = 0; i < 9; i++) for (int j = 0; j < 9; j++) board_actual[i, j] = -1;

            board_actual[3, 5] = 1;
            board_actual[4, 5] = 1;
            board_actual[5, 5] = 1;
            board_actual[6, 5] = 1;
            board_actual[7, 5] = 1;

            bool actual = ValidityTests.CheckForWin(board_actual, 7, 5);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WinDiagonalLeft_True()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            bool expected = true;
            int[,] board_actual = new int[9, 9];
            for (int i = 0; i < 9; i++) for (int j = 0; j < 9; j++) board_actual[i, j] = -1;

            board_actual[3, 3] = 1;
            board_actual[4, 4] = 1;
            board_actual[5, 5] = 1;
            board_actual[6, 6] = 1;
            board_actual[7, 7] = 1;

            bool actual = ValidityTests.CheckForWin(board_actual, 7, 7);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WinDiagonalRight_True()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            bool expected = true;
            int[,] board_actual = new int[9, 9];
            for (int i = 0; i < 9; i++) for (int j = 0; j < 9; j++) board_actual[i, j] = -1;

            board_actual[3, 7] = 1;
            board_actual[4, 6] = 1;
            board_actual[5, 5] = 1;
            board_actual[6, 4] = 1;
            board_actual[7, 3] = 1;

            bool actual = ValidityTests.CheckForWin(board_actual, 7, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
