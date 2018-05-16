using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCircle : MonoBehaviour
{
	public Vector2 m_boardCoordinates;
	public List<PlacementCircle> m_neighboors;
	void Start()
	{
		m_neighboors = new List<PlacementCircle>();
	}
	/// <summary>
	/// Finds all neighboors and adds them to the list of neighboors.
	/// </summary>
	/// <returns></returns>
	public List<PlacementCircle> FindNeighboors()
	{
		throw new NotImplementedException();
	}
	
}
