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
                if (currentState[x, y - i] == player) {
                    top++;
                } else { continueTop = false; }
            }
            //Bottom
            if (y + i < length && continueBottom) {
                if (currentState[x, y + i] == player) {
                    bottom++;
                } else {
                    continueBottom = false;
                }
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
                if (currentState[x - i, y - i] == player) topLeft++;
                else continueTopLeft = false;
            }
            //Bottom Right
            if (x + i < length && y + i < length && continueBottomRight) {
                if (currentState[x + i, y + i] == player) bottomRight++;
                else continueBottomRight = false;
            }
            if (topLeft + bottomRight + 1 >= 5) return true;

        }

        return false;
    }

    public static bool CheckForCaptureTop(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        if (y == 0) return false;
        if (y - 1 == 0) return false;
        if (y - 2 == 0) return false;
        if (y - 3 == 0) return false;
        if (!(currentState[x, y - 1] != player && currentState[x, y - 1] != -1)) return false;
        if (!(currentState[x, y - 2] != player && currentState[x, y - 2] != -1)) return false;
        if (currentState[x, y - 3] == player) return true;
        return false;
    }
    public static bool CheckForCaptureBottom(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        int length = (int)Math.Sqrt(currentState.Length);
        if (y == length) return false;
        if (y + 1 == length) return false;
        if (y + 2 == length) return false;
        if (y + 3 == length) return false;
        if (!(currentState[x, y + 1] != player && currentState[x, y + 1] != -1)) return false;
        if (!(currentState[x, y + 2] != player && currentState[x, y + 2] != -1)) return false;
        if (currentState[x, y + 3] == player) return true;
        return false;
    }
    public static bool CheckForCaptureLeft(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        if (x == 0) return false;
        if (x - 1 == 0) return false;
        if (x - 2 == 0) return false;
        if (x - 3 == 0) return false;
        if (!(currentState[x - 1, y] != player && currentState[x - 1, y] != -1)) return false;
        if (!(currentState[x - 2, y] != player && currentState[x - 2, y] != -1)) return false;
        if (currentState[x - 3, y] == player) return true;
        return false;
    }
    public static bool CheckForCaptureRight(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        int length = (int)Math.Sqrt(currentState.Length);
        if (x == length) return false;
        if (x + 1 == length) return false;
        if (x + 2 == length) return false;
        if (x + 3 == length) return false;
        if (!(currentState[x + 1, y] != player && currentState[x + 1, y] != -1)) return false;
        if (!(currentState[x + 2, y] != player && currentState[x + 2, y] != -1)) return false;
        if (currentState[x + 3, y] == player) return true;
        return false;
    }
    public static bool CheckForCaptureTopLeft(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        int length = (int)Math.Sqrt(currentState.Length);
        if (x == 0 || y == 0) return false;
        if (x - 1 == 0 || y - 1 == 0) return false;
        if (x - 2 == 0 || y - 2 == 0) return false;
        if (x - 3 == 0 || y - 3 == 0) return false;
        if (!(currentState[x - 1, y - 1] != player && currentState[x - 1, y - 1] != -1)) return false;
        if (!(currentState[x - 2, y - 2] != player && currentState[x - 2, y - 2] != -1)) return false;
        if (currentState[x - 3, y - 3] == player) return true;
        return false;
    }
    public static bool CheckForCaptureTopRight(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        int length = (int)Math.Sqrt(currentState.Length);
        if (x == length || y == 0) return false;
        if (x + 1 == length || y - 1 == 0) return false;
        if (x + 2 == length || y - 2 == 0) return false;
        if (x + 3 == length || y - 3 == 0) return false;
        if (!(currentState[x + 1, y - 1] != player && currentState[x + 1, y - 1] != -1)) return false;
        if (!(currentState[x + 2, y - 2] != player && currentState[x + 2, y - 2] != -1)) return false;
        if (currentState[x + 3, y - 3] == player) return true;
        return false;
    }
    public static bool CheckForCaptureBottomRight(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        int length = (int)Math.Sqrt(currentState.Length);
        if (x == length || y == length) return false;
        if (x + 1 == length || y + 1 == length) return false;
        if (x + 2 == length || y + 2 == length) return false;
        if (x + 3 == length || y + 3 == length) return false;
        if (!(currentState[x + 1, y + 1] != player && currentState[x + 1, y + 1] != -1)) return false;
        if (!(currentState[x + 2, y + 2] != player && currentState[x + 2, y + 2] != -1)) return false;
        if (currentState[x + 3, y + 3] == player) return true;
        return false;
    }
    public static bool CheckForCaptureBottomLeft(int[,] currentState, int x, int y) {
        int player = currentState[x, y];
        int length = (int)Math.Sqrt(currentState.Length);
        if (x == 0 || y == length) return false;
        if (x - 1 == 0 || y + 1 == length) return false;
        if (x - 2 == 0 || y + 2 == length) return false;
        if (x - 3 == 0 || y + 3 == length) return false;
        if (!(currentState[x - 1, y + 1] != player && currentState[x - 1, y + 1] != -1)) return false;
        if (!(currentState[x - 2, y + 2] != player && currentState[x - 2, y + 2] != -1)) return false;
        if (currentState[x - 3, y + 3] == player) return true;
        return false;
    }
}

