using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class NewEditModeTest
{
    [UnityTest]
    public IEnumerator ValidPiecePlace()
    {
        // Use the Assert class to test conditions.
        //var expected = true, actual = false;
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

        //Attempting to place a piece at  (0,0) 

        //Load the board Prefab
        GameObject mockedBoard = Board.Instantiate(new GameObject());
        var board = new GameObject().AddComponent<Board>();
        Debug.Log(mockedBoard);
        Assert.AreEqual(null, board.PlacementCircles);
        return null;
    }

	/*
		Player 1's first move must be center, position (0,0)
		Player 1's second movement must be 3 (inclusive) or more intersecting from center
		Exactly 2 pieces may be captured by blocking both sides (check for every possible capture)
	*/

	[UnityTest]
	public IEnumerator InvalidPiecePlace()
	{
		
		Assert.Fail();
		return null;
	}

	[UnityTest]
	public IEnumerator WinRow()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		Assert.Fail();
		return null;

	}

	[UnityTest]
	public IEnumerator WinColumn()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		Assert.Fail();
		return null;

	}

	[UnityTest]
	public IEnumerator WinDiagonalLeft()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		Assert.Fail();
		return null;
	}

	[UnityTest]
	public IEnumerator WinDiagonalRight()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		Assert.Fail();
		return null;
	}

	[Test]
	public IEnumerator WinTenOrMoreCaptures()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		Assert.Fail();
		return null;
	}

	[UnityTest]
	public IEnumerator CaptureRow()
	{
		Assert.Fail();
		return null;
	}

	[UnityTest]
	public IEnumerator CaptureColumn()
	{
		Assert.Fail();
		return null;
	}

	[UnityTest]
    public IEnumerator CaptureDiagonalLeft()
    {
		Assert.Fail();
		return null;
    }

	[UnityTest]
	public IEnumerator CaptureDiagonalRight()
	{
		Assert.Fail();
		return null;
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
