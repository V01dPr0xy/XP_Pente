using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    List<PlacementCircle> m_placementCircles = new List<PlacementCircle>();
    [SerializeField] GameObject m_placementCirclePrefab;
    void Start() {
        m_placementCircles = new List<PlacementCircle>();


    }


}
