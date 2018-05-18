using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	List<PlacementCircle> boardSpots;
	[SerializeField] GameObject m_placementCirclePrefab;
	void Start()
	{
		boardSpots = new List<PlacementCircle>();


	}

	
}
