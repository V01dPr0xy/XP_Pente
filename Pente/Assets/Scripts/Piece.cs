using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Piece : MonoBehaviour {

    private Player m_owner = null;
    private PlacementCircle m_location = null;

    public Player Owner {
        get { return m_owner; }
        set {
            m_owner = value;
            GetComponent<MeshRenderer>().material = (m_owner.PieceMaterial ? m_owner.PieceMaterial : null);
        }
    }

    void Start() {

    }

    /// <summary>
    /// Checks neighboors in cases of capturing opponents
    /// </summary>
    /// <returns></returns>
    public bool CheckForCapture() {
        throw new NotImplementedException();
    }

    /// <summary>
    /// checks for 5 in a row
    /// </summary>
    /// <returns></returns>
    public bool CheckForWin() {
        throw new NotImplementedException();
    }
}
