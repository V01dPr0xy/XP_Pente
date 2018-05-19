using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCircle : MonoBehaviour {

    [SerializeField] private float m_radius = 1.5f;
    [SerializeField] private List<PlacementCircle> m_neighbors = new List<PlacementCircle>();
    [SerializeField] private Piece m_piecePrefab = null;
    [SerializeField] private Vector2 m_coordinate;


    public List<PlacementCircle> Neighbors { get { return m_neighbors; } }
    private MeshRenderer m_renderer = null;
    private Piece m_piece = null;

    void Start() {
        m_renderer = GetComponent<MeshRenderer>();
        m_renderer.enabled = false;
        FindNeighbors();
    }

    /// <summary>
    /// Finds all neighboors and adds them to the list of neighboors.
    /// </summary>
    /// <returns></returns>
    public List<PlacementCircle> FindNeighbors() {
        m_neighbors.Clear();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_radius);

        foreach (var pc in hitColliders) {
            if (!pc.GetComponent<PlacementCircle>().Equals(this)) m_neighbors.Add(pc.GetComponent<PlacementCircle>());
        }
        return new List<PlacementCircle>(m_neighbors);
    }

    public void Highlight() {
        if (!m_piece) m_renderer.enabled = true;
    }

    public void Hide() {
        m_renderer.enabled = false;
    }

    public bool PlacePiece(Player player) {
        if (m_piece || !m_piecePrefab) return false;
        m_piece = Instantiate(m_piecePrefab, transform.position, Quaternion.identity, transform);
        m_piece.Owner = player;
        return true;
    }

    public void UpdateCoordinates() {
        m_coordinate = new Vector2(transform.position.x / 2, transform.position.y / 2);
    }
    
}
