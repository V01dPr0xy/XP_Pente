using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class ValidityTests {
        public static bool CheckForWin(int[,] currentState, int x, int y) {

            int player = currentState[x, y];

            int top = 0;
            bool continueTop = true;
            int bottom = 0;
            bool continueBottom = true;
            int left = 0;
            bool continueLeft = true;
            int right = 0;
            bool continueRight = true;


            int topLeft = 0;
            bool continueTopLeft = true;
            int topRight = 0;
            bool continueTopRight = true;
            int bottomLeft = 0;
            bool continueBottomLeft = true;
            int bottomRight = 0;
            bool continueBottomRight = true;

            int length = (int)Math.Sqrt(currentState.Length);

            for (int i = 1; i < 5; i++) {
                //Right
                if (x - i >= 0 && continueRight) {
                    if (currentState[x - i, y] == player) right++;
                    else continueRight = false;
                }
                //Left
                if (x + i < length && continueLeft) {
                    if (currentState[x + i, y] == player) left++;
                    else continueLeft = false;
                }
                if (left + right + 1 >= 5) return true;
                //Top
                if (y - i >= 0 && continueTop) {
                    if (currentState[x, y - i] == player) top++;
                    else continueTop = false;
                }
                //Bottom
                if (y + i < length && continueBottom) {
                    if (currentState[x, y + i] == player) bottom++;
                    else continueBottom = false;
                }
                if (top + bottom + 1 >= 5) return true;

                //Diagonals
                //Top Right
                if (x + i < length && y - i >= 0 && continueTopRight) {
                    if (currentState[x + i, y - i] == player) topRight++;
                    else continueTopRight = false;
                }
                //Bottom Left
                if (x - i >= 0 && y + i < length && continueBottomLeft) {
                    if (currentState[x - i, y + i] == player) bottomLeft++;
                    else continueBottomLeft = false;
                }
                if (topRight + bottomLeft + 1 >= 5) return true;

                //Top Left
                if (x - i >= 0 && y - i >= 0 && continueTopLeft) {
                    if (currentState[x - i, y - i] == player) top++;
                    else continueTop = false;
                }
                //Bottom Right
                if (x + i < length && y + i < length && continueBottomRight) {
                    if (currentState[x + i, y + i] == player) bottom++;
                    else continueBottom = false;
                }
                if (topLeft + bottomRight + 1 >= 5) return true;

            }

            return false;
        }

    }

