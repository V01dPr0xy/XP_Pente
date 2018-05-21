using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlacementCircle : MonoBehaviour {

    [SerializeField] private float m_radius = 1.5f;
    [SerializeField] private List<PlacementCircle> m_neighbors = new List<PlacementCircle>();
    [SerializeField] private Piece m_piecePrefab = null;
    [SerializeField] public Vector2 m_coordinate;


    public List<PlacementCircle> Neighbors { get { return m_neighbors; } }
    private MeshRenderer m_renderer = null;
    public Piece m_piece = null;

    void Start() {
        m_renderer = GetComponent<MeshRenderer>();
        m_renderer.enabled = false;
        FindNeighbors();
    }

    /// <summary>
    /// Finds all neighboors and adds them to the list of neighboors.
    /// </summary>
    /// <returns></returns>
    /// Could use Unit Test
    public List<PlacementCircle> FindNeighbors() {
        m_neighbors.Clear();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_radius);

        foreach (var pc in hitColliders) {
            if (pc.GetComponent<PlacementCircle>() != null)
                if (!pc.GetComponent<PlacementCircle>().Equals(this))
                    m_neighbors.Add(pc.GetComponent<PlacementCircle>());
        }
        return new List<PlacementCircle>(m_neighbors);
    }

    public void Highlight() {
        if (!m_piece) m_renderer.enabled = true;
    }

    public void Hide() {
        m_renderer.enabled = false;
    }

    //Needs Unit Test
    public bool PlacePiece(Player player) {
        if (m_piece || !m_piecePrefab) return false;
        m_piece = Instantiate(m_piecePrefab, transform.position, Quaternion.identity, transform);
        m_piece.Owner = player;
        if (Board.CheckForWin(Game.m_instance.m_board.ToArray(), (int)m_coordinate.x, (int)m_coordinate.y)) {
            Game.m_instance.PlayerWon();
        }
        return true;
    }
    public void Clear() {
        if (m_piece != null){
            Destroy(m_piece.gameObject);
        }
        m_piece = null;
    }

    public void UpdateCoordinates() {
        m_coordinate = new Vector2(transform.position.x / 2, transform.position.y / 2);
    }

}
