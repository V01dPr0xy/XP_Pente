using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pente_UnitTests
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

            bool actual = ValidityTests.CheckForWin(board_actual, 5, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
