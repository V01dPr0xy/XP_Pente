using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest
{

    /*
        public override bool PlacePiece()

        var expected = true;
        var actual = false;
        GameObject piece;
        GameObject board;
        is piece collider colliding with board
        if yes
        actual = true
        if no
        actual = false
    */

    /*
        public List<PlacementCircle> FindNeighboors

        char array[][] will act like the board
        place b (black pieces) and w (white pieces) according to what we to test
        store the positions of the surrounding array points
        have the expected array store the position that are filled
        compare the array positions

        actual array[][] will use funcion, and grab the positions that are filled
        iterate through list for()
        use PlacePiece function to check if a piece is placed
        if(true) store position

        compare positions
     */

    /*
       Check for win   
       
        Calls checks neighbors on an instance of 5 pieces, with a chain of 5 in a row. If so, return true, if not return false
        ^?
        
        //checking vertercally, horizontally, and diagnolly
    */

    /*
        Check neighbors
        
        Get a location and check all the adjacent position if a piece is placed

        //the follow code belongs elsewhere (currently unknown)
        Recurse and try to find any more pieces that would assist or prevent capturing two pieces
    */

    /*
        PlacePiece (Player) 
         
        Get the location at which the player is trying to place a piece

        Check if the place is taken or not

        //? Check for neighboring pieces

        compare actual to expected value if it can be placed or not
    */


    [Test]
    public void NewEditModeTestSimplePasses()
    {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewEditModeTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
