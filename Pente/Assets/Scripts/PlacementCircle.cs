﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlacementCircle : MonoBehaviour {

    [SerializeField] private float m_radius = 1.5f;
    [SerializeField] private List<PlacementCircle> m_neighbors = new List<PlacementCircle>();

    [SerializeField] PlacementCircle m_leftNeighbor;
    [SerializeField] PlacementCircle m_rightNeighbor;
    [SerializeField] PlacementCircle m_topNeighbor;
    [SerializeField] PlacementCircle m_bottomNeighbor;

    [SerializeField] PlacementCircle m_topLeftNeighbor;
    [SerializeField] PlacementCircle m_topRightNeighbor;
    [SerializeField] PlacementCircle m_bottomLeftNeighbor;
    [SerializeField] PlacementCircle m_bottomRightNeighbor;

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
        UpdateCoordinates();
        m_neighbors.Clear();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_radius);

        foreach (var pc in hitColliders) {
            if (pc.GetComponent<PlacementCircle>() != null)
                if (!pc.GetComponent<PlacementCircle>().Equals(this))
                    m_neighbors.Add(pc.GetComponent<PlacementCircle>());
        }

        return new List<PlacementCircle>(m_neighbors);
    }

    public void UpdateNeighborReferences() {
        foreach (PlacementCircle item in m_neighbors) {
            item.UpdateCoordinates();
            Vector2 direction = item.m_coordinate - m_coordinate;
            switch (Convert.ToInt32(direction.x)) {
                case -1:
                    switch (Convert.ToInt32(direction.y)) {
                        case -1:
                            m_bottomLeftNeighbor = item;
                            break;
                        case 0:
                            m_leftNeighbor = item;
                            break;
                        case 1:
                            m_topLeftNeighbor = item;
                            break;
                    }
                    break;
                case 0:
                    switch (Convert.ToInt32(direction.y)) {
                        case -1:
                            m_bottomNeighbor = item;
                            break;
                        case 0:
                        //throw new Exception();
                        case 1:
                            m_topNeighbor = item;
                            break;
                    }
                    break;
                case 1:
                    switch (Convert.ToInt32(direction.y)) {
                        case -1:
                            m_bottomRightNeighbor = item;
                            break;
                        case 0:
                            m_rightNeighbor = item;
                            break;
                        case 1:
                            m_topRightNeighbor = item;
                            break;
                    }
                    break;
            }
        }
    }

    public void Highlight() {
        if (!m_piece) m_renderer.enabled = true;
    }

    public void Hide() {
        m_renderer.enabled = false;
    }

    //Needs Unit Test
    public bool PlacePieceForSave(Player player) {
        if (m_piece || !m_piecePrefab) return false;
        m_piece = Instantiate(m_piecePrefab, transform.position, Quaternion.identity, transform);
        m_piece.Owner = player;
        return true;
    }

    public bool PlacePiece(Player player) {
        if (m_piece || !m_piecePrefab) return false;
        if (Game.m_instance.FirstTurn) {
            if (Convert.ToInt32(m_coordinate.x) != 0 || Convert.ToInt32(m_coordinate.y) != 0) return false;
            Game.m_instance.FirstTurn = false;
        } else if (Game.m_instance.SecondTurn && player.Equals(Game.m_instance.m_player1)) {
            if (m_coordinate.magnitude < 2.9f) return false;
            Game.m_instance.SecondTurn = false;
        }
        m_piece = Instantiate(m_piecePrefab, transform.position, Quaternion.identity, transform);
        m_piece.Owner = player;
        int offset = ((Convert.ToInt32(Game.m_instance.m_board.m_slider.value) * 2) + 7) / 2;
        if (ValidityTests.CheckForWin(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            Menu.m_instance.win.SetActive(true);
            Menu.m_instance.winText.text = Game.m_instance.m_currentPlayer.Name + " has won!";
            Game.m_instance.m_isPlayingGame = false;

        }
        //Check and make captures

        if (ValidityTests.CheckForCaptureTop(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_topNeighbor.m_topNeighbor.Clear();
            m_topNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }
        if (ValidityTests.CheckForCaptureBottom(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_bottomNeighbor.m_bottomNeighbor.Clear();
            m_bottomNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }
        if (ValidityTests.CheckForCaptureLeft(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_leftNeighbor.m_leftNeighbor.Clear();
            m_leftNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }
        if (ValidityTests.CheckForCaptureRight(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_rightNeighbor.m_rightNeighbor.Clear();
            m_rightNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }
        //Diagonals
        if (ValidityTests.CheckForCaptureBottomLeft(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_bottomLeftNeighbor.m_bottomLeftNeighbor.Clear();
            m_bottomLeftNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }
        if (ValidityTests.CheckForCaptureBottomRight(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_bottomRightNeighbor.m_bottomRightNeighbor.Clear();
            m_bottomRightNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }
        if (ValidityTests.CheckForCaptureTopLeft(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_topLeftNeighbor.m_topLeftNeighbor.Clear();
            m_topLeftNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }
        if (ValidityTests.CheckForCaptureTopRight(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            m_topRightNeighbor.m_topRightNeighbor.Clear();
            m_topRightNeighbor.Clear();
            Game.m_instance.m_currentPlayer.m_numberOfCaptures++;
        }

        if (Game.m_instance.m_currentPlayer.m_numberOfCaptures >= 5) Game.m_instance.PlayerWon();

		//Check for Trias

		if (ValidityTests.CheckForTriaHorizontal(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))
			|| ValidityTests.CheckForTriaVertical(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))
			|| ValidityTests.CheckForTriaBottomRightToTopLeftDiagonal(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))
			|| ValidityTests.CheckForTriaTopRightToBottomLeftDiagonal(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset)))
		{
            Menu.m_instance.tria.SetActive(true);
            Menu.m_instance.triaText.text = Game.m_instance.m_currentPlayer.Name + " has made a tria!";
            Game.m_instance.m_isPlayingGame = false;
        }
        if (ValidityTests.CheckForTesseraHorizontal(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))
    || ValidityTests.CheckForTesseraVertical(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))
    || ValidityTests.CheckForTesseraBottomRightToTopLeftDiagonal(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))
    || ValidityTests.CheckForTesseraTopRightToBottomLeftDiagonal(Game.m_instance.m_board.ToArray(), Convert.ToInt32(m_coordinate.x) + offset, Mathf.Abs(Convert.ToInt32(m_coordinate.y) - offset))) {
            Menu.m_instance.tessera.SetActive(true);
            Menu.m_instance.tesseraText.text = Game.m_instance.m_currentPlayer.Name + " has made a tessera!";
            Game.m_instance.m_isPlayingGame = false;
        }

        Game.m_instance.m_board.OpenPlacementCircles.Remove(this);
        return true;
    }
    public void Clear() {
        if (m_piece != null) {
            Destroy(m_piece.gameObject);
            Game.m_instance.m_board.OpenPlacementCircles.Add(this);
        }
        m_piece = null;
    }

    public void UpdateCoordinates() {
        m_coordinate = new Vector2(transform.position.x / 2, transform.position.y / 2);
    }

}
