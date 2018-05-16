using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
	public PlacementCircle m_location;
	void Start()
	{

	}

	/// <summary>
	/// Checks neighboors in cases of capturing opponents
	/// </summary>
	/// <returns></returns>
	public bool CheckNeighboors()
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// checks for 5 in a row
	/// </summary>
	/// <returns></returns>
	public bool CheckForWin()
	{
		throw new NotImplementedException();
	}
}
