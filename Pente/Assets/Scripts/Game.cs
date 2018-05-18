using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eTypes;

public class Game : MonoBehaviour {
    public static Game m_instance;
    [SerializeField] public eMode m_mode;
    [SerializeField] private Player m_player1;
    [SerializeField] private Player m_player2;
    [SerializeField] private Player m_playerAI;
    [SerializeField] List<PlacementCircle> m_boardAreas;

    private PlacementCircle m_highlightedCircle = null;
    private Player m_currentPlayer = null;

    void Start() {
        m_instance = this;
        m_currentPlayer = m_player1;
    }

    void Update() {
        PlacementCircle circle = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) circle = hit.collider.gameObject.GetComponent<PlacementCircle>();

        if (circle) circle.Highlight();
        if (circle != m_highlightedCircle && m_highlightedCircle != null) m_highlightedCircle.Hide();
        if (Input.GetMouseButtonDown(0) && circle != null) {
            circle.PlacePiece(m_currentPlayer);
            SwitchPlayers();
        }
        m_highlightedCircle = circle;

    }

    private void SwitchPlayers() {
        if (m_currentPlayer == m_player1) {
            switch (m_mode) {
                case eMode.PVP:
                    m_currentPlayer = m_player2;
                    break;
                case eMode.PVE:
                    m_currentPlayer = m_player2;
                    break;
            }
        } else {
            m_currentPlayer = m_player1;
        }
    }
}
